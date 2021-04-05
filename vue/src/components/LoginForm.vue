<template>
  <form @submit.prevent="login">
    <h1>Please Sign In</h1>
    <div role="alert" v-if="invalidCredentials">
      Invalid username and password!
    </div>
    <div
      role="alert"
      v-if="this.$route.query.registration"
    >
      Thank you for registering, please sign in.
    </div>
    <label class="sr-only" for="username">Username</label>
    <input
      type="text"
      id="username"
      placeholder="Username"
      v-model="user.username"
      required
      autofocus
    />
    <label for="password" class="sr-only">Password</label>
    <input
      type="password"
      id="password"
      placeholder="Password"
      v-model="user.password"
      required
    />
    <router-link :to="{ name: 'register' }">Need an account?</router-link>
    <button type="submit">Sign in</button>
  </form>
</template>

<script>
import authService from "../services/AuthService";

export default {
data() {
    return {
      user: {
        username: "",
        password: ""
      },
      invalidCredentials: false
    };
  },
  methods: {
    login() {
      authService
        .login(this.user)
        .then(response => {
          if (response.status == 200) {
            this.$store.commit("SET_AUTH_TOKEN", response.data.token);
            this.$store.commit("SET_USER", response.data.user);
            this.$router.push({name: 'home'});
          }
        })
        .catch(error => {
          const response = error.response;

          if (response.status === 401) {
            this.invalidCredentials = true;
          }
        });
    }
  }
};
</script>

<style></style>
