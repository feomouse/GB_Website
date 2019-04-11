import Vue from 'vue';

export const addUserComment = (userComment) => {
  return Vue.http.post('/comment/addUserComment', userComment, resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  })
}

export const addReplyComment = (replyComment) => {
  return Vue.http.post('/comment/addReplyComment', replyComment, resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  })
}

export const getUserCommentByOrderId = (orderId) => {
  return Vue.http.get('/comment/getUserCommentByOrderId', {
    headers: {
      'orderId': orderId
    }
  }, resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  })
}

export const getUserCommentsByShopId = (shopId) => {
  return Vue.http.get('/comment/getUserCommentsByShopId', {
    headers: {
      'shopId': shopId
    }
  }, resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  })
}