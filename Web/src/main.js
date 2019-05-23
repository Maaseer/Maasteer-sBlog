import Vue from 'vue'
import './plugins/axios'
import VueRouter from 'vue-router'
import App from './App.vue'


import axios from 'axios'
import bootstrap from 'bootstrap'

import Home from './components/Home.vue'

import Message from './components/Message.vue'

import Articles from './components/Articles.vue'

Vue.config.productionTip = false;
Vue.prototype.$http = axios;
//全局Host
Vue.prototype.$host = 'http://localhost:6005/api/';
Vue.use(VueRouter);


//配置路由
const router = new VueRouter({
  routes:[
    {path:"/",component:Home},
    {path:"/:searchStr",component:Home},
    {path:"/message",component:Message},
    {path:"/article/:id",component:Articles}
  ],
  mode:"history"  
  
})


new Vue({
  router,
  render: h => h(App),
}).$mount('#app')
