<template>
  <div class="privatekeeps col-6 pkeep-card">
    <img class="pkeep-img" :src="pkeepimg" alt="">
    {{keeprData.name}}
    {{keeprData.description}}
    {{keeprData.isPrivate}}
    {{keeprData.views}}
    {{keeprData.keeps}}
    {{keeprData.shares}}
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
  .pkeep-card {
    max-height: 75vh;
    display: flex;
    justify-content: center;
  }

  .pkeep-img {
    object-fit: contain;
  }
</style>