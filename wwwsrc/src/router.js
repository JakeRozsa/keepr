import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Loggin from './views/Loggin.vue'
// @ts-ignore
import About from './views/About.vue'
// @ts-ignore
import MainKeep from './views/MainKeep.vue'


Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/mainkeep/:id',
      name: 'MainKeep',
      component: MainKeep
    },
    {
      path: '/account',
      name: 'loggin',
      component: Loggin
    },
    {
      path: '/about',
      name: 'about',
      component: About
    }
  ]
})
