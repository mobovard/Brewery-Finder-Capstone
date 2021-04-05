<template>
  <div class="frosty-porter rounded p-3">
    <form class="d-grid" @submit.prevent="register">
      <h1 class="text-foam text-center">Create Account</h1>
      <div role="alert" v-if="registrationErrors">
        {{ registrationErrorMsg }}
      </div>
      <div class="row">
        <div class="col pr-1">
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
        </div>
        <div class="col pl-1">
          <label for="emailaddress" class="sr-only">E-mail Address</label>
          <input
            type="text"
            id="lastemailaddressname"
            placeholder="Email Address"
            v-model="user.emailaddress"
            autofocus
            class="form-control my-1"
          />
        </div>
      </div>
      <div class="row">
        <div class="col pr-1">
          <label for="firstname" class="sr-only">First Name</label>
          <input
            type="text"
            id="firstname"
            placeholder="First Name"
            v-model="user.firstname"
            autofocus
            class="form-control my-1"
          />
        </div>

        <div class="col pl-1">
          <label for="lastname" class="sr-only">Last Name</label>
          <input
            type="text"
            id="lastname"
            placeholder="Last Name"
            v-model="user.lastname"
            autofocus
            class="form-control my-1"
          />
        </div>
      </div>
      <div class="row">
        <div class="col pr-1">
          <label for="password" class="sr-only">Password</label>
          <input
            type="password"
            id="password"
            placeholder="Password"
            v-model="user.password"
            required
            class="form-control my-1"
          />
        </div>
        <div class="col pl-1">
          <input
            type="password"
            id="confirmPassword"
            placeholder="Confirm Password"
            v-model="user.confirmPassword"
            required
            class="form-control my-1"
          />
        </div>
      </div>
      <div class="row">
        <div class="col">
          <button
            type="submit"
            class="btn-block btn bg-foam text-fruit my-1 font-weight-bold"
          >
            Create Account
          </button>
        </div>
      </div>
      <div class="row mt-2">
        <div class="col">
          <router-link :to="{ name: 'login' }" class="text-center text-wheat"
            >Have an account?</router-link
          >
        </div>
      </div>
    </form>
  </div>
</template>
<script>
// DO WE MAKE ROLE A DROP-DOWN or Hard CODE
import authService from "../services/AuthService";

export default {
  data() {
    return {
      user: {
        username: "",
        password: "",
        confirmPassword: "",
        firstname: "",
        lastname: "",
        emailaddress: "",
        role: "Beer Lover",
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
