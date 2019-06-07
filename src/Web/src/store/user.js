const state = {
  userId : "",
  user: {
    "pkId": "",
    "lookingImg": "",
    "address": "",
    "email": "",
    "userName": ""
  }
}

const getters = {
  userId: function(state) {
    return state.userId
  },
  user: function(state) {
    return state.user
  }
}

const mutations = {
  setUserId: function(state, userId) {
    state.userId = userId
  },
  setUser: function(state, user) {
    state.user = user
  },
  setUserImg: function(state, img) {
    state.user.lookingImg = img
  }
}

const actions = {
  commitSetUserId: function({commit}, userId) {
    commit('setUserId', userId);
  },
  commitSetUser: function({commit}, user) {
    commit('setUser', user);
  },
  commitSetUserImg: function({commit}, img) {
    commit('setUserImg', img)
  }
}

export default {
  state,
  getters,
  mutations,
  actions
}