<template>
  <div class="frosty-porter rounded p-3">
    <form class="d-flex flex-column" @submit.prevent="register">
      <h1 class="text-foam">Create Account</h1>
      <div role="alert" v-if="registrationErrors">
        {{ registrationErrorMsg }}
      </div>
      <label for="username" class="sr-only">Username</label>
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
      <input
        type="password"
        id="confirmPassword"
        placeholder="Confirm Password"
        v-model="user.confirmPassword"
        required
        class="form-control my-1"
      />

      <button
        type="submit"
        class="btn bg-foam text-fruit my-1 font-weight-bold"
      >
        Create Account
      </button>
      <router-link :to="{ name: 'login' }" class="text-wheat"
        >Have an account?</router-link
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
        confirmPassword: "",
        role: "user",
      },
      registrationErrors: false,
      registrationErrorMsg: "There were problems registering this user.",
    };
  },
  methods: {
    register() {
      if (this.user.password != this.user.confirmPassword) {
        this.registrationErrors = true;
        this.registrationErrorMsg = "Password & Confirm Password do not match.";
      } else {
        authService
          .register(this.user)
          .then((response) => {
            if (response.status == 201) {
              this.$router.push({
                path: "/login",
                query: { registration: "success" },
              });
            }
          })
          .catch((error) => {
            const response = error.response;
            this.registrationErrors = true;
            if (response.status === 400) {
              this.registrationErrorMsg = "Bad Request: Validation Errors";
            }
          });
      }
    },
    clearErrors() {
      this.registrationErrors = false;
      this.registrationErrorMsg = "There were problems registering this user.";
    },
  },
};
</script>

<style></style>
