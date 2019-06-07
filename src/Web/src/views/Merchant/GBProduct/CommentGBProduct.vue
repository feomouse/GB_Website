<template>
  <div class="auto_ten tabContent_container">
    <div v-for="i in comments"
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
          <div style="text-align: right;"><el-button style="" type="primary" @click="reply(i)">回复</el-button></div>
        </div>
    </div>
    <el-dialog title="回复评论" :visible.sync="replyDialogVisible">
      <el-input  
        type="textarea"
        rows="2"
        placeholder="请输入内容"
        v-model="replyComment.Reply">
      </el-input>
      <div slot="footer">
        <el-button @click="replyDialogVisible = false">取消</el-button>
        <el-button type="primary" @click="ensureReply">回复</el-button>
      </div>
    </el-dialog>
    <el-pagination
      layout="prev, pager, next"
      :total="userCommentCount"
      @current-change="changeCommentPage">
    </el-pagination>
  </div>
</template>
<script>
import * as commentApi from '../../../api/Evaluate';
import * as identityApi from '../../../api/Identity';
import * as userApi from '../../../api/User';

export default {
  data() {
    return {
      comments: [],
      replyComment: {
        CommentId: "",
        Reply: "",
        Date: ""
      },
      userCommentCount: 0,
      replyDialogVisible: false
    }
  },
  beforeCreate() {
    commentApi.getUserCommentsByShopId(this.$store.getters.getShopId, 1).then(res => {
      if(res.status == 401) {
        identityApi.GetTokenByRefreshToken(this.$store.getters.getRefreshToken).then(res => {
          if(res.status == 400) this.$router.push('/Customer/SignIn');

          else {
            this.$store.dispatch('commitRefreshToken', res.body.refresh_token);
            this.$store.dispatch('commitToken', res.body.access_token);

            commentApi.getUserCommentsByShopId(this.$store.getters.getShopId, 1).then(res => {
              if(res.status != 200) this.$message.error();

              else {
                this.comments = res.body;
                let commentIds = new Array();
                let commentUserNames = new Array();
                for(let i = 0; i < this.comments.length; i++) {
                  commentIds[i] = this.comments[i].pkId;
                  commentUserNames[i] = this.comments[i].userName;
                }

                userApi.getUsersImg(commentUserNames).then(res => {
                  if(res.status != 200) this.$message.error("获取用户头像错误");

                  else {
                    for(let i = 0; i < this.comments.length; i++) {
                      this.comments[i].img = res.body[i];
                    }
                  }
                })
                commentApi.getUserCommentCount(this.$store.getters.getShopId).then(res => {
                  if(res.status != 200) this.$message.error('获取评论数量失败');

                  else {
                    this.userCommentCount = res.body;
                  }
                })
              }
            })
          }
        })
      }
      else if(res.status != 200) this.$message.error();

      else {
        this.comments = res.body;
        let commentIds = new Array();
        let commentUserNames = new Array();
        for(let i = 0; i < this.comments.length; i++) {
          commentIds[i] = this.comments[i].pkId;
          commentUserNames[i] = this.comments[i].userName;
        }

        userApi.getUsersImg(commentUserNames).then(res => {
          if(res.status != 200) this.$message.error("获取用户头像错误");

          else {
            for(let i = 0; i < this.comments.length; i++) {
              this.comments[i].img = res.body[i];
            }
          }
        })
        commentApi.getUserCommentCount(this.$store.getters.getShopId).then(res => {
          if(res.status != 200) this.$message.error('获取评论数量失败');

          else {
            this.userCommentCount = res.body;
          }
        })
      }
    })
  },
  methods: {
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
                  this.comments = res.body;
                }
              })
            }
          })
        }
        else if(res.status != 200) this.$message.error();

        else {
          this.comments = res.body;
        }
      })
    },
    reply(comment) {
      var date = new Date();
      this.replyComment.CommentId = comment.pkId;
      this.replyComment.Date = date.getFullYear() + '/' + date.getMonth() + '/' + date.getDate() + ' '
                           + date.getHours() + ':' + date.getMinutes() + ':' + date.getSeconds();

      this.replyDialogVisible = true;
    },
    ensureReply() {
      commentApi.addReplyComment(this.replyComment).then(res => {
        if(res.status == 401) {
          identityApi.GetTokenByRefreshToken(this.$store.getters.getRefreshToken).then(res => {
            if(res.status == 400) this.$router.push('/Customer/SignIn');

            else {
              this.$store.dispatch('commitRefreshToken', res.body.refresh_token);
              this.$store.dispatch('commitToken', res.body.access_token);
              
              commentApi.addReplyComment(this.replyComment).then(res => {
                if(res.status != 201) this.$message.error();

                else {
                  this.$message({
                    type: "success",
                    message: "回复成功"
                  })
                  this.replyDialogVisible = false;
                }
              })
            }
          })
        }
        else if(res.status != 201) this.$message.error();

        else {
          this.$message({
            type: "success",
            message: "回复成功"
          })
          this.replyDialogVisible = false;
        }
      })
    }
  }
}
</script>
<style lang="less" scoped>
  @import '../../../less/container';
  @import '../../../less/formEle';

  @list_item_height: auto;
</style>