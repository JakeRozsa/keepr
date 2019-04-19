<template>
  <div class="vaultdrop">
    <a class="dropdown-item" @click="addToVault(vaultData)">{{vaultData.name}}</a>

  </div>
</template>


<script>
  export default {
    name: 'vaultdrop',
    data() {
      return {}
    },
    props: ['vaultData', 'keepData'],
    computed: {},
    methods: {
      addToVault(vaultData) {
        let vaultId = vaultData.id
        let keepId = this.keepData.id
        let payload = {
          vaultId,
          keepId
        }
        this.$store.dispatch('CreateVaultKeep', payload)
      }
    },
    components: {}
  }
</script>


<style scoped>

</style>