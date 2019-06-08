<template>
  <div class="auto_ten" style="background: #f8f9f9;">
    <myBanner></myBanner>
    <div class="auto_eight" style="text-align: left; box-shadow: 3px 3px 3px lightgray; padding: 2rem 0 2rem 2rem;">
      <div style="float: left">
        <h1>{{shopDetail.name}}</h1>
        <el-rate
          v-model="shopDetail.averStarsNum"
          disabled
          show-score
          text-color="#ff9900"
          score-template="{value}">
        </el-rate>
        <div>
          <p>共有{{shopDetail.commentsNum}}条评论</p>
          <p>门店地址: {{shopDetail.province + shopDetail.city + shopDetail.district + shopDetail.location}}</p>
          <p>联系电话: {{shopDetail.tel}}</p>
          <p>营业时间: {{shopDetail.workingTime}}</p>
        </div>
      </div>
      <div style="float: right; margin: 3rem 3rem 0 0;">
        <el-carousel style="width: 30rem;">
          <el-carousel-item v-for="item in shopImgs" :key="item.pkId">
            <img :src="item.img" style="width: 30rem; height: 15rem;"/>
          </el-carousel-item>
        </el-carousel>
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
      <!--
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
      </el-dialog>-->
    </div>
    <div class="auto_eight" style="margin-top: 3rem;">
      <div class="shop-header">用户点评</div>
      <div v-for="i in commentList"
           v-bind:key="i.pkId"
           style="text-align: left; border-bottom: 1px solid lightgray; padding: 1rem 3rem 0 3rem; background: #f2f3f4; height: 12rem;">
          <div style="margin-right: 2rem;">
            <img :src="i.img" style="width:5rem; height: 5rem; border-radius: 50%; float: left; margin: 1rem 2rem 0 0;"/>
            <div style="float: left;">
              <div><p style="margin-top:2rem;">{{i.userName}}</p></div>
              <el-rate
                v-model="i.stars"
                disabled
                show-score
                text-color="#ff9900"
                score-template="{value}">
              </el-rate>
            </div>
            <div style="float: right; margin-top: 3rem;">日期: {{i.date}}</div>
          </div>
          <div style="clear: both;"></div>
          <div style="margin-top: 1rem;">
            <div style="margin: 1rem 0 1rem 7rem; font-size: 0.8rem;">{{i.comment}}</div>
            <div style="color: green; margin: 1rem 0 1rem 7rem;" v-if="typeof replyList[i.pkId] != 'undefined'">商家回复: {{replyList[i.pkId].reply}}</div>
          </div>
      </div>
      <el-pagination
        layout="prev, pager, next"
        :total="commentCount"
        page-size=3
        @current-change="changeCommentPage">
      </el-pagination>
    </div>
    <!--<div @click="test" style="cursor: pointer;">测试</div>-->
    <div style="width: 80%; margin: 0 auto;"><my-footer></my-footer></div>
  </div>
</template>
<script>
  import myFooter from '../../../views/Common/Footer';
import * as shopApi from '../../../api/Shop';
import * as merchantApi from '../../../api/Merchant';
import * as orderApi from '../../../api/Order';
import * as commentApi from '../../../api/Evaluate';
import * as identityApi from '../../../api/Identity';
import * as userApi from '../../../api/User';
import myBanner from '../../../components/Banner';
import cityData from '../../../data';

export default {
  components: {
    'myBanner': myBanner,
      'my-footer': myFooter
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
      commentCount: 0,
      'cityData': cityData,
      replys: [],
      shopImgs: []
    }
  },
  mounted() {
    this.shopDetail = this.$store.getters.getCurrentSelectedShop

    merchantApi.getGBProductByShopName(this.$store.getters.getShopSelectedName,
                                        this.cityData['86'][this.$store.getters.getSelectedProvince], 
                                        this.cityData[this.$store.getters.getSelectedProvince][this.$store.getters.getSelectedCity],
                                        this.shopDetail.district
                                        ).then(res => {
      if(res.status != 200) this.$message.error('获取团购产品失败');
      else {
        this.gbProductList = res.body;
      }
      /*
      merchantApi.getProductTypeByShopName(this.$store.getters.getShopSelectedName,
                                        this.cityData['86'][this.$store.getters.getSelectedProvince], 
                                        this.cityData[this.$store.getters.getSelectedProvince][this.$store.getters.getSelectedCity]).then(res => {
        if(res.status != 200) this.$message.error();
        else this.productTypes = res.body;
      })*/
    }).then(() => {
      shopApi.GetShopImgs(this.shopDetail.pkId).then(res => {
        if(res.status != 200) this.$message.error("获取门店图片出错");

        else this.shopImgs = res.body;
      })
    })
    /*
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
    }),*/
    commentApi.getUserCommentsByShopId(this.$store.getters.getCurrentSelectedShop.pkId, 1).then(res => {
      if(res.status == 401) {
        identityApi.GetTokenByRefreshToken(this.$store.getters.getRefreshToken).then(res => {
          if(res.status == 400) this.$router.push('/Customer/SignIn');

          else {
            this.$store.dispatch('commitRefreshToken', res.body.refresh_token);
            this.$store.dispatch('commitToken', res.body.access_token);

            commentApi.getUserCommentsByShopId(this.$store.getters.getCurrentSelectedShop.pkId, 1).then(res => {
              if(res.status != 200) this.$message.error();

              else {
                this.commentList = res.body;
                let commentIds = new Array();
                let commentUserNames = new Array();
                for(let i = 0; i < this.commentList.length; i++) {
                  commentIds[i] = this.commentList[i].pkId;
                  commentUserNames[i] = this.commentList[i].userName;
                }

                userApi.getUsersImg(commentUserNames).then(res => {
                  if(res.status != 200) this.$message.error("获取用户头像错误");

                  else {
                    for(let i = 0; i < this.commentList.length; i++) {
                      this.commentList[i].img = res.body[i];
                    }
                  }
                })
                commentApi.getReplyCommentsByCommentIds(commentIds).then(res => {
                  this.replys = res.body
                }).then(() => {
                  for(let m = 0; m < this.replys.length; m++) {
                    this.replyList[this.replys[m] != null ? this.replys[m].commentId : ''] = this.replys[m];
                  }
                    console.log(this.replyList)
                  for(let i = 0; i < this.commentList.length; i++) {
                    let dateArr = this.commentList[i].date.split('T');
                    this.commentList[i].date = dateArr[0];
                  }
                  commentApi.getUserCommentCount(this.$store.getters.getCurrentSelectedShop.pkId).then(res => {
                    if(res.status != 200) this.$message.error('获取评论数量失败');

                    else {
                      this.commentCount = res.body;
                    }
                  })
                })
              }
            })
          }
        })
      }
      else if(res.status != 200) this.$message.error();

      else {
        this.commentList = res.body;
        let commentIds = new Array();
        let commentUserNames = new Array();
        for(let i = 0; i < this.commentList.length; i++) {
          commentIds[i] = this.commentList[i].pkId;
          commentUserNames[i] = this.commentList[i].userName;
        }

        userApi.getUsersImg(commentUserNames).then(res => {
          if(res.status != 200) this.$message.error("获取用户头像错误");

          else {
            for(let i = 0; i < this.commentList.length; i++) {
              this.commentList[i].img = res.body[i];
            }
          }
        })
        commentApi.getReplyCommentsByCommentIds(commentIds).then(res => {
          this.replys = res.body
        }).then(() => {
          for(let m = 0; m < this.replys.length; m++) {
            this.replyList[this.replys[m] != null ? this.replys[m].commentId : ''] = this.replys[m];
          }
                    console.log(this.replyList)
          for(let i = 0; i < this.commentList.length; i++) {
            let dateArr = this.commentList[i].date.split('T');
            this.commentList[i].date = dateArr[0];
          }
          commentApi.getUserCommentCount(this.$store.getters.getCurrentSelectedShop.pkId).then(res => {
            if(res.status != 200) this.$message.error('获取评论数量失败');

            else {
              this.commentCount = res.body;
            }
          })
        })
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
    showGBProductDetail(index) {/*
      this.selectedGBProduct = this.gbProductList[index];
      this.selectedGBProduct.vailSDate = this.selectedGBProduct.vailSDate.split('T')[0];
      this.selectedGBProduct.vailEDate = this.selectedGBProduct.vailEDate.split('T')[0];
      this.gbProductDialogVisible = true;*/
      this.$store.dispatch('commitSetSelectedGBProduct', this.gbProductList[index]);
      this.$router.push('/GBProductDetail');
    },
    /*
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
      var month = now.getMonth() < 10? '0' + now.getMonth() : now.getMonth()
      var date = now.getDate() < 10? '0' + now.getDate() : now.getDate()
      var hours = now.getHours() < 10? '0' + now.getHours() : now.getHours()
      var minutes = now.getMinutes() < 10? '0' + now.getMinutes() : now.getMinutes()
      var seconds = now.getSeconds() < 10? '0' + now.getSeconds() : now.getSeconds()
      this.gbProductOrder.Time = now.getFullYear() + "/" + month + "/" + date  
      //+ " "  + hours + ":" + minutes + ":" + seconds;
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
    },
    */
    changeCommentPage(page) {
      commentApi.getUserCommentsByShopId(this.$store.getters.getShopId, page).then(res => {
        if(res.status == 401) {
          identityApi.GetTokenByRefreshToken(this.$store.getters.getRefreshToken).then(res => {
            if(res.status == 400) this.$router.push('/Customer/SignIn');

            else {
              this.$store.dispatch('commitRefreshToken', res.body.refresh_token);
              this.$store.dispatch('commitToken', res.body.access_token);

              commentApi.getUserCommentsByShopId(this.$store.getters.getShopId, page).then(res => {
                if(res.status != 200) this.$message.error();

                else {
                  this.commentList = res.body;
                  let commentIds = new Array();
                  let replys = new Array();
                  for(let i = 0; i < this.commentList.length; i++) {
                    commentIds[i] = this.commentList[i].pkId;
                  }
                  commentApi.getReplyCommentsByCommentIds(commentIds).then(res => {
                    replys = res.body
                  })
  
                  for(let m = 0; m < replys.length; m++) {
                    this.replyList[this.replys[m] != null ? this.replys[m].commentId : ''] = replys[m];
                  }
                  
                  for(let i = 0; i < this.commentList.length; i++) {
  /*                   if(this.commentList[i].isReply) {
                      commentApi.getReplyCommentByCommentId(this.commentList[i].pkId).then(res => {
                        if(res.status != 200) this.$message.error("获取回复失败");

                        else {
                          this.replyList[this.commentList[i].pkId] = res.body;
                          this.replyList[this.commentList[i].pkId].date = this.replyList[this.commentList[i].pkId].date.split('T')[0];
                        }
                      })
                    } */

                    let dateArr = this.commentList[i].date.split('T');
                    this.commentList[i].date = dateArr[0];

                    let starsArr = [];
                    for(let j = 0; j < this.commentList[i].stars; j++)
                    {
                      starsArr.push({});
                    }
                    this.commentList[i].stars = starArr;
                  }
                  commentApi.getUserCommentCount(this.$store.getters.getShopId).then(res => {
                    if(res.status != 200) this.$message.error('获取评论数量失败');

                    else {
                      this.commentCount = res.body;
                    }
                  })
                }
              })
            }
          })
        }
        else if(res.status != 200) this.$message.error();

        else {
          this.commentList = res.body;
          let commentIds = new Array();
          let replys = new Array();
          for(let i = 0; i < this.commentList.length; i++) {
            commentIds[i] = this.commentList[i].pkId;
          }
          commentApi.getReplyCommentsByCommentIds(commentIds).then(res => {
            replys = res.body
          })

          for(let m = 0; m < replys.length; m++) {
            this.replyList[this.replys[m] != null ? this.replys[m].commentId : ''] = replys[m];
          }
          
          for(let i = 0; i < this.commentList.length; i++) {
/*                   if(this.commentList[i].isReply) {
              commentApi.getReplyCommentByCommentId(this.commentList[i].pkId).then(res => {
                if(res.status != 200) this.$message.error("获取回复失败");

                else {
                  this.replyList[this.commentList[i].pkId] = res.body;
                  this.replyList[this.commentList[i].pkId].date = this.replyList[this.commentList[i].pkId].date.split('T')[0];
                }
              })
            } */

            let dateArr = this.commentList[i].date.split('T');
            this.commentList[i].date = dateArr[0];

            let starsArr = [];
            for(let j = 0; j < this.commentList[i].stars; j++)
            {
              starsArr.push({});
            }
            this.commentList[i].stars = starArr;
          }
          commentApi.getUserCommentCount(this.$store.getters.getShopId).then(res => {
            if(res.status != 200) this.$message.error('获取评论数量失败');

            else {
              this.commentCount = res.body;
            }
          })
        }
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
