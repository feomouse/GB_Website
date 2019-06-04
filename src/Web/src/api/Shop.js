import Vue from 'vue';

export const GetShopTypes = () => {
  return Vue.http.get('shop/ShopTypies').then(resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  })
}

export const AddShopTypes = (shopType) => {
  return Vue.http.post('shop/AddShopType', shopType).then(resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail
  })
}

export const SetShopType = (shopType) => {
  return Vue.http.post('shop/SetShopType', shopType).then(resSuccess => {
    return resSuccess
  }, resFail => {
    return resFail
  })
}

export const GetShopInfoByMerchantId = (merchantId) => {
  return Vue.http.get('shop/ShopInfo', {
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
  return Vue.http.get('shop/SearchShop', {
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

export const GetShopsInfoByShopNameAndCity = (shopName, province, city) => {
  return Vue.http.get('shop/GetShops', {
    params: {
      name: shopName,
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
  return Vue.http.get('shop/ShopBasicList', {
    params: {
      'shopType': shopType
    }
  }).then(successRes => {
    return successRes;
  }, errorRes => {
    return errorRes;
  })
}

export const GetShopListByShopTypeAndCity = (province, city, shopType, page) => {
  return Vue.http.get('shop/ShopBasicList', {
    params: {
      'province': province,
      'city': city,
      'shopType' : shopType,
      'page': page
    }
  }).then(successRes => {
    return successRes;
  }, errorRes => {
    return errorRes;
  })
}

export const GetShopListByCity = (province, city) => {
  return Vue.http.get('shop/ShopListOfCity', {
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
  return Vue.http.post('shop/SetGroupBuying', {
    'ShopId': shopId
  }).then(resSuccess => {
    return resSuccess;
  }, resFail => {
    return resFail;
  })
}

export const GetShopsCount = (province, city, shopType) => {
  return Vue.http.get('shop/TotalShopsCount', {
    params: {
      'province': province,
      'city': city,
      'shopType': shopType
    }
  }).then(resSuccess => {
    return resSuccess
  }, resFail => {
    return resFail
  })
}

export const GetShopListByShopIds = (shopIdList) => {
  return Vue.http.post('shop/ShopListByShopIdList', shopIdList).then(resSuccess => {
    return resSuccess
  }, resFail => {
    return resFail
  })
} 

export const GetShopsByMerchantIds = (merchantIds) => {
  return Vue.http.post('shop/GetShopsByMerchantIds', merchantIds).then(resSuccess => {
    return resSuccess
  }, resFail => {
    return resFail
  })
}

export const GetShopsByMerchantId = (merchantId) => {
  return Vue.http.get('shop/GetShopsByMerchantId', {
    headers: {
      'merchantId': merchantId
    }
  }).then(resSuccess => {
    return resSuccess
  }, resFail => {
    return resFail
  })
}

export const GetShopImgs = (shopId) => {
  return Vue.http.get('shop/GetShopImgs', {
    headers: {
      'shopId': shopId
    }
  }).then(resSuccess => {
    return resSuccess
  }, resFail => {
    return resFail
  })
}

export const AddShopImg = (body) => {
  return Vue.http.post('shop/SetShopImg', body).then(resSuccess => {
    return resSuccess
  }, resFail => {
    return resFail
  })
}

export const GetGBProductImgs = (gbProductId) => {
  return Vue.http.get('shop/GBProduct/GetGBProductImgs', {
    headers: {
      'gbProductId': gbProductId
    }
  }).then(resSuccess => {
    return resSuccess
  }, resFail => {
    return resFail
  })
}

export const AddGBProductImg = (body) => {
  return Vue.http.post('shop/GBProduct/SetGBProductImg', body).then(resSuccess => {
    return resSuccess
  }, resFail => {
    return resFail
  })
}

export const GetRandomShops = (province, city, shopTypeId) => {
  return Vue.http.get('shop/GetRandomShops', {
    params: {
      'province': province,
      'city': city
    },
    headers: {
      'shopTypeId': shopTypeId
    }
  }).then(resSuccess => {
    return resSuccess
  }, resFail => {
    return resFail
  })
}

export const GetShopsByDistrict = (province, city, district, shopTypeId, page) => {
  return Vue.http.get('shop/GetShopsByDistrictAndType', {
    params: {
      'province': province,
      'city': city,
      'district': district,
    },
    headers: {
      'shopTypeId': shopTypeId,
      'page': page
    }
  }).then(resSuccess => {
    return resSuccess
  }, resFail => {
    return resFail
  })
}

export const GetShopsNumByDistrictAndShopType = (province, city, district, shopTypeId) => {
  return Vue.http.get('shop/GetShopsNumByDistrictAndShopType', {
    params: {
      'province': province,
      'city': city,
      'district': district
    },
    headers: {
      'shopTypeId': shopTypeId
    }
  }).then(resSuccess => {
    return resSuccess
  }, resFail => {
    return resFail
  })
}

export const GetGBProductsFirstImg = (body) => {
  return Vue.http.post('shop/GBProduct/GetGBProductsFirstImg', body).then(resSuccess => {
    return resSuccess
  }, resFail => {
    return resFail
  })
}