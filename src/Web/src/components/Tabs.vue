<template>
  <div class="auto_ten">
    <div class="holdTab_container" style="height: 3rem; margin: 2rem 0 0 0;">
      <a v-bind:class="[activeItemIndex == index? isSelected: '', tab_link]" v-for="(i, index) in tabsData" v-bind:key="i.label" @click="clickTab(i.link, index)">{{i.label}}</a>
    </div>
    <slot :name="tabLabelNowData"></slot>
  </div>  
</template>
<script>
export default {
  props: {
    tabs: Array,
    tabLabelNow: String,
    activeIndex: String
  },
  data() {
    return {
      tabsData: this.tabs,
      tabLabelNowData: this.tabLabelNow,
      activeItemIndex: this.activeIndex,
      isSelected: 'isSelected',
      tab_link: 'tab_link'
    }
  },
  methods: {
    clickTab(link, index) {
      this.tabLabelNowData = link;
      this.activeItemIndex = index;
    }
  }
}
</script>
<style lang="less" scoped>
  @import '../less/container';
  @import '../less/formEle';

  .isSelected {
    color: green;
    border-bottom: 3px solid green;
  }
</style>
