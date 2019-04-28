<template>
  <div class="auto_ten" style="background: #f8f9f9;">
    <myBanner></myBanner>
    <div class="auto_eight" style="text-align: left; box-shadow: 3px 3px 3px lightgray; padding: 2rem 0 2rem 2rem;">
      <div style="float: left">
        <h1>{{shopDetail.name}}</h1>
        <div>
          <p>门店地址: {{shopDetail.province + shopDetail.city + shopDetail.district + shopDetail.location}}</p>
          <p>联系电话: {{shopDetail.tel}}</p>
        </div>
      </div>
      <div style="float: right;">
        <img :src="shopDetail.pic" style="width: 24rem; height: 12rem; margin-right: 2rem;"/>
      </div>
      <div style="clear: both;"></div>
    </div>
    <div class="auto_eight" style="margin-top: 3rem;">
      <div class="shop-header">团购产品</div>
      <div v-for="(i, index) of gbProductList" 
           v-bind:key="i.productName" 
           class="list_item" 
           style="text-align:left; cursor: pointer;"
           @click="showGBProductDetail(index)">
        <img :src="i.img" style="width: 5rem; height: 5rem; display: inline-block; margin: 1rem 5rem 0 1rem;" />
        <div style="display: inline-block; margin-right: 5rem;">
          <div style="height:2rem;">{{i.productName}}</div>
          <div>价格: <h1 style="display: inline;">{{i.price}}</h1></div>
        </div>
        <div style="display: inline-block; margin: 0 5rem 1rem 0;">
          <p>规格: {{i.quantity}}</p>
        </div>
        <div style="display: inline-block; margin: 0 5rem 1rem 0;">
          <p>点赞数: {{i.praiseNum}}</p>
          <p>月销量: {{i.mSellNum}}</p>
        </div>
      </div>
      <el-dialog title="团购产品详细信息" :visible.sync="gbProductDialogVisible" style="text-align: left;">
        <div>
          <img :src="selectedGBProduct.img" style="width: 8rem; height: 8rem; display: inline-block; margin-right: 5rem; "/>
          <span style="margin-right: 2rem;">选择数量:</span><el-input-number v-model="gbProductOrder.Number" :min="1" :max="50" label="描述文字" style="display: inline-block;"></el-input-number>
        </div>
        <div>
          <p style="display: inline-block; width: 10rem;">名称: {{selectedGBProduct.productName}}</p>
          <p style="display: inline-block; width: 10rem;">分类: {{selectedGBProductType}}</p>
        </div>
        <div>
          <p style="display: inline-block; width: 10rem;">原价: {{selectedGBProduct.orinPrice}}</p>
          <p style="display: inline-block; width: 10rem;">现价: {{selectedGBProduct.price}}</p>
        </div>
        <p>规格: {{selectedGBProduct.quantity}}</p>
        <div>
          <p style="display: inline-block; width: 40rem;">活动时间段: {{selectedGBProduct.vailSDate}}至{{selectedGBProduct.vailEDate}}</p>
          <p style="display: inline-block; width: 10rem;">有效时长: {{selectedGBProduct.vailTime}}</p>
        </div>
        <p>备注: {{selectedGBProduct.remark}}</p>
        <div>
          <p style="display: inline-block; width: 10rem;">点赞数: {{selectedGBProduct.praiseNum}}</p>
          <p style="display: inline-block; width: 10rem;">月销量: {{selectedGBProduct.mSellNum}}</p>      
        </div>
        <div slot="footer">
          <el-button @click="gbProductDialogVisible = false">取消</el-button>
          <el-button type="primary" @click="createGBOrder">创建订单</el-button>
        </div>
      </el-dialog>
      
    </div>
    <div class="auto_eight" style="margin-top: 3rem;">
      <div class="shop-header">用户点评</div>
      <div v-for="i of commentList"
           v-bind:key="i.pkId"
           style="text-align: left; border-bottom: 1px solid lightgray; padding: 1rem 3rem 0 3rem; background: #f2f3f4;">
          <div><p style="display: inline;">{{i.userName}}</p></div>
          <div style="margin-top: 1rem;">
            <i v-for="i in i.stars" :key="i" class="el-icon-star-on">
            </i>  
          </div>
          <div style="text-align: right;">日期: {{i.date}}</div>
          <div style="margin: 3rem 0 3rem 0;">{{i.comment}}</div>
          <div style="color: green; margin-bottom: 2rem;">商家回复: {{replyList[i.pkId].reply}}</div>
<!--           <div>
            <img :src="i.img" />
          </div> -->
      </div>
    </div>
    <!--<div @click="test" style="cursor: pointer;">测试</div>-->
  </div>
</template>
<script>
import * as shopApi from '../../../api/Shop';
import * as merchantApi from '../../../api/Merchant';
import * as orderApi from '../../../api/Order';
import * as commentApi from '../../../api/Evaluate';
import * as identityApi from '../../../api/Identity';
import myBanner from '../../../components/Banner';
import cityData from '../../../data';

export default {
  components: {
    'myBanner': myBanner
  },
  data() {
    return {
      shopDetail: {},
      gbProductList: [],
      productTypes: [],
      selectedGBProduct: {},
      gbProductOrder: {
        "GroupProductId": "aa2bdc64-373a-409d-5838-08d6b9a3b542",
        "Number": 1,
        "TotalCost": 23,
        "IsPayed": false,
        "Evaluate": "aa2bdc64-373a-409d-5838-08d6b9a3b542",
        "IsUsed": false,
        "OrderCode": "aa2bdc64-373a-409d-5838-08d6b9a3b542",
        "PayWay": 1,
        "CpkId": "aa2bdc64-373a-409d-5838-08d6b9a3b542",
        "SpkId": "aa2bdc64-373a-409d-5838-08d6b9a3b542",
        "Time": "2019/01/03 00:00:00"
      },
      gbProductDialogVisible: false,
      commentList: [],
      replyList: {},
      'cityData': cityData
    }
  },
  beforeMount() {
    shopApi.GetShopInfoByShopNameAndCity(this.$store.getters.getShopSelectedName, 
                                         this.cityData['86'][this.$store.getters.getSelectedProvince], 
                                         this.cityData[this.$store.getters.getSelectedProvince][this.$store.getters.getSelectedCity]).then(res => {
      if(res.status == 401) {
        identityApi.GetTokenByRefreshToken(this.$store.getters.getRefreshToken).then(res => {
          if(res.status == 400) this.$router.push('/Customer/SignIn');

          else {
            this.$store.dispatch('commitRefreshToken', res.body.refresh_token);
            this.$store.dispatch('commitToken', res.body.access_token);

            shopApi.GetShopInfoByShopNameAndCity(this.$store.getters.getShopSelectedName, 
                                         this.cityData['86'][this.$store.getters.getSelectedProvince], 
                                         this.cityData[this.$store.getters.getSelectedProvince][this.$store.getters.getSelectedCity]).then(res => {
              if(res.status != 200) this.$message.error();
              else this.shopDetail = res.body;
            })
          }
        })
      }
      else if(res.status != 200) this.$message.error();
      else this.shopDetail = res.body;

      merchantApi.getGBProductByShopName(this.$store.getters.getShopSelectedName,
                                         this.cityData['86'][this.$store.getters.getSelectedProvince], 
                                         this.cityData[this.$store.getters.getSelectedProvince][this.$store.getters.getSelectedCity]).then(res => {
        if(res.status != 200) this.$message.error();
        else this.gbProductList = res.body;

        merchantApi.getProductTypeByShopName(this.$store.getters.getShopSelectedName,
                                         this.cityData['86'][this.$store.getters.getSelectedProvince], 
                                         this.cityData[this.$store.getters.getSelectedProvince][this.$store.getters.getSelectedCity]).then(res => {
          if(res.status != 200) this.$message.error();
          else this.productTypes = res.body;
        })
      })
    }),
    commentApi.getUserCommentsByShopId(this.$store.getters.getShopId).then(res => {
      if(res.status == 401) {
        identityApi.GetTokenByRefreshToken(this.$store.getters.getRefreshToken).then(res => {
          if(res.status == 400) this.$router.push('/Customer/SignIn');

          else {
            this.$store.dispatch('commitRefreshToken', res.body.refresh_token);
            this.$store.dispatch('commitToken', res.body.access_token);

            commentApi.getUserCommentsByShopId(this.$store.getters.getShopId).then(res => {
              if(res.status != 200) this.$message.error();

              else {
                this.commentList = res.body;
                for(let i = 0; i < this.commentList.length; i++) {
                  if(this.commentList[i].isReply) {
                    commentApi.getReplyCommentByCommentId(this.commentList[i].pkId).then(res => {
                      if(res.status != 200) this.$message.error("获取回复失败");

                      else {
                        this.replyList[this.commentList[i].pkId] = res.body;
                        this.replyList[this.commentList[i].pkId].date = this.replyList[this.commentList[i].pkId].date.split('T')[0];
                      }
                    })
                  }

                  let dateArr = this.commentList[i].date.split('T');
                  this.commentList[i].date = dateArr[0];

                  let starsArr = [];
                  for(let j = 0; j < this.commentList[i].stars; j++)
                  {
                    starsArr.push({});
                  }
                  this.commentList[i].stars = starArr;
                }
              }
            })
          }
        })
      }
      else if(res.status != 200) this.$message.error();

      else {
        this.commentList = res.body;
        for(let i = 0; i < this.commentList.length; i++) {
          if(this.commentList[i].isReply) {
            commentApi.getReplyCommentByCommentId(this.commentList[i].pkId).then(res => {
              if(res.status != 200) this.$message.error("获取回复失败");

              else {
                this.replyList[this.commentList[i].pkId] = res.body;
                this.replyList[this.commentList[i].pkId].date = this.replyList[this.commentList[i].pkId].date.split('T')[0];
              }
            })
          }
          let dateArr = this.commentList[i].date.split('T');
          this.commentList[i].date = dateArr[0];

          let starsArr = [];
          for(let j = 0; j < this.commentList[i].stars; j++)
          {
            starsArr.push({});
          }
          this.commentList[i].stars = starArr;
        }
      }
    })
  },
  computed: {
    selectedGBProductType: function() {
      for(let i of this.productTypes) {
        if(i.pkId == this.selectedGBProduct.productTypeId) return i.typeName;
      }
    }
  },
  methods: {
    showGBProductDetail(index) {
      this.selectedGBProduct = this.gbProductList[index];
      this.selectedGBProduct.vailSDate = this.selectedGBProduct.vailSDate.split('T')[0];
      this.selectedGBProduct.vailEDate = this.selectedGBProduct.vailEDate.split('T')[0];
      this.gbProductDialogVisible = true;
    },
    createGBOrder() {
      var now = new Date();
      this.gbProductOrder.GroupProductName = this.selectedGBProduct.productName;
      this.gbProductOrder.TotalCost = this.selectedGBProduct.price * this.gbProductOrder.Number; 
      this.gbProductOrder.IsPayed = false;
      this.gbProductOrder.Evaluate = "";
      this.gbProductOrder.IsUsed = false;
      this.gbProductOrder.OrderCode = "";
      this.gbProductOrder.PayWay = 1;
      this.gbProductOrder.CpkId = this.$store.getters.userId;
      this.gbProductOrder.SpkId = this.$store.getters.getShopId;
      this.gbProductOrder.SName = this.$store.getters.getShopSelectedName;
      this.gbProductOrder.Time = now.getFullYear() + "/" + now.getMonth() + "/" + now.getDate() + " " 
                                 + now.getHours() + ":" + now.getMinutes() + ":" + now.getSeconds();
      this.gbProductOrder.Img = this.selectedGBProduct.img;

      orderApi.addOrder(this.gbProductOrder).then(res => {
        if(res.status == 401) {
          identityApi.GetTokenByRefreshToken(this.$store.getters.getRefreshToken).then(res => {
            if(res.status == 400) this.$router.push('/Customer/SignIn');

            else {
              this.$store.dispatch('commitRefreshToken', res.body.refresh_token);
              this.$store.dispatch('commitToken', res.body.access_token);
              
              orderApi.addOrder(this.gbProductOrder).then(res => {
                if(res.status != 201) this.$message.error();
                else this.$message({type: "success", message: "创建订单成功"});

                this.gbProductDialogVisible = false;
              })
            }
          })
        }
        else if(res.status != 201) this.$message.error();
        else this.$message({type: "success", message: "创建订单成功"});

        this.gbProductDialogVisible = false;
      })
    }
  }
}
</script>
<style lang="less" scoped>
  @import '../../../less/container';
  @import '../../../less/formEle';
  @list_item_height : auto;
</style>
