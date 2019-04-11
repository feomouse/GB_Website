import Vue from 'vue';
import Router from 'vue-router';
import Register from './register';
import Login from './login';
import User from './userMsg';
import Merchant from './merchant';
import Shop from './shop';
import Order from './order';

Vue.use(Router);

var routers = [
  ...Register,
  ...Login,
  ...User,
  ...Merchant,
  ...Shop,
  ...Order
]

var router = new Router({
  routes: routers
});

export default router;