<template>
  <div class="auto_ten tabContent_container">
    <div class="list_item" style="padding: 2rem 0 0 2rem;" v-for="i of comments" v-bind:key="i.pkId">
      <div style="text-align: left;">
        <img :src="i.img" style="border-radius: 50%; display: inline-block;" />
        <p style="display: inline-block;">用户: {{i.userName}}</p>
      </div>
      <div>
        <h3>{{i.comment}}</h3>
      </div>
      <div style="text-align: right; margin: 0 2rem 1rem 0;">
        <p>日期: {{i.date}}</p>
        <el-button type="primary" style="margin: 0 2rem 1rem 0;" @click="reply(i)">回复</el-button>
      </div>
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