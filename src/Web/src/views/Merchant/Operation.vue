<template>
  <div class="auto_ten">
    <merchant-menu></merchant-menu>
    <div class="auto_eight">
      <div style="text-align: right; height: 3rem; padding: 2rem 5rem 0 0; font-size: 1rem; border-bottom: 2px solid lightgray;">商户: 33@33.com</div>
      <router-view></router-view>
    </div>
  </div>
</template>
<script>
import MerchantMenu from '../../components/MerchantMenu';
import * as shopApi from '../../api/Shop'; 
import * as identityApi from '../../api/Identity';

export default {
  components : {
    'merchant-menu': MerchantMenu
  },
  data() {
    return {
      merchantName: this.$store.getters.getMerchantName
    }
  },
  beforeCreate() {
    identityApi.GetMerchantNameById(this.$store.getters.getMerchantId).then(res => {
      if(res.status != 200) this.$message.error();

      else {
        this.$store.dispatch('commitSetMerchantUserName', res.body.name);
      }
    }),
    shopApi.GetShopInfoByMerchantId(this.$store.getters.getMerchantId).then(res => {
      if(res.status != 200) this.$message.error();
      else {
        this.$store.dispatch('commitSetShopId', res.body.pkId);
        this.$store.dispatch('commitSetShopName', res.body.name);
      }
    })
  },
}
</script>
<style lang="less" scoped>
  @import '../../less/container';

  .auto_eight {
    display: inline-block;
  }
</style>
