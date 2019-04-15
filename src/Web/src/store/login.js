const state = {
  token: "",
  refreshToken: ""
}

const getters = {
  token: function (state) {
    return state.token
  },
  getRefreshToken : function (state) {
    return state.refreshToken
  }
}

const mutations = {
  setToken: function (state, token) {
    state.token = token;
  },
  setRefreshToken: function (state, token) {
    state.refreshToken = token;
  }
}

const actions = {
  commitToken: function ({commit}, token) {
    commit('setToken', token);
  },
  commitRefreshToken: function ({commit}, refresh) {
    commit('setRefreshToken', refresh);
  }
}

export default {
  state,
  getters,
  mutations,
  actions
}