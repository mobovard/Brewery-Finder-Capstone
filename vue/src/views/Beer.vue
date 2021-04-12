<template>
<div class="flex-grow-1 d-flex justify-content-center align-items-start p-4">
    <BeerInfo :breweryId="breweryId" :beerId="beerId" />
  </div>
</template>

<script>
import BeerInfo from "../components/BeerDetails.vue";
export default {
  components: { BeerInfo },
  props: {
    breweryId: { type: Number },
    beerId: { type: Number }
  }
};
</script>

<style>
</style>