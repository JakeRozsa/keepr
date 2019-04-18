<template>
  <div class="col-11 col-md-3 keeps">
    <div class="row">
      <div class="col-12 card keep-card" @click="$router.push({name:'keep', params: {id:keepData.id}})">
        <img :src="keepimg" alt="" class="keep-img">
        {{keepData.name}}
        {{keepData.description}}
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
        return this.keepData.img
      },

    },
    methods: {
      setActiveKeep() {
        return this.$store.dispatch('getActiveKeep')
      }
    },
    components: {}
  }
</script>

<style scoped>
  .keeps {
    max-width: 22vw;
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