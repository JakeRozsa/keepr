<template>
  <div class="privatekeeps col-6 ">
    <div class="row">
      <div class="col-12 keeprcard card">
        <img class="pkeep-img card-img-top" :src="pkeepimg" alt="">
        <hr>
        <h2>{{keeprData.name}}</h2>
        <h5>{{keeprData.description}}</h5>
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
        </div>
      </div>
    </div>
  </div>
</template>


<script>
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
    },
    methods: {},
    components: {}
  }
</script>


<style scoped>
  h2 {
    margin-top: -10px;
  }

  .keeprcard {
    display: flex;
    justify-content: center;
  }


  .pkeep-img {
    margin-top: 5px;
  }
</style>