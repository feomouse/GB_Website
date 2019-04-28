import cityData from '../data';

const state = {
  'cityData': cityData,
  'selectedProvince': "110000",
  'selectedCity': "110100",
  'selectedProvinceName': "北京市",
  'selectedCityName': "市辖区",
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
  getSelectedProvinceName: function(state) {
    return state.selectedProvinceName
  },
  getSelectedCityName: function(state) {
    return state.selectedCityName
  }
}

const mutations = {
  setSelectedProvince: function (state, province) {
    state.selectedProvince = province;
  },
  setSelectedCity: function (state, city) {
    state.selectedCity = city;
  },
  setSelectedProvinceName: function (state, provinceName) {
    state.selectedProvinceName = provinceName;
  },
  setSelectedCityName:function (state, cityName) {
    state.selectedCityName = cityName;
  }
}

const actions = {
  commitProvince: function({commit}, province) {
    commit('setSelectedProvince', province)
  },
  commitCity: function({commit}, city) {
    commit('setSelectedCity', city)
  },
  commitProvinceName: function({commit}, provinceName) {
    commit('setSelectedProvinceName', provinceName)
  },
  commitCityName: function({commit}, cityName) {
    commit('setSelectedCityName', cityName)
  }
}

export default {
  state,
  getters,
  mutations,
  actions
}