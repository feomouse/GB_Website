<template>
  <div id="userBasicHolder__place">
    <div class="auto_eight">
      <div style="height:15rem" class="auto_ten">
        <div id="name" class="left-eight">{{CustomerInfo.CustomerName}}</div>
        <div id="img" class="right-two">
          <el-upload
            class="avatar-uploader"
            action=""
            :show-file-list="false"
            :before-upload="boforeUpload">
            <img v-if="imgUrl" :src="imgUrl" class="avatar">
            <i v-else class="el-icon-plus avatar-uploader-icon"></i> 
          </el-upload>
        </div>
      </div>
      <div id="address">{{CustomerInfo.CustomerAddress}}</div>
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
      imgUrl: ''
    }
  },
  methods: {
    boforeUpload(file) {
      const is = file.type === 'image/jpeg' || file.type === 'image/png';
      console.log(file);

      var form = new FormData();

      var fileForm = form.append("file", file);

      if (!is) {
        this.$message.error('上传Jpg!');
        return
      }

      userApi.upLoadCustomerImg(fileForm).then(data => {
        this.imgUrl = URL.createObjectURL(data);
      })

      return is;
    }
  },
}
</script>
<style lang="less">
  @import "../../less/container.less";
  @import "../../less/formEle.less";
  @import "../../less/msg.less";

  @eight_height : 25rem;
  @top_distance : 15rem;

  #userBasicHolder__place {
    height: auto;
    background: lightblue;
  }

  #name {
    height: 15rem;
    background: green;
  }

  #img {
    height: 15rem;
    background: yellow;
  }

  #address {
    height: 10rem;
    background: red;
  }

  .avatar-uploader {
    margin: auto 0;
    padding-top: 1rem;
    line-height: 4rem;
    height: 4rem;
  }

  .avatar-uploader .el-upload {
    border: 1px dashed #d9d9d9;
    border-radius: 6px;
    cursor: pointer;
    position: relative;
    overflow: hidden;
  }

  .avatar-uploader .el-upload:hover {
    border-color: #409EFF;
  }

  .avatar-uploader-icon {
    font-size: 28px;
    color: #8c939d;
    width: 178px;
    height: 178px;
    line-height: 178px;
    text-align: center;
  }

  .avatar {
    width: 178px;
    height: 178px;
    display: block;
  }
</style>
