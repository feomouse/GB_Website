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