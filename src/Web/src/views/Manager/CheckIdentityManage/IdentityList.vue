<template>
  <div class="auto_ten">
    <el-table
      :data="identityList"
      stripe
      style="width: 100%">
      <el-table-column
        prop="shopName"
        label="门店"
        width="180">
      </el-table-column>
      <el-table-column
        prop="name"
        label="名称"
        width="180">
      </el-table-column>
      <el-table-column
        prop="location"
        label="地点"
        width="180">
      </el-table-column>
      <el-table-column
        fixed="right"
        label="操作"
        width="100">
        <template slot-scope="scope">
          <el-button @click="handleClick(scope.row)" type="text" size="small">查看</el-button>
        </template>
      </el-table-column>
    </el-table>
  </div>
</template>
<script>
import * as merchantApi from '../../../api/Merchant';
import * as shopApi from '../../../api/Shop';

export default {
  data() {
    return {
      merchantShopList: [],
      merchantIdList: [],
      merchantShopIdList: [],
      merchantIdentityIdList: [],
      identityList: []
    }
  },
  beforeMount() {
    let _this = this
    merchantApi.getMerchantShopListNotChecked(1).then(res => {
      if(res.status != 200) this.$message.error("获取商户信息有误");

      else {
        this.merchantShopList = res.body;
      } 
      return
    }).then(() => {
      for(let i of this.merchantShopList) {
        if(i.mIdentityId != null){
          this.merchantIdList.push({
            "Id": i.mBasicId
          });
          this.merchantShopIdList.push({
            "ShopId": i.shopId
          });
          this.merchantIdentityIdList.push({
            "IdentityId": i.mIdentityId
          })
        }
      }
      merchantApi.getMerchantsName(this.merchantIdList).then(res => {
        if(res.status != 200) this.$message.error("出错");

        else {
          for(let i of res.body) {
            this.identityList.push({
              "name": i,
              "shopName": "",
              "location": ""
            })
          }
          shopApi.GetShopListByShopIds(this.merchantShopIdList).then(res => {
            if(res.status != 200) this.$message.error("获取门店名称地址出错");

            else {
              for(let i=0; i<res.body.length; i++) {
                this.identityList[i].shopName = res.body[i].shopName;
                this.identityList[i].location = res.body[i].location;
              }
            }
          })/*
          var merchantIds = []
          for(var i =0 ; i< this.merchantIdList.length; i++) {
            merchantIds[i] = this.merchantIdList[i].Id
          }
          shopApi.GetShopsByMerchantIds(merchantIds).then(res => {
            if(res.status != 200) this.$message.error("出错");
          
            else {
              for(let i = 0; i < res.body.length; i++) {
                _this.identityList[i].shopName = res.body[i].shopName;
                _this.identityList[i].location = res.body[i].location;
              }
            }
          })*/
        }
      })
    })
  },
  methods: {
    handleClick(row) {
      let _this = this
      for(let i = 0; i <  this.identityList.length; i++) {
        if(_this.identityList[i].name == row.name) {
          this.$store.dispatch('commitIdentityMerchantId', this.merchantIdList[i].Id)
          this.$store.dispatch('commitSetMerchantShopId', this.merchantShopIdList[i].ShopId)
          this.$store.dispatch('commitsetMerchantIdentityId', this.merchantIdentityIdList[i].IdentityId)
        }
      }
      
      this.$router.push('/Manager/IdentityDetail');
    }
  }
}
</script>
<style lang="less" scoped>
  @import "../../../less/container.less";
</style>
