import Vue from 'vue';

export const GetShopTypes = () => {
  return Vue.http.get('/shop/ShopTypies').then(resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  })
}

export const GetShopInfoByMerchantId = (merchantId) => {
  return Vue.http.get('/shop/ShopInfo', {
    headers: {
      'Content-Type': 'application/json',
      'merchantId': merchantId
    }
  }).then(successRes => {
    return successRes;
  }, errorRes => {
    return errorRes;
  })
}

export const GetShopInfoByShopNameAndCity = (shopName, province, city) => {
  return Vue.http.get('/shop/SearchShop', {
    params: {
      name : shopName,
      'province': province,
      'city': city
    }
  }).then(successRes => {
    return successRes;
  }, errorRes => {
    return errorRes;
  })
}

export const GetShopBasicListByShopType = (shopType) => {
  return Vue.http.get('/shop/ShopBasicList', {
    params: {
      'shopType': shopType
    }
  }).then(successRes => {
    return successRes;
  }, errorRes => {
    return errorRes;
  })
}

export const GetShopListByShopTypeAndCity = (province, city, shopType) => {
  return Vue.http.get('/shop/ShopBasicList', {
    params: {
      'province': province,
      'city': city,
      'shopType' : shopType
    }
  }).then(successRes => {
    return successRes;
  }, errorRes => {
    return errorRes;
  })
}

export const GetShopListByCity = (province, city) => {
  return Vue.http.get('/shop/ShopListOfCity', {
    params: {
      'province': province,
      'city': city
    }
  }).then(resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  })
}

export const SetGroupBuying = (shopId) => {
  return Vue.http.post('/shop/SetGroupBuying', {
    'ShopId': shopId
  }).then(resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  })
}