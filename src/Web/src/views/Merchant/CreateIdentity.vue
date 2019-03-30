<template>
  <div class="auto_ten">
    <div class="left-five">
      <label>身份证名: </label>
      <input class="rem15-rem2-input" v-model="identity.IdentityName" placeholder="请输入"/>
    </div>
    <div class="left-five">
      <label>身份证号: </label>
      <input class="rem15-rem2-input" v-model="identity.IdentityNum" placeholder="请输入"/>
    </div>
    <div class="left-three">
      <label>身份证正面照: </label>
      <el-upload
        class="avatar-uploader"
        action=""
        :show-file-list="false"
        :before-upload="beforeAvatarImgFUpload">
        <img v-if="identity.IdentityImgF" :src="identity.IdentityImgF" class="avatar">
        <i v-else class="el-icon-plus avatar-uploader-icon"></i>
      </el-upload>
    </div>
    <div class="left-three">
      <label>身份证反面照: </label>
      <el-upload
        class="avatar-uploader"
        action=""
        :show-file-list="false"
        :before-upload="beforeAvatarImgBUpload">
        <img v-if="identity.IdentityImgB" :src="identity.IdentityImgB" class="avatar">
        <i v-else class="el-icon-plus avatar-uploader-icon"></i>
      </el-upload>
    </div>
    <div class="left-three">
      <label>营业执照正面照: </label>
      <el-upload
        class="avatar-uploader"
        action=""
        :show-file-list="false"
        :before-upload="beforeAvatarLicenseImgUpload">
        <img v-if="identity.LicenseImg" :src="identity.LicenseImg" class="avatar">
        <i v-else class="el-icon-plus avatar-uploader-icon"></i>
      </el-upload>
    </div>
    <div class="left-five">
      <label>营业执照代码: </label>
      <input class="rem15-rem2-input" v-model="identity.LicenseCode" placeholder="请输入"/>
    </div>
    <div class="left-five">
      <label>营业执照名字: </label>
      <input class="rem15-rem2-input" v-model="identity.LicenseName" placeholder="请输入"/>
    </div>
    <div class="left-five">
      <label>营业执照法人: </label>
      <input class="rem15-rem2-input" v-model="identity.LicenseOwner" placeholder="请输入"/>
    </div>
    <div class="left-five">
      <label>营业执照起效日期: </label>
      <el-date-picker
        type="date"
        v-model="identity.AvailableStartTime"
        aria-placeholder="请选择日期">
      </el-date-picker>
    </div>
    <div class="left-five">
      <label>营业执照有效截至日期: </label>
      <el-date-picker
        type="date"
        v-model="identity.AvailableTime"
        aria-placeholder="请选择日期">
      </el-date-picker>
    </div>
    <div class="left-five">
      <label>经营者电话: </label>
      <input class="rem15-rem2-input" v-model="identity.Tel" placeholder="请输入" />
    </div>
    <div class="auto_ten">
      <button class="rem15-rem2-button" @click="sendIdentity">提交</button>
    </div>
  </div>
</template>
<script>
  import * as merchantApi from '../../api/Merchant';
  import * as imgUploadApi from '../../api/img';

  export default {
    data() {
      return {
        identity: {
          MerchantId: this.$store.getters.getMerchantId,
          IdentityName: "",
          IdentityNum: "",
          IdentityImgF: "",
          IdentityImgB: "",
          LicenseImg: "",
          LicenseCode: "",
          LicenseName: "",
          LicenseOwner: "",
          AvailableStartTime: "",
          AvailableTime: "",
          Tel: ""
        }
      }
    },
    methods: {
      beforeAvatarImgFUpload(file) {
        const is = file.type === 'image/jpeg' || file.type === 'image/png';

        var form = new FormData();

        form.append("file", file);

        if (!is) {
          this.$message.error('上传Jpg!');
          return
        }

        imgUploadApi.ImgUpload(form).then(data => {
          this.identity.IdentityImgF = data.body;
        })

        return is;
      },

      beforeAvatarImgBUpload(file) {
        const is = file.type === 'image/jpeg' || file.type === 'image/png';

        var form = new FormData();

        form.append("file", file);

        if (!is) {
          this.$message.error('上传Jpg!');
          return
        }

        imgUploadApi.ImgUpload(form).then(data => {
          this.identity.IdentityImgB = data.body;
        })

        return is;
      },

      beforeAvatarLicenseImgUpload(file) {
        const is = file.type === 'image/jpeg' || file.type === 'image/png';

        var form = new FormData();

        form.append("file", file);

        if (!is) {
          this.$message.error('上传Jpg!');
          return
        }

        imgUploadApi.ImgUpload(form).then(data => {
          this.identity.LicenseImg = data.body;
        })

        return is;
      },

      sendIdentity() {
        merchantApi.addIdentity(this.identity).then((res) => {
          if(res !== 200) this.$message.error("创建资质失败");
        });
      }
    }
  }
</script>
<style lang="less">
  @import '../../less/container';
  @import '../../less/ele-ui';
  @import '../../less/formEle';

  @left_three_height : 10rem;
  @left_five_height : 3rem;
</style>