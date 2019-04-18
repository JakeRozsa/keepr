<template>
  <div class="row">
    <div class="home bg col">
      <div class="row">

      </div>
      <div class="row">
        <div class="col-12">
          <div class="row">
            <keeps v-for="keep in keeps" :keepData="keep"></keeps>
            <active-keep></active-keep>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  import Keeps from "@/components/Keeps.vue"
  import ActiveKeep from "@/components/ActiveKeep.vue"

  export default {
    name: "home",
    data() {
      return {}
    },
    mounted() {
      this.$store.dispatch('getKeeps')
      this.$store.dispatch('getVaults')
    },
    computed: {
      keeps() {
        return this.$store.state.keeps
      },
      vaults() {
        return this.$store.state.vaults
      }
    },
    methods: {},
    components: {
      Keeps,
      ActiveKeep
    }
  };
</script>

<style>
  @media only screen and (max-width: 450px) {
    .show-top {
      margin-top: 20vh;
    }
  }
</style>