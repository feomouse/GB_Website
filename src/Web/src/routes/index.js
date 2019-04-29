import Vue from 'vue';
import Router from 'vue-router';
import Register from './register';
import Login from './login';
import Merchant from './merchant';
import Shop from './shop';
import User from './user';
import Manager from './manager';

Vue.use(Router);

var routers = [
  ...Register,
  ...Login,
  ...User,
  ...Merchant,
  ...Shop,
  ...Manager
]

var router = new Router({
  routes: routers
});

export default router;