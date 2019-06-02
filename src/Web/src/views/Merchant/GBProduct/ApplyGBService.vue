<template>
  <div class="auto_ten">
    <div style="font-size: 2rem; color: lightgray; font-weight: bold; margin: 10rem 0 2rem 0;">申请团购</div>
    <div style="font-size: 1rem; 
                color: lightgray; 
                font-weight: bold;
                margin: 10rem 0 2rem 0;">资质信息提交一个星期后还未通过的，账号将会注销，到时请重新注册并填写相关信息</div>
    <el-button type="primary" @click="apply">申请</el-button>
  </div>
</template>
<script>
import * as shopApi from '../../../api/Shop';
import * as merchantApi from '../../../api/Merchant';

export default {
  beforeMount() {
    /*
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
    */
  },
  data() {
    return {
      isChecked: true
    }
  },
  methods: {
    apply() {
      merchantApi.getMerchantShop(this.$store.getters.getMerchantId, this.$store.getters.getShopId).then(res => {
        if(res.status != 200 || res.body == null) this.$message.error('无法检测是否填写资质信息');

        else if(res.body.mIdentityId == null) this.$router.push('/Merchant/CreateIdentity');

        else if(res.body.isChecked == false) this.$message.error('资质信息还未通过验证');

        else this.$router.push('/Merchant/Operation/GBServiceContract');
      })
    }
  }
}
</script>
<style lang="less" scoped>

</style>
