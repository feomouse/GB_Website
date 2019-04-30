<template>
  <div>
    <div>
      <span>角色: </span>
      <el-select v-model="selectedRole" placeholder="请选择" @change="changeRole">
        <el-option
          key="顾客"
          label="顾客"
          value="customer">
        </el-option>
        <el-option
          key="商户"
          label="商户"
          value="merchant">
        </el-option>
      </el-select>
    </div>
    <el-table
      :data="okList"
      stripe
      style="width: 100%">
      <el-table-column
        prop="name"
        label="名字"
        width="180">
      </el-table-column>
      <el-table-column label="操作">
        <template slot-scope="scope">
          <el-button
            size="mini"
            @click="handleAdd(scope.$index, scope.row)">加入黑名单</el-button>
        </template>
      </el-table-column>
    </el-table>
    <el-dialog title="加入黑名单" :visible.sync="showAddToBlackDialog" style="text-align:left;">
      <div>确认将{{selectedItemName}}加入黑名单?</div>
      <div style="margin-top: 2rem;">原因: <el-input v-model="vioMemberData.Detail" placeholder="请输入加入黑名单原因"></el-input></div>
      <span slot="footer" class="dialog-footer">
        <el-button @click="showAddToBlackDialog = false">取 消</el-button>
        <el-button type="primary" @click="addToBlack">确 定</el-button>
      </span>
    </el-dialog>
  </div>
</template>
<script>
import * as customerApi from '../../../api/User';
import * as merchantApi from '../../../api/Merchant';
import * as managerApi from '../../../api/Manager';

export default{
  data() {
    return {
      selectedRole: "customer",
      okList: [],
      customerList: [{
        "pkId": "",
        "lookingImg": "",
        "address": null,
        "email": "",
        "userName": null
      }],
      merchantList: [{
        "authPkId": "",
        "shopId": "",
        "isChecked": false
      }],
      merchantNameList: [],
      merchantIdList: [],
      showAddToBlackDialog: false,
      selectedItemIndex: 0,
      selectedItemName: "",
      vioMemberData: {
        "UserName": "",
        "Date": "",
        "Detail": "",
        "Role": 2,
        "ManagerId": ""
      }
    }
  },
  beforeCreate() {
    customerApi.getCustomers(1).then(res => {
      if(res.status != 200) this.$message.error();

      else {
        this.customerList = res.body;

        for(let i of this.customerList)
        {
          this.okList.push({
            'name': i.email
          })
        }
      }
    })
  },
  methods: {
    handleAdd(index, role) {
      this.showAddToBlackDialog = true
      this.selectedItemIndex = index
      this.selectedItemName = role.name
    },
    addToBlack() {
      this.showAddToBlackDialog = false;
      var now = new Date();

      this.vioMemberData.UserName = this.selectedItemName
      this.vioMemberData.Date = now.getFullYear() + "/" + now.getMonth() + "/" + now.getDate() + " " 
                              + now.getHours() + ":" + now.getMinutes() + ":" + now.getSeconds();
      if(this.selectedRole == "customer")   this.vioMemberData.Role = 1;
      if(this.selectedRole == "merchant")this.vioMemberData.Role = 2;
      this.vioMemberData.ManagerId = this.$store.getters.getManagerId;

      managerApi.setViolateUser(this.vioMemberData).then(res => {
        if(res.status != 201) this.$message.error("加入黑名单失败");

        else {
          if(this.selectedRole == "customer") {
            customerApi.getCustomers(1).then(res => {
              if(res.status != 200) this.$message.error();

              else {
                this.customerList = res.body;

                for(let i of this.customerList)
                {
                  this.okList.push({
                    'name': i.email
                  })
                }
              }
            })
          } else if(this.selectedRole == "merchant")
          {
            merchantApi.getMerchantBasics(1).then(res => {
              if(res.status != 200) this.$message.error();

              else this.merchantList = res.body;

              return
            }).then(() => {
              for(let i of this.merchantList) {
                this.merchantIdList.push({
                  "Id": i.authPkId
                });
              }
              merchantApi.getMerchantsName(this.merchantIdList).then(res => {
                if(res.status != 200) this.$message.error("出错");

                else {
                  this.merchantNameList = res.body
                  this.okList = [];
                  for(let i of this.merchantNameList)
                  {
                    this.okList.push({
                      'name': i
                    })
                  }
                }
              })
            })
          }
        }
      })
    },
    changeRole(role) {
      if(role == 'customer') {
        this.okList = []
        customerApi.getCustomers(1).then(res => {
          if(res.status != 200) this.$message.error();

          else {
            this.customerList = res.body;

            for(let i of this.customerList)
            {
              this.okList.push({
                'name': i.email
              })
            }
          }
        })
      } else if (role == 'merchant') {
        this.okList = []
        merchantApi.getMerchantBasics(1).then(res => {
          if(res.status != 200) this.$message.error();

          else this.merchantList = res.body;

          return
        }).then(() => {
          for(let i of this.merchantList) {
            this.merchantIdList.push({
              "Id": i.authPkId
            });
          }
          merchantApi.getMerchantsName(this.merchantIdList).then(res => {
            if(res.status != 200) this.$message.error("出错");

            else {
              this.merchantNameList = res.body
              this.okList = [];
              for(let i of this.merchantNameList)
              {
                this.okList.push({
                  'name': i
                })
              }
            }
          })
        })
      }
    }
  }
}
</script>
<style lang="less" scoped>

</style>