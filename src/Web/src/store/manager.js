const state = {
  userName: ""
}

const getters = {
  getManagerName: function (state) {
    return state.userName;
  }
}

const mutations = {
  setManagerName: function(state, name) {
    state.userName = name
  }
}

const actions = {
  commitManagerName: function ({
    commit
  }, name) {
    commit('setManagerName', name);
  }
}

export default {
  state,
  getters,
  mutations,
  actions
}