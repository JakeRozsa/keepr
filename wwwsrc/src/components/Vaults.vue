<template>
  <div class="vaults col-12 card" @click="$router.push({name: 'activevault', params: {id:vaultData.id}})">
    <p>{{vaultData.name}}</p>
    <p>{{vaultData.description}}</p>
    VAULTS HERE
    <vault-keeps></vault-keeps>
  </div>
</template>


<script>
  import VaultKeeps from "@/components/VaultKeeps.vue"

  export default {
    name: 'vaults',
    props: ['vaultData'],
    data() {
      return {}
    },
    computed: {},
    methods: {},
    components: {
      VaultKeeps
    }
  }
</script>


<style scoped>
</style>