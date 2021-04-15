<template>
  <div class="frosty-porter rounded p-3">
    <form class="d-flex flex-column" @submit.prevent="login">
      <h1 class="text-foam text-center">Please Sign In</h1>
      <div role="alert" class="alert alert-danger" v-if="invalidCredentials">
        Invalid username and password!
      </div>
      <div
        role="alert"
        class="alert alert-success"
        v-if="this.$route.query.registration && !invalidCredentials"
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
        class="form-control my-1"
      />
      <label for="password" class="sr-only">Password</label>
      <input
        type="password"
        id="password"
        placeholder="Password"
        v-model="user.password"
        required
        class="form-control my-1"
      />

      <button
        type="submit"
        class="btn frosty-foam text-foam text-belgian-h my-1"
      >
        Sign in
      </button>
      <router-link :to="{ name: 'register' }" class="text-wheat text-foam-h text-right mt-1"
        >Need an account?</router-link
      >
    </form>
  </div>
</template>

<script>
import authService from "../services/AuthService";

export default {
  data() {
    return {
      user: {
        username: "",
        password: "",
      },
      invalidCredentials: false,
    };
  },
  methods: {
    login() {
      authService
        .login(this.user)
        .then((response) => {
          if (response.status == 200) {
            this.$store.commit("SET_AUTH_TOKEN", response.data.token);
            this.$store.commit("SET_USER", response.data.user);
            this.$router.push({ name: "home" });
          }
        })
        .catch((error) => {
          const response = error.response;

          if (response.status === 401) {
            this.invalidCredentials = true;
          }
        });
    },
  },
};
</script>

<style></style>
