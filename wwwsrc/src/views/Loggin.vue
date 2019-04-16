<template>
  <div class="loggin">
    <login></login>
    LOGIN PAGE HERE
  </div>
</template>


<script>
  import Login from "@/components/Login.vue"
  export default {
    name: 'loggin',
    data() {
      return {}
    },
    mounted() {
      // if (!this.$store.state.user.id) {
      //   this.$router.push({ name: "loggin" });
      // }
      this.$store.dispatch('getKeeps')
    },
    computed: {
      keeps() {
        return this.$store.state.keeps
      }
    },
    methods: {},
    components: {
      Login
    }
  }
</script>


<style scoped>

</style>