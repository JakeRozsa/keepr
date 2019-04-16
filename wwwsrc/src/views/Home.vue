<template>
  <div class="row">
    <div class="home bg col">
      <div class="row">
        <div class="col-12">
          <login></login>
        </div>
      </div>
      <div class="row show-top">
        <add-keep></add-keep>
        <div class="col-12 text-center mb-2 mt-1  ">
          <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">
            Add Keep
          </button>
        </div>
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

  .show-top {
    margin-top: 15vh;
  }

  @media only screen and (max-width: 450px) {
    .show-top {
      margin-top: 20vh;
    }
  }
</style>