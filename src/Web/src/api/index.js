import Vue from "vue";
import Store from '../store/index'; 


Vue.http.push(function(req) {
  if (req.url != "/Customer/SignUp" && req.url != "/Merchant/SignUp" 
      && req.url != "/Customer/SignIn" && req.url != "/Merchant/SignIn")
  {
    req.headers.set('Authorization', "Bearer" + Store.login.getters.token());
  }
})