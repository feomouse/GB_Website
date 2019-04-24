<template>
  <div class="auto_ten">
    <div style="font-size: 2rem; color: lightgray; font-weight: bold; margin: 10rem 0 2rem 0;">申请团购</div>
    <el-button type="primary" @click="apply">申请</el-button>
  </div>
</template>
<script>
export default {
  methods: {
    apply() {
      this.$router.push('/Merchant/Operation/GBServiceContract');
    }
  }
}
</script>
<style lang="less" scoped>

</style>
