import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import {Const} from './common/Consts.js'

export const EventBus = new Vue()

Vue.config.productionTip = false
Vue.prototype.$Const = Const;
new Vue({
  router,
  render: h => h(App),
  store
}).$mount('#app')
