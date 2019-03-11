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