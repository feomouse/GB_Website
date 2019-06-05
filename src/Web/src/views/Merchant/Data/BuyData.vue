<template>
  <div style='text-align: center;'>
    <div style="margin: 0 auto;">
      <highcharts :options="chartOptions"></highcharts>
    </div>
  </div>  
</template>
<script>
import * as shopApi from '../../../api/Shop'

export default {
  beforeMount() {
    let date = new Date();
    shopApi.GetMonthSell(this.$store.getters.getMerchantCurrentShop.pkId, date.getFullYear()).then(res => {
      if(res.status != 200) this.$message.error('获取访问量错误');

      else {
        for(let i=0; i<res.body.length; i++) {
          this.chartOptions.series[0].data[res.body[i].month-1].y = res.body[i].num;
        }
      }
    })
  },
  data() {
    return {
      chartOptions: {
        title: '门店月购买量数量变化',
        chart: {
          type: 'line'
        },
        xAxis: {
          categories: ['一月', '二月', '三月', '四月', '五月', '六月',
                       '七月', '八月', '九月', '十月', '十一月', '十二月']
        },
        series: [{
          data: [{y:0},{y:0},{y:0},{y:0},{y:0},{y:0},{y:0},{y:0},{y:0},{y:0},{y:0},{y:0}],
          name: "购买数"
        }]
      }
    }
  }
}
</script>
<style lang="less" scoped>

</style>
