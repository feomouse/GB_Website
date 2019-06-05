import Vue from 'vue'; 
import App from './App';
import router from './routes/index';
import Router from 'vue-router';
import Vuex from 'vuex';
import store from './store/index';
import ElementUI from 'element-ui';
import HighchartsVue from 'highcharts-vue';
import 'element-ui/lib/theme-chalk/index.css';
import './api/index';
import './components/svgIcon';
import _ from 'lodash';

Vue.use(ElementUI);
Vue.use(HighchartsVue)

Vue.prototype._ = _; 

new Vue({
  el: "#app",
  template: "<App/>",
  components: {
    'App': App
  },
  router,
  store
})