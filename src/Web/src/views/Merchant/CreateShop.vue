<template>
  <div class="auto_eight" style="background: #eff7f2; padding-bottom: 5rem; box-shadow: 6px 6px 6px lightgray; margin-top: 3rem;">
    <header style="text-align: left; font-weight: bold; font-size: 3rem; color: gray; padding-left: 3rem; margin-bottom: 4rem;">门店信息</header>
    <div class="left-eight">
      <el-form label-width="70px" inline="true" style="text-align:left;">
        <el-form-item label="名称" style="width: 100%;">
          <el-input v-model="shop.Name" placeholder="请输入门店名称"></el-input>
        </el-form-item>
        <el-form-item label="门店类型" style="width: 100%;">
          <el-select v-model="shop.Type">
            <el-option v-for="i in shopTypies" v-bind:value="i.id" v-bind:key="i.id" :label="i.name"></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="省" style="width: 30%;">
          <el-select v-model="tempLocation.provinceCode" aria-placeholder="请输入省">
            <el-option v-for="(i, k) of mapData['86']" v-bind:value="k" v-bind:key="k" :label="i"></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="市" style="width: 30%;">
          <el-select v-model="tempLocation.cityCode">
            <el-option v-for="(i, k) of mapData[tempLocation.provinceCode]" v-bind:value="k" v-bind:key="k" :label="i"></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="区" style="width: 30%;">
          <el-select v-model="tempLocation.districtCode">
            <el-option v-for="(i, k) of mapData[tempLocation.cityCode]" v-bind:value="k" v-bind:key="k" :label="i"></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="具体地点" style="width: 100%;">
          <el-input v-model="shop.Location" placeholder="请输入门店具体地点"></el-input>
        </el-form-item>
        <el-form-item label="电话" style="width: 80%;">
          <el-input v-model="shop.Tel" placeholder="请输入门店电话"></el-input>
          <span v-if="telErrMsgShow" style="color: red; font-size: 0.75rem;">请输入正确电话</span>
        </el-form-item>
      </el-form>
      <div>
        <el-button type="primary" @click="createShop">提交</el-button>
      </div>
    </div>
    <div class="right-two">
      <el-upload
        class="avatar-uploader"
        action=""
        :show-file-list="false"
        :before-upload="beforeAvatarUpload">
        <img v-if="shop.Pic" :src="shop.Pic" class="avatar">
        <i v-else class="el-icon-plus avatar-uploader-icon"></i>
      </el-upload>
      <p style="margin-top: 1rem;">门店图像信息</p>
    </div>
  </div>
</template>
<script>
import * as merchantApi from '../../api/Merchant';
import * as imageApi from '../../api/img';
import * as identityApi from '../../api/Identity';
import map from '../../data';

export default {
  data() {
    return {
      shop: {
        Name: "",
        Province: "",
        City: "",
        District: "",
        Location: "",
        Type: "",
        Tel: "",
        Manager: this.$store.getters.getMerchantId,
        Pic: ""
      },
      shopTypies: [{
        id: "",
        name: ""
      }],
      tempLocation: {
        provinceCode: "",
        cityCode: "",
        districtCode: ""
      },
      mapData: map,
      telErrMsgShow: false
    }
  },

  beforeMount() {
    merchantApi.getShopTypies().then(result => {
      if(result.status == 401) {
        identityApi.GetTokenByRefreshToken(this.$store.getters.getRefreshToken).then(res => {
          if(res.status == 400) this.$router.push('/Customer/SignIn');

          else {
            this.$store.dispatch('commitRefreshToken', res.body.refresh_token);
            this.$store.dispatch('commitToken', res.body.access_token);

            merchantApi.getShopTypies().then(result => {
              if(result.status == 200)
              {
                this.shopTypies = result.body;
              } else if (result.status != 200)
              {
                this.$message.error("get shop type error")
              } 
            })
          }
        })
      }
      else if(result.status == 200)
      {
        this.shopTypies = result.body;
      } else if (result.status != 200)
      {
         this.$message.error("get shop type error")
      } 
    })
  },

  methods: {
    beforeAvatarUpload(file) {
      const is = file.type === 'image/jpeg' || file.type === 'image/png';

      var form = new FormData();

      form.append("file", file);
      form.append("merchantId", this.$store.getters.getMerchantId);
      console.log(form);

      if (!is) {
        this.$message.error('上传Jpg!');
        return
      }

      imageApi.ImgUpload(form).then(result => {
        if(result.status == 401) {
          identityApi.GetTokenByRefreshToken(this.$store.getters.getRefreshToken).then(res => {
            if(res.status == 400) this.$router.push('/Customer/SignIn');

            else {
              this.$store.dispatch('commitRefreshToken', res.body.refresh_token);
              this.$store.dispatch('commitToken', res.body.access_token);

              imageApi.ImgUpload(form).then(result => {
                if(result.status != 200)
                {
                  this.$message.error('上传图片失败!');
                } else {
                  this.shop.Pic = result.body;
                }
              })
            }
          })
        }
        else if(result.status != 200)
        {
          this.$message.error('上传图片失败!');
        } else {
          this.shop.Pic = result.body;
        }
      })
    },
    createShop() {
      if(!/^1[34567]\d{9}$/.test(this.shop.Tel))
      {
        this.telErrMsgShow = true;
        setTimeout(() => {
          this.telErrMsgShow = false;
        }, 2000);

        return;
      }
      this.shop.Province = this.mapData['86'][this.tempLocation.provinceCode];
      this.shop.City = this.mapData[this.tempLocation.provinceCode][this.tempLocation.cityCode];
      this.shop.District = this.mapData[this.tempLocation.cityCode][this.tempLocation.districtCode];

      if(this.shop.Name == "" || this.shop.Province == "" || this.shop.City == "" || this.shop.District == "" ||
         this.shop.Location == "" || this.shop.Type == "" || this.shop.Tel == "" || this.shop.Manager == "" ||
         this.shop.Pic == "") {
           this.$message.error("请将门店信息全部添齐");

           return
      }
      merchantApi.createShop(this.shop).then(result => {
        if(result.status == 401) {
          identityApi.GetTokenByRefreshToken(this.$store.getters.getRefreshToken).then(res => {
            if(res.status == 400) this.$router.push('/Customer/SignIn');

            else {
              this.$store.dispatch('commitRefreshToken', res.body.refresh_token);
              this.$store.dispatch('commitToken', res.body.access_token);
              
              merchantApi.createShop(this.shop).then(result => {
                if(result.status == 201)
                {
                  this.$message({
                    message: "创建门店成功",
                    type: "success"
                  })

                  this.$router.push('/Merchant/CreateIdentity');
                } else if (result.status != 201)
                {
                  this.$message.error("创建门店失败");
                }
              })
            }
          })
        }
        else if(result.status == 201)
        {
          this.$message({
            message: "创建门店成功",
            type: "success"
          })

          this.$router.push('/Merchant/CreateIdentity');
        } else if (result.status != 201)
        {
          this.$message.error("创建门店失败");
        }
      })
    }
  }
}
</script>
<style lang="less" scoped>
  @import "../../less/container.less";
  @import "../../less/ele-ui.less";

  @eight_height : auto;
  @top_distance : auto;
  @left_five_height : 4rem;

  header {
    font-size: 3rem; 
    border-bottom: 2px solid gray; 
    height: 12rem; 
    line-height: 12rem;
  }

  .right-two {
    border-left: 2px solid lightgray;
  }
</style>