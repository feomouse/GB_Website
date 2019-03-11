import Vue from 'vue';
import Vuex from 'vuex';
import Login from './login';
import User from './user';
import user from './user';

Vue.use(Vuex);

export default new Vuex.Store({
  modules: {
    login: Login,
    user: User
  }
})