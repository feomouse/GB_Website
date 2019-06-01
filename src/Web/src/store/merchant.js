var state = {
  merchantId : "",
  merchantName : "",
  merchantShopId: "",
  merchantShops: [],
  merchantCurrentShop: {}
};

var getters = {
  getMerchantId: function(state) {
    return state.merchantId
  },
  getMerchantName: function(state) {
    return state.merchantName
  },
  getMerchantShopId: function(state) {
    return state.merchantShopId
  },
  getMerchantShops: function(state) {
    return state.merchantShops
  },
  getMerchantCurrentShop: function(state) {
    return state.merchantCurrentShop
  }
}

var mutations = {
  setMerchantId : function(state, id) {
    state.merchantId = id
  },
  setMerchantName : function(state, name) {
    state.merchantName = name
  },
  setMerchantShopId: function(state, shopId) {
    state.merchantShopId = shopId
  },
  setMerchantShops: function(state, shops) {
    state.merchantShops = shops
  },
  setMerchantCurrentShop: function(state, shop) {
    state.merchantCurrentShop = shop
  }
}

var actions = {
  commitSetMerchantName : function({commit}, id) {
    commit('setMerchantId', id)
  },
  commitSetMerchantUserName : function({commit}, name) {
    commit('setMerchantName', name)
  },
  commitSetMerchantShopId : function({commit}, shopId) {
    commit('setMerchantShopId', shopId)
  },
  commitSetMerchantShops: function({commit}, shops) {
    commit('setMerchantShops', shops)
  },
  commitSetMerchantCurrentShop: function({commit}, shop) {
    commit('setMerchantCurrentShop', shop)
  }
}


export default {
  state: state,
  getters: getters,
  mutations: mutations,
  actions: actions
}