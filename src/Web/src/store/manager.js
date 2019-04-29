const state = {
  id: "",
  userName: "",
  identityMerchantId: ""
}

const getters = {
  getManagerId: function (state) {
    return state.id
  },
  getManagerName: function (state) {
    return state.userName;
  },
  getIdentityMerchantId: function (state) {
    return state.identityMerchantId
  }
}

const mutations = {
  setManagerId: function (state, id) {
    state.id = id;
  },
  setManagerName: function(state, name) {
    state.userName = name
  },
  setIdentityMerchantId: function (state, id) {
    state.identityMerchantId = id
  }
}

const actions = {
  commitManagerId: function ({
    commit
  }, id) {
    commit('setManagerId', id);
  },
  commitManagerName: function ({
    commit
  }, name) {
    commit('setManagerName', name);
  },
  commitIdentityMerchantId: function ({
    commit
  }, id) {
    commit('setIdentityMerchantId', id)
  }
}

export default {
  state,
  getters,
  mutations,
  actions
}