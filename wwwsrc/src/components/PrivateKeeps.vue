<template>
  <div class="privatekeeps col-4 ">
    <div class="row">
      <div class="col-11 keeprcard card mb-3">
        <div class="row">
          <div class="col-12" @click="$router.push({name:'keep', params: {id:keeprData.id}})">
            <img class="pkeep-img card-img-top" :src="pkeepimg" alt="">
            <hr>
            <h2>{{keeprData.name}}</h2>
            <h5>{{keeprData.description}}</h5>
          </div>
        </div>
        <div class="row">
          <div class="col-4">
            <p>
              <i class="far fa-eye"></i>
              {{keeprData.views}}</p>
          </div>
          <div class="col-4">
            <p>
              <i class="fas fa-chess-rook"></i>
              {{keeprData.keeps}}</p>
          </div>
          <div class="col-4">
            <p>
              <i class="fas fa-share"></i>
              {{keeprData.shares}}</p>
          </div>
          <div class="dropdown col-3">
            <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton"
              data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
              + vault
            </button>
            <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
              <vault-drop v-for="vault in vaults" :vaultData="vault" :keepData="keeprData"></vault-drop>

            </div>
          </div>
          <div class="col-3 offset-6">
            <i class="fas fa-trash" @click="deleteKeep(keeprData)"></i>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
  import VaultDrop from '@/components/VaultDrop.vue'
  export default {
    name: 'privatekeeps',
    props: ['keeprData'],
    data() {
      return {}
    },
    computed: {
      pkeepimg() {
        return this.keeprData.img
      },
      vaults() {
        return this.$store.state.vaults
      }
    },
    methods: {
      deleteKeep(keeprData) {
        this.$store.dispatch('deleteKeep', keeprData)
      }
    },
    components: {
      VaultDrop
    }
  }
</script>


<style scoped>
  h2 {
    margin-top: -10px;
  }

  .keeprcard {
    display: flex;
    justify-content: center;
    background-color: #a9c6de;
    box-shadow: 5px 5px 5px rgba(0, 0, 0, 0.555);
    padding: 5px;
  }


  .pkeep-img {
    margin-top: 5px;
  }
</style>