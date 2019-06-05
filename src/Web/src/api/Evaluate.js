import Vue from 'vue';

export const addUserComment = (userComment) => {
  return Vue.http.post('comment/addUserComment', userComment, resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  })
}

export const addReplyComment = (replyComment) => {
  return Vue.http.post('comment/addReplyComment', replyComment, resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  })
}

export const getUserCommentByOrderId = (orderId) => {
  return Vue.http.get('comment/getUserCommentByOrderId', {
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
  return Vue.http.get('comment/getUserCommentsByShopId', {
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
  return Vue.http.get('comment/getUserCommentCount', {
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

export const getReplyCommentsByCommentIds = (commentIds) => {
  return Vue.http.post('comment/getReplyComments', commentIds).then(resSuccess => {
    return resSuccess
  }, resFail => {
    return resFail
  })
}

export const getCommentsNumAndAverStarsNumByShopIds = (shopIds) => {
  return Vue.http.post('comment/getCommentsNumAndAverStarsNumByShopIds', shopIds).then(resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  })
}

export const getCommentStarsMoreThree = (shopId, year) => {
  return Vue.http.get('comment/getCommentStarsMoreThree', {
    headers: {
      'shopId': shopId,
      'year': year
    }
  }, resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  })
}
/*
export const getCommentStarsLessThree = (shopId, year) => {
  return Vue.http.get('comment/getCommentStarsLessThree', {
    headers: {
      'shopId': shopId,
      'year': year
    }
  }, resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  })
}*/