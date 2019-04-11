var state = {
  shopId: "",
  shopName: "",
  shopSelectedName: ""
}

var getters = {
  getShopId: (state) => {
    return state.shopId;
  },
  getShopName: (state) => {
    return state.shopName;
  },
  getShopSelectedName: (state) => {
    return state.shopSelectedName;
  }
}

var mutations = {
  setShopId: (state, id) => {
    state.shopId = id;
  },
  setShopName: (state, name) => {
    state.shopName = name;
  },
  setShopSelectedName: (state, name) => {
    state.shopSelectedName = name;
  }
}

var actions = {
  commitSetShopId: ({commit}, id) => {
    commit('setShopId', id);
  },
  commitSetShopName: ({commit}, name) => {
    commit('setShopName', name);
  },
  commitSetSelectedName: ({commit}, name) => {
    commit('setShopSelectedName', name)
  }
}

export default {
  state: state,
  getters: getters,
  mutations: mutations,
  actions: actions
}