<template>
  <div class="col-6">
    <div class="pvaults row">
      <div class="col-11 vault mb-3">
        <div class="row">
          <div class="col-11 tm" @click="$router.push({name: 'vault', params: {id:vaultData.id}})">
            <h5 class="textfix">{{vaultData.name}}</h5>
            <h6 class="textfix">{{vaultData.description}}</h6>
          </div>
          <div class="col-1">
            <i class="fas fa-trash" @click="deleteVault(vaultData)"></i>
          </div>
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
  .vcard {
    box-shadow: 5px 5px 5px rgba(0, 0, 0, 0.555);
  }

  .vault {
    background-image: url('../assets/lock.png');
    background-position: center;
    background-size: 150px;
    min-height: 160px;
  }

  .tm {
    margin-top: 80px;
    margin-left: 5px;
  }

  .textfix {
    color: black;
    -webkit-text-fill-color: rgb(0, 0, 0);
    /* Will override color (regardless of order) */
    -webkit-text-stroke-width: 1px;
    -webkit-text-stroke-color: rgb(255, 255, 255);
  }
</style>