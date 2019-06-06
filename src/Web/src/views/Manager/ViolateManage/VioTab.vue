<template>
  <div>
    <tabs :tabs="tabLabels" :tabLabelNow="tabLabels[0].link" activeIndex='0'>
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
import OkList from './OkList';

export default {
  components: {
    'tabs': Tabs,
    'vio': ViolateList,
    'ok': OkList
  },
  data() {
    return {
      tabLabels: [  {
          label : "黑名单",
          link : "violate"
        }, {
          label : "用户名单",
          link : "ok"
        }]
    }
  },
  beforeMount() {

  }
}
</script>