<template>
  <div>
    <myBanner></myBanner>
    <div style="width: 80%; margin: 0 auto;">
      <div style="box-shadow: 3px 3px 3px black; padding-bottom: 2rem; height: 15rem;">
        <div style="display:inline-block; margin-right: 5rem;">区域</div>
        <div style="display:inline-block; width: 80%; margin-top: 3rem;">
          <div 
            v-for="(i,k) of districts" 
            @click="changeDistrict(i, k)"
            v-bind:class="selectedDistrict == i ? activeDistrictClass : ''"
            style="width: 6rem; height: 3rem; cursor: pointer; display:inline-block; line-height: 3rem;">
            {{i}}
          </div>
        </div>
      </div>
      <div style="clear:both;"></div>
      <div style="border-bottom: 1px solid black; margin-bottom: 3rem;"></div>
      <div style="box-shadow: 3px 3px 3px black;">
        <div v-for="i in shopList" v-bind:key="i.pkId" class="list_item" style="cursor:pointer;" @click="selectShop(i)">
          <img style="float: left; height: 8rem; width:10rem; margin: 1rem 0 0 1rem; border-radius: 10px;" :src="i.img" />
          <div style="float: left; text-align: left; margin-left: 3rem;">
            <p>{{i.name}}</p>
            <el-rate
              v-model="i.averStarsNum"
              disabled
              show-score
              text-color="#ff9900"
              score-template="{value}">
            </el-rate>
            <p>共有{{i.commentsNum}}条评论</p>
            <p>{{i.province+i.city+i.district+i.location}}</p>
          </div>
        </div>
      </div>
      <el-pagination
        :page-size="10"
        :pager-count="11"
        layout="prev, pager, next"
        :total="shopTotalCount"
        :current-change="changePage">
      </el-pagination>
    </div>
    <div style="width: 80%; margin: 0 auto;"><my-footer></my-footer></div>
  </div>
</template>
<script>
  import myFooter from '../../../views/Common/Footer';
import city from '../../../data';
import * as shopApi from '../../../api/Shop';
import * as commentApi from '../../../api/Evaluate';
import myBanner from '../../../components/Banner';

export default {
  components: {
    'myBanner': myBanner,
      'my-footer': myFooter
  },
  data() {
    return {
      activeDistrictClass: 'active_district',
      selectedDistrict: this.$store.getters.getSelectedDistrictName,
      districts: city[this.$store.getters.getSelectedCity],
      shopList: [],
      shopTotalCount: 0
    }
  },
  beforeMount() {
    shopApi.GetShopsByDistrict(this.$store.getters.getSelectedProvinceName, this.$store.getters.getSelectedCityName, this.districts[this._.keys(this.districts)[0]], 
                               this.$store.getters.getSelectedShopTypeId, '1').then(res => {
                                 if(res.status != 200) this.$message.error('获取门店数据失败');

                                 else {
                                   this.shopList = res.body
                                   let shopIds = []
                                   for(let i of this.shopList) {
                                     shopIds.push(i.pkId)
                                   }
                                   return shopIds
                                 }
                               }).then((shopIds) => {
                                  shopApi.GetShopsNumByDistrictAndShopType(this.$store.getters.getSelectedProvinceName, this.$store.getters.getSelectedCityName, this.districts[this._.keys(this.districts)[0]], 
                                                            this.$store.getters.getSelectedShopTypeId).then(res => {
                                                              if(res.status != 200) this.$message.error('获取门店数量失败');

                                                              else this.shopTotalCount = res.body
                                                            })
                                 commentApi.getCommentsNumAndAverStarsNumByShopIds(shopIds).then(res => {
                                   if(res.status != 200) this.$message.error("获取评论数失败");

                                   else {
                                     for(let i=0; i < this.shopList.length; i++) {
                                       this.shopList[i].commentsNum = res.body[i]['commentsNum'];
                                       this.shopList[i].averStarsNum = parseFloat(res.body[i]['averStarsNum'].toFixed(1));
                                     }
                                   }
                                 })
                               })
  },
  methods: {
    selectShop(shop) {
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
    },
    changeDistrict(v, k) {
      this.$store.dispatch('commitDistrictName', v);
      this.$store.dispatch('commitDistrict', k);
      this.selectedDistrict = v;
      shopApi.GetShopsByDistrict(this.$store.getters.getSelectedProvinceName, this.$store.getters.getSelectedCityName, v, 
                            this.$store.getters.getSelectedShopTypeId, '1').then(res => {
                              if(res.status != 200) this.$message.error();

                              else {
                                this.shopList = res.body
                                let shopIds = []
                                for(let i of this.shopList) {
                                  shopIds.push(i.pkId)
                                }
                                return shopIds
                              }
                            }).then((shopIds) => {
                              commentApi.getCommentsNumAndAverStarsNumByShopIds(shopIds).then(res => {
                                if(res.status != 200) this.$message.error("获取评论数失败");

                                else {
                                  for(let i=0; i < this.shopList.length; i++) {
                                    this.shopList[i].commentsNum = res.body[i]['commentsNum'];
                                    this.shopList[i].averStarsNum = parseFloat(res.body[i]['averStarsNum'].toFixed(1));
                                  }
                                }
                              })
                            })
    },
    changePage(p) {
      shopApi.GetShopsByDistrict(this.$store.getters.getSelectedProvinceName, this.$store.getters.getSelectedCityName, v, 
                            this.$store.getters.getSelectedShopTypeId, p).then(res => {
                              if(res.status != 200) this.$message.error();

                              else {
                                this.shopList = res.body
                                let shopIds = []
                                for(let i of this.shopList) {
                                  shopIds.push(i.pkId)
                                }
                                return shopIds
                              }
                            }).then((shopIds) => {
                              commentApi.getCommentsNumAndAverStarsNumByShopIds(shopIds).then(res => {
                                if(res.status != 200) this.$message.error("获取评论数失败");

                                else {
                                  for(let i=0; i < this.shopList.length; i++) {
                                    this.shopList[i].commentsNum = res.body[i]['commentsNum'];
                                    this.shopList[i].averStarsNum = parseFloat(res.body[i]['averStarsNum'].toFixed(1));
                                  }
                                }
                              })
                            })
    }
  }
}
</script>
<style lang="less" scoped>
  @import '../../../less/container';
  @import '../../../less/formEle';

  @list_item_height: 11rem;

  .active_district {
    background: green;
    color: white;
  }
</style>
