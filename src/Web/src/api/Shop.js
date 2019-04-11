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

export const GetShopInfoByShopName = (shopName) => {
  return Vue.http.get('/shop/SearchShop', {
    params: {
      name : shopName
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

export const GetShopListByShopType = (shopType) => {
  return Vue.http.get('/shop/ShopLists', {
    params: {
      'shopType' : shopType
    }
  }).then(successRes => {
    return successRes;
  }, errorRes => {
    return errorRes;
  })
}