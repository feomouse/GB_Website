<template>
  <div class="auto_eight" style="text-align: center;">
      <h1 style="text-align:left;">合同: </h1>
      <div style="text-align: left; height: 30rem; width: 100%; border: 1px solid lightgray; margin-bottom: 2rem;">
        <div>合同内容</div>
        <div>合同内容</div>
        <div>合同内容</div>
        <div>合同内容</div>
        <div>合同内容</div>
        <div>合同内容</div>
        <div>合同内容</div>
        <div>合同内容</div>
      </div>
      <el-checkbox v-model="agreeContract">我已阅读并同意以上合同内容</el-checkbox>
      <el-button type="primary" @click="ensure">确认</el-button>
  </div>  
</template>
<script>
import * as shopApi from '../../../api/Shop';
import * as identityApi from '../../../api/Identity';

export default {
  date () {
    return {
      agreeContract: false
    }
  },
  methods: {
    ensure() {
      if(this.agreeContract) {
        shopApi.SetGroupBuying(this.$store.getters.getShopId).then(res => {
          if(res.status == 401) {
            identityApi.GetTokenByRefreshToken({
              "RefreshToken" : this.$store.getters.getRefreshToken
            }).then(res => {
              if(res.status != 200) this.$router.push('/Customer/SignIn');

              else {
                this.$store.dispatch('commitRefreshToken', res.body.refresh_token);
                this.$store.dispatch('commitToken', res.body.access_token);

                shopApi.SetGroupBuying(this.$store.getters.getShopId).then(res => {
                  if(res.status != 200) this.$message.error("设置团购服务失败");

                  else {
                    this.$message({
                      type: 'success',
                      message: '设置成功'
                    })
                    this.$store.dispatch('commitSetIsGB', true);
                    this.$router.push('/Merchant/Operation/GBProductOperations');
                  }
                })
              }
            })
          }
          else if(res.status != 200) this.$message.error("设置团购服务失败");

          else {
            this.$message({
              type: 'success',
              message: '设置成功'
            })
            this.$store.dispatch('commitSetIsGB', true);
            this.$router.push('/Merchant/Operation/GBProductOperations');
          }
        })
      } else {
        this.$message({
          type: 'warning',
          message: '请同意合同内容'
        })
      }
    }
  }
}
</script>
<style lang="less" scoped>

</style>
