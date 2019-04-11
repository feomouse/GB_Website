<template>
  <div class="auto_ten">
    <merchant-menu></merchant-menu>
    <div class="auto_eight">
      <router-view></router-view>
    </div>
  </div>
</template>
<script>
import MerchantMenu from '../../components/MerchantMenu';
import * as shopApi from '../../api/Shop'; 

export default {
  components : {
    'merchant-menu': MerchantMenu
  },
  beforeCreate() {
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
