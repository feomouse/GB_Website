<template>
  <div class="auto_ten">
    <div style="font-size: 2rem; color: lightgray; font-weight: bold; margin: 10rem 0 2rem 0;">申请团购</div>
    <el-button type="primary" @click="apply">申请</el-button>
  </div>
</template>
<script>
import * as shopApi from '../../../api/Shop';

export default {
  beforeMount() {
    shopApi.GetShopInfoByMerchantId(this.$store.getters.getMerchantId).then(res => {
      if(res.status == 401) {
        identityApi.GetTokenByRefreshToken(this.$store.getters.getRefreshToken).then(res => {
          if(res.status == 400) this.$router.push('/Customer/SignIn');

          else {
            this.$store.dispatch('commitRefreshToken', res.body.refresh_token);
            this.$store.dispatch('commitToken', res.body.access_token);
            
            shopApi.GetShopInfoByMerchantId(this.$store.getters.getMerchantId).then(res => {
              if(res.status != 200) {
                if(res.status == 400 && res.body == "identity yourself first") {
                  this.isChecked = false;
                }
              }
              else {
                this.$store.dispatch('commitSetShopId', res.body.pkId);
                this.$store.dispatch('commitSetShopName', res.body.name);
                this.$store.dispatch('commitProvinceName', res.body.province);
                this.$store.dispatch('commitCityName', res.body.city);
              }
            })
          }
        })
      }
      else if(res.status != 200) {
        if(res.status == 400 && res.body == "identity yourself first") {
          this.isChecked = false;
        }
      }
      else {
        this.$store.dispatch('commitSetShopId', res.body.pkId);
        this.$store.dispatch('commitSetShopName', res.body.name);
        this.$store.dispatch('commitProvinceName', res.body.province);
        this.$store.dispatch('commitCityName', res.body.city);
      }
    })
  },
  data() {
    return {
      isChecked: true
    }
  },
  methods: {
    apply() {
      if(this.isChecked == false) this.$message.error("还未通过资质验证, 请耐心等待");

      else this.$router.push('/Merchant/Operation/GBServiceContract');
    }
  }
}
</script>
<style lang="less" scoped>

</style>
