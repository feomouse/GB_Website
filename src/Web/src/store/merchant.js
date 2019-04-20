var state = {
  merchantId : "",
  merchantName : "" 
};

var getters = {
  getMerchantId: function(state) {
    return state.merchantId
  },
  getMerchantName: function(state) {
    return state.merchantName
  }
}

var mutations = {
  setMerchantId : function(state, id) {
    state.merchantId = id
  },
  setMerchantName : function(state, name) {
    state.merchantName = name
  }
}

var actions = {
  commitSetMerchantName : function({commit}, id) {
    commit('setMerchantId', id)
  },
  commitSetMerchantUserName : function({commit}, name) {
    commit('setMerchantName', name)
  }
}


export default {
  state: state,
  getters: getters,
  mutations: mutations,
  actions: actions
}