<template>
  <div class="auto_ten">
    <my-banner></my-banner>
    <div class="auto_eight">
      <tabs :tabs="tabsData" :tabLabelNow="selectedLabel">
        <order-list type="待支付" slot="待支付"></order-list>
        <order-list type="待使用" slot="待使用"></order-list>
        <order-list type="已完成" slot="已完成"></order-list>
        <order-list type="已评价" slot="已评价"></order-list>
      </tabs>
    </div>   
  </div>
</template>
<script>
import Tab from '../../../components/Tabs';
import OrderList from './OrdersList';
import MyBanner from '../../../components/Banner';
import * as orderApi from '../../../api/Order';

export default {
  components: {
    "tabs": Tab,
    "order-list": OrderList,
    "my-banner": MyBanner
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
