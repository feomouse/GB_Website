<template>
  <div class="auto_ten">
    <div class="holdTab_container" style="height: 3rem">
      <a class="tab_link" v-for="i in tabsData" v-bind:key="i.label" @click="clickTab(i.link)">{{i.label}}</a>
    </div>
    <slot :name="tabLabelNowData"></slot>
  </div>  
</template>
<script>
export default {
  props: {
    tabs: Array,
    tabLabelNow: String
  },
  data() {
    return {
      tabsData: this.tabs,
      tabLabelNowData: this.tabLabelNow
    }
  },
  methods: {
    clickTab(link) {
      this.tabLabelNowData = link;
      console.log(link);
    }
  }
}
</script>
<style lang="less">
  @import '../less/container';
  @import '../less/formEle';
</style>
