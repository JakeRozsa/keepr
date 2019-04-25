<template>
  <div class="col-12">
    <div class="pvaults row">
      <div class="col-12 vault mb-3">
        <div class="row">
          <div class="col-12 tm pt-3 pb-3" @click="$router.push({name: 'vault', params: {id:vaultData.id}})">
            <h5 class="textfix">{{vaultData.name}}</h5>
          </div>
          <div class="col-12">
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
    background-image: url('../assets/vault-seethru.png');
    background-position: center;
    background-size: 126px;
    height: 140px;
    width: 220px;
    background-repeat: no-repeat;
  }

  .tm {
    margin: 12px 0px 0px 0px;
  }

  .textfix {
    -webkit-text-fill-color: #05004e;
    /* Will override color (regardless of order) */
    -webkit-text-stroke-width: .7px;
    -webkit-text-stroke-color: #ffffff;
    text-shadow: 2px 2px 2px black;
  }

  .fa-trash {
    -webkit-text-fill-color: rgb(68, 68, 68);
    /* Will override color (regardless of order) */
    -webkit-text-stroke-width: 1px;
    -webkit-text-stroke-color: rgb(255, 255, 255);
    text-shadow: 3px 3px 3px black;
  }

  @media only screen and (max-width: 550px) {
    .vault {
      height: 20vh;
      width: 20vw;
      background-size: contain;
      margin-right: 2vw;
    }
  }
</style>