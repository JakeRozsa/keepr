<template>
  <header class="row">
    <div class="col-1 col-md-6 logo">
      <ul class="nav row">
        <li class="nav-item col-12">
          <img @click="$router.push({name:'home'})" class="klogo" src="@/assets/keeprlogo.png" alt="">
        </li>
        <br>
        <li v-if="activeUser.active" class="nav-item col-12">
          <a @click="$router.push({name:'profile'})">Dashboard</a>
        </li>
      </ul>
    </div>
    <div class="col-11 col-md-6 lgnfix">
      <div class="row" v-if="!activeUser.active">
        <div class="col-12 bool-flip" @click="loginForm = !loginForm">
          <p v-if="loginForm">Register here</p>
          <p v-else>Login here</p>
        </div>
        <div class="col-12 lf">
          <form v-if="loginForm" @submit.prevent="loginUser">
            <input class="formsize" type="email" v-model="creds.email" placeholder="email">
            <input class="formsize" type="password" v-model="creds.password" placeholder="password">
            <button class="btn lgnbtn" type="submit">Login</button>
          </form>
          <form v-else @submit.prevent="register">
            <input class="formsize" type="text" v-model="newUser.username" placeholder="name">
            <input class="formsize" type="email" v-model="newUser.email" placeholder="email">
            <input class="formsize" type="password" v-model="newUser.password" placeholder="password">
            <button class="btn lgnbtn" type="submit">Create Account</button>
          </form>
        </div>
      </div>
      <div class="row" v-else>
        <div class="col-12 login">
          <button class="logout lgnbtn" @click="logoutUser">Logout</button>
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
      register() {
        this.$store.dispatch("register", this.newUser);
      },
      loginUser() {
        this.$store.dispatch("login", this.creds);
      },
      logoutUser() {
        this.$store.dispatch("logout")
        this.$router.push({ name: 'home' })
      },

    },
    computed: {
      activeUser() {
        return this.$store.state.user
      }
    }
  };
</script>

<style>
  header {
    position: sticky;
    top: 0px;
    left: 0px;
    right: 0px;
    background-color: #76b39d;
    padding: 5px;
    z-index: 5;
    margin-bottom: 5px;
    height: 95px;
  }

  .lgnbtn {
    margin-left: 5px;
    background-color: #05004e;
    color: #f9f8eb;
    box-shadow: 2px 2px 5px rgba(0, 0, 0, 0.651);

  }

  .lgnfix {
    margin-top: -8px;
  }

  .nav-item {
    margin: auto;
    color: azure;
    cursor: pointer;
  }

  .logo {
    display: flex;
    justify-content: flex-start;
  }

  .login {
    margin-top: 15px;
    margin-right: 10px;
    display: flex;
    justify-content: flex-end;

  }

  .logout {
    margin-top: 5px;
    border-radius: 5px;
    box-shadow: 3px 3px 5px rgba(0, 0, 0, 0.753);
    border-style: none;
  }

  .bool-flip {
    margin-bottom: -15px;
  }

  .lf {
    display: flex;
    justify-content: center;
  }

  .klogo {
    max-height: 50px;
    cursor: pointer;
  }

  .formsize {
    width: 15vw;
    margin-left: 3px;
    border-radius: 4px;
  }

  @media only screen and (max-width: 550px) {
    .formsize {
      width: 33vw;
    }
  }
</style>