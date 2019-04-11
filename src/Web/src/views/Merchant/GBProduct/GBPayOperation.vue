<template>
  <div class="auto_eight">
    <div class="a-element-a-line" style="margin-top: 4rem;">
      <input class="rem15-rem2-input" placeholder="团购券码" v-model="orderCode" />
    </div>
    <div class="a-element-a-line">
      <button class="rem15-rem2-button" @click="ensure">确认团购交易</button>
    </div>
  </div>
</template>
<script>
import * as orderApi from '../../../api/Order';

export default {
  data() {
    return {
      orderCode: ""
    }
  },
  methods: {
    ensure() {
      orderApi.ensurePay(
        {"ShopName": this.$store.getters.getShopName, "OrderCode": this.orderCode}).then(res => {
          if(res.status != 200) this.$message.error();
          else this.$message({type: "success", message: "交易成功"}); 
        })
    }
  }
}
</script>
<style lang="less" scoped>
  @import '../../../less/container';
  @import '../../../less/formEle';
</style>
