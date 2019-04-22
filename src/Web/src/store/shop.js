var state = {
  shopId: "",
  shopName: "",
  shopSelectedName: "",
  shopList: []
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
  },
  getShopList: (state) => {
    return state.shopList
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
  },
  setShopList: (state, list) => {
    state.shopList = list;
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
  },
  commitSetShopList: ({commit}, list) => {
    commit('setShopList', list)
  }
}

export default {
  state: state,
  getters: getters,
  mutations: mutations,
  actions: actions
}