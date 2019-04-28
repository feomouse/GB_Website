<template>
  <mytab :tabLabelNow="tabLabels[0].link" :tabs="tabLabels" activeIndex='0'>
    <template v-slot:edit>
      <edit-gbproduct></edit-gbproduct>
    </template>
    <template v-slot:list>
      <gbproduct-list></gbproduct-list>
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
  import CommentGBProduct from './CommentGBProduct';
  import * as merchantApi from '../../../api/Merchant';
  import * as identityApi from '../../../api/Identity';

  export default {
    components : {
      'mytab': Tabs,
      'edit-gbproduct': EditGBProduct,
      'gbproduct-list': GBProductList,
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
        }/* , {
          label : "交易确认",
          link : "pay"
        } */, {
          label : "评论",
          link : "comment"
        }]
      }
    },
    beforeMount() {

    },
  }
</script>
<style lang="less">

</style>


