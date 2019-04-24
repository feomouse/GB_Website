<template>
  <div class="auto_ten">
    <div class="banner">
      <div style="float:right; margin-right: 4rem; line-height: 3rem;">登陆商户: {{merchantName}}</div>
    </div>
  </div>
</template>
<script>
export default {
  data() {
    return {
      merchantName: this.$store.getters.getMerchantName
    }
  }
}
</script>
<style lang="less" scoped>
  @import '../less/container';
  @import '../less/formEle';

  .banner {
    height: 3rem;
    background: #edf6eb;
    padding: 0 12rem 0 16rem;
    font-size: 0.8rem;
    color: #666a65;
  }

</style>
