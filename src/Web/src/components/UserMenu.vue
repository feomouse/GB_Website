<template>
  <div class="leftMenu_container" style="background: #eaeded; width: 25%; padding-top: 3rem; ">
    <div class="menu-item1" 
         v-for="(i,index) in menuTranslateList" 
         v-bind:key="index" 
         @click="clickUp(i.label, index)">
         <svg-icon :iconClass="i.icon"></svg-icon>
         {{i.label}}    
         <i style="float:right; margin-right: 2rem;">></i>
    </div>
  </div>
</template>
<script>
export default {
  name: "MerchantMenu",

  data() {
    return {
      control: {
      },
      menuTranslateList: [{
          label: "我的信息",
          link: "/Customer/Basic",
          icon: "shop",
          level: 1
        }, {
          label: "我的订单",
          link: "/Customer/Order",
          icon: "gb",
          level: 1
        }]
    }
  },
  methods: {
    clickUp: function(label, index){
      let indexMove = index;

      if(this.menuTranslateList[indexMove].level === 1 && this.menuTranslateList[indexMove].link != "") {
        this.$router.push(this.menuTranslateList[indexMove].link);
      }

      else if( indexMove === this.menuTranslateList.length  || this.menuTranslateList[indexMove].level === 1) {
        for(let i in this.menu[label]) {
          this.menuTranslateList.splice(indexMove, 0, {
            "label": i,
            "link": this.menu[label][i],
            "level": 2
          })

          indexMove++;
        }
      }

      else if (this.menuTranslateList[indexMove].level === 2) {
        this.menuTranslateList.splice(indexMove, this.menu[label].length);
      }
    }
  },
  beforeCreate() {
  }
}
</script>
<style lang="less" scoped>
  @import "../less/container";

  .menu-item1 {
    min-height: 4rem;
    width: 100%;
    line-height: 4rem;
    color: black;
  }

  .menu-item2 {
    height: 2rem;
    width: 100%;
    background: wheat;
  }
</style>
