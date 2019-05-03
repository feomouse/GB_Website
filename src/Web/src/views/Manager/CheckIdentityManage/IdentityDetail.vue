<template>
  <div class="auto_eight">
    <div  style="margin-top: 3rem; background: lightblue; border: 1px solid blue;">
      <div class="left-five itemShow">名字: {{identity.identityName}}</div>
      <div class="left-five itemShow">身份证号: {{identity.identityNum}}</div>
      <div class="left-five itemShow">营业执照码: {{identity.licenseCode}}</div>
      <div class="left-five itemShow">营业执照名: {{identity.licenseName}}</div>
      <div class="left-five itemShow">营业执照拥有者: {{identity.licenseOwner}}</div>
      <div class="left-five itemShow">营业执照起始日期: {{identity.availableSatartTime}}</div>
      <div class="left-five itemShow">营业执照有效日期至: {{identity.availableTime}}</div>
      <div class="left-five itemShow">联系电话: {{identity.tel}}</div>
      <div>
        <div class="imgShow"><p>身份证正面照: </p><img :src="identity.identityImgF" alt="身份证正面照" style="width: 10rem; height: 10rem;"/></div>
        <div class="imgShow"><p>身份证反面照: </p><img :src="identity.identityImgB" alt="身份证反面照" style="width: 10rem; height: 10rem;"/></div>
        <div class="imgShow"><p>营业执照照片: </p><img :src="identity.licenseImg" alt="营业执照照片" style="width: 10rem; height: 10rem;"/></div>
      </div>
      <div style="clear:both;"></div>
    </div>
    <div>
      <el-button type="success" @click="passCheck" style="margin: 2rem 2rem 0 2rem;">通过验证</el-button>
      <el-button type="danger" @click="failCheck" style="margin: 2rem 2rem 0 2rem;">验证失败</el-button>
    </div>
  </div>
</template>
<script>
  import * as merchantApi from '../../../api/Merchant';

  export default {
    data() {
      return {
        identity: {

        }
      }
    },
    beforeMount() {
      merchantApi.getMerchantIdentityByMerchantId(this.$store.getters.getIdentityMerchantId).then(res => {
        if(res.status != 200) this.$message.error('get identity error');

        else this.identity = res.body;
      })
    },
    methods: {
      passCheck() {
        merchantApi.checkIdentity({
          "MerchantId": this.$store.getters.getIdentityMerchantId,
          "CheckResult": true
        }).then(res => {
          if(res.status != 200) this.$message.error();

          else {
            this.$message({
              type: 'success',
              message: '通过验证资质成功'
            })
            this.$router.push('/Manager/IdentityList');
          }
        })
      },
      failCheck() {
        this.$message({
          type: 'warning',
          message: '未通过商户资质信息'
        })
        this.$router.push('/Manager/IdentityList');
      }
    }
  }
</script>
<style lang="less" scoped>
  @import "../../../less/container.less";

  @left_five_height : auto;
  .imgShow {
    float: left;
    margin-left: 8rem;
  }
  .itemShow {
    height: 3rem;
    margin-top: 0.3rem;
  }
</style>