<template>
  <div class="auto_ten">
    <div class="left-eight">
      <div class="a-element-a-line">
        <label>名字: </label>
        <input placeholder="请输入" class="form-5rem__input" v-model="newShop.name"/>
      </div>
      <div class="a-element-a-line">
        <label>省: </label>
        <select class="form-5rem__input" v-model="newShop.province">
          <option v-for="(i, k) of dataMap['86']" 
                  v-bind:key="k" 
                  v-bind:value="k" 
                  >{{i}}
          </option>
        </select>
        <label>市: </label>
        <select class="form-5rem__input" v-model="newShop.city">
          <option v-for="(i, k) of dataMap[newShop.province]" 
                  v-bind:key="k" 
                  v-bind:value="k" 
                  >{{i}}
          </option>
        </select>
        <label>区: </label>
        <select class="form-5rem__input" v-model="newShop.district">
          <option v-for="(i, k) of dataMap[newShop.city]" 
                  v-bind:key="k" 
                  v-bind:value="k" 
                  >{{i}}
          </option>
        </select>
      </div>
      <div class="a-element-a-line">
        <label>具体地址: </label><input placeholder="请输入" class="form-15rem__input" v-model="newShop.location"/>
      </div>
      <div class="a-element-a-line">
        <label>类型: </label><input placeholder="请输入" class="form-5rem__input" v-model="newShop.type"/>
        <label>电话: </label><input placeholder="请输入" class="form-5rem__input" v-model="newShop.tel"/>
      </div>
      <div class="a-element-a-line">
        <button class="rem15-rem2-button" @click="updateShop">更新门店基本信息</button>
      </div>
    </div>
    <div class="right-two">      
      <el-upload
        class="avatar-uploader"
        action=""
        :show-file-list="false"
        :before-upload="beforeAvatarUpload">
        <img v-if="newShop.pic" :src="newShop.pic" class="avatar">
        <i v-else class="el-icon-plus avatar-uploader-icon"></i>
      </el-upload>
    </div>
  </div>
</template>
<script>
import * as shopApi from '../../../api/Shop';
import * as merchantApi from '../../../api/Merchant';
import * as imgApi from '../../../api/img';
import * as map from '../../../data';

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
      if(res.status == 400) this.$message.error();
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
        if(res.status == 400) this.$message.error();
        else {
          this.newShop = res.body;
          this.$message('更新成功');
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
    height: 30rem;
  }

  .a-element-a-line {
    text-align: left;
  }
</style>

