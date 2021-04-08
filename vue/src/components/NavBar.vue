<template>
  <b-navbar toggleable="md" class="frosty-porter" sticky>
    <div class="container">
      <b-navbar-brand class="img-logo"
        ><img src="../img/BF.png" class="img-fluid" alt="Brewery Finder" />
      </b-navbar-brand>

      <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

      <b-collapse id="nav-collapse" is-nav>
        <b-navbar-nav>
          <b-nav-item :to="{ name: 'home' }"
            ><span class="text-foam text-wheat-h font-weight-bold">Home</span></b-nav-item
          >
          <b-nav-item :to="{ name: 'breweries' }"
            ><span class="text-foam text-wheat-h font-weight-bold"
              >Breweries</span
            ></b-nav-item
          >
        </b-navbar-nav>

        <!-- Right aligned nav items -->
        <b-navbar-nav class="ml-auto">
          <b-nav-item
            v-if="$store.getters.isAdmin"
            :to="{name: 'admin'}"
          ><span class="text-foam text-wheat-h font-weight-bold">Admin</span></b-nav-item>
          <b-nav-item-dropdown id="user-dropdown" right>
            <!-- Using 'button-content' slot -->
            <template #button-content>
              <BIconPersonCircle class="text-porter" />
            </template>
            <b-dropdown-item 
              v-if="$store.getters.isLoggedIn"
              >
                {{$store.state.user.firstName}}
              </b-dropdown-item>
            <b-dropdown-item
              :to="{ name: 'logout' }"
              v-if="$store.getters.isLoggedIn"
            >
              Sign Out
            </b-dropdown-item>
            <b-dropdown-item
              :to="{ name: 'login' }"
              v-if="!$store.getters.isLoggedIn"
            >
              Sign in
            </b-dropdown-item>
            <b-dropdown-item
              :to="{ name: 'register' }"
              v-if="!$store.getters.isLoggedIn"
            >
              Register
            </b-dropdown-item>
          </b-nav-item-dropdown>
        </b-navbar-nav>
      </b-collapse>
    </div>
  </b-navbar>
</template>

<script>
import { BIconPersonCircle } from "bootstrap-vue";
export default {
  components: { BIconPersonCircle },
};
</script>

<style>
.img-logo {
  width: 2.2rem;
}
</style>