var state = {
  shopId: "",
  shopName: "",
  shopSelectedName: "",
  shopList: [],
  shopTypes: [],
  randomShops: [],
  selectedShopTypeId: '',
  currentSelectedShop: {},
  selectedGBProduct: {},
  selectedShopStars: 0
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
  },
  getShopTypes: (state) => {
    return state.shopTypes
  },
  getRandomShops: (state) => {
    return state.randomShops
  },
  getSelectedShopTypeId: (state) => {
    return state.selectedShopTypeId
  },
  getCurrentSelectedShop: (state) => {
    return state.currentSelectedShop
  },
  getSelectedGBProduct: (state) => {
    return state.selectedGBProduct
  },
  getSelectedShopStars: (state) => {
    return state.selectedShopStars
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
  },
  setShopTypes: (state, types) => {
    state.shopTypes = types;
  },
  setRandomShops: (state, shops) => {
    state.randomShops = shops
  },
  setSelectedShopTypeId: (state, shopTypeId) => {
    state.selectedShopTypeId = shopTypeId
  },
  setCurrentSelectedShop: (state, shop) => {
    state.currentSelectedShop = shop
  },
  setSelectedGBProduct: (state, gbProduct) => {
    state.selectedGBProduct = gbProduct
  },
  setSelectedShopStars: (state, shopStars) => {
    state.selectedShopStars = shopStars
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
  },
  commitSetShopTypes: ({commit}, types) => {
    commit('setShopTypes', types)
  },
  commitSetRandomShops: ({commit}, shops) => {
    commit('setRandomShops', shops)
  },
  commitSetSelectedShopTypeId: ({commit}, shopTypeId) => {
    commit('setSelectedShopTypeId', shopTypeId)
  },
  commitSetCurrentSelectedShop: ({commit}, shop) => {
    commit('setCurrentSelectedShop', shop)
  },
  commitSetSelectedGBProduct: ({commit}, gbProduct) => {
    commit('setSelectedGBProduct', gbProduct)
  },
  commitSetSelectedShopStars:({commit}, shopStars) => {
    commit('setSelectedShopStars', shopStars)
  }
}

export default {
  state: state,
  getters: getters,
  mutations: mutations,
  actions: actions
}