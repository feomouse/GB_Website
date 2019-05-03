<template>
  <div id="cholder__SignIn">
    <div class="auto_eight">
      <div id="cleft__place">
        <img src="../../static/imgs/winter.jpg" alt="冬天到了，点点东西吧" style="width: 80%; height: 30rem; margin-top: 5rem;"/>
      </div>
      <div id="cright__place">
        <div class="formEle_container" style="box-shadow: 3px 3px 3px gray; border: 1px solid gray;">
          <h2>顾客登陆</h2>
          <div class="a-element-a-line">
            <input class="rem15-rem2-input" placeholder="邮箱或电话" v-model="UserName"/>
            <div class="InputError__Mes" v-if="ShowUserNameError">请输入正确的邮箱或电话</div>
          </div>
          <div class="a-element-a-line">
            <input class="rem15-rem2-input" placeholder="密码" v-model="SignIn.Password" type="password"/>
            <div class="InputError__Mes" v-if="ShowPassError">请输入秘密</div>
          </div>
          <div class="a-element-a-line">
            <div class="rem15-rem2-button" v-on:click="LoginRequest">登陆</div>
            <div class="InputError__Mes" v-if="ShowSignInError">登陆失败</div> 
            <div class="NormalSuccess__Mes" v-if="ShopSignInSuccess">登陆成功</div>
          </div>
          <div class="a-element-a-line">
            <p style="cursor: pointer; color: blue; font-size: 0.75rem; float: left;" @click="redirectToRegister">>>我要注册</p>
            <p style="cursor: pointer; color: blue; font-size: 0.75rem; float: right;" @click="redirectToMerchant">>>我是商户</p>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import * as SignInReq from '../../api/Identity';
import * as UserReq from '../../api/User';
import * as ManagerApi from '../../api/Manager';

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
      UserName: "",
      ifInBlack: false
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
        console.log(res)
        if(res.status == 401) 
        {
          this.ShowSignInError = true;
          setTimeout(()=> {
            this.ShowSignInError = false;
          }, 2000);

          return 401;
        }

        else if(res.status == 403)
        {
          this.ShowSignInError = true;
          setTimeout(()=> {
            this.ShowSignInError = false;
          }, 2000);
          return 403
        }

        else if(res.status == 200) 
        { 
          this.$store.dispatch('commitToken',res.body.token.access_token);
          this.$store.dispatch('commitRefreshToken', res.body.token.refresh_token);
          this.$store.dispatch('commitSetUserId', res.body.pkId);
          this.ShopSignInSuccess = true;
          setTimeout(()=> {
            this.ShopSignInSuccess = false;
          }, 2000);

          return 200;
        }
      }).then(status => {
          if(status == 200) {
            ManagerApi.ifViolateUser(this.UserName).then(res => {
              if(res.status != 200) {
                this.$message.error("检测是否在黑名单失败");
              }

              else if(res.body == true) {
                this.$message.error("对不起, 您被加入黑名单中");
                this.ifInBlack = true
              } else if(res.body == false)
              {
                UserReq.getUserBasicMessage(this.$store.getters.userId).then(res => {
                  if(res.status != 200)
                  {
                    this.$message.error('请求用户数据失败');
                  }
                  else if(res.status == 200)
                  {
                    this.$store.dispatch('commitSetUser', res.body);
        
                    this.$router.push({path: "/Customer/Basic"});
                  }
                })
              }
            })
          }
          else if(status == 401)
          {
            this.$message.error('您还未注册，请先注册');
          }
          else if(status == 403) 
          {
            this.$message.error('您的密码输入错误，请重新输入密码');
          }
      })
    },
    redirectToRegister() {
      this.$router.push('/Customer/SignUp');
    },
    redirectToMerchant() {
      this.$router.push('/Merchant/SignIn');
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

  #cholder__SignIn {
    height: auto;
    overflow: hidden;
  }

  #cleft__place {
    float: left;
    width: 65%;
    height: 40rem;
    line-height: 40rem;
    border-right: 1px solid lightgray;
  }

  #cleft__place #customer_logo{
    font-size: 5rem;
  }

  #cright__place {
    float: right;
    width: 30%;
    height: 40rem;
  }
</style>
