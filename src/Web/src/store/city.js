import cityData from '../data';

const state = {
  'cityData': cityData,
  'selectedProvince': "110000",
  'selectedCity': "110100",
  'selectedDistrict': '110101',
  'selectedProvinceName': "北京市",
  'selectedCityName': "市辖区",
  'selectedDistrictName': '东城区'
}

const getters = {
  getCityData: function(state) {
    return state.cityData
  },
  getSelectedProvince: function(state) {
    return state.selectedProvince
  },
  getSelectedCity: function(state) {
    return state.selectedCity
  },
  getSelectedDistrict: function(state) {
    return state.selectedDistrict
  },
  getSelectedProvinceName: function(state) {
    return state.selectedProvinceName
  },
  getSelectedCityName: function(state) {
    return state.selectedCityName
  },
  getSelectedDistrictName: function(state) {
    return state.selectedDistrictName
  }
}

const mutations = {
  setSelectedProvince: function (state, province) {
    state.selectedProvince = province;
  },
  setSelectedCity: function (state, city) {
    state.selectedCity = city;
  },
  setSelectedDistrict: function(state, district) {
    state.selectedDistrict = district;
  },
  setSelectedProvinceName: function (state, provinceName) {
    state.selectedProvinceName = provinceName;
  },
  setSelectedCityName:function (state, cityName) {
    state.selectedCityName = cityName;
  },
  setSelectedDistrictName: function(state, districtName) {
    state.selectedDistrictName = districtName;
  }
}

const actions = {
  commitProvince: function({commit}, province) {
    commit('setSelectedProvince', province)
  },
  commitCity: function({commit}, city) {
    commit('setSelectedCity', city)
  },
  commitDistrict: function({commit}, district) {
    commit('setSelectedDistrict', district)
  },
  commitProvinceName: function({commit}, provinceName) {
    commit('setSelectedProvinceName', provinceName)
  },
  commitCityName: function({commit}, cityName) {
    commit('setSelectedCityName', cityName)
  },
  commitDistrictName: function({commit}, districtName) {
    commit('setSelectedDistrictName', districtName)
  }
}

export default {
  state,
  getters,
  mutations,
  actions
}