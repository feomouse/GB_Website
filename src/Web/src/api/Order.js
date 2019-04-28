import Vue from 'vue';

export const addOrder = (order) => {
  return Vue.http.post('/order/add', order).then(resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  })
}

export const getOrderByUserId = (userId) => {
  return Vue.http.get('/order/getOrdersList', {
    headers: {
      'userId': userId
    }
  }).then(resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  });
}

export const pay = (order) => {
  return Vue.http.post('/order/pay',order).then(resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  })
}

export const ensureUsed = (order) => {
  return Vue.http.post('/order/SetUsed', order).then(resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  })
}