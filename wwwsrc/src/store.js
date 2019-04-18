import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? '//localhost:5000/' : '/'

let auth = Axios.create({
  baseURL: baseUrl + "account/",
  timeout: 3000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    keeps: [],
    activeKeep: {},
    vaults: [],
    vaultKeeps: []
  },
  mutations: {
    addKeep(state, data) {
      state.keeps.push(data)
    },
    addVault(state, data) {
      state.vaults.push(data)
    },
    addVaultKeep(state, data) {
      state.vaultKeeps.push(data)
    },
    setUser(state, user) {
      state.user = user
    },
    setKeeps(state, data) {
      state.keeps = data
    },
    setVaults(state, data) {
      state.vaults = data
    },
    setVaultKeeps(state, data) {
      state.vaultKeeps = data
    },
    setActiveKeep(state, data) {
      state.activeKeep = data
    }
  },
  actions: {
    // #region --AUTH STUFF--
    register({ commit, dispatch }, newUser) {
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('[registration failed] :', e)
        })
    },
    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
          // router.push({ name: 'home' })
        })
        .catch(e => {
          // router.push({ name: "loggin" })
          console.log('not authenticated')
        })
    },
    login({ commit, dispatch }, creds) {
      auth.post('login', creds)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('Login Failed')
        })
    },
    logout({ commit, dispatch }) {
      auth.delete('Logout')
        .then(res => {
          let data = {}
          // router.push({ name: 'loggin' })
          commit('setUser', data)
        })
    },
    // #endregion

    CreateKeep({ commit, dispatch }, payload) {
      console.log(payload)
      api.post('keeps', payload)
        .then(res => {
          commit('addKeep', res.data)
          dispatch('getKeeps', res.data)
          dispatch('getMyKeeps', res.data)
        })
    },
    CreateVault({ commit, dispatch }, payload) {
      api.post('/vaults', payload)
        .then(res => {
          console.log(res)
          commit('addVault', res.data)
          dispatch('getVaults', res.data)

        })
    },
    CreateVaultKeep({ commit, dispatch }, payload) {
      api.post('/vaultkeeps', payload)
        .then(res => {
          console.log(res)
          commit('addVaultKeep', res.data)
        })
    },
    getActiveKeep({ commit, dispatch }) {
      api.get('keeps')
        .then(res => {
          commit('setActiveKeep', res.data)
        })
    },
    getKeeps({ commit, dispatch }, payload) {
      api.get('keeps')
        .then(res => {
          commit('setKeeps', res.data)
        })
    },
    getMyKeeps({ commit, dispatch }) {
      api.get('keeps/user/profile')
        .then(res => {
          commit('setKeeps', res.data)
        })
    },
    getVaults({ commit, dispatch }) {
      api.get('/vaults')
        .then(res => {
          commit('setVaults', res.data)
        })
    },
    getVaultKeeps({ commit, dispatch }, payload) {
      api.get('vaultkeeps/' + payload)
        .then(res => {
          commit('setVaultKeeps', res.data)
        })
    },
    deleteKeep({ commit, dispatch }, id) {
      api.delete('keeps/' + id.id)
        .then(res => {
          dispatch('getKeeps', res.data.userId)
        })
    },
    deleteVault({ commit, dispatch }, payload) {
      api.delete('vaults/' + payload.id)
        .then(res => {
          dispatch('getVaults', res.data.userId)
        })
    },
    deleteVaultKeep({ commit, dispatch }, payload) {
      api.delete('vaultkeeps/' + payload.vaultId + '/' + payload.keepId)
        .then(res => {
          dispatch('getVaultKeeps', res.data)
        })
    },
  }
})
