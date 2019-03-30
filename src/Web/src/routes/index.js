import Vue from 'vue';
import Router from 'vue-router';
import Register from './register';
import Login from './login';
import User from './userMsg';
import Merchant from './merchant';

Vue.use(Router);

var routers = [
  ...Register,
  ...Login,
  ...User,
  ...Merchant
]

var router = new Router({
  routes: routers
});

export default router;