<template>
  <div id="userBasicHolder__place">
    <div class="auto_eight">
      <div style="height:15rem" class="auto_ten">
        <div id="name" class="left-eight">
          <div class="place__font">
            邮箱: {{CustomerInfo.CustomerEmail}}
          </div>
        </div>
        <div id="img" class="right-two">
          <el-upload
            class="avatar-uploader"
            action=""
            :show-file-list="false"
            :before-upload="boforeUpload">
            <img v-if="CustomerInfo.CustomerImg" :src="CustomerInfo.CustomerImg" class="avatar">
            <i v-else class="el-icon-plus avatar-uploader-icon"></i> 
          </el-upload>
        </div>
      </div>
      <div class="msgItem">
        <div v-if="!JudgeEditing.isUserNameEditing" class="msgBox">
          <div class="place__font">
            用户名: {{CustomerInfo.CustomerName}}
          </div>
        </div>
        <div v-if="JudgeEditing.isUserNameEditing" class="msgBox">
          <div class="place__input">
            <input 
            v-model="TempCustomerInfo.CustomerName"
            class="rem15-rem2-input" 
            placeholder="请输入用户名" />
          </div>
        </div>
        <div class="editButton" v-on:click="editUserNameItem" v-if="!JudgeEditing.isUserNameEditing">编辑</div>
        <div class="editButton" v-on:click="insureUserNameChange" v-if="JudgeEditing.isUserNameEditing">确认</div>
        <div class="editButton" v-on:click="cancelUserNameChange" v-if="JudgeEditing.isUserNameEditing">取消</div>
      </div>
      <div class="msgItem">
        <div v-if="!JudgeEditing.isUserAddressEditing" class="msgBox">
          <div class="place__font">
            用户地址: {{CustomerInfo.CustomerAddress}}
          </div>
        </div>
        <div v-if="JudgeEditing.isUserAddressEditing" class="msgBox">
          <div class="place__input">
            <input 
            v-model="TempCustomerInfo.CustomerAddress"
            class="rem15-rem2-input" 
            placeholder="请输入用户地址" />
          </div>
        </div>
        <div class="editButton" v-on:click="editUserAddressItem" v-if="!JudgeEditing.isUserAddressEditing">编辑</div>
        <div class="editButton" v-on:click="insureUserAddressChange" v-if="JudgeEditing.isUserAddressEditing">确认</div>
        <div class="editButton" v-on:click="cancelUserAddressChange" v-if="JudgeEditing.isUserAddressEditing">取消</div>
      </div>
    </div>
  </div>
</template>
<script>
import * as userApi from '../../api/User';

export default {
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
      JudgeEditing: {
        isUserNameEditing: false,
        isUserAddressEditing: false
      }
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
      console.log(form);

      if (!is) {
        this.$message.error('上传Jpg!');
        return
      }

      userApi.upLoadCustomerImg(form).then(data => {
        console.log(data);
        this.CustomerInfo.CustomerImg = data;
      })

      return is;
    },
    editUserNameItem() {
      this.JudgeEditing.isUserNameEditing = true;
    },
    insureUserNameChange() {
      var setUserNameObj = {
        UserId: this.$store.getters.userId,
        UserName: this.TempCustomerInfo.CustomerName
      }
      userApi.setCustomerUserName(setUserNameObj).then(status => {
        if (status == 200) {
          this.CustomerInfo.CustomerName = this.TempCustomerInfo.CustomerName;
          this.JudgeEditing.isUserNameEditing = false;

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
          this.JudgeEditing.isUserNameEditing = false;
        }
      })
    },
    cancelUserNameChange() {
      this.JudgeEditing.isUserNameEditing = false;
    },
    editUserAddressItem() {
      this.JudgeEditing.isUserAddressEditing = true;
    },
    insureUserAddressChange() {
      var setUserAddressObj = {
        UserId: this.$store.getters.userId,
        Address: this.TempCustomerInfo.CustomerAddress
      };
      userApi.setCustomerAddress(setUserAddressObj).then(status => {
        if (status == 200) {
          this.CustomerInfo.CustomerAddress = this.TempCustomerInfo.CustomerAddress;
          this.JudgeEditing.isUserAddressEditing = false;

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
        } else if (status != 200) {
          this.$message.error('请求用户数据失败');
          this.JudgeEditing.isUserAddressEditing = false;
        }
      })
    },
    cancelUserAddressChange() {
      this.JudgeEditing.isUserAddressEditing = false;
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
    background: lightblue;
  }

  #name {
    height: @top_distance;
    background: green;
  }

  #img {
    height: @top_distance;
    background: yellow;
  }

  .place__font {
    font-size: 3rem;
    font-weight: bold;
    padding-left: 2rem;
    height: @line_distance;
    line-height: @line_distance;
    vertical-align: baseline;
  }

  .place__input {
    height: @line_distance;
    line-height: @line_distance;
    vertical-align: baseline;
  }

  .msgItem {
    height: @line_distance;
    background: gray;
    border: 3px solid black;
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
