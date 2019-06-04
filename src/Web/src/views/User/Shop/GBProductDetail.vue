<template>
  <div>
    <myBanner></myBanner>
    <div class="auto_eight">
      <div style="text-align: left; box-shadow: 3px 3px 3px lightgray; padding: 3rem 2rem 2rem 2rem; vertical-align: center; height: 18rem;">
        <div style="float: left; width: 20%; height: 15rem; padding-top: 2rem;">
          <el-carousel>
            <el-carousel-item v-for="item in gbProductImgs" :key="item.pkId">
              <img :src="item.img" style="width: 15rem; height: 12rem;" />
            </el-carousel-item>
          </el-carousel>
        </div>
        <div style="float: left;  width: 70%; height: 15rem; padding-left:4rem;">
          <h2>{{gbProduct.productName}}</h2>
          <div style="border-top: 1px solid black;"></div>
          <div><span style="margin-right: 3rem;">团购价:</span>   <span style="color: orange;">￥<span style="font-size: 3rem; color: orange;">{{gbProduct.price}}</span></span></div>
          <div style="margin-bottom: 2rem;">
            <p><span style="margin-right: 3rem;">有效期:</span>   {{gbProduct.vailSDate + ' - ' + gbProduct.vailEDate}}</p>
          </div>
          <el-button type="warning" @click="makeOrder">立即抢购</el-button>
        </div>
      </div>
      <div style="clear: both;"></div>
      <div style="margin: 3rem 0 0 0; text-align: left;">
        <tabs :tabs="tabsData" :tabLabelNow="selectedLabel" activeIndex="0">
          <template v-slot:适用门店>
            <div style="box-shadow: 3px 3px 3px lightgray; padding: 0 0 3rem 3rem;">
              <h2>适用门店</h2>
              <div>
                <p>{{currentShop.name}}</p>
                <el-rate
                  v-model="currentShop.averStarsNum"
                  disabled
                  show-score
                  text-color="#ff9900"
                  score-template="{value}">
                </el-rate>
                <div>
                  <p>共有{{currentShop.commentsNum}}条评论</p>
                  <p>门店地址: {{currentShop.province + currentShop.city + currentShop.district + currentShop.location}}</p>
                  <p>联系电话: {{currentShop.tel}}</p>
                </div>
              </div>
            </div>
          </template>
          <template v-slot:团购详情>
            <div style="box-shadow: 3px 3px 3px lightgray; padding: 0 2rem 3rem 3rem;">
              <h2>团购详情</h2>
              <div>
                <div>
                  <span style="margin-right: 10rem;">名称</span>
                  <span style="margin-right: 2rem;">规格</span>
                  <span style="margin-right: 2rem;">原价</span>
                  <span style="margin-right: 2rem;">团购价</span>
                </div>
                <div style="border-top: 1px solid gray; margin: 1rem 0 1rem 0;"></div>
                <div>
                  <span style="margin-right: 10rem; color: gray;">{{gbProduct.productName}}</span>
                  <span style="margin-right: 2rem; color: gray;">{{gbProduct.quantity}}</span>
                  <span style="margin-right: 2rem; color: gray;">{{gbProduct.orinPrice}}</span>
                  <span style="margin-right: 2rem; color: gray;">{{gbProduct.price}}</span>
                </div>
              </div>
            </div>
          </template>
          <template v-slot:套餐详情介绍>
            <div style="box-shadow: 3px 3px 3px lightgray; padding-left: 3rem;">
              <h2>套餐详情介绍</h2>
              <div>
                <p>{{gbProduct.detail}}</p>
                <div v-for="i in gbProductImgs" v-bind:key='i'>
                  <img :src="i.img" style="width:80%; height: 20rem;" />
                </div>
              </div>
            </div>
          </template>
        </tabs>
      </div>
      <el-dialog title="创建订单" :visible.sync="makeOrderDialogShow">
        <div style="text-align: left;">
          <img :src="gbProductImgs[0].img" style="width: 10rem; height: 8rem;margin: 0 0 3rem 3rem; display: inline-block;" />
          <div style="display: inline-block; margin: 0 0 0 8rem;">
            <p style="margin-bottom: 2rem;"><span style="margin-right:4rem;">门店名称</span>{{currentShop.name}}</p>
            <p style="margin-bottom: 2rem;"><span style="margin-right:4rem;">团购产品名称</span>{{gbProduct.productName}}</p>
            <el-input-number v-model="gbProductNum" :min="1" :max="10" label="团购产品数量"></el-input-number>
            <p style="margin: 2rem 0 2rem 0;"><span style="margin-right:4rem;">单价</span>{{gbProduct.price}}</p>
            <div style="margin-bottom: 2rem;">
              <span style="margin-right:4rem;">总价</span>
              <span style="color: orange;">￥<span style="font-size: 3rem; color: orange;">{{gbProduct.price * gbProductNum}}</span></span>
            </div>
          </div>
        </div>
        <div slot="footer" class="dialog-footer">
          <el-button @click="makeOrderDialogShow = false">取 消</el-button>
          <el-button type="warning" @click="sendOrder">提交订单</el-button>
        </div>
      </el-dialog>
    </div>
  </div>
</template>
<script>
import Tab from '../../../components/Tabs';
import * as shopApi from '../../../api/Shop';
import * as orderApi from '../../../api/Order';
import myBanner from '../../../components/Banner';

export default {
  components: {
    "tabs": Tab,
    'myBanner': myBanner
  },
  data() {
    return {
      selectedLabel: "适用门店",
      tabsData: [{
        label: "适用门店",
        link: "适用门店"
      }, {
        label: "团购详情",
        link: "团购详情"
      }, {
        label: "套餐详情介绍",
        link: "套餐详情介绍"
      }],
      gbProductImgs: [],
      gbProduct: {},
      currentShop: {},
      gbProductNum: 1,
      makeOrderDialogShow: false,
      formLabelWidth: '8rem',
      gbProductOrder: {}
    }
  },
  beforeMount() {
    this.gbProduct = this.$store.getters.getSelectedGBProduct;
    this.currentShop = this.$store.getters.getCurrentSelectedShop;

    shopApi.GetGBProductImgs(this.gbProduct.pkId).then(res => {
      if(res.status != 200) this.$message.error("获取团购图片错误");

      else {
        this.gbProductImgs = res.body
      }
    })
  },
  methods: {
    makeOrder() {
      this.makeOrderDialogShow = true
    },
    sendOrder() {
      var now = new Date();
      this.gbProductOrder.GroupProductName = this.gbProduct.productName;
      this.gbProductOrder.Number = this.gbProductNum;
      this.gbProductOrder.TotalCost = this.gbProduct.price * this.gbProductNum; 
      this.gbProductOrder.IsPayed = false;
      this.gbProductOrder.Evaluate = "";
      this.gbProductOrder.IsUsed = false;
      this.gbProductOrder.OrderCode = "";
      this.gbProductOrder.PayWay = 1;
      this.gbProductOrder.CpkId = this.$store.getters.userId;
      this.gbProductOrder.SpkId = this.currentShop.pkId;
      this.gbProductOrder.SName = this.currentShop.name;
      var month = now.getMonth() < 10? '0' + now.getMonth() : now.getMonth()
      var date = now.getDate() < 10? '0' + now.getDate() : now.getDate()
      var hours = now.getHours() < 10? '0' + now.getHours() : now.getHours()
      var minutes = now.getMinutes() < 10? '0' + now.getMinutes() : now.getMinutes()
      var seconds = now.getSeconds() < 10? '0' + now.getSeconds() : now.getSeconds()
      this.gbProductOrder.Time = now.getFullYear() + "/" + month + "/" + date  
      //+ " "  + hours + ":" + minutes + ":" + seconds;
      this.gbProductOrder.Img = this.currentShop.img;

      orderApi.addOrder(this.gbProductOrder).then(res => {
        if(res.status == 401) {
          identityApi.GetTokenByRefreshToken(this.$store.getters.getRefreshToken).then(res => {
            if(res.status == 400) this.$router.push('/Customer/SignIn');

            else {
              this.$store.dispatch('commitRefreshToken', res.body.refresh_token);
              this.$store.dispatch('commitToken', res.body.access_token);
              
              orderApi.addOrder(this.gbProductOrder).then(res => {
                if(res.status != 201) this.$message.error();
                else {
                  this.$message({type: "success", message: "创建订单成功"});
                  this.$router.push('/redirect')
                }

                this.gbProductDialogVisible = false;
              })
            }
          })
        }
        else if(res.status != 201) this.$message.error();
        else {
          this.$message({type: "success", message: "创建订单成功"});
          this.$router.push('/redirect')
        }

        this.gbProductDialogVisible = false;
      })
    }
  }
}
</script>
<style lang="less" scoped>

</style>