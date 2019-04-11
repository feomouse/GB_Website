<template>
  <div class="auto_ten">
    <div class="list_item" v-for="i of comments" v-bind:key="i.pkId">
      <div style="text-align: left;">
        <img :src="i.img" style="border-radius: 50%; display: inline-block;" />
        <p style="display: inline-block;">{{i.userName}}</p>
      </div>
      <div>
        <p>{{i.comment}}</p>
      </div>
      <div style="text-align: right; margin: 0 2rem 1rem 0;">
        <p>日期: {{i.date}}</p>
      </div>
      <div style="text-align: right;">
        <p style="cursor: pointer;" @click="reply(i)">回复</p>
        <el-dialog label="回复评论" :visible.sync="replyDialogVisible">
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
    </div>
  </div>
</template>
<script>
import * as commentApi from '../../../api/Evaluate';

export default {
  data() {
    return {
      comments: [],
      replyComment: {
        CommentId: "",
        Reply: "",
        Date: ""
      },
      replyDialogVisible: false
    }
  },
  beforeCreate() {
    commentApi.getUserCommentsByShopId(this.$store.getters.getShopId).then(res => {
      if(res.status != 200) this.$message.error();

      else {
        this.comments = res.body;
      }
    })
  },
  methods: {
    reply(comment) {
      var date = new Date();
      this.replyComment.CommentId = comment.pkId;
      this.replyComment.Date = date.getFullYear() + '/' + date.getMonth() + '/' + date.getDate() + ' '
                           + date.getHours() + ':' + date.getMinutes() + ':' + date.getSeconds();
    },
    ensureReply() {
      commentApi.addReplyComment(this.replyComment).then(res => {
        if(res.status != 201) this.$message.error();

        else {
          this.$message({
            type: "success",
            message: "回复成功"
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

  @list_item_height: auto;
</style>