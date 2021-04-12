<template>
  <div class="frosty-porter rounded p-3">
    <form class="d-grid" @submit.prevent="register">
      <h1 class="text-foam text-center">Create Account</h1>
      <div
        role="alert"
        class="alert alert-danger text-center"
        v-if="registrationErrors"
      >
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
            v-model="user.email"
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
          <b-form-datepicker
            v-model="value"
            locale="en"
            :start-weekday="weekday"
            :show-decade-nav="showDecadeNav"
            :hide-header="hideHeader"
            :max="max"
            value-as-date
            class="mb-2"
          ></b-form-datepicker>
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
      <div class="row mt-1">
        <div class="col d-flex justify-content-end">
          <router-link :to="{ name: 'login' }" class="text-wheat text-foam-h"
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
  props: {},
  data() {
    return {
      user: {
        username: "",
        password: "",
        confirmPassword: "",
        firstname: "",
        lastname: "",
        email: "",
        dob: "",
        role: "Beer Lover",
      },
      registrationErrors: false,
      registrationErrorMsg: "There were problems registering this user.",
      value: "",
      max: null,
      showDecadeNav: true,
      hideHeader: false,
      weekday: 0,
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
  created() {
    const now = new Date();
    const today = new Date(now.getFullYear(), now.getMonth(), now.getDate());
    const maxDate = new Date(today);
    maxDate.setYear(maxDate.getFullYear() - 21);
    this.max = maxDate;
    console.log(maxDate);
  },
};
</script>

<style></style>
