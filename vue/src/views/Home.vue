<template>
  <div class="bg-porter text-foam">
    <div class="home">
      <h1>Home</h1>
      <p>You must be authenticated to see this</p>
      <BreweriesList />
    </div>
  </div>
</template>

<script>
import BreweriesList from '../components/BreweriesList.vue';
export default {
  components: { BreweriesList },
  name: "home",
};
</script>
