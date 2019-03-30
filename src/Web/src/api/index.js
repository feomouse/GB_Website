import Vue from "vue";
import Resource from 'vue-resource';
import store from '../store/index';

Vue.use(Resource);

Vue.http.interceptors.push(function (req) {
/*   if (req.url != "/Customer/SignUp" && req.url != "/Merchant/SignUp" &&
    req.url != "/Customer/SignIn" && req.url != "/Merchant/SignIn") { */
    req.headers.set('Authorization', "Bearer " + store.getters.token);
/*   } */
})