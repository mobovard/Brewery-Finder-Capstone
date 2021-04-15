<template>
  <div class="frosty-porterdk text-foam mx-auto my-auto p-2 text-center">
    <h1 class="text-wheat" v-if="$store.getters.isLoggedIn">Hello {{$store.state.user.firstName}},</h1>
    <h1 class="text-wheat">Welcome to Brewery Finder</h1>
    <h3 class="mt-3">Find your next brew here!</h3>
    <p class="mt-3" v-if="!$store.getters.isLoggedIn">
      Sign-up to see local breweries, their history, and most importantly - BEER
      SELECTION!
    </p>

    <button
      class="btn frosty-foam text-foam text-wheat-h"
      v-if="$store.getters.isLoggedIn"
      @click="$router.push({ name: 'breweries' })"
    >
      Breweries
    </button>
    <button
      class="btn frosty-foam text-foam text-wheat-h ml-2"
      v-if="$store.getters.isLoggedIn"
      @click="$router.push({ name: 'logout' })"
    >
      Sign out
    </button>
    <button
      class="btn frosty-foam text-foam text-wheat-h"
      v-if="!$store.getters.isLoggedIn"
      @click="$router.push({ name: 'login' })"
    >
      Sign in
    </button>
    <button
      class="btn frosty-foam text-foam text-wheat-h ml-2"
      v-if="!$store.getters.isLoggedIn"
      @click="$router.push({ name: 'register' })"
    >
      Register
    </button>
  </div>
</template>

<script>

export default {
  name: "home",
};
</script>
