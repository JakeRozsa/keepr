<template>
  <div class="col-6 col-md-5 offset-md-1 card vkcard">
    <div class="row">
      <div class="col-12" @click="$router.push({name:'keep', params: {id:vaultKeepData.id}})">
        <img class="pkeep-img card-img-top" :src="vkimg" alt="">
        <hr>
        <h2>{{vaultKeepData.name}}</h2>
        <h5>{{vaultKeepData.description}}</h5>
      </div>
    </div>
    <div class="row">
      <div class="col-4">
        <p>
          <i class="far fa-eye"></i>
          {{vaultKeepData.views}}</p>
      </div>
      <div class="col-4">
        <p>
          <i class="fas fa-chess-rook"></i>
          {{vaultKeepData.keeps}}</p>
      </div>
      <div class="col-4">
        <p>
          <i class="fas fa-share"></i>
          {{vaultKeepData.shares}}</p>
      </div>
      <div class="col-3 offset-9">
        <i class="fas fa-trash" @click="deleteVaultKeep(vaultKeepData)"></i>
      </div>
    </div>
  </div>
</template>


<script>
  export default {
    name: 'vaultkeeps',
    props: ['vaultKeepData'],
    data() {
      return {}
    },
    computed: {
      vkimg() {
        return this.vaultKeepData.img
      },
    },
    methods: {
      deleteVaultKeep(vaultKeepData) {
        let vaultId = this.$route.params.id
        let keepId = vaultKeepData
        let payload = {
          vaultId,
          keepId
        }
        this.$store.dispatch('deleteVaultKeep', payload)
      }
    },
    components: {}
  }
</script>


<style scoped>
  .vkcard {
    display: flex;
    justify-content: center;
    background-color: #a9c6de;
    box-shadow: 5px 5px 5px rgba(0, 0, 0, 0.555);
    padding: 5px;
  }
</style>