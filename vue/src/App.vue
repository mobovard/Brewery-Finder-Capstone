<template>
  <div id="app" class="d-flex flex-column vh-100" > <!-- took this out of class and added css for background :style="{ backgroundImage: `url(${$store.state.bg_image})`}" -->
    <NavBar />
    <div class="container flex-grow-1 d-flex flex-column">
      <router-view />
    </div>
  </div>
</template>

<script>
import NavBar from "./components/NavBar";

export default {
  components: { NavBar },
};
</script> 

<style scoped>
/* .bg-full {
  background-attachment: fixed;
  background-repeat: no-repeat;
  background-size: cover;
} */
</style>
