<template>
  <div class="auto_ten" style="background: #e4eee1;">
    <div class="auto_six" style="background: #f1fcee;">
      <div style="height: 10rem; border-bottom: 1px solid gray; 
                  font-size: 3rem; font-weight: bold; text-align: left; color: gray; padding: 3rem  0 0 3rem; 
                  margin-bottom: 3rem;">资质信息</div>
      <el-form label-width="100px" inline="true" style="text-align:left;padding-left: 3rem;">
        <el-form-item label="身份证名" style="width: 100%;">
          <el-input v-model="identity.IdentityName" placeholder="请输入"></el-input>
        </el-form-item>
        <el-form-item label="身份证号" style="width: 100%;">
          <el-input v-model="identity.IdentityNum" placeholder="请输入"></el-input>
        </el-form-item>
        <el-form-item label="身份证正面照" style="width: 30%;">
          <el-upload
            class="avatar-uploader"
            action=""
            :show-file-list="false"
            :before-upload="beforeAvatarImgFUpload">
            <img v-if="identity.IdentityImgF" :src="identity.IdentityImgF" class="avatar">
            <i v-else class="el-icon-plus avatar-uploader-icon"></i>
          </el-upload>
        </el-form-item>
        <el-form-item label="身份证反面照:" style="width: 30%;">
          <el-upload
            class="avatar-uploader"
            action=""
            :show-file-list="false"
            :before-upload="beforeAvatarImgBUpload">
            <img v-if="identity.IdentityImgB" :src="identity.IdentityImgB" class="avatar">
            <i v-else class="el-icon-plus avatar-uploader-icon"></i>
          </el-upload>
        </el-form-item>
        <el-form-item label="营业执照正面照:" style="width: 30%;">
          <el-upload
            class="avatar-uploader"
            action=""
            :show-file-list="false"
            :before-upload="beforeAvatarLicenseImgUpload">
            <img v-if="identity.LicenseImg" :src="identity.LicenseImg" class="avatar">
            <i v-else class="el-icon-plus avatar-uploader-icon"></i>
          </el-upload>
        </el-form-item>
        <el-form-item label="营业执照代码:" style="width: 100%;">
          <el-input v-model="identity.LicenseCode" placeholder="请输入"></el-input>
        </el-form-item>
        <el-form-item label="营业执照名字:" style="width: 100%;">
          <el-input v-model="identity.LicenseName" placeholder="请输入"></el-input>
        </el-form-item>
        <el-form-item label="营业执照法人:" style="width: 100%;">
          <el-input v-model="identity.LicenseOwner" placeholder="请输入"></el-input>
        </el-form-item>
        <el-form-item label="营业执照起效日期:" style="width: 100%;">
          <el-date-picker
            type="date"
            v-model="identity.AvailableStartTime"
            aria-placeholder="请选择日期">
          </el-date-picker>
        </el-form-item>
        <el-form-item label="营业执照有效截至日期:" style="width: 100%;">
          <el-date-picker
            type="date"
            v-model="identity.AvailableTime"
            aria-placeholder="请选择日期">
          </el-date-picker>
        </el-form-item>
        <el-form-item label="经营者电话:" style="width: 100%;">
          <el-input v-model="identity.Tel" placeholder="请输入"></el-input>
        </el-form-item>
      </el-form>
      <div class="auto_ten">
        <el-button type="primary" @click="sendIdentity">提交</el-button>
      </div>
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

          else {
            merchantApi.checkIdentity({
              "MerchantId": this.$store.getters.getMerchantId,
	            "CheckResult": true
            }).then(res => {
              if(res.status != 200) this.$message.error();

              else this.$router.push('/Merchant/Operation');
            })
          }
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