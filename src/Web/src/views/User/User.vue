<template>
  <div class="auto_ten">
    <user-banner></user-banner>
    <div class="auto_eight" style="margin-top: 2rem; background: #f8f9f9;">
      <user-menu></user-menu>
      <div style="float: right; width: 70%;">
        <router-view></router-view>
      </div>
    </div>
    <div style="width: 80%; margin: 0 auto;"><my-footer></my-footer></div>
  </div>
</template>
<script>
  import myFooter from '../../views/Common/Footer';
import UserBanner from '../../components/Banner';
import UserMenu from '../../components/UserMenu';

export default {
  components: {
    'user-banner': UserBanner,
    'user-menu': UserMenu,
    'my-footer': myFooter
  }  
}
</script>
<style lang="less" scoped>
  @import "../../less/container.less";
</style>