<template>
  <div class="auto_ten">
    <div class="banner">
      <p style="float: left; cursor: pointer; margin-right: 3rem;" @click="redirectToShops">浏览门店</p>
      <p style="float: left; cursor: pointer;" @click="showSelectCityDialogShow = true">选择城市: {{selectedProvinceName + ' ' + selectedCityName}}</p>
      <p style="float: right; cursor: pointer;" @click="directToMyMessage">{{userName}} : 我的信息</p>
    </div>
    <el-dialog label-width="70px" :visible.sync="showSelectCityDialogShow">
      <el-form inline="true">
        <el-form-item label="省" style="width:40%;">
          <el-select v-model="selectedProvince" placeholder="请选择省" @change="selectProvince">
            <el-option 
              v-for="(i, k) in cityData['86']"
              :key="k"
              :label="i"
              :value="k">

            </el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="城市" style="width:40%;">
          <el-select v-model="selectedCity" placeholder="请选择市">
            <el-option
              v-for="(i, k) in cityData[selectedProvince]"
              :key="k"
              :label="i"
              :value="k">
            
            </el-option>
          </el-select>
        </el-form-item>
      </el-form>
      <div slot="footer">
        <el-button type="primary" @click="getShopsByLocation">选择</el-button>
        <el-button @click="showSelectCityDialogShow = false">取消</el-button>
      </div>
    </el-dialog>
  </div>
</template>
<script>
import * as shopApi from '../api/Shop';

export default {
  data () {
    return {
      showSelectCityDialogShow : false,
      selectedProvince: this.$store.getters.getSelectedProvince,
      selectedCity: this.$store.getters.getSelectedCity,
      //selectedDistrict: this.$store.getters.getSeletedDistrict,
      selectedProvinceName : this.$store.getters.getSelectedProvinceName,
      selectedCityName : this.$store.getters.getSelectedCityName,
      //selectedDistrictName: this.$store.getters.getSelectedDistrictName,
      userName : this.$store.getters.user.userName,
      cityData : this.$store.getters.getCityData
    }
  },
  beforeMount() {
    console.log(this.selectedProvinceName)
  },
  methods : {
    redirectToShops() {
      this.$router.push('/Shops');
    },
    directToMyMessage() {
      this.$router.push('/Customer/Basic');
    },
    getShopsByLocation() {
      this.selectedProvinceName = this.cityData['86'][this.selectedProvince];
      this.selectedCityName = this.cityData[this.selectedProvince][this.selectedCity];
      //this.selectedDistrictName = this.cityData[this.selectedCity][this.selectedDistrict];
      shopApi.GetRandomShops(this.selectedProvinceName, this.selectedCityName, this.$store.getters.getShopTypes[0].pkId).then(res => {
        if(res.status != 200) this.$message.error();

        else {
          this.showSelectCityDialogShow = false;
          this.$store.dispatch('commitProvince', this.selectedProvince);
          this.$store.dispatch('commitCity', this.selectedCity);
          this.$store.dispatch('commitDistrict', this._.keys(this.districts)[0]);
          this.$store.dispatch('commitProvinceName', this.selectedProvinceName);
          this.$store.dispatch('commitCityName', this.selectedCityName);
          this.$store.dispatch('commitDistrictName', this.cityData[this.selectedCity][this._.keys(this.cityData[this.selectedCity])[0]]);
          this.$store.dispatch('commitSetRandomShops', res.body);

          this.selectedProvince = "";
          this.selectedCity = "";
          this.selectedProvinceName = "";
          this.selectedCityName = "";

          this.$router.push('/Shops');
        }
      })
    },
    selectProvince() {
      this.selectedCity = ""
    }
  }
}
</script>
<style lang="less" scoped>
  @import '../less/container';
  @import '../less/formEle';

  .banner {
    height: 3rem;
    background: #edf6eb;
    padding: 0 12rem 0 16rem;
    font-size: 0.8rem;
    color: #666a65;
  }
</style>
