import Vue from 'vue';

export const setCustomerImg = (body) => {
  return Vue.http.post('user/SetImg', body).then(responseSuccess => {
    return responseSuccess.status;
  }, responseFail => {
    return responseFail.status;
  })
}

export const setCustomerAddress = (body) => {
  return Vue.http.post('user/SetAddress', body).then(responseSuccess => {
    return responseSuccess.status;
  }, responseFail => {
    return responseFail.status;
  })
}

export const upLoadCustomerImg = (formData) => {
  return Vue.http.post('user/uploadImg', formData).then(responseSuccess => {
    return responseSuccess.status;
  }, responseFail => {
    return responseFail.status;
  })
}