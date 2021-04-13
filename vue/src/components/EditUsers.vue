<template>
  <div>
    <h4 class="text-foam text-center">Edit Users</h4>
    <table
      role="table"
      aria-busy="false"
      class="table b-table table-striped table-borderless table-sm text-foam"
    >
      <tbody role="rowgroup">
        <EditUserRow v-for="user in users" :key="user.userId" :userId="user.userId" />
      </tbody>
    </table>
  </div>
</template>

<script>
import breweriesService from "../services/BreweriesService";
import EditUserRow from "./EditUserRow";

export default {
  components: { EditUserRow },
  created() {
    if (this.$store.state.users.length === 0) {
      breweriesService
        .getUsers()
        .then((resp) => {
          this.$store.commit("SET_USERS", resp.data);
        })
        .catch((err) => console.log(err));
    }
  },
  computed: {
    users() {
      return this.$store.state.users;
    },
  },
};
</script>

<style></style>
