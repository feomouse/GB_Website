<template>
  <div>
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

</script>
<style lang="less" scoped>

</style>