<template>
  <div id="container">
    <transition>
      <router-view></router-view>
    </transition>
  </div>
</template>
<script>
  export default{
    
  }
</script>
<style>
  #container {
    position: relative;
    text-align: center;
    width : 100%;
  }
</style>