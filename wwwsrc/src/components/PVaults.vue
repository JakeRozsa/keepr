<template>
  <div class="pvaults row">
    <div class="col-12 card">
      <div class="row">
        <div class="col-11" @click="$router.push({name: 'vault', params: {id:vaultData.id}})">
          <p>{{vaultData.name}} - {{vaultData.description}} {{vaultData.id}}</p>
        </div>
        <div class="col-1">
          <i class="fas fa-trash" @click="deleteVault(vaultData)"></i>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
  export default {
    name: 'pvaults',
    props: ['vaultData'],
    data() {
      return {}
    },
    mounted() {
      this.$store.dispatch('getVaults')
    },
    computed: {
      vaults() {
        return this.$store.state.vaults
      }
    },
    methods: {
      deleteVault(vaultData) {
        this.$store.dispatch('deleteVault', vaultData)
      }
    },
    components: {}
  }
</script>


<style scoped>

</style>