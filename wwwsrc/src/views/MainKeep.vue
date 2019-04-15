<template>
  <div class="bg MainKeep row">
    <div class="col-12">
      <login></login>
      <active-keep></active-keep>
    </div>
  </div>
</template>


<script>
  import Login from "@/components/Login.vue"
  import ActiveKeep from "@/components/ActiveKeep.vue"

  export default {
    name: 'MainKeep',
    data() {
      return {}
    },
    computed: {},
    methods: {},
    components: {
      Login,
      ActiveKeep
    }
  }
</script>


<style scoped>
  .bg {
    background-color: #a0fcff;
    height: 100vh;
  }
</style>