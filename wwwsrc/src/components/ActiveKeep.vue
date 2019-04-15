<template>
  <div class="ActiveKeep">
    <h1>{{keep.name}}</h1>
    <img class="activeimg" :src="keepimg" alt="">
    <h2>{{keep.description}}</h2>
  </div>
</template>


<script>
  export default {
    name: 'ActiveKeep',
    data() {
      return {}
    },
    computed: {
      keep() {
        return this.$store.state.keeps.find(k => k.id == this.$route.params.id)
      },
      keepimg() {
        return this.keep.img || "@/assets/Image-Here6.png"
      }
    },
    methods: {},
    components: {}
  }
</script>


<style scoped>

</style>