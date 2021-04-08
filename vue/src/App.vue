<template>
  <div id="app" class="d-flex flex-column">
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