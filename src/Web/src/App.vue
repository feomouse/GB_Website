<template>
  <div id="container">
    <transition>
      <router-view></router-view>
    </transition>
    <div style="width: 80%; margin: 0 auto;"><my-footer></my-footer></div>
  </div>
</template>
<script>
  import myFooter from './views/Common/Footer';

  export default{
    components: {
      'my-footer': myFooter
    }
  }
</script>
<style>
  #container {
    position: relative;
    text-align: center;
    width : 100%;
    box-sizing: border-box;
  }
</style>