<template>
  <div id="holderMSignUp__place">
    <div class="auto_eight">
      <div id="mleft__place">
        <label id="merchant_logo">团购&#968商户</label>
      </div>
      <div id="mright__place">
        <div class="formEle_container">
          <div class="a-element-a-line">
            <input class="rem15-rem2-input" placeholder="邮箱" v-model="SignUp.Email"/>
            <div class="InputError__Mes" v-if="ShowEmailError">请输入正确的邮箱</div>
          </div>
          <div class="a-element-a-line">
            <input class="rem15-rem2-input" placeholder="密码" v-model="SignUp.Password"/>
            <div class="InputError__Mes" v-if="ShowPassError">请输入秘密</div>
          </div>
          <div class="a-element-a-line">
            <input class="rem15-rem2-input" placeholder="确认密码" v-model="SignUp.ConfirmedPassword"/>
            <div class="InputError__Mes" v-if="ShowPassComfiredError">确认密码与密码不相同</div>
          </div>
          <div class="a-element-a-line">
            <div class="rem15-rem2-button" v-on:click="RegisterRequest">注册</div>
            <div class="InputError__Mes" v-if="ShowSignUpError">注册请求失败</div> 
            <div class="NormalSuccess__Mes" v-if="ShopSignUpSuccess">注册请求成功</div>
          </div>
        </div>
      </div>
    </div>
    <div id="mbottom__place"></div>
  </div>
</template>
<script>
  import * as SignUpReq from '../../api/Identity';

  export default {
    data() {
      return {
        SignUp: {
          Email: "",
          Password: "",
          ConfirmedPassword: "",
          Role: "merchant"
        },
        ShowEmailError: false,
        ShowPassError: false,
        ShowPassComfiredError: false,
        ShowSignUpError: false,
        ShopSignUpSuccess: false
      }
    },

    methods: {
      RegisterRequest() {
        if(this.SignUp.Email == "") {
          this.ShowEmailError = true;
          return;
        } 
        else if (this.SignUp.Password == "") {
          this.ShowPassError = true;
          return;
        }
        else if (this.SignUp.ConfirmedPassword !==this.SignUp.Password) {
          this.ShowPassComfiredError = true;
          return;
        }
        
        SignUpReq.SignUpRequest(this.SignUp).then(status => {
          console.log(status);
          if(status == 400) this.ShowSignUpError = true;
          else if(status == 200) this.ShopSignUpSuccess = true;
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
  
  #holderMSignUp__place {
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
