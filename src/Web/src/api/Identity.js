import Vue from 'vue';

export const SignUpRequest = (body) => {
  return Vue.http.post('/identity/register', body).then(responseSuccess => {
    return responseSuccess.status;
  }, responseFail => {
    return responseFail.status;
  })
}

export const SignInRequest = (body) => {
  return Vue.http.post('/identity/login', body).then(responseSuccess => {
    return {
      body: responseSuccess.body,
      status: responseSuccess.status
    }
  }, responseFail => {
    return responseFail.status;
  })
}

export const GetTokenByRefreshToken = (refresh) => {
  return Vue.http.post('/identity/refresh', {
    "RefreshToken": refresh
  }).then(resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  })
}

export const GetMerchantNameById = (id) => {
  return Vue.http.get('/identity/merchantInfo', {
    headers: {
      "merchantId": id
    }
  }).then(resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  })
}