const state = {
  token: ""
}

const getters = {
  token: function (state) {
    return state.token
  }
}

const mutations = {
  setToken: function (state, token) {
    state.token = token;
  }
}

const actions = {
  commitToken: function ({commit}, token) {
    commit('setToken', token);
  }
}

export default {
  state,
  getters,
  mutations,
  actions
}