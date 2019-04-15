<template>
  <div id="mholder__SignIn">
    <div class="auto_eight">
      <div id="mleft__place">
        <label id="merchant_logo" style="box-shadow: 3px 3px 3px gray; border: 1px solid gray;">团购&#968商户登陆</label>
      </div>
      <div id="mright__place">
        <div class="formEle_container" style="box-shadow: 3px 3px 3px gray; border: 1px solid gray; padding-top: 2rem;">
          <div class="a-element-a-line">
            <input class="rem15-rem2-input" placeholder="邮箱或电话" v-model="UserName"/>
            <div class="InputError__Mes" v-if="ShowUserNameError">请输入正确的邮箱或电话</div>
          </div>
          <div class="a-element-a-line">
            <input class="rem15-rem2-input" placeholder="密码" v-model="SignIn.Password"/>
            <div class="InputError__Mes" v-if="ShowPassError">请输入秘密</div>
          </div>
          <div class="a-element-a-line">
            <div class="rem15-rem2-button" v-on:click="LoginRequest">登陆</div>
            <div class="InputError__Mes" v-if="ShowSignInError">登陆失败</div> 
            <div class="NormalSuccess__Mes" v-if="ShopSignInSuccess">登陆成功</div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import * as SignInReq from '../../api/Identity';
import * as MerchantApi from '../../api/Merchant';

export default {
  data() {
    return {
      SignIn: {
        Email: "",
        PhoneNumber: "",
        Password: ""
      },
      ShowUserNameError: false,
      ShowPassError: false,
      ShowSignInError: false,
      ShopSignInSuccess: false,
      UserName: ""
    }
  },
  methods: {
    LoginRequest() {
      if(/^[0-9a-zA-Z-_]+@[0-9a-zA-Z-_]+(\.[0-9A-Za-z-_]+)+$/.test(this.UserName))
      {
        this.SignIn.Email = this.UserName;
      }

      else if(/^1[34567]\d{9}$/.test(this.UserName))
      {
        this.SignIn.PhoneNumber = this.UserName;
      }

      else {
        this.ShowUserNameError = true;

        setTimeout(()=> {
          this.ShowUserNameError = false;
        }, 2000);
        return
      }
      if (this.SignIn.Password == "") {
        this.ShowPassError = true;

        setTimeout(()=> {
          this.ShowPassError = false;
        }, 2000);
        return;
      }
      
      SignInReq.SignInRequest(this.SignIn).then(res => {
        if(res.status != 200) {
          this.ShowSignInError = true;

          setTimeout(()=> {
            this.ShowSignInError = false;
          }, 2000);
        }
        else if(res.status == 200)
        { 
          this.$store.dispatch('commitToken',res.body.token.access_token);
          this.$store.dispatch('commitRefreshToken', res.body.token.refresh_token);
          this.$store.dispatch('commitSetMerchantName', res.body.pkId);
          this.ShopSignInSuccess = true;

          setTimeout(()=> {
            this.ShopSignInSuccess = false;
          }, 2000);

          MerchantApi.getMerchantBasicByMerchantId(this.$store.getters.getMerchantId).then(res => {
            if(res.status != 200) this.$message.error();

            if(res.body.shopId == "00000000-0000-0000-0000-000000000000") this.$router.push('/Merchant/CreateShop');
            else this.$router.push('/Merchant/Operation');
          })
        }
      })
    }
  }
}
</script>
<style lang="less" scoped>
  @import "../../less/container.less";
  @import "../../less/formEle.less";
  @import "../../less/msg.less";

  @eight_height : 40rem;
  @top_distance : 15rem;
  @left_eight_height : auto;
  @right_two_height : auto;
  @left_five_height : auto;
  
  #mholder__SignIn {
    height: auto;
  }

  #mleft__place {
    float: left;
    width: 65%;
    height: 40rem;
    line-height: 40rem;
    border-right: 1px solid lightgray;
  }

  #mleft__place #merchant_logo{
    font-size: 5rem;
  }

  #mright__place {
    float: right;
    width: 30%;
    height: 40rem;
  }
</style>
