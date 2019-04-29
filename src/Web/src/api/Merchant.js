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

export const updateShop = (newShop) => {
  return Vue.http.post('/shop/EditShop', newShop).then(resSucess => {
    return resSucess;
  }, resFail => {
    return resFail;
  })
}

export const createProductType = (newType) => {
  return Vue.http.post('/shop/productType/add', newType).then(resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  })
}

export const getProductTypeByShopName = (shopName, province, city) => {
  return Vue.http.get('/shop/productType/getProductTypes', {
    params: {'shopName': shopName, 'province': province, 'city': city}
  }).then(resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  })
}

export const deleteProductType = (productTypeId) => {
  return Vue.http.delete('/shop/productType/delete',{
    body: {
      'ProductTypePkId': productTypeId
    }
  }).then(resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  })
}

export const addGBProduct = (GBProduct) => {
  return Vue.http.post('/shop/GBProduct/add', GBProduct).then(resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  })
}

export const getGBProductByShopName = (shopName, province, city) => {
  return Vue.http.get('/shop/GBProduct/GBProducts', {
    params: {
      'shopName': shopName,
      'province': province,
      'city': city
    }
  }).then(resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  })
}

export const getGBProductKeyByProductName = (productName) => {
  return Vue.http.get('/shop/GBProduct/GBProductKey', {
    params: {
      'productName': productName
    }
  }, resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  })
} 

export const updateGBProduct = (gbProduct) => {
  return Vue.http.post('/shop/GBProduct/Update', gbProduct).then(resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  });
}

export const deleteGBProduct = (gbProductName) => {
  return Vue.http.delete('/shop/GBProduct/Delete', {
    params: {
      gbProduct: gbProductName
    }
  }).then(resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  });
}

export const getMerchantBasicByMerchantId = (merchantId) => {
  return Vue.http.get('/merchant/GetMerchantBasic', {
    headers: {
      'merchantId': merchantId
    }
  }).then(resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  })
}

export const getMerchantBasicListNotChecked = (page) => {
  return Vue.http.get('/merchant/GetMerchantBasicListIsNotChecked', {
    params: {
      'page': page
    }
  }).then(resSuccess => {
    return resSuccess
  }, resFail => {
    return resFail
  })
}

export const getGBProductsByProductTypeId = (productTypeId) => {
  return Vue.http.get('/shop/GBProduct/ProductType/GBProducts', {
    headers: {
      'productTypeId': productTypeId
    }
  }).then(resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  })
}

export const checkIdentity = (body) => {
  return Vue.http.post('/merchant/CheckIdentity', body).then(resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  })
}

export const ifSetGBService = (merchantId) => {
  return Vue.http.get('/shop/IfSetGB', {
    headers: {
      'merchantId': merchantId
    }
  }).then(resSuccess => {
    return resSuccess
  }, resFail => {
    return resFail
  })
}

export const getMerchantsName = (merchantIdList) => {
  return Vue.http.post('/identity/merchantInfoList', merchantIdList).then(resSuccess => {
    return resSuccess
  }, resFail => {
    return resFail
  })
} 

export const ifWriteIdentity = (merchantId) => {
  return Vue.http.get('/merchant/IfWriteIdentity', {
    headers: {
      'merchantId' : merchantId
    }
  }).then(resSuccess => {
    return resSuccess
  }, resFail => {
    return resFail
  })
}

export const getMerchantIdentityByMerchantId = (merchantId) => {
  return Vue.http.get('/merchant/GetMerchantIdentityByMerchantId', {
    headers: {
      'merchantId': merchantId
    }
  }).then(resSuccess => {
    return resSuccess
  }, resFail => {
    return resFail
  })
}