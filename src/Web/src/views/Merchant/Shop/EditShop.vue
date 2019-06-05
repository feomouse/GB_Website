<template>
  <div class="auto_ten">
    <div>
      <el-button type="primary" @click="goBindShop"  style="float: right;">绑定门店</el-button>
      <el-button type="primary" @click="goChooseShop" style="float: right;margin-right: 2rem;">选择门店</el-button>
      <el-button type="error" @click="unbindShopDialogShow = true" style="float: right; margin-right: 2rem;">解绑门店</el-button>
      <el-dialog title="解绑门店" :visible.sync="unbindShopDialogShow">
        <h2>确定解绑当前绑定门店?</h2>
        <span slot="footer">
          <el-button @click="unbindShopDialogShow = false">取 消</el-button>
          <el-button type="primary" @click="ensureUnbindMerchantShop">提交</el-button>
        </span>
      </el-dialog>
      <el-dialog title="选择门店" :visible.sync="selectShopDialogShow">
        <el-row :gutter="20">
          <el-col :span="6">
            <el-select v-model="selectedShopId" placeholder="请选择门店" @change="selectedShopChange">
              <el-option
                v-for="item in merchantShops"
                :key="item.pkId"
                :label="item.name"
                :value="item.pkId">
              </el-option>
            </el-select>
          </el-col>
          <el-col :span="18">
            <el-card style="text-align: left;">
              <div>店名: {{selectedShop.name}}</div>
              <div>地点: {{selectedShop.province + selectedShop.city + selectedShop.district + selectedShop.location}}</div>
              <div>电话: {{selectedShop.tel}}</div>
            </el-card>
          </el-col>
        </el-row>
        <span slot="footer">
          <el-button @click="selectShopDialogShow = false">取 消</el-button>
          <el-button type="primary" @click="selectShop">提交</el-button>
        </span>
      </el-dialog>
    </div>
    <div style="font-size: 2rem; border-bottom: 2px solid lightgray; color: lightgray;">门店基本信息</div>
    <div class="left-eight" style="text-align:left; background: #eff7f2; box-shadow: 3px 3px 3px lightgray; margin-top: 1rem;">
      <el-form label-width="100px">
        <el-form-item label="名字: " style="width: 40%;">
          <el-input placeholder="请输入" v-model="newShop.name"></el-input>
        </el-form-item>
        <el-form-item label="省: ">
          <el-select v-model="newShop.province" @change="provinceChange">
            <el-option v-for="(i, k) of dataMap['86']" 
                    v-bind:key="k" 
                    v-bind:value="k"
                    :label="i"
                    >
            </el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="市: ">
          <el-select v-model="newShop.city" @change="cityChange">
            <el-option v-for="(i, k) of dataMap[newShop.province]" 
                    v-bind:key="k" 
                    v-bind:value="k"
                    :label="i"
                    >
            </el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="区: ">
          <el-select v-model="newShop.district">
            <el-option v-for="(i, k) of dataMap[newShop.city]" 
                    v-bind:key="k" 
                    v-bind:value="k"
                    :label="i"
                    >
            </el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="具体地址" style="width: 70%;">
          <el-input placeholder="请输入" v-model="newShop.location"></el-input>
        </el-form-item>
        <el-form-item label="类型: " style="width: 30%;">
           <el-select v-model="newShop.type" disabled>
             <el-option v-for="i in shopTypes"
                        v-bind:key="i.pkid"
                        v-bind:value="i.pkid"
                        :label="i.name">
             </el-option>
           </el-select>
        </el-form-item>
        <el-form-item label="电话: " style="width: 40%;">
          <el-input placeholder="请输入" v-model="newShop.tel"></el-input>
        </el-form-item>
        <el-form-item label="营业时间: " style="width: 50%;">
          <el-input placeholder="请输入" v-model="newShop.workingTime"></el-input>
        </el-form-item>
      </el-form>
      <div class="a-element-a-line" style="text-align: center;">
        <el-button class="rem15-rem3-button" type="success" @click="updateShop">更新门店基本信息</el-button>
      </div>
    </div>
    <div style="float: right; width: 18rem; padding-top: 10rem;">      
      <div style="margin-bottom:2rem;"><el-button type="success" @click="lookShopImgs">查看门店图片</el-button></div>
      <div><el-button type="success" @click="setShopImgsDialogShow = true">新增门店图片</el-button></div>
      <el-dialog title="查看门店图片" :visible.sync="getShopImgsDialogShow">
        <el-carousel :interval="4000" type="card" height="200px">
          <el-carousel-item v-for="item in shopImgs" :key="item.pkId">
            <img :src="item.img" style="width: 150px; height: 150px;" />
          </el-carousel-item>
        </el-carousel>
      </el-dialog>
      <el-dialog title="新增门店图片" :visible.sync="setShopImgsDialogShow">
        <div style="height: 100%;">
          <el-upload
            class="avatar-uploader"
            action=""
            :show-file-list="false"
            :before-upload="beforeAvatarUpload">
            <img v-if="tempShopImg" :src="tempShopImg" class="avatar">
            <i v-else class="el-icon-plus avatar-uploader-icon"></i>
          </el-upload>
        </div>
        <div>门店图像</div>
        <div slot="footer">
          <el-button @click="setShopImgsDialogShow = false">取 消</el-button>
          <el-button type="primary" @click="ensureAddShopImg">确 定</el-button>
        </div>
      </el-dialog>
    </div>
  </div>
</template>
<script>
import * as shopApi from '../../../api/Shop';
import * as merchantApi from '../../../api/Merchant';
import * as imgApi from '../../../api/img';
import * as map from '../../../data';
import * as identityApi from '../../../api/Identity';

export default {
  data() {
    return {
      newShop: {},
      tempProvince: '',
      tempCity: '',
      tempDistrict: '',
      dataMap: map,
      shopTypes: [],
      selectShopDialogShow: false,
      getShopImgsDialogShow: false,
      setShopImgsDialogShow: false,
      unbindShopDialogShow: false,
      tempShopImg: '',
      shopImgs: [],
      selectedShopId: '',
      selectedShop: {},
      merchantShops: this.$store.getters.getMerchantShops
    }
  },
  beforeMount() {
    merchantApi.getShopTypies().then(res => {
      if(res.status != 200) this.$message.error("获取门店类型出错");

      else {
        this.shopTypes = res.body;

        this.selectedShop = this.$store.getters.getMerchantCurrentShop;
        let mid = {};
        this._.assign(mid, this.selectedShop);
        this.newShop = mid;

        for(let i of this.shopTypes) {
          if(i.pkId == this.newShop.type) this.newShop.type = i.name
        }
        for(let i in map['86']) {
          if(map['86'][i] == this.newShop.province)  this.newShop.province = i;
        }

        for(let i in map[this.newShop.province]) {
          if(map[this.newShop.province][i] == this.newShop.city) this.newShop.city = i;
        }

        for(let i in map[this.newShop.city]) {
          if(map[this.newShop.city][i] == this.newShop.district) this.newShop.district = i;
        }
      }
    })

    /*
    shopApi.GetShopInfoByMerchantId(this.$store.getters.getMerchantId).then(res => {
      if(res.status == 401) {
        identityApi.GetTokenByRefreshToken(this.$store.getters.getRefreshToken).then(res => {
          if(res.status == 400) this.$router.push('/Customer/SignIn');

          else {
            this.$store.dispatch('commitRefreshToken', res.body.refresh_token);

            shopApi.GetShopInfoByMerchantId(this.$store.getters.getMerchantId).then(res => {
              if(res.status == 400) this.$message.error();
              else {
                this.newShop = res.body;
                merchantApi.getShopTypies().then(res => {
                  if(res.status != 200) this.$message.error("获取门店类型出错");

                  else this.shopTypes = res.body;
                })
              }
            })
          }
        })
      }
      else if(res.status == 400) this.$message.error();
      else {
        this.newShop = res.body;
        merchantApi.getShopTypies().then(res => {
          if(res.status != 200) this.$message.error("获取门店类型出错");

          else this.shopTypes = res.body;
        })
      }
    })
    */
  },
  mounted() {/*
    shopApi.GetShopImgs(this.selectedShop.pkId).then(res => {
      if(res.status == 400) this.$message.error('获取门店图片失败');

      else {
        this.shopImgs = res.body
      }
    })*/
  },
  updated() {
    /*
    for(let i in map['86']) {
      if(map['86'][i] == this.newShop.province)  this.newShop.province = i;
    }

    for(let i in map[this.newShop.province]) {
      if(map[this.newShop.province][i] == this.newShop.city) this.newShop.city = i;
    }

    for(let i in map[this.newShop.city]) {
      if(map[this.newShop.city][i] == this.newShop.district) this.newShop.district = i;
    }*/
  },
  methods: {
    ensureUnbindMerchantShop() {
      merchantApi.unbindShop(this.$store.getters.getMerchantId, this.$store.getters.getMerchantCurrentShop.pkId).then(res => {
        if(res.status != 200) this.$message.error('解绑失败');

        else {
          this.$message({
            type: 'success',
            message: '解绑当前门店成功'
          })
          this.unbindShopDialogShow = false
          this.selectedShop = {}
          this.selectedShopId = ""
          this.selectShop()
        }
      })
    },
    goBindShop() {
      this.$router.push('/Merchant/CreateShop')
    },
    goChooseShop() {
      this.selectShopDialogShow = true
    },
    selectedShopChange(v) {
      for(var i of this.merchantShops) {
        if(i.pkId == v) {
          this.selectedShop = i
          this.selectedShopId = i.pkId
        }
      }
    },
    selectShop() {
      this.$store.dispatch('commitSetShopId', this.selectedShopId);
      this.$store.dispatch('commitSetMerchantShopId', this.selectedShopId);
      this.$store.dispatch('commitSetMerchantCurrentShop', this.selectedShop);
      let mid = {};
      this._.assign(mid, this.selectedShop);
      this.newShop = mid;
      for(let i of this.shopTypes) {
        if(i.pkId == this.newShop.type) this.newShop.type = i.name
      }
      for(let i in map['86']) {
        if(map['86'][i] == this.newShop.province)  this.newShop.province = i;
      }

      for(let i in map[this.newShop.province]) {
        if(map[this.newShop.province][i] == this.newShop.city) this.newShop.city = i;
      }

      for(let i in map[this.newShop.city]) {
        if(map[this.newShop.city][i] == this.newShop.district) this.newShop.district = i;
      }
      this.selectShopDialogShow = false
    },
    provinceChange() {
      this.newShop.city = ""
      this.newShop.district = ""
    },
    cityChange() {
      this.newShop.district = ""
    },
    beforeAvatarUpload(file) {
        const is = file.type === 'image/jpeg' || file.type === 'image/png';

        var form = new FormData();

        form.append("file", file);

        if (!is) {
          this.$message.error('上传Jpg!');
          return
        }

        imgApi.ImgUpload(form).then(data => {
          if(data.status == 401) {
            identityApi.GetTokenByRefreshToken(this.$store.getters.getRefreshToken).then(res => {
              if(res.status == 400) this.$router.push('/Customer/SignIn');

              else {
                this.$store.dispatch('commitRefreshToken', res.body.refresh_token);

                imgApi.ImgUpload(form).then(data => {
                  this.tempShopImg = data.body;
                })
              }
            })
          }
          this.tempShopImg = data.body;
        })

        return is;
    },
    ensureAddShopImg() {
      shopApi.AddShopImg({'ShopId': this.selectedShop.pkId, 'Img': this.tempShopImg}).then(res => {
        if(res.status == 400) this.$message.error('设置门店图片失败');

        else {
          this.$message({
            type: 'success',
            message: '新增门店图片成功'
          })
          this.setShopImgsDialogShow = false
          this.tempShopImg = ''
        }
      })
    },
    lookShopImgs() {
      shopApi.GetShopImgs(this.selectedShop.pkId).then(res => {
        if(res.status == 400) this.$message.error('获取门店图片失败');

        else {
          this.shopImgs = res.body
        }
      })
      this.getShopImgsDialogShow = true;
    },
    updateShop() {
      if(this.newShop.city == "" || this.newShop.district == "") {
        this.$message.error("请在重新选择省份后，重新选择城市与区域");
        
        return
      }
      var shop = {
        "PkId": this.newShop.pkId,
        "Name": this.newShop.name,
        "Province": this.dataMap['86'][this.newShop.province],
        "City": this.dataMap[this.newShop.province][this.newShop.city],
        "District": this.dataMap[this.newShop.city][this.newShop.district],
        "Location": this.newShop.location,
        "Tel": this.newShop.tel,
        "WorkingTime": this.newShop.workingTime
      }
      merchantApi.updateShop(shop).then(res => {
        if(res.status == 401) {
          identityApi.GetTokenByRefreshToken(this.$store.getters.getRefreshToken).then(res => {
            if(res.status == 400) this.$router.push('/Customer/SignIn');

            else {
              this.$store.dispatch('commitRefreshToken', res.body.refresh_token);
              this.$store.dispatch('commitToken', res.body.access_token);
              
              merchantApi.updateShop(shop).then(res => {
                if(res.status == 400) this.$message.error('更新失败');
                else {
                  this.newShop = res.body;
                  this.$message({
                    type: 'success',
                    message:'更新成功'
                  });
                  this.$store.dispatch('commitSetMerchantCurrentShop', res.body)
                  this.$store.dispatch('commitSetShopName', this.newShop.name);
                }
              })
            }
          })
        }
        else if(res.status == 400) this.$message.error('更新失败');
        else {
          this.newShop = res.body;
          this.$message({
            type: 'success',
            message:'更新成功'
          });
          this.$store.dispatch('commitSetMerchantCurrentShop', res.body)
          this.$store.dispatch('commitSetShopName', this.newShop.name);
        }
      })
    }
  },
}
</script>
<style lang="less" scoped>
  @import '../../../less/container';
  @import '../../../less/ele-ui';

  @left_eight_height : auto;
  @right_two_height : auto;

  .form-5rem__input {
    width: 8rem;
    height: 2rem;
    display: inline-block;
    margin-right: 2rem;
  }

  .form-15rem__input { 
    width: 20rem;
    height: 2rem;
    display: inline-block;
  }

  .left-eight {
    margin-top: 5rem;
    border: 1px solid lightgray;
    height: 40rem;
    padding-top: 2rem;
  }

  .a-element-a-line {
    text-align: left;
  }
</style>

