<template>
  <div class="home">
    <h1>Welcome Home</h1>
    <home></home>
  </div>
</template>

<script>
  import Home from '@/components/home.vue'
  export default {
    name: "home",
    mounted() {
      //blocks users not logged in
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }
    },
    computed: {},
    methods: {},
    components: {
      Home
    },
  };
</script>