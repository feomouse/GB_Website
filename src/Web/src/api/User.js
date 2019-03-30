import Vue from 'vue';

export const getUserBasicMessage = (UserId) => {
/*   var body = JSON.stringify(UserId); */

  return Vue.http.get('/user/userMessage', {
      headers: {
        'Content-Type': 'application/json',
        'UserId': UserId
      }
    }).then(responseSuccess => {
    return { body: responseSuccess.body, status: responseSuccess.status };
  }, responseFail => {
    return { body: responseFail.body, status: responseFail.status };
  })
}

export const setCustomerUserName = (body) => {
  return Vue.http.post('/user/SetUserName', body, {
    headers: {
      'Content-Type': 'application/json'
    }
  }).then(responseSuccess => {
    return responseSuccess.status;
  }, responseFail => {
    return responseFail.status;
  })
}

export const setCustomerAddress = (body) => {
  return Vue.http.post('/user/SetAddress', body, {
    headers: {
      'Content-Type': 'application/json'
    }
  }).then(responseSuccess => {
    return responseSuccess.status;
  }, responseFail => {
    return responseFail.status;
  })
}

export const upLoadCustomerImg = (formData) => {
  return Vue.http.post('/user/uploadImg', formData,
  {
    headers: {
      'Content-Type': "multipart/form-data"
    }
  }).then(responseSuccess => {
    return responseSuccess.body;
  }, responseFail => {
    return responseFail.status;
  })
}