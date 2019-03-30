<template>
  <div id="mholder__SignIn">
    <div class="auto_eight">
      <div id="mleft__place">
        <label id="merchant_logo">团购&#968商户登陆</label>
      </div>
      <div id="mright__place">
        <div class="formEle_container">
          <div class="a-element-a-line">
            <input class="rem15-rem2-input" placeholder="邮箱" v-model="SignIn.Email"/>
            <div class="InputError__Mes" v-if="ShowEmailError">请输入正确的邮箱</div>
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
    <div id="mbottom_place"></div>
  </div>
</template>
<script>
import * as SignInReq from '../../api/Identity';
export default {
  data() {
    return {
      SignIn: {
        Email: "",
        Password: ""
      },
      ShowEmailError: false,
      ShowPassError: false,
      ShowSignInError: false,
      ShopSignInSuccess: false
    }
  },
  methods: {
    LoginRequest() {
      if(this.SignIn.Email == "") {
        this.ShowEmailError = true;
        return;
      } 
      else if (this.SignIn.Password == "") {
        this.ShowPassError = true;
        return;
      }
      
      SignInReq.SignInRequest(this.SignIn).then(res => {
        console.log(res.status);
        if(res.status != 200) this.ShowSignInError = true;
        else if(res.status == 200)
        { 
          this.$store.dispatch('commitToken',res.body.token.access_token);
          this.$store.dispatch('commitSetMerchantName', res.body.pkId);
          this.ShopSignInSuccess = true;
        }
      })
    }
  }
}
</script>
<style lang="less">
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
    width: 70%;
    height: 40rem;
    background: gray;
    line-height: 40rem;
  }

  #mleft__place #merchant_logo{
    font-size: 5rem;
  }

  #mright__place {
    float: right;
    width: 30%;
    height: 40rem;
    background: wheat;
  }

  #mbottom__place {
    width: 80%;
    height: 10rem;
    background: wheat;
    margin: 0 auto;
  }
</style>
