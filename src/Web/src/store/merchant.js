var state = {
  merchantId : ""
};

var getters = {
  getMerchantId: function(state) {
    return state.merchantId
  }
}

var mutations = {
  setMerchantId : function(state, id) {
    state.merchantId = id
  } 
}

var actions = {
  commitSetMerchantName : function({commit}, id) {
    commit('setMerchantId', id)
  }
}


export default {
  state: state,
  getters: getters,
  mutations: mutations,
  actions: actions
}