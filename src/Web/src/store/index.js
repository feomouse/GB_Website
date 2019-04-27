import Vue from 'vue';
import Vuex from 'vuex';
import Login from './login';
import User from './user';
import Merchant from './merchant';
import Shop from './shop';
import Order from './order';
import Staff from './staff';
import City from './city';
import Manager from './manager';

Vue.use(Vuex);

export default new Vuex.Store({
  modules: {
    login: Login,
    user: User,
    merchant: Merchant,
    shop: Shop,
    order: Order,
    staff: Staff,
    city: City,
    manager: Manager
  }
})