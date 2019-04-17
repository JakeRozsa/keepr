<template>
  <div class="vaults col-12 card" @click="$router.push({name: 'activevault', params: {id:vaultData.id}})">
    {{vaultData.name}}
  </div>
</template>


<script>
  export default {
    name: 'vaults',
    props: ['vaultData'],
    data() {
      return {}
    },
    computed: {},
    methods: {},
    components: {}
  }
</script>


<style scoped>
</style>