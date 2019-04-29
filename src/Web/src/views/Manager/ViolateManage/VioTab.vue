<template>
  <div>
    <tabs :tabs="tabLabels" :tabLabelNow="tabLabels[0].label" activeIndex='1'>
      <template v-slot:violate>
        <vio></vio>
      </template>
      <template v-slot:ok>
        <ok></ok>
      </template>
    </tabs>
  </div>
</template>
<script>
import Tabs from '../../../components/Tabs';
import ViolateList from './ViolateList';
import OkMerchantList from './OkMerchantList';

export default {
  components: {
    'tabs': Tabs,
    'vio': ViolateList,
    'ok': OkMerchantList
  },
  data() {
    return {
      tabLabels: [ {
          label : "商户名单",
          link : "ok"
        }, {
          label : "黑名单",
          link : "violate"
        }]
    }
  }
}
</script>