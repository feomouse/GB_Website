<template>
  <mytab :tabLabelNow="tabLabels[0].link" :tabs="tabLabels">
    <template v-slot:edit>
      <edit-gbproduct></edit-gbproduct>
    </template>
    <template v-slot:list>
      <gbproduct-list></gbproduct-list>
    </template>
    <template v-slot:types>
      <product-type></product-type>
    </template>
    <template v-slot:pay>
      <gb-pay></gb-pay>
    </template>
    <template v-slot:comment>
      <comment-gb></comment-gb>
    </template>
  </mytab>
</template>
<script>
  import Tabs from '../../../components/Tabs';
  import EditGBProduct from './EditGBProduct';
  import GBProductList from './GBProductList';
  import ProductType from './ProductType';
  import GBPayOperation from './GBPayOperation';
  import CommentGBProduct from './CommentGBProduct';

  export default {
    components : {
      'mytab': Tabs,
      'edit-gbproduct': EditGBProduct,
      'gbproduct-list': GBProductList,
      'product-type': ProductType,
      'gb-pay': GBPayOperation,
      'comment-gb': CommentGBProduct
    },
    data() {
      return {
        tabLabels: [/* {
          label : "产品类型",
          link : "types"
        }, */ {
          label : "团购产品",
          link : "list"
        }, {
          label : "交易确认",
          link : "pay"
        }, {
          label : "评论",
          link : "comment"
        }]
      }
    }
  }
</script>
<style lang="less">

</style>


