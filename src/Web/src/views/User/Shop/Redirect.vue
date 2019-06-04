<template>
  <div style="text-align: center;">
    <p>提交订单成功</p>
    <h1>系统将在{{time}}秒后跳转到门店首页</h1>
  </div>
</template>
<script>
export default {
  data() {
    return {
      time: 5
    }
  },
  beforeMount() {
    var interval = setInterval(() => {
      this.time--;
    }, 1000);
    setTimeout(()=> {
      clearInterval(interval);
      this.$router.push('/Shops');
    }, 5000);
  }
}
</script>
<style lang="less" scoped>

</style>