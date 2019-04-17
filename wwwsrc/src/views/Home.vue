<template>
  <div class="row">
    <div class="home bg col">
      <div class="row">

      </div>
      <div class="row">
        <div class="col-12">
          <div class="row">
            <keeps v-for="keep in keeps" :keepData="keep"></keeps>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  import Keeps from "@/components/Keeps.vue"
  import Vaults from "@/components/Vaults.vue"

  export default {
    name: "home",
    data() {
      return {}
    },
    mounted() {
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "loggin" });
      }
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
      Vaults
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