<template>
  <div class="privatekeeps col-6 ">
    <div class="row">
      <div class="col-12 keeprcard card">
        <img class="pkeep-img card-img-top" :src="pkeepimg" alt="">
        <hr>
        <h2>{{activeKeep.name}}</h2>
        <h5>{{activeKeep.description}}</h5>
        <div class="row">
          <div class="col-4">
            <p>
              <i class="far fa-eye"></i>
              {{activeKeep.views}}</p>
          </div>
          <div class="col-4">
            <p>
              <i class="fas fa-chess-rook"></i>
              {{activeKeep.keeps}}</p>
          </div>
          <div class="col-4">
            <p>
              <i class="fas fa-share"></i>
              {{activeKeep.shares}}</p>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>



<script>
  export default {
    name: 'ActiveKeep',
    data() {
      return {}
    },
    mounted() { },
    computed: {
      activeKeep() {
        return this.$store.state.keeps.find(k => k.id == this.$route.params.id)
      },
      pkeepimg() {
        return this.activeKeep.img
      },
    },
    methods: {},
    components: {}
  }
</script>


<style scoped>

</style>