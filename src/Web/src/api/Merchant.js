import Vue from 'vue';

export const attachShop = (body) => {
  return Vue.http.post('merchant/AttachShop', body).then(responseSuccess => {
    return responseSuccess.status;
  }, responseFail => {
    return responseFail.status;
  })
}

export const bindShop = (body) => {
  return Vue.http.post('merchant/BindShop', body).then(resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail
  })
}

export const getShops = (merchantId) => {
  return Vue.http.get('merchant/GetShops', {
    headers: {
      'merchantId': merchantId
    }
  }).then(res => {
    return res;
  }, resFail => {
    return resFail
  })
}

export const addIdentity = (body) => {
  return Vue.http.post('merchant/AddIdentity', body).then(responseSuccess => {
    return responseSuccess.status;
  }, responseFail => {
    return responseFail.status;
  })
}

export const createShop = (body) => {
  return Vue.http.post('shop/Create', body).then(responseSuccess => {
    return {body : responseSuccess.body, status : responseSuccess.status} 
  }, responseFail => {
    return {status: responseFail.status}
  })
}

export const getShopTypies = () => {
  return Vue.http.get('shop/ShopTypies').then(responseSuccess => {
    return responseSuccess
  }, responseFail => {
    return responseFail
  })
}

export const updateShop = (newShop) => {
  return Vue.http.post('shop/EditShop', newShop).then(resSucess => {
    return resSucess;
  }, resFail => {
    return resFail;
  })
}

export const createProductType = (newType) => {
  return Vue.http.post('shop/productType/add', newType).then(resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  })
}

export const getProductTypeByShopName = (shopName, province, city, district) => {
  return Vue.http.get('shop/productType/getProductTypes', {
    params: {'shopName': shopName, 'province': province, 'city': city, 'district': district}
  }).then(resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  })
}

export const deleteProductType = (productTypeId) => {
  return Vue.http.delete('shop/productType/delete',{
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
  return Vue.http.post('shop/GBProduct/add', GBProduct).then(resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  })
}

export const getGBProductByShopName = (shopName, province, city, district) => {
  return Vue.http.get('shop/GBProduct/GBProducts', {
    params: {
      'shopName': shopName,
      'province': province,
      'city': city,
      'district': district
    }
  }).then(resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  })
}

export const getGBProductKeyByProductName = (productName) => {
  return Vue.http.get('shop/GBProduct/GBProductKey', {
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
  return Vue.http.post('shop/GBProduct/Update', gbProduct).then(resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  });
}

export const deleteGBProduct = (gbProductId) => {
  return Vue.http.delete('shop/GBProduct/Delete', {
    headers: {
      'gbProductId': gbProductId
    }
  }).then(resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  });
}

export const getMerchantBasicByMerchantId = (merchantId) => {
  return Vue.http.get('merchant/GetMerchantBasic', {
    headers: {
      'merchantId': merchantId
    }
  }).then(resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  })
}

export const getMerchantShopListNotChecked = (page) => {
  return Vue.http.get('merchant/GetMerchantShopListIsNotChecked', {
    params: {
      'page': page
    }
  }).then(resSuccess => {
    return resSuccess
  }, resFail => {
    return resFail
  })
}

export const getMerchantShopListNotCheckedNum = () => {
  return Vue.http.get('merchant/GetMerchantShopListNotCheckedNum').then(resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  })
}

export const getGBProductsByProductTypeId = (productTypeId) => {
  return Vue.http.get('shop/GBProduct/ProductType/GBProducts', {
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
  return Vue.http.post('merchant/CheckIdentity', body).then(resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  })
}

export const ifSetGBService = (shopId) => {
  return Vue.http.get('shop/IfSetGB', {
    headers: {
      'shopId': shopId
    }
  }).then(resSuccess => {
    return resSuccess
  }, resFail => {
    return resFail
  })
}

export const getMerchantsName = (merchantIdList) => {
  return Vue.http.post('identity/merchantInfoList', merchantIdList).then(resSuccess => {
    return resSuccess
  }, resFail => {
    return resFail
  })
} 

export const ifWriteIdentity = (merchantId, shopId) => {
  return Vue.http.get('merchant/IfWriteIdentity', {
    headers: {
      'merchantId' : merchantId,
      'shopId': shopId
    }
  }).then(resSuccess => {
    return resSuccess
  }, resFail => {
    return resFail
  })
}

export const getMerchantIdentityByMerchantId = (merchantId) => {
  return Vue.http.get('merchant/GetMerchantIdentityByMerchantId', {
    headers: {
      'merchantId': merchantId
    }
  }).then(resSuccess => {
    return resSuccess
  }, resFail => {
    return resFail
  })
}

export const getMerchantBasics = (page) => {
  return Vue.http.get('merchant/GetMerchantList', {
    params: {
      "page": page
    }
  }).then(resSuccess => {
    return resSuccess
  }, resFail => {
    return resFail
  })
}

export const getMerchantBasicsNum = () => {
  return Vue.http.get('merchant/GetMerchantNum').then(resSuccess => {
    return resSuccess
  }, resFail => {
     return resFail
  })
}

export const getMerchantShop = (merchantId, shopId) => {
  return Vue.http.get('merchant/GetMerchantShop', {
    headers: {
      'merchantId': merchantId,
      'shopId': shopId
    }
  }).then(resSuccess => {
    return resSuccess
  }, resFail => {
    return resFail
  })
}

export const getMerchantIdentity = (identityId) => {
  return Vue.http.get('merchant/GetMerchantIdentity', {
    headers: {
      'identityId': identityId
    }
  }).then(resSuccess => {
    return resSuccess
  }, resFail => {
    return resFail
  })
}

export const unbindShop = (merchantId, shopId) => {
  return Vue.http.post('merchant/UnbindShop', {
    'merchantId': merchantId,
    'shopId': shopId
  }).then(resSuccess => {
    return resSuccess
  }, resFail => {
    return resFail
  })
}