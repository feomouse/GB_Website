<template>
  <div class="auto_ten">
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
    </el-table>
  </div>
</template>
<script>
import * as managerApi from '../../../api/Manager';

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
  beforeMount() {
    managerApi.getViolateUsers(1).then(res => {
      if(res.status != 200) this.$message.error();

      else this.violateList = res.body
    })
  }
  methods: {
  }
}
</script>
<style lang="less" scoped>
  @import '../../../less/container';
</style>
