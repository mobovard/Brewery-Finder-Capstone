<template>
  <div class="frosty-porter text-foam p-3 mt-3 rounded">
    <div
      class="d-flex justify-content-center frosty-porter text-foam p-3 rounded"
    >
      <h4>Profile Information</h4>
    </div>
    <div class="d-flex flex-column frosty-porter text-foam p-3 mt-3 rounded">
      <div class="mb-2">
        Name: {{ $store.state.user.firstName }}
        {{ $store.state.user.lastName }}
      </div>

      <div class="mb-2">Username: {{ $store.state.user.username }}</div>
      <div class="mb-2">Email: {{ $store.state.user.email }}</div>

      <div class="mb-2">Role: {{ $store.state.user.role }}</div>
    </div>
    <button
      type="submit"
      class="btn frosty-porter text-wheat text-belgian-h my-1 font-weight-bold mt-2"
      @click="deleteAccount()"
    >
      Delete Profile
    </button>
  </div>
</template>

<script>
import breweriesService from "../services/BreweriesService";

export default {
  methods: {
    deleteAccount() {
      breweriesService
        .updateUser({ ...this.$store.state.user, status: false })
        .then(() => {
          this.$router.push({ name: "logout" });
        })
        .catch((err) => console.log(err));
    },
  },
};
</script>

<style></style>
