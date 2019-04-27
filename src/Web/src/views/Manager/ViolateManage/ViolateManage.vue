<template>
  <div class="auto_ten">
    <my-tab :tabs="tabData" :tabLabelNow="tabData[0].link">
      <template>
        <violate-list v-slot:vlist></violate-list>
      </template>
      <template>
        <iswarned-list v-slot:warnedlist></iswarned-list>
      </template>
      <template>
        <isinblack-menu v-slot:blackmenu></isinblack-menu>
      </template>
    </my-tab>
  </div>
</template>

<script>
import MyTab from '../../../components/Tabs';
import ViolateList from './ViolateList';
import IsWarnedList from './IsWarnedList';
import IsInBlackMenu from './IsInBlackMenu';

export default {
  components: {
    'my-tab': MyTab,
    'violate-list': ViolateList,
    'iswarned-list': IsWarnedList,
    'isinblack-menu': IsInBlackMenu
  },
  data() {
    return {
      tabData: [{
          label : "违规人员",
          link : "vlist"
        }, {
          label : "已被警告人员",
          link : "warnedlist"
        }, {
          label : "黑名单人员",
          link : "blackmenu"
        }]
    }
  }
}
</script>

<style>
  @import '../../../less/container';
</style>
