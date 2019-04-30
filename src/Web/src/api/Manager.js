import Vue from 'vue';

export const getViolateUsers = (page) => {
  return Vue.http.get('/Manager/ViolateUsers', {
    params: {
      'page': page
    }
  }).then(resSuccess => {
    return resSuccess
  }, resFail => {
    return resFail
  })
}

export const setViolateUser = (vioUser) => {
  return Vue.http.post('/manager/SetViolateUser',vioUser).then(resSuccess => {
    return resSuccess
  }, resFail => {
    return resFail
  })
}

export const ifViolateUser = (userName) => {
  return Vue.http.get('/manager/IfInVioList',{
    params: {
      'userName': userName
    }
  }).then(resSuccess => {
    return resSuccess
  }, resFail => {
    return resFail
  })
}