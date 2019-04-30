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
        prop="role"
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
      violateList: [],
      roles: {
        1: "顾客",
        2: "商户"
      }
    }
  },
  beforeMount() {
    managerApi.getViolateUsers(1).then(res => {
      if(res.status != 200) this.$message.error();

      else {
        this.violateList = res.body

        for(let i = 0; i < this.violateList.length; i++) {
          this.violateList[i].role = this.violateList[i].role == 1 ? "顾客" : "商户";
        }
      }
    })
  },
  methods: {
  }
}
</script>
<style lang="less" scoped>
  @import '../../../less/container';
</style>
