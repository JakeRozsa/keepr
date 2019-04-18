<template>
  <div class="pvaults row">
    <div class="col-12 card" @click="$router.push({name: 'vault', params: {id:vaultData.id}})">
      <p>{{vaultData.name}} - {{vaultData.description}} {{vaultData.id}}</p>

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
      // viewVault(vaultId) {
      //   this.$router.push({ name: 'vault', params: { vaultId: vaultId } })
      // }
    },
    components: {}
  }
</script>


<style scoped>

</style>