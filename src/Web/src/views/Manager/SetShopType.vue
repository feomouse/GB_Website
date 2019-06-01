<template>
  <div>
    <div style="margin-top: 2rem;">
      <el-button style="float: right;" type="primary" @click="addShopType">新建门店类型</el-button>
    </div>
    <div>
      <el-table
        :data="shopTypes"
        stripe
        style="width: 100%">
        <el-table-column
          prop="name"
          label="名称"
          width="180">
        </el-table-column>
        <el-table-column label="操作">
          <template slot-scope="scope">
            <el-button
              size="mini"
              @click="setShopType(scope.$index, scope.row)">编辑</el-button>
          </template>
        </el-table-column>
      </el-table>
    </div>
    <el-dialog title="新建门店类型" :visible.sync="addShopTypeDialogShow">
      <el-form>
        <el-form-item label="门店类型名称" label-width="100px">
          <el-input v-model="newShopType.TypeName" placeholder="请输入内容"></el-input>
        </el-form-item>
        <el-form-item label="门店类型照片" label-width="100px">
          <el-upload
            class="avatar-uploader"
            action=""
            :show-file-list="false"
            :before-upload="beforeShopTypeImgUpload">
            <img v-if="newShopType.Img" :src="newShopType.Img" class="avatar">
            <i v-else class="el-icon-plus avatar-uploader-icon"></i>
          </el-upload>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button @click="addShopTypeDialogShow = false">取 消</el-button>
        <el-button type="primary" @click="ensureAddShopType">确 定</el-button>
      </div>
    </el-dialog>
    <el-dialog title="编辑门店类型" :visible.sync="editShopTypeDialogShow">
      <el-form>
        <el-form-item label="门店类型名称" label-width="100px">
          <el-input v-model="editShopType.Name" placeholder="请输入内容"></el-input>
        </el-form-item>
        <el-form-item label="门店类型照片" label-width="100px">
          <el-upload
            class="avatar-uploader"
            action=""
            :show-file-list="false"
            :before-upload="beforeSetShopTypeImgUpload">
            <img v-if="editShopType.Img" :src="editShopType.Img" class="avatar">
            <i v-else class="el-icon-plus avatar-uploader-icon"></i>
          </el-upload>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button @click="editShopTypeDialogShow = false">取 消</el-button>
        <el-button type="primary" @click="ensureSetShopType">确 定</el-button>
      </div>
    </el-dialog>
  </div>
</template>
<script>
import * as imgUploadApi from '../../api/img'
import * as shopApi from '../../api/Shop'
import * as identityApi from '../../api/Identity'

export default {
  data() {
    return {
      shopTypes: [],
      newShopType: {},
      editShopType: {},
      addShopTypeDialogShow: false,
      editShopTypeDialogShow: false
    }
  },
  beforeMount() {
    shopApi.GetShopTypes().then(res => {
      if(res.status != 200) this.$message.error("获取门店类型失败");

      else this.shopTypes = res.body
    });
  },
  methods: {
    addShopType(){
      this.addShopTypeDialogShow = true
    },
    setShopType(i, v) {
      this.editShopTypeDialogShow = true
      this.editShopType = {
        PkId : v.pkId,
        Name : v.name,
        Img : v.img
      }
    },
    ensureAddShopType() {
      shopApi.AddShopTypes(this.newShopType).then(res => {
        if(res.status != 200) this.$message.error("新建门店类型失败");

        else {
          this.$message({
            type: 'success',
            message: '新建门店类型成功'
          })
          shopApi.GetShopTypes().then(res => {
            if(res.status != 200) this.$message.error("获取门店类型失败");

            else this.shopTypes = res.body
          });
          this.addShopTypeDialogShow = false
        }
      })
    },
    ensureSetShopType() {
      shopApi.SetShopType(this.editShopType).then(res => {
        if(res.status != 200) this.$message.error("编辑门店类型失败");

        else {
          this.$message({
            type: 'success',
            message: '编辑门店类型成功'
          })
          shopApi.GetShopTypes().then(res => {
            if(res.status != 200) this.$message.error("获取门店类型失败");

            else this.shopTypes = res.body
          });
          this.editShopTypeDialogShow = false
        }
      })
    },
    beforeShopTypeImgUpload(file) {
      const is = file.type === 'image/jpeg' || file.type === 'image/png';

      var form = new FormData();

      form.append("file", file);

      if (!is) {
        this.$message.error('上传Jpg!');
        return
      }

      imgUploadApi.ImgUpload(form).then(data => {
        if(data.status == 401) {
          identityApi.GetTokenByRefreshToken(this.$store.getters.getRefreshToken).then(res => {
            if(res.status == 400) this.$router.push('/Manager/SignIn');

            else {
              this.$store.dispatch('commitRefreshToken', res.body.refresh_token);
              this.$store.dispatch('commitToken', res.body.access_token);

              imgUploadApi.ImgUpload(form).then(data => {
                this.newShopType.Img = data.body;
              })
            }
          })
        }
        this.newShopType.Img = data.body;
      })

      return is;
    },
    beforeSetShopTypeImgUpload(file) {
      const is = file.type === 'image/jpeg' || file.type === 'image/png';

      var form = new FormData();

      form.append("file", file);

      if (!is) {
        this.$message.error('上传Jpg!');
        return
      }

      imgUploadApi.ImgUpload(form).then(data => {
        if(data.status == 401) {
          identityApi.GetTokenByRefreshToken(this.$store.getters.getRefreshToken).then(res => {
            if(res.status == 400) this.$router.push('/Manager/SignIn');

            else {
              this.$store.dispatch('commitRefreshToken', res.body.refresh_token);
              this.$store.dispatch('commitToken', res.body.access_token);

              imgUploadApi.ImgUpload(form).then(data => {
                this.editShopType.Img = data.body;
              })
            }
          })
        }
        this.editShopType.Img = data.body;
      })

      return is;
    }
  }
}
</script>