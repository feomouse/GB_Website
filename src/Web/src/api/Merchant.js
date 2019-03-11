import Vue from 'vue';

export const attachShop = (body) => {
  Vue.http.post('/v1/api/merchant/AttachShop', body).then(responseSuccess => {
    return responseSuccess.status;
  }, responseFail => {
    return responseFail.status;
  })
}

export const addIdentity = (body) => {
  Vue.http.post('v1/api/merchant/AddIdentity', body).then(responseSuccess => {
    return responseSuccess.status;
  }, responseFail => {
    return responseFail.status;
  })
}