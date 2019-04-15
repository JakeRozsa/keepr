<template>
  <div class="row">
    <div class="home bg col">
      <div class="row">
        <div class="col-12">
          <login></login>
        </div>
      </div>
      <div class="row">
        <add-keep></add-keep>
      </div>
      <div class="row">
        <keeps v-for="keep in keeps" :keepData="keep"></keeps>
      </div>
    </div>
  </div>
</template>

<script>
  import Keeps from "@/components/Keeps.vue"
  import Login from "@/components/Login.vue"
  import AddKeep from "@/components/AddKeep.vue"

  export default {
    name: "home",
    data() {
      return {}
    },
    mounted() {
      this.$store.dispatch('getKeeps')
    },
    computed: {
      keeps() {
        return this.$store.state.keeps
      }
    },
    methods: {},
    components: {
      Keeps,
      Login,
      AddKeep
    }
  };
</script>

<style>
  .bg {
    background-color: #a0fcff;
    height: 100vh;
  }
</style>