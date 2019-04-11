<template>
   <div class="auto_eight">
     <div v-for="i of shopTypes" 
          v-bind:key="i.id" 
          class="left-two" 
          style="text-align: center; cursor:pointer;" 
          @click="selectShopTypes(i)">
       <img :src="i.img" style="border-radius: 50%; width: 4rem; height: 4rem;"/>
       <div>{{i.name}}</div>
     </div>
     <div v-for="(i, index) of shopList" v-bind:key="i.name" class="list_item" @click="showDetail(index)"
          style="text-align: left; padding-left: 3rem; vertical-align: bottom; cursor:pointer;">
       <img :src="i.img" style="width: 6rem; height: 5rem; display: inline-block; margin-right: 3rem;" />
       <div style="display: inline-block;">
         <p style="font-size: 1.5rem">{{i.name}}</p>
         <p>{{i.province + i.city + i.district + i.location}}</p>
       </div>
     </div>
   </div>
</template>
<script>
import * as shopApi from '../../../api/Shop';

export default {
  data() {
    return {
      shopTypes: [],
      shopList:[]
    }
  },
  beforeCreate() {
    shopApi.GetShopTypes().then(res => {
      if(res.status != 200) this.$message.error('获取门店类型错误');
      else {
        this.shopTypes = res.body;
        shopApi.GetShopBasicListByShopType(1).then(res => {
          if(res.status != 200) this.$message.error('获取门店错误')
          else this.shopList = res.body;
        })
      }
    })
  },
  methods: {
    showDetail(index) {
      this.$store.dispatch('commitSetSelectedName', this.shopList[index].name);
      this.$store.dispatch('commitSetShopId', this.shopList[index].pkId);
      this.$router.push('/ShopDetail');
    },
    selectShopTypes(type) {
      shopApi.GetShopBasicListByShopType(type.id).then(res => {
        if(res.status != 200) this.$message.error('获取门店错误')
        else this.shopList = res.body;
      })
    }
  }
}
</script>
<style lang="less" scoped>
  @import '../../../less/container';
  @import '../../../less/formEle';

  @list_item_height : 10rem;
  @left_two_height : 8rem;
</style>
