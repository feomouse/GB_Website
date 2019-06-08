import Vue from 'vue';

export const getUserBasicMessage = (UserId) => {
/*   var body = JSON.stringify(UserId); */

  return Vue.http.get('user/userMessage', {
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
  return Vue.http.post('user/SetUserName', body, {
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
  return Vue.http.post('user/SetAddress', body, {
    headers: {
      'Content-Type': 'application/json'
    }
  }).then(responseSuccess => {
    return responseSuccess.status;
  }, responseFail => {
    return responseFail.status;
  })
}

export const setCustomerImg = (userId, fileName) => {
  return Vue.http.post('user/SetImg', {
    'UserId': userId,
    'FileName': fileName
  }).then(responseSuccess => {
    return responseSuccess;
  }, responseFail => {
    return responseFail;
  })
}

export const getCustomers = (page) => {
  return Vue.http.get("user/GetUsers", {
    params: {
      'page': page
    }
  }).then(resSuccess => {
    return resSuccess
  }, resFail => {
    return resFail
  })
}

export const getCustomersNum = () => {
  return Vue.http.get('user/GetUserNum').then(resSuccess => {
    return resSuccess
  }, resFail => {
    return resFail
  })
}

export const getUsersImg = (usersName) => {
  return Vue.http.post('user/GetUserImgsByUsersName', usersName).then(resSuccess => {
    return resSuccess
  }, resFail => {
    return resFail
  })
}