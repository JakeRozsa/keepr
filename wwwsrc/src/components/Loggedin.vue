<template>
  <header class="row">
    <div class="col-12 col-md-6 logo">
      <ul class="nav row">
        <li class="nav-item col-4">
          <a @click="$router.push({name:'home'})">Keepr</a>
        </li>
        <li class="nav-item col-4">
          <a @click="$router.push({name:'loggedin'})">Vaults</a>
        </li>
        <li class="nav-item col-4">
          <a @click="$router.push({name:'about'})">About</a>
        </li>
      </ul>
    </div>
    <div class="col-12 col-md-6">
      <div class="row">
        <div class="col-12 bool-flip" @click="loginForm = !loginForm">
          <p v-if="loginForm">Register here</p>
          <p v-else>Login here</p>
        </div>
        <div class="col-12 lf">
          <form v-if="loginForm" @submit.prevent="loginUser">
            <input type="email" v-model="creds.email" placeholder="email">
            <input type="password" v-model="creds.password" placeholder="password">
            <br>
            <button type="submit" class="btn btn-success">Login</button>
          </form>
          <form v-else @submit.prevent="register">
            <input type="text" v-model="newUser.username" placeholder="name">
            <input type="email" v-model="newUser.email" placeholder="email">
            <input type="password" v-model="newUser.password" placeholder="password">
            <br>
            <button type="submit">Create Account</button>
          </form>
        </div>
      </div>
    </div>
  </header>

</template>

<script>
  export default {
    name: "loggedin",
    mounted() {
      //checks for valid session
      this.$store.dispatch("authenticate");
    },
    data() {
      return {
        loginForm: true,
        creds: {
          email: "",
          password: ""
        },
        newUser: {
          email: "",
          password: "",
          username: ""
        }
      };
    },
    methods: {
    },
    computed: {
      User() {
        return this.$store.state.user
      }
    }
  };
</script>

<style>
  header {
    position: fixed;
    top: 0px;
    left: 0px;
    right: 0px;
    background-color: rgb(2, 48, 48);
    padding: 5px;
    z-index: 5;
  }

  .logo {
    display: flex;
    justify-content: flex-start;
  }

  .login {
    display: flex;
    justify-content: flex-end;
  }

  .logout {
    border-radius: 5px;
    box-shadow: 2px 2px 5px rgba(0, 0, 0, 0.651);
  }
</style>