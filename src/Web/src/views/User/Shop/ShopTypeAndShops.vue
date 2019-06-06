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
        <div v-for="(i,index) in shopTypes"
            v-bind:key="i.pkId" 
            @click="selectShopTypes(i)"
            style="height: 3rem; padding-left: 2rem; cursor: pointer;">
            <svg-icon :iconClass="icons[index]"> </svg-icon>
            {{i.name}}
        </div>
      </div>
      <div class="float-left-six" style="text-align: center;">
        <div class="left-three" v-for="i in shopTypes" v-bind:key='i.pkId'>
          <img :src="i.img" style="width: 100%; height: 100%; cursor: pointer;" @click="selectShopTypes(i)"/>
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
     <div class="shop-header">
        <label style="float: left; font-size: 1.2rem; font-weight: bold;">门店信息</label>
        <div v-for="(i,index) in shopTypes"
          v-bind:key="i.pkId" 
          @click="selectShopTypesGetRandom(i)"
          style="padding-left: 2rem; cursor: pointer; float: left;">
          {{i.name}}
        </div>
     </div>
     <div>
       <div v-for="i in shopList" class="random-shop" @click="selectShop(i)">
         <img :src="i.img" style="width:100%; height: 12rem; border-radius:20px;"/>
         <h3>{{i.name}}</h3>
       </div>
     </div>
     <!--
     <div v-for="(i, index) of shopList" v-bind:key="i.name" class="list_item" @click="showDetail(index)"
          style="text-align: left; vertical-align: bottom; cursor:pointer;">
       <img :src="i.img" style="width: 6rem; height: 5rem; display: inline-block; margin: 0 3rem 0 3rem;" />
       <div style="display: inline-block;">
         <p style="font-size: 1.5rem">{{i.name}}</p>
         <p>{{i.province + i.city + i.district + i.location}}</p>
       </div>
     </div>
     <div style="text-align:center;">
      <el-pagination
        layout="prev, pager, next"
        :total="shopsNum"
        @current-change="changePage">
      </el-pagination>
     </div>-->
   </div>
    <div style="width: 80%; margin: 0 auto;"><my-footer></my-footer></div>
  </div>
</template>
<script>
  import myFooter from '../../../views/Common/Footer';
import * as shopApi from '../../../api/Shop';
import * as identityApi from '../../../api/Identity';
import myBanner from '../../../components/Banner';
import cityData from '../../../data';

export default {
  components: {
    'myBanner': myBanner,
      'my-footer': myFooter
  },
  data() {
    return {
      shopTypes: [],
      shopList: this.$store.getters.getRandomShops,
      showSelectCityDialogShow: false,
      'cityData': cityData,
      selectedProvince: this.$store.getters.getSelectedProvince,
      selectedCity: this.$store.getters.getSelectedCity,
      selectedDistrict: this.$store.getters.getSelectedDistrict,
      selectedProvinceName: this.$store.getters.getSelectedProvinceName,
      selectedCityName: this.$store.getters.getSelectedCityName,
      selectedDistrictName: this.$store.getters.getSelectedDistrictName,
      selectedShopType: 1,
      userName: this.$store.getters.user.userName,

      icons: {
        0: 'beauty',
        1: 'entertain',
        2: 'food',
        3: 'living',
        4: 'learning',
        5: 'sports',
        6: 'bars',
      },
      CustomerInfo: {
        CustomerName: "",
        CustomerImg: "",
        CustomerAddress: "",
        CustomerEmail: ""
      },
      shopsNum: 0
    }
  },
  beforeMount() {
    shopApi.GetShopTypes().then(res => {
      if(res.status == 401) {
        identityApi.GetTokenByRefreshToken(this.$store.getters.getRefreshToken).then(res => {
          if(res.status == 400) this.$router.push('/Customer/SignIn');

          else {
            this.$store.dispatch('commitRefreshToken', res.body.refresh_token);
            this.$store.dispatch('commitToken', res.body.access_token);

            shopApi.GetShopTypes().then(res => {
              if(res.status != 200) this.$message.error('获取门店类型错误');
              else {
                this.$store.dispatch('commitSetShopTypes', res.body);
                this.shopTypes = res.body;
                shopApi.GetRandomShops('北京市', '市辖区', this.shopTypes[0].pkId).then(res => {
                  if(res.status != 200) this.$message.error('获取门店错误')
                  else {
                    this.shopList = res.body;
                    this.$store.dispatch('commitSetRandomShops', res.body);
                    /*
                    shopApi.GetShopsCount(this.cityData['86'][this.selectedProvince], this.cityData[this.selectedProvince][this.selectedCity], 1).then(res => {
                      if(res.status != 200) this.$message.error("获取数量错误");

                      else this.shopsNum = res.body;
                    })*/
                    //this.$store.dispatch('commitSetShopList', res.body);
                  }
                })
              }
            })
          }
        })
      }
      else if(res.status != 200) this.$message.error('获取门店类型错误');
      else {
        this.$store.dispatch('commitSetShopTypes', res.body);
        this.shopTypes = res.body;
        shopApi.GetRandomShops('北京市', '市辖区', this.shopTypes[0].pkId).then(res => {
          if(res.status != 200) this.$message.error('获取门店错误')
          else {
            this.shopList = res.body;
            this.$store.dispatch('commitSetRandomShops', res.body);
            /*
            shopApi.GetShopsCount(this.cityData['86'][this.selectedProvince], this.cityData[this.selectedProvince][this.selectedCity], 1).then(res => {
              if(res.status != 200) this.$message.error("获取数量错误");

              else this.shopsNum = res.body;
            })*/
            //this.$store.dispatch('commitSetShopList', res.body);
          }
        })
      }
    })
    //this.selectedProvinceName = this.cityData['86'][this.selectedProvince];
    //this.selectedCityName = this.cityData[this.selectedProvince][this.selectedCity];
    this.$store.dispatch('commitProvinceName', this.cityData['86']['110000']);
    this.$store.dispatch('commitCityName', this.cityData['110000']['110100']);
    //this.$store.dispatch('commitDistrictName', this.cityData['110100']['110101'])

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
      this.selectedShopType = type.pkId;
      this.$store.dispatch('commitSetSelectedShopTypeId', type.pkId);
      this.$router.push('/ShopLists');
      /*
      shopApi.GetShopListByShopTypeAndCity(this.cityData['86'][this.$store.getters.getSelectedProvince], this.cityData[this.$store.getters.getSelectedProvince][this.$store.getters.getSelectedCity], type.id, 1).then(res => {
        if(res.status == 401) {
          identityApi.GetTokenByRefreshToken(this.$store.getters.getRefreshToken).then(res => {
            if(res.status == 400) this.$router.push('/Customer/SignIn');

            else {
              this.$store.dispatch('commitRefreshToken', res.body.refresh_token);
              this.$store.dispatch('commitToken', res.body.access_token);
              
              shopApi.GetShopListByShopTypeAndCity(this.cityData['86'][this.$store.getters.getSelectedProvince], this.cityData[this.$store.getters.getSelectedProvince][this.$store.getters.getSelectedCity], type.id, 1).then(res => {
                if(res.status != 200) this.$message.error('获取门店错误')
                else {
                  this.shopList = res.body;
                  shopApi.GetShopsCount(this.cityData['86'][this.selectedProvince], this.cityData[this.selectedProvince][this.selectedCity], 1).then(res => {
                    if(res.status != 200) this.$message.error("获取数量错误");

                    else this.shopsNum = res.body;
                  })
                }
              })
            }
          })
        }
        else if(res.status != 200) this.$message.error('获取门店错误')
        else {
          this.shopList = res.body;
          shopApi.GetShopsCount(this.cityData['86'][this.selectedProvince], this.cityData[this.selectedProvince][this.selectedCity], 1).then(res => {
            if(res.status != 200) this.$message.error("获取数量错误");

            else this.shopsNum = res.body;
          })
          //this.$store.dispatch('commitSetShopList', res.body);
        }
      })*/
    },
    selectShopTypesGetRandom(v) {
      shopApi.GetRandomShops(this.$store.getters.getSelectedProvinceName, this.$store.getters.getSelectedCityName, v.pkId).then(res => {
        if(res.status != 200) this.$message.error('获取门店错误')
        else {
          this.shopList = res.body;
          this.$store.dispatch('commitSetRandomShops', res.body);
        }
      })
    },
    directToMyMessage() {
      this.$router.push('/Customer/Basic');
    },
    selectShop(shop){
      let date = new Date();
      shopApi.IncreaseVisitNum({
        ShopId: shop.pkId,
        Year: date.getFullYear(),
        Month: date.getMonth()
      }).then(res => {
        if(res.status != 200) this.$message.error('增加访问数失败');

        else {
          this.$store.dispatch('commitSetSelectedName', shop.name);
          this.$store.dispatch('commitSetCurrentSelectedShop', shop);
          this.$router.push('/ShopDetail')
        }
      })
    }
    /*
    changePage(page) {
      shopApi.GetShopListByShopTypeAndCity(this.cityData['86'][this.$store.getters.getSelectedProvince], this.cityData[this.$store.getters.getSelectedProvince][this.$store.getters.getSelectedCity], this.selectedShopType, page).then(res => {
        if(res.status == 401) {
          identityApi.GetTokenByRefreshToken(this.$store.getters.getRefreshToken).then(res => {
            if(res.status == 400) this.$router.push('/Customer/SignIn');

            else {
              this.$store.dispatch('commitRefreshToken', res.body.refresh_token);
              this.$store.dispatch('commitToken', res.body.access_token);
              
              shopApi.GetShopListByShopTypeAndCity(this.cityData['86'][this.$store.getters.getSelectedProvince], this.cityData[this.$store.getters.getSelectedProvince][this.$store.getters.getSelectedCity], this.selectedShopType, page).then(res => {
                if(res.status != 200) this.$message.error('获取门店错误')
                else {
                  this.shopList = res.body;
                }
              })
            }
          })
        }
        else if(res.status != 200) this.$message.error('获取门店错误')
        else {
          this.shopList = res.body;
          //this.$store.dispatch('commitSetShopList', res.body);
        }
      })
    }
     
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
