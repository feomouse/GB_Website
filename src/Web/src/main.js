import Vue from 'vue'; 
import App from './App';
import router from './routes/index';
import Router from 'vue-router';
import Resource from 'vue-resource';
import Vuex from 'vuex';
import store from './store/index';
import ElementUI from 'element-ui';
import 'element-ui/lib/theme-chalk/index.css';

Vue.use(ElementUI);

Vue.use(Resource);

new Vue({
  el: "#app",
  template: "<App/>",
  components: {App},
  router,
  store
})