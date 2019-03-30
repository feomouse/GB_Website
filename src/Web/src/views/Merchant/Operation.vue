<template>
  <div class="auto_ten">
    <merchant-menu></merchant-menu>
    <div class="auto_eight"></div>
  </div>
</template>
<script>
import MerchantMenu from '../../components/MerchantMenu';

export default {
  components : {
    'merchant-menu': MerchantMenu
  }
}
</script>
<style lang="less">
  @import '../../less/container';

  .auto_eight {
    display: inline-block;
  }
</style>
