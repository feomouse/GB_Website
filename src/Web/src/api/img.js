import Vue from 'vue';

export const ImgUpload = (imgData) => {
  return Vue.http.post('imgUpload', imgData, {
    headers: {
      'Content-Type': 'multipart/form-data'
    }
  }).then((resSuccess) => {
    return resSuccess;
  }, (resFail) => {
    return resFail;
  })
}