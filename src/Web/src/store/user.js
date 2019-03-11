const state = {
  name : ""
}

const getters = {

}

const mutations = {
  setName: function(state, name) {
    state.name = name
  }
}

const actions = {
  commitSetName: function({commit}, name) {
    commit('setName', name);
  }
}

export default {
  state,
  getters,
  mutations,
  actions
}