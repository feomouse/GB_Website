var state = {
  OrdersListNotPayed : [],
  OrdersListIsPayedNotUsed : [],
  OrdersListIsUsed : []
};

var getters = {
  getOrdersListNotPayed: function(state) {
    return state.OrdersListNotPayed
  },
  getOrdersListIsPayedNotUsed: function(state) {
    return state.OrdersListIsPayedNotUsed
  },
  getOrdersListIsUsed: function(state) {
    return state.OrdersListIsUsed
  }
}

var mutations = {
  setOrdersListNotPayed : function(state, orders) {
    state.OrdersListNotPayed = orders
  },
  setOrdersListIsPayedNotUsed : function(state, orders) {
    state.OrdersListIsPayedNotUsed = orders
  },
  setOrdersListIsUsed : function(state, orders) {
    state.OrdersListIsUsed = orders
  }
}

var actions = {
  commitSetOrdersListNotPayed : function({commit}, orders) {
    commit('setOrdersListNotPayed', orders)
  },
  commitSetOrdersListIsPayedNotUsed : function({commit}, orders) {
    commit('setOrdersListIsPayedNotUsed', orders)
  },
  commitSetOrdersListIsUsed: function({commit}, orders) {
    commit('setOrdersListIsUsed', orders)
  }
}


export default {
  state: state,
  getters: getters,
  mutations: mutations,
  actions: actions
}