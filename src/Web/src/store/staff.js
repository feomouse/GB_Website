const state = {
  tabChange: false
}

const getters = {
  getTabChange: function(state) {
    return state.tabChange;
  }
}

const mutations = {
  setTabChange: function(state, change) {
    state.tabChange = change;
  }
}

const actions = {
  commitSetTabChange: function ({
    commit
  }, change) {
    commit('setTabChange', change);
  }
}

export default {
  state,
  getters,
  mutations,
  actions
}