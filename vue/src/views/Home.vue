<template>
  <div class="frosty-porter text-foam mx-auto my-auto p-2">
    <h1>Home</h1>
    <p>You must be authenticated to see this</p>
    <BeerList />
  </div>
</template>

<script>
import BeerList from '../components/BeerList'

export default {
  components: { BeerList },
  name: "home",
};
</script>
