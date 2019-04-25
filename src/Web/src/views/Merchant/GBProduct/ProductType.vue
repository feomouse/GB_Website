<template>
  <div class="auto_ten tabContent_container">
    <div style="width: 100%; height: 3rem;">
      <button class="rem5-rem2-button" style="float: left" @click="createTypeFormVisible = true">新建</button>
      <el-dialog title="新建产品类型" :visible.sync="createTypeFormVisible">
        <el-form :model="productTypeForm">
          <el-form-item label="产品类型名" label-width="6">
            <el-input v-model="productTypeForm.TypeName" auto-complete="off"></el-input>
          </el-form-item>
        </el-form>
        <div slot="footer" class="dialog-footer">
          <el-button @click="createTypeFormVisible = false">取 消</el-button>
          <el-button type="primary" @click="createProductType()">确 定</el-button>
        </div>
      </el-dialog>
    </div>
    <div v-for="i in productTypes" v-bind:key="i.name" class="list_item">
      <div style="font-size: 2rem; display:inline-block;">产品类别: {{i.name}}</div>
      <div style="margin-left: 40rem; display:inline-block;">
        <button class="rem5-rem2-button" @click="deleteProductType(i.pkId)">删除</button>
      </div>
    </div>
  </div>
</template>
<script>
import * as merchantApi from '../../../api/Merchant';
import * as identityApi from '../../../api/Identity';

export default {
  data() {
    return {
      productTypes: [],
      createTypeFormVisible: false,
      productTypeForm: {
        ShopId: this.$store.getters.getShopId,
        TypeName: ""
      }
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
    })
  },
  methods: {
    createProductType() {
      merchantApi.createProductType(this.productTypeForm).then(res => {
        if(res.status != 201) this.$message.error();
        else {
          this.$message({message: '创建成功', type: 'success'});
          merchantApi.getProductTypeByShopName(this.$store.getters.getShopName).then(res => {
            if(res.status == 400) this.$message.error();
            else {
              this.productTypes = [];
              for(let i of res.body) {
                this.productTypes.push({
                  pkId: i.pkId,
                  name: i.typeName
                })
              }
            }
          })
        }
        this.createTypeFormVisible = false;
      })
    },
    deleteProductType(productTypeId) {
      merchantApi.deleteProductType(productTypeId).then(res => {
        if(res.status != 204) this.$message.error();
        else {
          this.$message({type: 'success', message: '成功删除'});
          merchantApi.getProductTypeByShopName(this.$store.getters.getShopName).then(res => {
            if(res.status == 400) this.$message.error();
            else {
              this.productTypes = [];
              for(let i of res.body) {
                this.productTypes.push({
                  pkId: i.pkId,
                  name: i.typeName
                })
              }
            }
          })
        }
      })
    }
  }
}
</script>
<style lang="less" scoped>
  @import '../../../less/container';
  @import '../../../less/formEle';
</style>
