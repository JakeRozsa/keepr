<template>
  <div @click="$router.push({name: 'MainKeep', params: {id:keepData.id}})" class="Keeps col-4 card">
    {{keepData.name}}
    {{keepData.description}}
    <img :src="keepimg" alt="">

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

</style>