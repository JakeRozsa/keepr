<template>
  <header class="row">
    <div class="col-12 col-md-6 logo">
      <ul class="nav row">
        <li class="nav-item col-4">
          <a href="">Keepr</a>
        </li>
        <li class="nav-item col-4">
          <a href="">Vaults</a>
        </li>
        <li class="nav-item col-4">
          <a href="">About</a>
        </li>
      </ul>
    </div>
    <div class="col-12 col-md-6">
      <div class="row">
        <div class="col-12 bool-flip" @click="loginForm = !loginForm">
          <p v-if="loginForm">Register here</p>
          <p v-else>Login here</p>
        </div>
        <div class="col-12 lf" v-if="user == null">
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
      <div class="row" v-if="user != null">
        <div class="col login">
          <button class="logout btn-danger" @click="logoutUser">Logout</button>
        </div>
      </div>
    </div>
  </header>

</template>

<script>
  export default {
    name: "login",
    mounted() {
      //checks for valid session
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
      register() {
        this.$store.dispatch("register", this.newUser);
      },
      loginUser() {
        this.$store.dispatch("login", this.creds);
      },
      logoutUser() {
        this.$store.dispatch("logout")
      }
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

  .bool-flip {
    margin-bottom: -15px;
  }

  .lf {
    display: flex;
    justify-content: center;
  }
</style>