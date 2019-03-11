import Vue from 'vue';
import Router from 'vue-router';
import Register from './register';
import Login from './login';
import User from './userMsg';

Vue.use(Router);

var routers = [
  ...Register,
  ...Login,
  ...User
]

var router = new Router({
  routes: routers
});

export default router;