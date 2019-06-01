<template>
  <div class="leftMenu_container">
    <div class="logo_container">logo容器</div>
    <div class="menu-item1" 
         v-for="(i,index) in menuTranslateList" 
         v-bind:key="index" 
         @click="clickUp(i.label, index)">
         <svg-icon :iconClass="i.icon"></svg-icon>
         {{i.label}}
    </div>
  </div>
</template>
<script>
export default {
  name: "ManagerMenu",

  data() {
    return {
      control: {
      },
      menuTranslateList: [{
          label: "资质认证",
          link: "/Manager/IdentityList",
          icon: "shop",
          level: 1
        }, {
          label: "违规管理",
          link: "/Manager/ViolateManager",
          icon: "gb",
          level: 1
        }, {
          label: "门店类型",
          link: "/Manager/SetShopType",
          icon: "shopType",
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
<style lang="less">
  @import "../less/container";

  .menu-item1 {
    min-height: 4rem;
    width: 100%;
    border-top: 2px solid white;
    line-height: 4rem;
    color: white;
  }

  .menu-item2 {
    height: 2rem;
    width: 100%;
    background: wheat;
  }
</style>
