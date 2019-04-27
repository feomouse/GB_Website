<template>
  <div>
    <manager-banner></manager-banner>
    <manager-menu></manager-menu>
    <div class="auto_eight">
      <router-view></router-view>
    </div>
  </div>
</template>

<script>
import ManagerBanner from '../../components/ManagerBanner';
import ManagerMenu from '../../components/ManagerMenu';

export default {
  components: {
    'manager-banner': ManagerBanner,
    'manager-menu': ManagerMenu
  }
}
</script>

<style>
  @import '../../less/container';

  .auto_eight {
    display: inline-block;
  }
</style>
