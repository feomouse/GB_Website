<template>
  <div class="auto_eight">
    <header style="">门店信息</header>
    <div class="left-eight">
      <div class="left-five">
        <label>名称:</label>
        <input v-model="shop.Name" class="form__input" placeholder="请输入门店名称"/>
      </div>
      <div class="left-five">
        <label>类型:</label>
        <select class="form__input" v-model="shop.Type">
         <option v-for="i in shopTypies" v-bind:value="i.id" v-bind:key="i.id">{{i.name}}</option>
        </select>
      </div>
      <div class="left-five">
        <label>省:</label>
        <select class="form__input" v-model="tempLocation.provinceCode" aria-placeholder="请输入省">
          <option v-for="(i, k) of mapData['86']" v-bind:value="k" v-bind:key="k">{{i}}</option>
        </select>
      </div>
      <div class="left-five">
        <label>市:</label>
        <select class="form__input" v-model="tempLocation.cityCode">
          <option v-for="(i, k) of mapData[tempLocation.provinceCode]" v-bind:value="k" v-bind:key="k">{{i}}</option>
        </select>
      </div>
      <div class="left-five">
        <label>区:</label>
        <select class="form__input" v-model="tempLocation.districtCode">
          <option v-for="(i, k) of mapData[tempLocation.cityCode]" v-bind:value="k" v-bind:key="k">{{i}}</option>
        </select>
      </div>
      <div class="left-five">
        <label>具体地点:</label>
        <input v-model="shop.Location" class="form__input" placeholder="请输入门店具体地点"/>
      </div>
      <div class="left-five" style="float: left; padding-left:3rem;">
        <label>电话:</label>
        <input v-model="shop.Tel" class="form__input" placeholder="请输入门店电话"/>
      </div>
      <div>
        <button style="background: lightblue; width:8rem; height: 3rem" @click="createShop">提交</button>
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
      <div style="font-size:0.5rem;">门店图像信息</div>
    </div>
  </div>
</template>
<script>
import * as merchantApi from '../../api/Merchant';
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
      mapData: map
    }
  },

  beforeMount() {
    merchantApi.getShopTypies().then(result => {
      if(result.status == 200)
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

      merchantApi.uploadShopPic(form).then(result => {
        if(result.status != 200)
        {
          this.$message.error('上传图片失败!');
        }
      })
    },
    createShop() {
      this.shop.Province = this.mapData['86'][this.tempLocation.provinceCode];
      this.shop.City = this.mapData[this.tempLocation.provinceCode][this.tempLocation.cityCode];
      this.shop.District = this.mapData[this.tempLocation.cityCode][this.tempLocation.districtCode];

      merchantApi.createShop(this.shop).then(result => {
        if(result.status == 201)
        {
          this.$message({
            message: "创建门店成功",
            type: "success"
          })
        } else if (result.status != 201)
        {
          this.$message.error("创建门店失败")
        }
      })
    }
  }
}
</script>
<style lang="less">
  @import "../../less/container.less";
  @import "../../less/ele-ui.less";

  @eight_height : auto;
  @top_distance : auto;
  @left_eight_height : 50rem;
  @right_two_height : 50rem;
  @left_five_height : 4rem;

  header {
    font-size: 3rem; 
    border-bottom: 2px solid gray; 
    height: 12rem; 
    line-height: 12rem;
  }

  .auto_eight {
    border: 2px solid black;
  }

  .form__input {
    height: 2rem;
    width: 10rem;
    border-radius: 10%;
  }

  .right-two {
    background: lightblue;
  }
</style>