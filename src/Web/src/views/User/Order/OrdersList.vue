<template>
  <div class="auto_ten">
    <div v-if="type == '待支付'">
      <div class="list_item" v-for="i of ordersListNotPayed" v-bind:key="i.pkId" style="text-align: left; vertical-align: middle;">
        <img :src="i.img" style="width: 5rem; height: 5rem; display: inline-block; margin-left: 2rem;" />
        <div style="display: inline-block; vertical-align: middle; line-height: 5rem;">
          <h1 style="display: inline-block; margin: 0 3rem 0 3rem;">{{i.groupProductName}}</h1>
        </div>
        <div style="display: inline-block; margin: 0 3rem 0 3rem;">
          <p>数量: {{i.number}}</p>
          <p>总价: {{i.totalCost}}</p>
        </div>
        <div style="display: inline-block; margin: 0 3rem 0 3rem;">
          <p>支付方式: {{i.payWay}}</p>
          <p>商店名称: {{i.sName}}</p>
          <p>下单时间: {{i.time}}</p>
        </div>
        <el-button type="success" v-if="type == '待支付'" @click="pay(i)">支付订单</el-button>
      </div>
    </div>
    <div v-if="type == '待使用'">
      <div class="list_item" v-for="i of ordersListIsPayedNotUsed" v-bind:key="i.pkId" style="text-align: left; vertical-align: middle;">
        <img :src="i.img" style="width: 5rem; height: 5rem; display: inline-block; margin-left: 2rem;" />
        <div style="display: inline-block; vertical-align: middle; line-height: 5rem;">
          <h1 style="display: inline-block; margin: 0 3rem 0 3rem;">{{i.groupProductName}}</h1>
        </div>
        <div style="display: inline-block; margin: 0 3rem 0 3rem;">
          <p>数量: {{i.number}}</p>
          <p>总价: {{i.totalCost}}</p>
        </div>
        <div style="display: inline-block; margin: 0 3rem 0 3rem;">
          <p>支付方式: {{i.payWay}}</p>
          <p>商店名称: {{i.sName}}</p>
          <p>下单时间: {{i.time}}</p>
        </div>
        <el-button type="success" v-if="type == '待使用'" @click="showOrderCode(i)">使用</el-button>
        <el-dialog label="团购券码" :visible.sync="useDialogVisible">
          <h2>团购码: {{useOrder.orderCode}}</h2>
          <div slot="footer">
            <el-button @click="useDialogVisible = false">关闭</el-button>
            <el-button type="primary" @click="refreshSeeUsed">更新查看团购券状态</el-button>
          </div>
        </el-dialog>
      </div>
    </div>
    <div v-if="type == '已完成'">
      <div class="list_item" v-for="i of ordersListIsUsed" v-bind:key="i.pkId" style="text-align: left; vertical-align: middle;">
        <img :src="i.img" style="width: 5rem; height: 5rem; display: inline-block; margin-left: 2rem;" />
        <div style="display: inline-block; vertical-align: middle; line-height: 5rem;">
          <h1 style="display: inline-block; margin: 0 3rem 0 3rem;">{{i.groupProductName}}</h1>
        </div>
        <div style="display: inline-block; margin: 0 3rem 0 3rem;">
          <p>数量: {{i.number}}</p>
          <p>总价: {{i.totalCost}}</p>
        </div>
        <div style="display: inline-block; margin: 0 3rem 0 3rem;">
          <p>支付方式: {{i.payWay}}</p>
          <p>商店名称: {{i.sName}}</p>
          <p>下单时间: {{i.time}}</p>
        </div>
        <div style="display: inline-block;">
          <el-button type="success" @click="commentAction(i)">评论</el-button>
          <el-button type="success" @click="refresh()">刷新</el-button>
        </div>
        <el-dialog label="评价" :visible.sync="evaluateDialogVisible">
          <div>
            <p style="display: inline-block;">满意度: </p>
            <el-select v-model="evaluate.Stars" aria-placeholder="请选择" @change="changeStars">
              <el-option key="1" label="一分" value="1"></el-option>
              <el-option key="2" label="二分" value="2"></el-option>
              <el-option key="3" label="三分" value="3"></el-option>
              <el-option key="4" label="四分" value="4"></el-option>
              <el-option key="5" label="五分" value="5"></el-option>
            </el-select>
            <i class="el-icon-star-on" v-for="i of starsNum" v-bind:key="i.id"></i>
          </div>
          <div>
            <p style="display: inline-block;">评论: </p>
            <el-input type="textarea" rows="3" aria-placeholder="请输入评论" v-model="evaluate.Comment"></el-input>
          </div>
          <p style="display: inline-block;">现场图: </p>
          <el-upload
            class="avatar-uploader"
            action=""
            :show-file-list="false"
            :before-upload="beforeAvatarUpload">
            <img v-if="evaluate.Img" :src="evaluate.Img" class="avatar">
            <i v-else class="el-icon-plus avatar-uploader-icon"></i>
          </el-upload>
          <div slot="footer">
            <el-button @click="evaluateDialogVisible = false">取消</el-button>
            <el-button type="primary" @click="ensureEvaluate">确认</el-button>
          </div>
        </el-dialog>
      </div>
    </div>
    <div v-if="type == '已评价'">
      <div class="list_item" 
           v-for="i of ordersListIsEvaluate" 
           v-bind:key="i.pkId"
           style="text-align: left; vertical-align: middle;">
        <img :src="i.img" style="width: 5rem; height: 5rem; display: inline-block; margin-left: 2rem;" />
        <div style="display: inline-block; vertical-align: middle; line-height: 5rem;">
          <h1 style="display: inline-block; margin: 0 3rem 0 3rem;">{{i.groupProductName}}</h1>
        </div>
        <div style="display: inline-block; margin: 0 3rem 0 3rem;">
          <p>数量: {{i.number}}</p>
          <p>总价: {{i.totalCost}}</p>
        </div>
        <div style="display: inline-block; margin: 0 3rem 0 3rem;">
          <p>支付方式: {{i.payWay}}</p>
          <p>商店名称: {{i.sName}}</p>
          <p>下单时间: {{i.time}}</p>
        </div>
        <div style="display: inline-block;">
          <el-button type="success" @click="seeComment(i.pkId)">查看评论</el-button>
        </div>
        <el-dialog label="评价" :visible.sync="commentDetailDialogVisible">
          <div style="float: left;">
            <img :src="comment.img" style="width: 8rem; height: 6rem;" />
          </div>
          <div style="font-size: 1.5rem;">
            <div>
              <label>评价: </label>
              <i class="el-icon-star-on" v-for="i of starsNum" v-bind:key="i.id"></i>
            </div>
            <div>
              <label>评论内容: {{comment.comment}}</label>
            </div>
          </div>
          <div slot="footer">
            <el-button @click="commentDetailDialogVisible = false">取消</el-button>
          </div>
        </el-dialog>
      </div>
    </div>
  </div>  
</template>
<script>
import * as orderApi from '../../../api/Order';
import * as commentApi from '../../../api/Evaluate';
import * as merchantApi from '../../../api/Merchant';

export default {
  props: {
    type: ""
  },
  data() {
    return {
      ordersListNotPayed: [],
      ordersListIsPayedNotUsed: [],
      ordersListIsUsed: [],
      ordersListIsEvaluate: [],
      useOrder: {},
      useDialogVisible: false,
      evaluateDialogVisible: false,
      commentDetailDialogVisible: false,
      evaluate: {
        Comment: "",
        Date: "",
        Stars: 0,
        Img: "",
        OrderId: "",
        ProductId: "",
        ShopId: "",
        UserName: ""
      },
      comment: {

      },
      starsNum: []
    }
  },
  beforeCreate() {
    orderApi.getOrderByUserId(this.$store.getters.userId).then(res => {
      if (res.status != 200) this.$message.error();
      else {
        for(let i of res.body)
        {
          if(i.isPayed == false) {
            this.ordersListNotPayed.push(i);
          }
          else if(i.isPayed == true && i.isUsed == false) {
            this.ordersListIsPayedNotUsed.push(i);
          }
          else if(i.isUsed == true) {
            this.ordersListIsUsed.push(i);
          }
          if(i.isUsed == true && i.evaluate != "") {
            this.ordersListIsEvaluate.push(i);
          }
        }
      }
    })
  },
  methods: {
    pay(order) {
      orderApi.pay({"OrderId":order.pkId, "TotalCost":order.totalCost}).then(res => {
        if(res.status != 200) this.$message.error();

        else {
          this.$message({type: "success", message: "模拟订单支付成功"});
          orderApi.getOrderByUserId(this.$store.getters.userId).then(res => {
            if (res.status != 200) this.$message.error();
            else {
              this.ordersListNotPayed = [];
              this.ordersListIsPayedNotUsed = [];
              this.ordersListIsUsed = [];
              this.ordersListIsEvaluate = [];
              
              for(let i of res.body)
              {
                if(i.isPayed == false) {
                  this.ordersListNotPayed.push(i);
                }
                else if(i.isPayed == true && i.isUsed == false) {
                  this.ordersListIsPayedNotUsed.push(i);
                }
                else if(i.isUsed == true) {
                  this.ordersListIsUsed.push(i);
                }
                if(i.isUsed == true && i.evaluate != "") {
                  this.ordersListIsEvaluate.push(i);
                }
              }
            }
          })
        }
      })
    },
    showOrderCode(i) {
      this.useOrder = i;
      this.useDialogVisible = true;
    },
    refreshSeeUsed() {
      orderApi.getOrderByUserId(this.$store.getters.userId).then(res => {
        if (res.status != 200) this.$message.error();
        else {
          this.ordersListNotPayed = [];
          this.ordersListIsPayedNotUsed = [];
          this.ordersListIsUsed = [];
          this.ordersListIsEvaluate = [];
          
          for(let i of res.body)
          {
            if(i.isPayed == false) {
              this.ordersListNotPayed.push(i);
            }
            else if(i.isPayed == true && i.isUsed == false) {
              this.ordersListIsPayedNotUsed.push(i);
            }
            else if(i.isUsed == true) {
              this.ordersListIsUsed.push(i);
            }
            if(i.isUsed == true && i.evaluate != "") {
              this.ordersListIsEvaluate.push(i);
            }
          }
        };
        this.useDialogVisible = false;
      })
    },
    commentAction(order) {
      merchantApi.getGBProductKeyByProductName(order.groupProductName).then(res => {
        if(res.status != 200) {
          this.$message.error();
          return;
        }
        else {
          this.evaluate.ProductId = res.body;
          this.evaluate.OrderId = order.pkId;
          this.evaluate.ShopId = this.$store.getters.getShopId;
          this.evaluate.UserName = this.$store.getters.user.email;
        }
      })
      this.evaluateDialogVisible = true;
    },
    changeStars(starsNumber) {
      this.starsNum = [];
      for(let i = 0; i < starsNumber; i++) this.starsNum.push({id: i});
    },
    beforeAvatarUpload() {

    },
    ensureEvaluate() {
      var date = new Date();
      this.evaluate.Date = date.getFullYear() + '/' + date.getMonth() + '/' + date.getDate() + ' '
                           + date.getHours() + ':' + date.getMinutes() + ':' + date.getSeconds();
      commentApi.addUserComment(this.evaluate).then(res => {
        if(res.status != 201) this.$message.error();

        else {
          this.$message({
            type: "success",
            message: "评论成功"
          });

          this.evaluateDialogVisible = false;
        }
      })
    },
    refresh() {
      orderApi.getOrderByUserId(this.$store.getters.userId).then(res => {
        if (res.status != 200) this.$message.error();
        else {
          this.ordersListNotPayed = [];
          this.ordersListIsPayedNotUsed = [];
          this.ordersListIsUsed = [];
          this.ordersListIsEvaluate = [];
          
          for(let i of res.body)
          {
            if(i.isPayed == false) {
              this.ordersListNotPayed.push(i);
            }
            else if(i.isPayed == true && i.isUsed == false) {
              this.ordersListIsPayedNotUsed.push(i);
            }
            else if(i.isUsed == true) {
              this.ordersListIsUsed.push(i);
            }
            if(i.isUsed == true && i.evaluate != "") {
              this.ordersListIsEvaluate.push(i);
            }
          }
        }
      })
    },
    seeComment(orderId){
      commentApi.getUserCommentByOrderId(orderId).then(res => {
        if(res.status != 200) this.$message.error();

        else {
          this.comment = res.body;
          this.starsNum = [];
          for(var i = 0; i < res.body.stars; i++) {
            this.starsNum.push({id:i});
          }
          this.commentDetailDialogVisible = true;
          console.log(this.commentDetailDialogVisible);
        }
      })
    }
  }
}
</script>
<style lang="less" scoped>
  @import '../../../less/container';
  @import '../../../less/formEle';
  @import '../../../less/ele-ui';

  @list_item_height: auto;
</style>
