<template>
  <div class="auto_ten">
    <div class="auto_ten"></div>
    <el-table
      :data="violateList"
      stripe
      style="width: 100%">
      <el-table-column
        prop="name"
        label="名字"
        width="180">
      </el-table-column>
      <el-table-column
        :prop="roles[role]"
        label="角色"
        width="180">
      </el-table-column>
      <el-table-column
        fixed="right"
        label="操作"
        width="100">
        <template slot-scope="scope">
          <el-button @click="addWarn(scope.row)" type="text" size="small">警告</el-button>
          <el-dialog
            title="提示"
            :visible.sync="showWarnTip">
            <span>确认警告此违规用户?</span>
            <span slot="footer">
              <el-button type="success"></el-button>  
              <el-button type="error"></el-button>
            </span>  
          </el-dialog>
          <el-button @click="addInBlackMenu(scope.row)" type="text" size="small">加入黑名单</el-button>
          <el-dialog
            title="提示"
            :visible.sync="showBlackTip">
            <span>确认将此违规用户加入黑名单?</span>
            <span slot="footer">
              <el-button type="success"></el-button>  
              <el-button type="error"></el-button>
            </span>  
          </el-dialog>
        </template>
      </el-table-column>
    </el-table>
  </div>
</template>
<script>
export default {
  data() {
    return {
      violateList: [{
        "pkId": "",
        "name": "",
        "date": "",
        "detail": "",
        "role": 1,
        "isWarned": true,
        "isInBlackMenu": true,
        "managerId": ""
      }],
      roles: {
        1: "商户",
        2: "顾客"
      }
    }
  },
  methods: {
    addWarn(user) {
      
    },
    addInBlackMenu(user) {

    }
  }
}
</script>
<style lang="less" scoped>
  @import '../../../less/container';
</style>
