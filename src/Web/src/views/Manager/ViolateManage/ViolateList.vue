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
    <el-pagination
      background
      layout="prev, pager, next"
      page-size=10
      :total="vioNum"
      @current-change="changeList">
    </el-pagination>
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
      },
      vioNum: 0
    }
  },
  beforeMount() {
    managerApi.getViolateUsers(1).then(res => {
      if(res.status != 200) this.$message.error();

      else {
        this.violateList = res.body

        managerApi.getVioNum().then(res => {
          if(res.status != 200) this.$message.error('获取黑名单数量有误');

          else this.vioNum = res.body;
        })

        for(let i = 0; i < this.violateList.length; i++) {
          this.violateList[i].role = this.violateList[i].role == 1 ? "顾客" : "商户";
        }
      }
    })
  },
  methods: {
    changeList(curPage) {
      managerApi.getViolateUsers(curPage).then(res => {
        if(res.status != 200) this.$message.error();

        else {
          this.violateList = res.body

          for(let i = 0; i < this.violateList.length; i++) {
            this.violateList[i].role = this.violateList[i].role == 1 ? "顾客" : "商户";
          }
        }
      })
    }
  }
}
</script>
<style lang="less" scoped>
  @import '../../../less/container';
</style>
