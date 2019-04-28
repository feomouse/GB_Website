<template>
  <div>
    <tabs :tabs="tabsData" :tabLabelNow="selectedLabel" activeIndex="0">
      <template v-slot:待支付>
        <order-list type="待支付"></order-list>
      </template>
      <template v-slot:待使用>
        <order-list type="待使用"></order-list>
      </template>
      <template v-slot:已完成>
        <order-list type="已完成"></order-list>
      </template>
      <template v-slot:已评价>
        <order-list type="已评价"></order-list>
      </template>
    </tabs>
  </div>
</template>
<script>
import Tab from '../../../components/Tabs';
import OrderList from './OrdersList';
import * as orderApi from '../../../api/Order';

export default {
  components: {
    "tabs": Tab,
    "order-list": OrderList
  },
  data() {
    return {
      selectedLabel: "待支付",
      tabsData: [{
        label: "待支付",
        link: "待支付"
      }, {
        label: "待使用",
        link: "待使用"
      }, {
        label: "已完成",
        link: "已完成"
      }, {
        label: "已评价",
        link: "已评价"
      }]
    }
  }
}
</script>
<style lang="less" scoped>
  @import '../../../less/container';
</style>
