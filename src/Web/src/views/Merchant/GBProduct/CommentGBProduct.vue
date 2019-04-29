<template>
  <div class="auto_ten tabContent_container">
    <div class="list_item" style="padding: 2rem 0 0 2rem;" v-for="i of comments" v-bind:key="i.pkId">
      <div style="text-align: left; margin: 2rem 0 1rem 1rem;">
        <!-- <img :src="i.img" style="border-radius: 50%; display: inline-block;" /> -->
        <p style="display: inline-block;">{{i.userName}}</p>
      </div>
      <div>
        <h3 style="margin: 2rem 0 1rem 1rem;">{{i.comment}}</h3>
      </div>
      <div style="text-align: right; margin: 0 2rem 1rem 0;">
        <p>日期: {{i.date}}</p>
        <el-button type="primary" style="margin: 0 2rem 1rem 0;" @click="reply(i)">回复</el-button>
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
    </div>
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