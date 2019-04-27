<template>
  <div class="auto_ten">
    <div style="font-size: 2rem; border-bottom: 2px solid lightgray; color: lightgray;">门店基本信息</div>
    <div class="left-eight" style="text-align:left; background: #eff7f2; box-shadow: 3px 3px 3px lightgray; margin-top: 1rem;">
      <el-form label-width="100px">
        <el-form-item label="名字: " style="width: 40%;">
          <el-input placeholder="请输入" v-model="newShop.name"></el-input>
        </el-form-item>
        <el-form-item label="省: ">
          <el-select v-model="newShop.province">
            <el-option v-for="(i, k) of dataMap['86']" 
                    v-bind:key="k" 
                    v-bind:value="k"
                    :label="i"
                    >
            </el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="市: ">
          <el-select v-model="newShop.city">
            <el-option v-for="(i, k) of dataMap[newShop.province]" 
                    v-bind:key="k" 
                    v-bind:value="k"
                    :label="i"
                    >
            </el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="区: ">
          <el-select v-model="newShop.district">
            <el-option v-for="(i, k) of dataMap[newShop.city]" 
                    v-bind:key="k" 
                    v-bind:value="k"
                    :label="i"
                    >
            </el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="具体地址" style="width: 70%;">
          <el-input placeholder="请输入" v-model="newShop.location"></el-input>
        </el-form-item>
        <el-form-item label="类型: " style="width: 30%;">
           <el-input placeholder="请输入" v-model="newShop.type"></el-input>
        </el-form-item>
        <el-form-item label="电话: " style="width: 40%;">
          <el-input placeholder="请输入" v-model="newShop.tel"></el-input>
        </el-form-item>
      </el-form>
      <div class="a-element-a-line" style="text-align: center;">
        <el-button class="rem15-rem3-button" type="success" @click="updateShop">更新门店基本信息</el-button>
      </div>
    </div>
    <div style="float: right; width: 18rem; padding-top: 10rem;">      
      <div style="height: 100%;">
        <el-upload
          class="avatar-uploader"
          action=""
          :show-file-list="false"
          :before-upload="beforeAvatarUpload">
          <img v-if="newShop.pic" :src="newShop.pic" class="avatar">
          <i v-else class="el-icon-plus avatar-uploader-icon"></i>
        </el-upload>
      </div>
      <div>门店图像</div>
    </div>
  </div>
</template>
<script>
import * as shopApi from '../../../api/Shop';
import * as merchantApi from '../../../api/Merchant';
import * as imgApi from '../../../api/img';
import * as map from '../../../data';
import * as identityApi from '../../../api/Identity';

export default {
  data() {
    return {
      newShop: {

      },
      tempProvince: '',
      tempCity: '',
      tempDistrict: '',
      dataMap: map
    }
  },
  beforeMount() {
    shopApi.GetShopInfoByMerchantId(this.$store.getters.getMerchantId).then(res => {
      if(res.status == 401) {
        identityApi.GetTokenByRefreshToken(this.$store.getters.getRefreshToken).then(res => {
          if(res.status == 400) this.$router.push('/Customer/SignIn');

          else {
            this.$store.dispatch('commitRefreshToken', res.body.refresh_token);

            shopApi.GetShopInfoByMerchantId(this.$store.getters.getMerchantId).then(res => {
              if(res.status == 400) this.$message.error();
              else {
                this.newShop = res.body;
              }
            })
          }
        })
      }
      else if(res.status == 400) this.$message.error();
      else {
        this.newShop = res.body;
      }
    })
  },
  updated() {
    for(let i in map['86']) {
      if(map['86'][i] == this.newShop.province)  this.newShop.province = i;
    }

    for(let i in map[this.newShop.province]) {
      if(map[this.newShop.province][i] == this.newShop.city) this.newShop.city = i;
    }

    for(let i in map[this.newShop.city]) {
      if(map[this.newShop.city][i] == this.newShop.district) this.newShop.district = i;
    }
  },
  methods: {
    beforeAvatarUpload(file) {
        const is = file.type === 'image/jpeg' || file.type === 'image/png';

        var form = new FormData();

        form.append("file", file);

        if (!is) {
          this.$message.error('上传Jpg!');
          return
        }

        imgApi.ImgUpload(form).then(data => {
          if(data.status == 401) {
            identityApi.GetTokenByRefreshToken(this.$store.getters.getRefreshToken).then(res => {
              if(res.status == 400) this.$router.push('/Customer/SignIn');

              else {
                this.$store.dispatch('commitRefreshToken', res.body.refresh_token);

                imgApi.ImgUpload(form).then(data => {
                  this.newShop.pic = data.body;
                })
              }
            })
          }
          this.newShop.pic = data.body;
        })

        return is;
    },
    updateShop() {
      var shop = {
        "PkId": this.newShop.pkId,
        "Name": this.newShop.name,
        "Province": this.dataMap['86'][this.newShop.province],
        "City": this.dataMap[this.newShop.province][this.newShop.city],
        "District": this.dataMap[this.newShop.city][this.newShop.district],
        "Location": this.newShop.location,
        "Type": this.newShop.type,
        "Tel": this.newShop.tel,
        "Manager": this.newShop.registerId,
        "Pic": this.newShop.pic
      }
      merchantApi.updateShop(shop).then(res => {
        if(res.status == 401) {
          identityApi.GetTokenByRefreshToken(this.$store.getters.getRefreshToken).then(res => {
            if(res.status == 400) this.$router.push('/Customer/SignIn');

            else {
              this.$store.dispatch('commitRefreshToken', res.body.refresh_token);
              this.$store.dispatch('commitToken', res.body.access_token);
              
              merchantApi.updateShop(shop).then(res => {
                if(res.status == 400) this.$message.error('更新失败');
                else {
                  this.newShop = res.body;
                  this.$message({
                    type: 'success',
                    message:'更新成功'
                  });
                }
              })
            }
          })
        }
        else if(res.status == 400) this.$message.error('更新失败');
        else {
          this.newShop = res.body;
          this.$message({
            type: 'success',
            message:'更新成功'
          });
        }
      })
    }
  },
}
</script>
<style lang="less" scoped>
  @import '../../../less/container';
  @import '../../../less/ele-ui';

  @left_eight_height : auto;
  @right_two_height : auto;

  .form-5rem__input {
    width: 8rem;
    height: 2rem;
    display: inline-block;
    margin-right: 2rem;
  }

  .form-15rem__input { 
    width: 20rem;
    height: 2rem;
    display: inline-block;
  }

  .left-eight {
    margin-top: 5rem;
    border: 1px solid lightgray;
    height: 40rem;
    padding-top: 2rem;
  }

  .a-element-a-line {
    text-align: left;
  }
</style>

