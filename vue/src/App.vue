<template>
  <div id="app" class="d-flex flex-column">
    <NavBar />
    <router-view />
  </div>
</template>

<script>
import NavBar from './components/NavBar'

export default {
  components: { NavBar },
}
</script>


<style>

</style>