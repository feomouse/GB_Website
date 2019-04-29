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

export const getUserCommentsByShopId = (shopId, page) => {
  return Vue.http.get('/comment/getUserCommentsByShopId', {
    headers: {
      'shopId': shopId,
    },
    params: {
      'page': page
    }
  }, resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  })
}

export const getUserCommentCount = (shopId) => {
  return Vue.http.get('/comment/getUserCommentCount', {
    headers: {
      'shopId': shopId
    }
  }, resSuccess => {
    return resSuccess
  }, resFail => {
    return resFail
  })
}

export const getReplyCommentByCommentId = (commentId) => {
  return Vue.http.get('comment/getReplyComment', {
    headers: {
      'commentId': commentId
    }
  }, resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  })
}