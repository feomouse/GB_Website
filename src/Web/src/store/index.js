import Vue from 'vue';
import Vuex from 'vuex';
import Login from './login';
import User from './user';
import Merchant from './merchant';

Vue.use(Vuex);

export default new Vuex.Store({
  modules: {
    login: Login,
    user: User,
    merchant: Merchant
  }
})