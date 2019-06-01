<template>
  <div class="auto_ten">
    <my-banner></my-banner>
    <merchant-menu></merchant-menu>
    <div class="auto_eight">
      <router-view></router-view>
    </div>
  </div>
</template>
<script>
import MerchantMenu from '../../components/MerchantMenu';
import MerchantBanner from '../../components/MerchantBanner';
import * as shopApi from '../../api/Shop'; 
import * as identityApi from '../../api/Identity';
import * as merchantApi from '../../api/Merchant';
import cityData from '../../data';

export default {
  components : {
    'merchant-menu': MerchantMenu,
    'my-banner': MerchantBanner
  },
  data() {
    return {
      merchantName: this.$store.getters.getMerchantName,
      'cityData': cityData
    }
  },
  beforeMount() {
    /*
    merchantApi.ifWriteIdentity(this.$store.getters.getMerchantId, this.$store.getters.getMerchantShopId).then(res => {
      if(res.status == 401) {
        identityApi.GetTokenByRefreshToken(this.$store.getters.getRefreshToken).then(res => {
          if(res.status == 400) this.$router.push('/Customer/SignIn');

          else {
            this.$store.dispatch('commitRefreshToken', res.body.refresh_token);
            this.$store.dispatch('commitToken', res.body.access_token);

            merchantApi.ifWriteIdentity(this.$store.getters.getMerchantId, this.$store.getters.getMerchantShopId).then(res => {
              if(res.status != 200) this.$message.error("草,错误");

              else if(res.body == false) this.$router.push('/Merchant/CreateIdentity');
            })
          }
        })
      }
      else if(res.status != 200) this.$message.error("草,错误");

      else if(res.body == false) this.$router.push('/Merchant/CreateIdentity');
    }),*/
    identityApi.GetMerchantNameById(this.$store.getters.getMerchantId).then(res => {
      if(res.status == 401) {
        identityApi.GetTokenByRefreshToken(this.$store.getters.getRefreshToken).then(res => {
          if(res.status == 400) this.$router.push('/Customer/SignIn');

          else {
            this.$store.dispatch('commitRefreshToken', res.body.refresh_token);
            this.$store.dispatch('commitToken', res.body.access_token);

            identityApi.GetMerchantNameById(this.$store.getters.getMerchantId).then(res => {
              if(res.status != 200) this.$message.error();

              else {
                this.$store.dispatch('commitSetMerchantUserName', res.body.name);
              }
            })
          }
        })
      }
      else if(res.status != 200) this.$message.error();

      else {
        this.$store.dispatch('commitSetMerchantUserName', res.body.name);
      }
    }),
    shopApi.GetShopsByMerchantId(this.$store.getters.getMerchantId).then(res => {
      if(res.status == 401) {
        identityApi.GetTokenByRefreshToken(this.$store.getters.getRefreshToken).then(res => {
          if(res.status == 400) this.$router.push('/Customer/SignIn');

          else {
            this.$store.dispatch('commitRefreshToken', res.body.refresh_token);
            this.$store.dispatch('commitToken', res.body.access_token);
            
            shopApi.GetShopsByMerchantId(this.$store.getters.getMerchantId).then(res => {
              if(res.status != 200) {
                if(res.status == 400 && res.body == "identity yourself first") {
                  //this.$router.push('/Merchant/CreateIdentity');
                }
              }
              else {
                this.$store.dispatch('commitSetShopId', res.body[0].pkId);
                this.$store.dispatch('commitSetShopName', res.body[0].name);
                this.$store.dispatch('commitProvinceName', res.body[0].province);
                this.$store.dispatch('commitCityName', res.body[0].city);
                this.$store.dispatch('commitSetMerchantShops', res.body);
                this.$store.dispatch('commitSetMerchantCurrentShop', res.body[0])
              }
            })
          }
        })
      }
      else if(res.status != 200) {
        if(res.status == 400 && res.body == "identity yourself first") {
          //this.$router.push('/Merchant/CreateIdentity');
        }
      }
      else {
        this.$store.dispatch('commitSetShopId', res.body[0].pkId);
        this.$store.dispatch('commitSetShopName', res.body[0].name);
        this.$store.dispatch('commitProvinceName', res.body[0].province);
        this.$store.dispatch('commitCityName', res.body[0].city);
        this.$store.dispatch('commitSetMerchantShops', res.body);
        this.$store.dispatch('commitSetMerchantCurrentShop', res.body[0]);
      }
    }) 
  }
}
</script>
<style lang="less" scoped>
  @import '../../less/container';

  .auto_eight {
    display: inline-block;
  }
</style>
