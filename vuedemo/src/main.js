import Vue from 'vue'
import './plugins/axios'
import App from './App.vue'

import axios from 'axios'
import bootstrap from 'bootstrap'

Vue.config.productionTip = false;
Vue.prototype.$http = axios;

new Vue({
  render: h => h(App),
}).$mount('#app')
