<template>
  <div class="privatekeeps col-4">
    <div class="row">
      <div class="col-12 keeprcard card-column">
        <div class="row">
          <div class="col-12" @click="$router.push({name:'keep', params: {id:keepData.id}})">
            <img class="pkeep-img card-img-top" :src="keepimg" alt="">
            <hr>
            <h2>{{keepData.name}}</h2>
            <h5>{{keepData.description}}</h5>
          </div>
        </div>
        <div class="row">
          <div class="col-4">
            <p>
              <i class="far fa-eye"></i>
              {{keepData.views}}</p>
          </div>
          <div class="col-4">
            <p>
              <i class="fas fa-chess-rook"></i>
              {{keepData.keeps}}</p>
          </div>
          <div class="col-4">
            <p>
              <i class="fas fa-share"></i>
              {{keepData.shares}}</p>
          </div>
          <div class="dropdown col-3">
            <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton"
              data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
              + vault
            </button>
            <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
              <vault-drop v-for="vault in vaults" :vaultData="vault" :keepData="keepData"></vault-drop>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
  import VaultDrop from '@/components/VaultDrop.vue'
  export default {
    name: 'Keeps',
    props: ['keepData'],
    data() {
      return {}
    },
    computed: {
      keepimg() {
        return this.keepData.img
      },
      vaults() {
        return this.$store.state.vaults
      }
    },
    methods: {
      setActiveKeep() {
        return this.$store.dispatch('getActiveKeep')
      }
    },
    components: {
      VaultDrop
    }
  }
</script>

<style scoped>
  .keeps {
    max-width: 22vw;
    margin: 5px 1vw;
  }


  .keep-img {
    object-fit: contain;
  }

  .keeprcard {
    background-color: #a9c6de;
    max-width: 25vw;
    padding: 10px;
    border-radius: 5px;
    box-shadow: 5px 5px 5px gray;
  }

  @media only screen and (max-width: 450px) {
    .keeps {
      min-width: 90vw;
      margin-left: 4vw;
      text-align: center;
    }
  }
</style>