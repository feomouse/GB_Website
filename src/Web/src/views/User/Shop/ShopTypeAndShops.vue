<template>
  <div class="auto_ten">
    <div class="banner">
      <p style="float: left; cursor: pointer;" @click="showSelectCityDialogShow = true">选择城市: {{selectedProvinceName + ' ' + selectedCityName}}</p>
      <p style="float: right; cursor: pointer;" @click="directToMyMessage">{{userName}} : 我的信息</p>
    </div>
    <el-dialog label-width="70px" :visible.sync="showSelectCityDialogShow" inline="true">
      <el-form>
        <el-form-item label="省" style="width:40%;">
          <el-select v-model="selectedProvince" placeholder="请选择省">
            <el-option 
              v-for="(i, k) in cityData['86']"
              :key="k"
              :label="i"
              :value="k">

            </el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="城市" style="width:40%;">
          <el-select v-model="selectedCity" placeholder="请选择市">
            <el-option
              v-for="(i, k) in cityData[selectedProvince]"
              :key="k"
              :label="i"
              :value="k">
            
            </el-option>
          </el-select>
        </el-form-item>
      </el-form>
      <div slot="footer">
        <el-button type="primary" @click="getShopsByCity">选择</el-button>
        <el-button @click="showSelectCityDialogShow = false">取消</el-button>
      </div>
    </el-dialog>
   <div class="auto_eight" style="text-align: left;">
     <div v-for="i of shopTypes" 
          v-bind:key="i.id" 
          class="left-two" 
          style="text-align: center; cursor:pointer; margin-top: 3rem;" 
          @click="selectShopTypes(i)">
       <img :src="i.img" style="border-radius: 50%; width: 4rem; height: 4rem;"/>
       <div>{{i.name}}</div>
     </div>
     <div v-for="(i, index) of shopList" v-bind:key="i.name" class="list_item" @click="showDetail(index)"
          style="text-align: left; padding-left: 3rem; vertical-align: bottom; cursor:pointer;">
       <img :src="i.img" style="width: 6rem; height: 5rem; display: inline-block; margin-right: 3rem;" />
       <div style="display: inline-block;">
         <p style="font-size: 1.5rem">{{i.name}}</p>
         <p>{{i.province + i.city + i.district + i.location}}</p>
       </div>
     </div>
   </div>
  </div>
</template>
<script>
import * as shopApi from '../../../api/Shop';
import cityData from '../../../data';

export default {
  data() {
    return {
      shopTypes: [],
      shopList:[],
      showSelectCityDialogShow: false,
      'cityData': cityData,
      selectedProvince: "110000",
      selectedCity: "110100",
      selectedProvinceName: "北京市",
      selectedCityName: "直辖区",
      selectedShopType: 1,
      userName: this.$store.getters.user.userName
    }
  },
  beforeCreate() {
    shopApi.GetShopTypes().then(res => {
      if(res.status != 200) this.$message.error('获取门店类型错误');
      else {
        this.shopTypes = res.body;
        shopApi.GetShopListByShopTypeAndCity(this.cityData['86'][this.selectedProvince], this.cityData[this.selectedProvince][this.selectedCity], 1).then(res => {
          if(res.status != 200) this.$message.error('获取门店错误')
          else this.shopList = res.body;
        })
      }
    })
    this.selectedProvinceName = cityData['86'][this.selectedProvince];
    this.selectedCityName = cityData[this.selectedProvince][this.selectedCity];
  },
  methods: {
    showDetail(index) {
      this.$store.dispatch('commitSetSelectedName', this.shopList[index].name);
      this.$store.dispatch('commitSetShopId', this.shopList[index].pkId);
      this.$router.push('/ShopDetail');
    },
    selectShopTypes(type) {
      this.selectedShopType = type.id;
      console.log('test')
      shopApi.GetShopListByShopTypeAndCity(this.cityData['86'][this.selectedProvince], this.cityData[this.selectedProvince][this.selectedCity], type.id).then(res => {
        if(res.status != 200) this.$message.error('获取门店错误')
        else this.shopList = res.body;
      })
    },
    directToMyMessage() {
      this.$router.push('/Customer/Basic');
    },
    getShopsByCity() {
      this.selectedProvinceName = cityData['86'][this.selectedProvince];
      this.selectedCityName = cityData[this.selectedProvince][this.selectedCity];
      shopApi.GetShopListByShopTypeAndCity(this.cityData['86'][this.selectedProvince], this.cityData[this.selectedProvince][this.selectedCity]).then(res => {
        if(res.status != 200) this.$message.error();

        else {
          this.showSelectCityDialogShow = false;
          this.shopList = res.body;
        }
      })
    }
  }
}
</script>
<style lang="less" scoped>
  @import '../../../less/container';
  @import '../../../less/formEle';

  @list_item_height : 10rem;
  @left_two_height : 8rem;

  .banner {
    height: 3rem;
    background: #edf6eb;
    padding: 0 12rem 0 16rem;
    font-size: 0.8rem;
    color: #666a65;
  }
</style>
