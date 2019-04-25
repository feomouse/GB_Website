<template>
  <div class="auto_ten tabContent_container">
    <div class="a-element-a-line" style="margin-top: 4rem;">
      <input class="rem15-rem2-input" placeholder="团购券码" v-model="orderCode" />
    </div>
    <div class="a-element-a-line">
      <el-button type="success" @click="ensure">确认团购交易</el-button>
    </div>
  </div>
</template>
<script>
import * as orderApi from '../../../api/Order';
import * as identityApi from '../../../api/Identity';

export default {
  data() {
    return {
      orderCode: ""
    }
  },
  methods: {
    ensure() {
      orderApi.ensurePay({"ShopName": this.$store.getters.getShopName, "OrderCode": this.orderCode}).then(res => {
          if(res.status == 401) {
            identityApi.GetTokenByRefreshToken(this.$store.getters.getRefreshToken).then(res => {
              if(res.status == 400) this.$router.push('/Customer/SignIn');

              else {
                this.$store.dispatch('commitRefreshToken', res.body.refresh_token);

                orderApi.ensurePay({"ShopName": this.$store.getters.getShopName, "OrderCode": this.orderCode}).then(res => {
                  if(res.status != 200) this.$message.error();
                  else this.$message({type: "success", message: "交易成功"}); 
                })
              }
            })
          }
          else if(res.status != 200) this.$message.error();
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
