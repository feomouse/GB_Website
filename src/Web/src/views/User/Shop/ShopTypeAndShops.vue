<template>
  <div class="auto_ten">
   <myBanner></myBanner>
   <div class="auto_eight" style="text-align: left;">
     <div style="width: 100%; border-bottom: 2px solid lightgray;">
       <div style="width: 20%; 
            height: 5rem; 
            font-size:2rem;
            color: white;
            font-weight: bold;
            background: #7dcea0;
            text-align:center;
            padding-top: 1rem;">
            门店分类
        </div>
     </div>
     <div style="width: 100%; height: auto;">
      <div class="float-left-two" style="background: #7dcea0; padding-top: 1rem; color: white;">
        <div v-for="i of shopTypes"
            v-bind:key="i.id" 
            @click="selectShopTypes(i)"
            style="height: 3rem; padding-left: 2rem; cursor: pointer;">
            <svg-icon :iconClass="icons[i.id]"> </svg-icon>
            {{i.name}}
        </div>
      </div>
      <div class="float-left-six" style="text-align: center;">
        <div class="left-six">
          <img :src="shopTypes[1].img" style="width: 100%; height: 100%; cursor: pointer;" @click="selectShopTypes(shopTypes[1])"/>
        </div>
        <div class="right-three">
          <img :src="shopTypes[0].img" style="width: 100%; height: 100%; cursor: pointer;" @click="selectShopTypes(shopTypes[0])"/>
        </div>
        <div class="left-three">
          <img :src="shopTypes[2].img" style="width: 100%; height: 100%; cursor: pointer;" @click="selectShopTypes(shopTypes[2])"/>
        </div>
        <div class="left-three">
          <img :src="shopTypes[3].img" style="width: 100%; height: 100%; cursor: pointer;" @click="selectShopTypes(shopTypes[3])"/>
        </div>
        <div class="left-three">
          <img :src="shopTypes[4].img" style="width: 100%; height: 100%; cursor: pointer;" @click="selectShopTypes(shopTypes[4])"/>
        </div>
      </div>
      <div class="float-left-two" style="text-align: center; background: #f4f6f6; cursor: pointer;" @click="directToMyMessage">
        <div style="font-weight: bold; margin: 5rem 0 2rem 0; font-size: 2rem;">用户信息</div>
        <div>
          <img :src="CustomerInfo.CustomerImg" style="width: 5rem; height: 5rem; border-radius: 50%;" />
        </div>
        <div>
          {{CustomerInfo.CustomerName}}
        </div>
      </div>
     </div>
     <div style="clear:both;"></div>
     <div class="shop-header">门店信息</div>
     <div v-for="(i, index) of shopList" v-bind:key="i.name" class="list_item" @click="showDetail(index)"
          style="text-align: left; vertical-align: bottom; cursor:pointer;">
       <img :src="i.img" style="width: 6rem; height: 5rem; display: inline-block; margin: 0 3rem 0 3rem;" />
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
import myBanner from '../../../components/Banner';

export default {
  components: {
    'myBanner': myBanner
  },
  data() {
    return {
      shopTypes: [],
      shopList: this.$store.getters.getShopList,
      showSelectCityDialogShow: false,
      cityData: this.$store.getters.getCityData,
      selectedProvince: this.$store.getters.getSelectedProvince,
      selectedCity: this.$store.getters.getSelectedCity,
      selectedProvinceName: this.$store.getters.getSelectedProvinceName,
      selectedCityName: this.$store.getters.getSelectedCityName,
      selectedShopType: 1,
      userName: this.$store.getters.user.userName,

      icons: {
        1: 'beauty',
        3: 'entertain',
        2: 'food',
        4: 'living',
        5: 'learning'
      },
      CustomerInfo: {
        CustomerName: "",
        CustomerImg: "",
        CustomerAddress: "",
        CustomerEmail: ""
      },
    }
  },
  beforeCreate() {
    shopApi.GetShopTypes().then(res => {
      if(res.status != 200) this.$message.error('获取门店类型错误');
      else {
        this.shopTypes = res.body;
        shopApi.GetShopListByShopTypeAndCity(this.cityData['86'][this.selectedProvince], this.cityData[this.selectedProvince][this.selectedCity], 1).then(res => {
          if(res.status != 200) this.$message.error('获取门店错误')
          else {
            this.shopList = res.body;
            //this.$store.dispatch('commitSetShopList', res.body);
          }
        })
      }
    })
    //this.selectedProvinceName = this.cityData['86'][this.selectedProvince];
    //this.selectedCityName = this.cityData[this.selectedProvince][this.selectedCity];
    this.$store.dispatch('commitProvinceName', this.cityData['86'][this.selectedProvince]);
    this.$store.dispatch('commitCityName', this.cityData[this.selectedProvince][this.selectedCity]);
  },
  beforeMount() {
    this.CustomerInfo.CustomerName = this.$store.getters.user.userName;
    this.CustomerInfo.CustomerImg = this.$store.getters.user.lookingImg;
    this.CustomerInfo.CustomerAddress = this.$store.getters.user.address;
    this.CustomerInfo.CustomerEmail = this.$store.getters.user.email;
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
      shopApi.GetShopListByShopTypeAndCity(this.cityData['86'][this.$store.getters.getSelectedProvince], this.cityData[this.$store.getters.getSelectedProvince][this.$store.getters.getSelectedCity], type.id).then(res => {
        if(res.status != 200) this.$message.error('获取门店错误')
        else {
          this.shopList = res.body;
          //this.$store.dispatch('commitSetShopList', res.body);
        }
      })
    },
    directToMyMessage() {
      this.$router.push('/Customer/Basic');
    },/* 
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
    } */
  }
}
</script>
<style lang="less" scoped>
  @import '../../../less/container';
  @import '../../../less/formEle';

  @list_item_height : 10rem;
  @left_two_height : 8rem;

  @fleft_two_height : 20rem;
  @fleft_three_height : 20rem;
  @fleft_six_height : 20rem;

  @left_six_height : 10rem;
  @right_three_height : 10rem;
  @left_three_height : 10rem;
</style>
