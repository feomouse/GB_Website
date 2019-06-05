<template>
  <div style='text-align: center;'>
    <my-tab :tabs="tabData" :tabLabelNow="tabDataNow" :activeIndex="activeIndex">
      <template slot=read>
        <visit-data></visit-data>
      </template>
      <template slot=sell>
        <buy-data></buy-data>
      </template>
      <template slot=good>
        <goodcomment-data></goodcomment-data>
      </template>
      <template slot=bad>
        <badcomment-data></badcomment-data>
      </template>
    </my-tab>
  </div>  
</template>
<script>
import MyTab from '../../../components/Tabs';
import VisitData from './VisitData';
import GoodCommentData from './GoodCommentData';
import BuyData from './BuyData';
import BadCommentData from './BadCommentData';

export default {
  components: {
    'my-tab':MyTab,
    'visit-data': VisitData,
    'buy-data': BuyData,
    'goodcomment-data': GoodCommentData,
    'badcomment-data': BadCommentData
  },
  data() {
    return {
      tabData: [{
        label: "阅读门店数",
        link: "read"
      }, {
        label: "月销量",
        link: "sell"
      }, {
        label: "好评量",
        link: "good"
      }, {
        label: "差评量",
        link: "bad"
      }],
      tabDataNow: "阅读门店数",
      activeIndex: "0"
    }
  }
}
</script>
<style lang="less" scoped>

</style>
