<template>
  <div class="active-vault col-12 col-md-10 offset-md-1">
    <div class="row">
      <div class="col-12">
        <h2>{{activeVault.name}}</h2>
        <h5>{{activeVault.description}}</h5>
      </div>
      <div class="col-12">
        <div class="row">
          <vault-keeps v-for="vaultKeep in vaultKeeps" :vaultKeepData="vaultKeep"></vault-keeps>
        </div>
      </div>
    </div>

  </div>
</template>


<script>
  import VaultKeeps from '@/components/VaultKeeps.vue'
  export default {
    name: 'active-vault',
    data() {
      return {}
    },
    mounted() {
      this.$store.dispatch('getVaultKeeps', this.$route.params.id)
    },
    computed: {
      activeVault() {
        return this.$store.state.vaults.find(v => v.id == this.$route.params.id)
      },
      vaultKeeps() {
        return this.$store.state.vaultKeeps
      }
    },
    methods: {},
    components: {
      VaultKeeps
    }
  }
</script>


<style scoped>

</style>