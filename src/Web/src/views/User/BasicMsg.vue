<template>
  <div id="userBasicHolder__place">
    <user-banner></user-banner>
    <div class="auto_eight">
      <div style="text-align: left; 
                  padding-left: 2rem; 
                  height: 4rem; line-height: 4rem; background: white; 
                  sont-size: 3rem; font-weight: bold;">用户基本信息:
      </div>
      <div style="height:15rem; background: lightgreen; line-height: 15rem; text-align: left;" class="auto_ten">
        <el-upload
          class="avatar-uploader"
          action=""
          style="float: left; margin-left: 2rem;"
          :show-file-list="false"
          :before-upload="boforeUpload">
          <img v-if="CustomerInfo.CustomerImg" :src="CustomerInfo.CustomerImg" class="avatar">
          <i v-else class="el-icon-plus avatar-uploader-icon"></i> 
        </el-upload>
        <h2 style="float: left; margin-left: 5rem;">用户名: {{CustomerInfo.CustomerName}}</h2>
        <div style="float: right; padding-right: 5rem;"><p style="display: inline-block; cursor:pointer;" @click="ShowNameEditDialog = true">修改用户名></p></div>
      </div>
      <el-dialog title="编辑用户名" :visible.sync="ShowNameEditDialog">
        <el-form :model="CustomerInfo" label-width="80px">
          <el-form-item label="旧用户名">{{CustomerInfo.CustomerName}}</el-form-item>
          <el-form-item label="新用户名">
            <el-input v-model="TempCustomerInfo.CustomerName"></el-input>
          </el-form-item>
        </el-form>
        <div slot="footer">
          <el-button type="primary" @click="insureUserNameChange">确认修改</el-button>
          <el-button @click="ShowNameEditDialog = false">取消</el-button>
        </div>
      </el-dialog>
      <div style="clear:both;"></div>
      <div class="msgItem">
        <div class="msgItemHeader">邮箱</div>
        <div style="text-align: left; line-height: 6rem; padding-left: 3rem;">{{CustomerInfo.CustomerEmail}}</div>
      </div>
      <div class="msgItem">
        <div class="msgItemHeader">地址</div>
        <div style="text-align: left; line-height: 6rem; padding-left: 3rem;">{{CustomerInfo.CustomerAddress}}
          <div style="text-align: right; float: right; padding-right: 4rem;">
            <el-button @click="ShowAddressEditDialog = true">修改</el-button>
          </div>
        </div>
      </div>
      <el-dialog title="编辑地址" :visible.sync="ShowAddressEditDialog">
        <el-form :model="CustomerInfo" label-width="80px">
          <el-form-item label="旧地址">
            {{CustomerInfo.CustomerAddress}}
          </el-form-item>
          <el-form-item label="新地址">
            <el-input v-model="TempCustomerInfo.CustomerAddress"></el-input>
          </el-form-item>
        </el-form>
        <div slot="footer">
          <el-button type="primary" @click="insureUserAddressChange">确认修改</el-button>
          <el-button @click="ShowAddressEditDialog = false">取消</el-button>
        </div>
      </el-dialog>
    </div>
  </div>
</template>
<script>
import * as userApi from '../../api/User';
import * as imgApi from '../../api/img';
import * as identityApi from '../../api/Identity';
import UserBanner from '../../components/Banner';

export default {
  components: {
    'user-banner': UserBanner
  },
  data() {
    return {
      CustomerInfo: {
        CustomerName: "",
        CustomerImg: "",
        CustomerAddress: "",
        CustomerEmail: ""
      },
      TempCustomerInfo: {
        CustomerName: "",
        CustomerImg: "",
        CustomerAddress: "",
        CustomerEmail: ""
      },
      ShowNameEditDialog: false,
      ShowEmailEditDialog: false,
      ShowAddressEditDialog: false
    }
  },
  beforeMount() {
    this.CustomerInfo.CustomerName = this.$store.getters.user.userName;
    this.CustomerInfo.CustomerImg = this.$store.getters.user.lookingImg;
    this.CustomerInfo.CustomerAddress = this.$store.getters.user.address;
    this.CustomerInfo.CustomerEmail = this.$store.getters.user.email;
  },
  methods: {
    boforeUpload(file) {
      const is = file.type === 'image/jpeg' || file.type === 'image/png';

      var form = new FormData();

      form.append("file", file);
      form.append("userId", this.$store.getters.userId);

      if (!is) {
        this.$message.error('上传Jpg!');
        return
      }

      imgApi.ImgUpload(form).then(res => {
        if(res.status == 401) {
          identityApi.GetTokenByRefreshToken(this.$store.getters.getRefreshToken).then(res => {
            if(res.status == 400) this.$router.push('/Customer/SignIn');

            else {
              this.$store.dispatch('commitRefreshToken', res.body.refresh_token);
              this.$store.dispatch('commitToken', res.body.access_token);

              imgApi.ImgUpload(form).then(res => {
                if (res.status == 400) this.$message.error();
      
                else {
                  userApi.setCustomerImg(this.$store.getters.userId, res.body).then(res => {
                    if(res.status != 200) this.$message.error("设置图像失败");

                    else this.CustomerInfo.CustomerImg = res.body;
                  })
                }
              })
            }
          })
        }
        else if (res.status == 400) this.$message.error();

        else {
          userApi.setCustomerImg(this.$store.getters.userId, res.body).then(res => {
            if(res.status != 200) this.$message.error("设置图像失败");

            else {
              this.CustomerInfo.CustomerImg = res.body;
            }
          })
        }
      })

      return is;
    },
    insureUserNameChange() {
      var setUserNameObj = {
        UserId: this.$store.getters.userId,
        UserName: this.TempCustomerInfo.CustomerName
      }
      userApi.setCustomerUserName(setUserNameObj).then(status => {
        if(status == 401) {
          identityApi.GetTokenByRefreshToken(this.$store.getters.getRefreshToken).then(res => {
            if(res.status == 400) this.$router.push('/Customer/SignIn');

            else {
              this.$store.dispatch('commitRefreshToken', res.body.refresh_token);
              this.$store.dispatch('commitToken', res.body.access_token);

              userApi.setCustomerUserName(setUserNameObj).then(status => {
                if (status == 200) {
                  this.CustomerInfo.CustomerName = this.TempCustomerInfo.CustomerName;
                  this.ShowNameEditDialog = false;

                  userApi.getUserBasicMessage(this.$store.getters.userId).then(res => {
                    if(res.status != 200)
                    {
                      this.$message.error('请求用户数据失败');
                    }
                    else if(res.status == 200)
                    {
                      this.$store.dispatch('commitSetUser', res.body);
                    }
                  })
                } else if (status != 200)
                {
                  this.$message.error("修改用户名失败");
                }
              })
            }
          })
        }
        else if (status == 200) {
          this.CustomerInfo.CustomerName = this.TempCustomerInfo.CustomerName;
          this.ShowNameEditDialog = false;

          userApi.getUserBasicMessage(this.$store.getters.userId).then(res => {
            if(res.status != 200)
            {
              this.$message.error('请求用户数据失败');
            }
            else if(res.status == 200)
            {
              this.$store.dispatch('commitSetUser', res.body);
            }
          })
        } else if (status != 200)
        {
          this.$message.error("修改用户名失败");
        }
      })
    },
    insureUserAddressChange() {
      var setUserAddressObj = {
        UserId: this.$store.getters.userId,
        Address: this.TempCustomerInfo.CustomerAddress
      };
      userApi.setCustomerAddress(setUserAddressObj).then(status => {
        if(status == 401) {
          identityApi.GetTokenByRefreshToken(this.$store.getters.getRefreshToken).then(res => {
            if(res.status == 400) this.$router.push('/Customer/SignIn');

            else {
              this.$store.dispatch('commitRefreshToken', res.body.refresh_token);
              this.$store.dispatch('commitToken', res.body.access_token);

              userApi.setCustomerAddress(setUserAddressObj).then(status => {
                if (status == 200) {
                  this.CustomerInfo.CustomerAddress = this.TempCustomerInfo.CustomerAddress;

                  userApi.getUserBasicMessage(this.$store.getters.userId).then(res => {
                    if(res.status != 200)
                    {
                      this.$message.error('请求用户数据失败');
                    }
                    else if(res.status == 200)
                    {
                      this.$store.dispatch('commitSetUser', res.body);
                      this.ShowAddressEditDialog = false;
                    }
                  })
                } else if (status != 200) {
                  this.$message.error('请求用户数据失败');
                }
              })
            }
          })
        }
        else if (status == 200) {
          this.CustomerInfo.CustomerAddress = this.TempCustomerInfo.CustomerAddress;

          userApi.getUserBasicMessage(this.$store.getters.userId).then(res => {
            if(res.status != 200)
            {
              this.$message.error('请求用户数据失败');
            }
            else if(res.status == 200)
            {
              this.$store.dispatch('commitSetUser', res.body);
              this.ShowAddressEditDialog = false;
            }
          })
        } else if (status != 200) {
          this.$message.error('请求用户数据失败');
        }
      })
    }
  },
}
</script>
<style lang="less">
  @import "../../less/container.less";
  @import "../../less/formEle.less";
  @import "../../less/msg.less";
  @import "../../less/ele-ui.less";

  @eight_height : 25rem;
  @top_distance : 15rem;
  @line_distance: 10rem;
  @left_eight_height : auto;
  @right_two_height : auto;
  @left_five_height : auto;
  
  #userBasicHolder__place {
    height: auto;
  }

  .el-upload {
    height: 10rem;
    border-radius: 50%;
    border: 3px solid black;
  }

  .avatar-uploader {
    border-radius: 50%;
  }

  .place__input {
    height: @line_distance;
    line-height: @line_distance;
    vertical-align: baseline;
  }

  .msgItem {
    height: @line_distance;
    box-shadow: 1px 3px 3px gray;
    margin-top: 2rem;
  }

  .msgItemHeader {
    border-left: 6px solid lightgreen;
    text-align: left;
    font-size: 1.5rem;
    font-weight: bold;
    padding-left: 3rem;
  }
  
  .msgBox {
    height: @line_distance;
    display: inline-block;
    width: 55rem;
  }

  .editButton {
    display: inline-block;
    font-size: 1.5rem;
    cursor: pointer;
    width:5rem;
  }
</style>
