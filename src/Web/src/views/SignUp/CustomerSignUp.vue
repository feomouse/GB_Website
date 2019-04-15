<template>
  <div id="holderCSignUp__place">
    <div class="auto_eight">
      <div id="cleft__place">
        <label id="customer_logo" style="box-shadow: 3px 3px 3px gray; border: 1px solid gray;">团购&#968用户</label>
      </div>
      <div id="cright__place">
        <div class="formEle_container" style="box-shadow: 3px 3px 3px gray; border: 1px solid gray; padding-top: 2rem;">
          <div class="a-element-a-line">
            <input class="rem15-rem2-input" placeholder="邮箱或电话" v-model="UserName"/>
            <div class="InputError__Mes" v-if="ShowUserNameError">请输入正确的邮箱或电话</div>
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
  </div>
</template>
<script>
  import * as SignUpReq from '../../api/Identity';

  export default {
    data() {
      return {
        SignUp: {
          Email: "",
          PhoneNumber: "",
          Password: "",
          ConfirmedPassword: "",
          Role: "customer"
        },
        ShowUserNameError: false,
        ShowPassError: false,
        ShowPassComfiredError: false,
        ShowSignUpError: false,
        ShopSignUpSuccess: false,
        UserName: ""
      }
    },

    methods: {
      RegisterRequest() {
        if(/^[0-9a-zA-Z-_]+@[0-9a-zA-Z-_]+(\.[0-9A-Za-z-_]+)+$/.test(this.UserName))
        {
          this.SignUp.Email = this.UserName;
        }

        else if(/^1[34567]\d{9}$/.test(this.UserName))
        {
          this.SignUp.PhoneNumber = this.UserName;
        }

        else {
          this.ShowUserNameError = true;

          setTimeout(()=> {
            this.ShowUserNameError = false;
          }, 2000);
          return
        }

        if (this.SignUp.Password == "") {
          this.ShowPassError = true;

          setTimeout(()=> {
            this.ShowPassError = false;
          }, 2000);
          return;
        }
        if (this.SignUp.ConfirmedPassword !==this.SignUp.Password) {
          this.ShowPassComfiredError = true;

          setTimeout(()=> {
            this.ShowPassComfiredError = false;
          }, 2000);
          return;
        }

        SignUpReq.SignUpRequest(this.SignUp).then(status => {
          if(status == 400) {
            this.ShowSignUpError = true;
            setTimeout(()=> {
              this.ShowSignUpError = false;
            }, 2000);
          }

          else if(status == 200) {
            this.ShopSignUpSuccess = true;
            setTimeout(()=> {
              this.ShopSignUpSuccess = false;
            }, 2000);
          }
          
          this.SignUp = {
            Email: "",
            PhoneNumber: "",
            Password: "",
            ConfirmedPassword: "",
            Role: "customer"
          }

          this.UserName = "";
          this.$router.push('/Customer/SignIn');
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
  
  #holderCSignUp__place {
    height: auto;
  }

  #cleft__place {
    float: left;
    margin-top: 2rem;
    width: 65%;
    height: 40rem;
    line-height: 40rem;
    border-right: 1px solid lightgray;
  }

  #cright__place {
    float: right;
    width: 30%;
    height: 40rem;
  }

  #cleft__place #customer_logo{
    font-size: 5rem;
  }
</style>
