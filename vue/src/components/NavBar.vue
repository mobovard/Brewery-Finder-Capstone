<template>
  <b-navbar toggleable="md" class="frosty-porter" sticky>
    <b-navbar-brand class="img-logo"
      ><img src="../img/BF.png" class="img-fluid" alt="Brewery Finder">
      </b-navbar-brand
    >

    <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

    <b-collapse id="nav-collapse" is-nav>
      <b-navbar-nav>
        <b-nav-item :to="{ name: 'home' }"
          ><span class="text-foam font-weight-bold">Home</span></b-nav-item
        >
      </b-navbar-nav>

      <!-- Right aligned nav items -->
      <b-navbar-nav class="ml-auto">
        <b-nav-item-dropdown id="user-dropdown" right>
          <!-- Using 'button-content' slot -->
          <template #button-content>
            <BIconPersonCircle class="text-porter" />
          </template>
          <b-dropdown-item v-if="$store.getters.isLoggedIn">{{
            $store.state.user.username
          }}</b-dropdown-item>
          <b-dropdown-item
            :to="{ name: 'logout' }"
            :disabled="!$store.getters.isLoggedIn"
            >Sign Out</b-dropdown-item
          >
        </b-nav-item-dropdown>
      </b-navbar-nav>
    </b-collapse>
  </b-navbar>
</template>

<script>
import { BIconPersonCircle } from "bootstrap-vue";
export default {
  components: { BIconPersonCircle },
};
</script>

<style>
.router-link-exact-active,
.router-link-exact-active:hover {
  text-decoration: underline;
}

.img-logo{
  flex-basis: 3.5%;
}
</style>