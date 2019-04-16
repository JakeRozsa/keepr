<template>
  <div class="col-11 col-md-4 keeps">
    <div class="row">
      <div @click="$router.push({name: 'MainKeep', params: {id:keepData.id}})" class="col-12 card keep-card">
        {{keepData.name}}
        {{keepData.description}}
        <img :src="keepimg" alt="" class="keep-img">
      </div>
    </div>

  </div>
</template>


<script>
  export default {
    name: 'Keeps',
    props: ['keepData'],
    data() {
      return {}
    },
    computed: {
      keepimg() {
        return this.keepData.img || "@/assets/Image-Here6.png"
      }
    },
    methods: {
    },
    components: {}
  }
</script>

<style scoped>
  .keeps {
    max-width: 30vw;
    margin: 5px 1vw;
  }

  .keep-card {
    max-height: 75vh;
    display: flex;
    justify-content: center;
  }

  .keep-img {
    object-fit: contain;
  }

  @media only screen and (max-width: 450px) {
    .keeps {
      min-width: 90vw;
      margin-left: 4vw;
      text-align: center;
    }
  }
</style>