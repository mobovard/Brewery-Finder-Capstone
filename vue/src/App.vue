<template>
  <div id="app">
    <div id="nav">
      <router-link v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;|&nbsp;
      <router-link
        v-bind:to="{ name: 'logout' }"
        v-if="$store.state.token != ''"
        >Logout</router-link
      >
    </div>
    <router-view />
  </div>
</template>

<style>
#app {
  background: url("./img/brewerybg.jpg") no-repeat;
  height: 100vh;
  background-attachment: fixed;
  background-size: cover;
}
</style>