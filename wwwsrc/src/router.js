import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import About from './views/About.vue'
// @ts-ignore
import Profile from './views/Profile.vue'
// @ts-ignore
import MainKeep from './views/MainKeep.vue'
// @ts-ignore
import MainVault from './views/MainVault.vue'



Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/about',
      name: 'about',
      component: About
    },
    {
      path: '/profile',
      name: 'profile',
      component: Profile
    },
    {
      path: '/keeps/:id',
      name: 'keep',
      component: MainKeep,
      props: true
    },
    {
      path: '/vaults/:id',
      name: 'vault',
      component: MainVault,
      props: true
    },
  ]
})
