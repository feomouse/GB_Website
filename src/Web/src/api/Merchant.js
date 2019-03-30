import Vue from 'vue';

export const attachShop = (body) => {
  return Vue.http.post('/merchant/AttachShop', body).then(responseSuccess => {
    return responseSuccess.status;
  }, responseFail => {
    return responseFail.status;
  })
}

export const addIdentity = (body) => {
  return Vue.http.post('/merchant/AddIdentity', body).then(responseSuccess => {
    return responseSuccess.status;
  }, responseFail => {
    return responseFail.status;
  })
}

export const createShop = (body) => {
  return Vue.http.post('/shop/Create', body).then(responseSuccess => {
    return {body : responseSuccess.body, status : responseSuccess.status} 
  }, responseFail => {
    return {status: responseFail.status}
  })
}

export const getShopTypies = (body) => {
  return Vue.http.get('/shop/ShopTypies').then(responseSuccess => {
    return {body : responseSuccess.body, status: responseSuccess.status}
  }, responseFail => {
    return {status : responseFail.status}
  })
}

export const uploadShopPic = (formData) => {
    return Vue.http.post('/shop/UploadShopImg', formData, {
      headers: {
        'Content-Type': "multipart/form-data"
      }
    }).then(responseSuccess => {
      return {body: responseSuccess.body, status: responseSuccess.status};
    }, responseFail => {
      return {status: responseFail.status};
    })
}