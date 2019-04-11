<template>
  <div class="leftMenu_container">
    <div class="logo_container">logo容器</div>
    <div class="menu-item1" v-for="(i,index) in menuTranslateList" v-bind:key="index" @click="clickUp(i.label, index)">{{i.label}}</div>
  </div>
</template>
<script>
export default {
  name: "MerchantMenu",

  data() {
    return {
      menu: {
        "门店编辑": "/Merchant/Operation/EditShop", 
        "团购服务": "/Merchant/Operation/GBProductOperations"
      },
      control: {
      },
      menuTranslateList: []
    }
  },
  methods: {
    getMenuData: function(){
      for(let i in this.menu) {
        let tempObj = {
          label: i,
          link: typeof(this.menu[i]) === "object"? "" : this.menu[i],
          level: 1
        };
        console.log(tempObj);
        this.menuTranslateList.push(tempObj);
      }
      console.log(this.menuTranslateList);
    },
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
  beforeMount() {
    this.getMenuData();
  }
}
</script>
<style lang="less">
  @import "../less/container";

  .menu-item1 {
    min-height: 2rem;
    width: 100%;
    background: palegreen;
  }

  .menu-item2 {
    height: 2rem;
    width: 100%;
    background: wheat;
  }
</style>
