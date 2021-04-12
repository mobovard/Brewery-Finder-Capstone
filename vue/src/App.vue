<template>
  <div
    id="app"
    class="d-flex flex-column vh-100"
  >
  <b-img src="./beer.jpg" class="bg-img" />
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
/*.bg-full {
  background-image: url('./img/beer.jpg');
  background-repeat: no-repeat;
  background-attachment: fixed;
  background-size: cover;
  max-width: 100vw;
}*/
.bg-img {
  position: fixed;
  left: 0;
  top: 0;
  height: 100vh;
  width: 100vw;
  object-fit: cover;
  z-index: 0;
}
</style>
