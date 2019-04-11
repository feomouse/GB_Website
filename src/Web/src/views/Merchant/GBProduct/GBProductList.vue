<template>
  <div class="auto_ten tabContent_container">
    <div style="width: 100%; height: 3rem;">
      <button class="rem5-rem2-button" style="float: left" @click="createGBDialogVisible = true">新建</button>
      <el-dialog title="新建团购产品" :visible.sync="createGBDialogVisible">
        <el-form :model="newGBProduct">
          <el-form-item label="产品名称: " label-width="5rem">
            <el-input v-model="newGBProduct.productName" auto-complete="off" style="width: 10rem"></el-input>
          </el-form-item>
          <el-form-item label="产品原价" label-width="5rem">
            <el-input v-model="newGBProduct.orinPrice" auto-complete="off" style="width: 10rem"></el-input>
          </el-form-item>
          <el-form-item label="产品现价" label-width="5rem">
            <el-input v-model="newGBProduct.price" auto-complete="off" style="width: 10rem"></el-input>
          </el-form-item>
          <el-form-item label="产品规格" label-width="5rem">
            <el-input v-model="newGBProduct.quantity" auto-complete="off" style="width: 10rem"></el-input>
          </el-form-item>
          <el-form-item label="开始时间" label-width="5rem">
            <el-date-picker
              v-model="newGBProduct.vailSDate"
              type="datetime"
              placeholder="选择日期时间">
            </el-date-picker>
          </el-form-item>
          <el-form-item label="截止时间" label-width="5rem">
            <el-date-picker
              v-model="newGBProduct.vailEDate"
              type="datetime"
              placeholder="选择日期时间">
            </el-date-picker>
          </el-form-item>
          <el-form-item label="有效时间" label-width="5rem">
            <el-input v-model="newGBProduct.vailTime" auto-complete="off" style="width: 10rem"></el-input>
          </el-form-item>
          <el-form-item label="备注" label-width="5rem">
            <el-input v-model="newGBProduct.remark" type="textarea" autosize auto-complete="off"></el-input>
          </el-form-item>
          <el-form-item label="是否显示" label-width="5rem">
            <el-radio v-model="newGBProduct.isDisplay" label="true">显示</el-radio>
            <el-radio v-model="newGBProduct.isDisplay" label="false">不显示</el-radio>
          </el-form-item>
          <el-form-item label="类型" label-width="5rem">
            <el-select v-model="newGBProduct.productTypeId" placeholder="请选择">
              <el-option
                v-for="item in productTypes"
                :key="item.name"
                :label="item.name"
                :value="item.pkId">
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="图片" label-width="5rem">
            <el-upload
              class="avatar-uploader"
              action=""
              :show-file-list="false"
              :before-upload="beforeCreateAvatarUpload">
              <img v-if="newGBProduct.img" :src="newGBProduct.img" class="avatar">
              <i v-else class="el-icon-plus avatar-uploader-icon"></i>
            </el-upload>
          </el-form-item>
        </el-form>
        <div slot="footer">
          <el-button @click="createGBDialogVisible = false">取 消</el-button>
          <el-button type="primary" @click="createGBProduct">确 定</el-button>
        </div>
      </el-dialog>
    </div>
    <div v-for="(i,index) in gbProducts" v-bind:key="i.productName" class="list_item">
      <div style="display:inline-block; line-height: 4rem;">
        <img :src="i.img" style="display: inline-block; width: 4rem; height: 3rem;"/>
        <div style="display:inline-block; margin: 0 0 0 2rem; height: 3rem; font-size: 2rem;">
          <span>{{i.productName}}</span>
        </div>
      </div>
      <div style="margin-left: 45rem; display:inline-block; line-height: 4rem; ">
        <button class="rem5-rem2-button" style="display:inline-block;" @click="showUpdateGBProduct(index)">编辑</button>
        <el-dialog title="产品详情" :visible.sync="detailGBDialogVisible">
          <el-form :model="editGBProduct">
            <el-form-item label="产品名称: " label-width="5rem">
              <el-input v-model="editGBProduct.productName" auto-complete="off" style="width: 10rem"></el-input>
            </el-form-item>
            <el-form-item label="产品原价" label-width="5rem">
              <el-input v-model="editGBProduct.orinPrice" auto-complete="off" style="width: 10rem"></el-input>
            </el-form-item>
            <el-form-item label="产品现价" label-width="5rem">
              <el-input v-model="editGBProduct.price" auto-complete="off" style="width: 10rem"></el-input>
            </el-form-item>
            <el-form-item label="产品规格" label-width="5rem">
              <el-input v-model="editGBProduct.quantity" auto-complete="off" style="width: 10rem"></el-input>
            </el-form-item>
            <el-form-item label="开始时间" label-width="5rem">
              <el-date-picker
                v-model="editGBProduct.vailSDate"
                type="datetime"
                placeholder="选择日期时间">
              </el-date-picker>
            </el-form-item>
            <el-form-item label="截止时间" label-width="5rem">
              <el-date-picker
                v-model="editGBProduct.vailEDate"
                type="datetime"
                placeholder="选择日期时间">
              </el-date-picker>
            </el-form-item>
            <el-form-item label="有效时间" label-width="5rem">
              <el-input v-model="editGBProduct.vailTime" auto-complete="off" style="width: 10rem"></el-input>
            </el-form-item>
            <el-form-item label="备注" label-width="5rem">
              <el-input v-model="editGBProduct.remark" type="textarea" autosize auto-complete="off"></el-input>
            </el-form-item>
            <el-form-item label="是否显示" label-width="5rem">
              <el-radio v-model="editGBProduct.isDisplay" label="true">显示</el-radio>
              <el-radio v-model="editGBProduct.isDisplay" label="false">不显示</el-radio>
            </el-form-item>
            <el-form-item label="类型" label-width="5rem">
              <el-select v-model="editGBProduct.productTypeId" placeholder="请选择">
                <el-option
                  v-for="item in productTypes"
                  :key="item.name"
                  :label="item.name"
                  :value="item.pkId">
                </el-option>
              </el-select>
            </el-form-item>
            <el-form-item label="图片" label-width="5rem">
              <el-upload
                class="avatar-uploader"
                action=""
                :show-file-list="false"
                :before-upload="beforeUpdateAvatarUpload">
                <img v-if="editGBProduct.img" :src="editGBProduct.img" class="avatar">
                <i v-else class="el-icon-plus avatar-uploader-icon"></i>
              </el-upload>
            </el-form-item>
          </el-form>
          <div slot="footer">
            <el-button @click="detailGBDialogVisible = false">取 消</el-button>
            <el-button type="primary" @click="updateGBProduct">确 定</el-button>
          </div>
        </el-dialog>
        <button class="rem5-rem2-button" 
                style="display:inline-block;" 
                @click="showDeleteGBProduct(index)">删除</button>
        <el-dialog label="删除" :visible.sync="deleteDialogVisible">
          <div>确认删除?</div>
          <div slot="footer">
            <el-button @click="deleteDialogVisible = false">取 消</el-button>
            <el-button type="primary" @click="deleteGBProduct()">确 定</el-button>
          </div>
        </el-dialog>
      </div>
    </div>
  </div>
</template>
<script>
import * as merchantApi from '../../../api/Merchant';
import * as imgApi from '../../../api/img';

export default {
  data () {
    return {
      gbProducts: [],
      newGBProduct: {
        "pkId": "",
        "productName": "",
        "orinPrice": 0,
        "price": 0,
        "quantity": "",
        "vailSDate": "",
        "vailEDate": "",
        "vailTime": "",
        "img": "",
        "remark": "",
        "isDisplay": null,
        "praiseNum": 0,
        "mSellNum": 0,
        "productTypeId": ""
      },
      editGBProduct: {
        "pkId": "",
        "productName": "",
        "orinPrice": 0,
        "price": 0,
        "quantity": "",
        "vailSDate": "",
        "vailEDate": "",
        "vailTime": "",
        "img": "",
        "remark": "",
        "isDisplay": null,
        "praiseNum": 0,
        "mSellNum": 0,
        "productTypeId": ""
      },
      deleteGBProductName: "",
      productTypes:[],
      createGBDialogVisible: false,
      detailGBDialogVisible: false,
      deleteDialogVisible: false
    }
  },
  beforeCreate() {
    merchantApi.getProductTypeByShopName(this.$store.getters.getShopName).then(res => {
      if(res.status == 400) this.$message.error();
      else {
        for(let i of res.body) {
          this.productTypes.push({
            pkId: i.pkId,
            name: i.typeName
          })
        }
      }
      merchantApi.getGBProductByShopName(this.$store.getters.getShopName).then(res => {
        if(res.status == 400) this.$message.error('获取团购产品失败');
        else this.gbProducts = res.body;
      })
    })
  },
  methods: {
    createGBProduct() {
      merchantApi.addGBProduct(this.newGBProduct).then(res => {
        if(res.status != 201) this.$message.error();
        else {
          this.$message({type: 'success', message: '创建团购产品成功'});
          this.createGBDialogVisible = false;
          merchantApi.getGBProductByShopName(this.$store.getters.getShopName).then(res => {
            if(res.status != 200) this.$message.error();
            else {
              this.gbProducts = res.body;
            }
          })
        } 
      })
    },
    showUpdateGBProduct(index) {
      this.editGBProduct = this.gbProducts[index];
      for(let i of this.productTypes) {
        if(i.pkId == this.editGBProduct.productTypeId) this.editGBProduct.productTypeId = i.name;
      }
      this.detailGBDialogVisible = true;
    },
    updateGBProduct() {
      for(let i of this.productTypes) {
        if(i.name == this.editGBProduct.productTypeId) this.editGBProduct.productTypeId = i.pkId;
      }
      var newEditGBProduct = {
        "GBProductId" : this.editGBProduct.pkId,
        "ProductTypeId" : this.editGBProduct.productTypeId,
        "ProductName" : this.editGBProduct.productName,
        "OrinPrice" : this.editGBProduct.orinPrice,
        "Price" : this.editGBProduct.price,
        "Quantity" : this.editGBProduct.quantity,
        "VailSDate" : this.editGBProduct.vailSDate,
        "VailEDate" : this.editGBProduct.vailEDate,
        "VailTime" : this.editGBProduct.vailTime,
        "Img" : this.editGBProduct.img,
        "Remark" : this.editGBProduct.remark
      }
      merchantApi.updateGBProduct(newEditGBProduct).then(res => {
        if(res.status != 200) this.$message.error('更新失败');
        else {
          this.$message({type: 'success', message: '更新成功'});
          this.detailGBDialogVisible = false;
        }
      })
    },
    showDeleteGBProduct(index) {
      this.deleteGBProductName = this.gbProducts[index].productName;
      this.deleteDialogVisible = true;
    },
    deleteGBProduct() {
       merchantApi.deleteGBProduct(this.deleteGBProductName).then(res => {
        if(res.status != 204) this.$message.error('删除失败');
        else {
          this.$message({type: 'success', message: '删除成功'});
          this.deleteDialogVisible = false;
          merchantApi.getGBProductByShopName(this.$store.getters.getShopName).then(res => {
            if(res.status != 200) this.$message.error('获取产品失败');
            else this.gbProducts = res.body;
          })
        }
      })
    },
    beforeCreateAvatarUpload(file) {
      var is = file.type == 'image/jpeg' || file.type == 'image/png';
    
      var form = new FormData();

      form.append("file", file);

      if(!is) {
        this.$message.error('图片格式错误');
        return;
      }
      
      imgApi.ImgUpload(form).then(res => {
        if(res.status != 200) this.$message.error('上传错误');
        else this.newGBProduct.img = res.body;
      })
    },
    beforeUpdateAvatarUpload(file) {
      var is = file.type == 'image/jpeg' || file.type == 'image/png';
    
      var form = new FormData();

      form.append("file", file);

      if(!is) {
        this.$message.error('图片格式错误');
        return;
      }
      
      imgApi.ImgUpload(form).then(res => {
        if(res.status != 200) this.$message.error('上传错误');
        else this.editGBProduct.img = res.body;
      })
    }
  }
}
</script>
<style lang="less" scoped>
  @import '../../../less/container';
  @import '../../../less/formEle';
  @import '../../../less/ele-ui';
</style>
