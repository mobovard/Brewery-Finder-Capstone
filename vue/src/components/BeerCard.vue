<template>
  <div>
    <b-card
      no-body
      class="d-flex flex-column text-porter frosty-foam card-size m-1 p-1"
    >
      <div class="flex-custom d-flex align-items-center">
        <b-card-img
          :src="beer.image"
          class="rounded-circle img-fluid"
        ></b-card-img>
      </div>
      <div class="flex-custom">
        <b-card-title class="text-center mt-2">{{ beer.name }}</b-card-title>
        <b-card-text class="text-center">{{ `ABV: ${beer.abv}%` }}</b-card-text>
      </div>
    </b-card>
  </div>
</template>

<script>
export default {
  props: ["beer"],
};
</script>

<style scoped>
.card-size {
  max-width: 10rem;
  height: 15rem;
}
.flex-custom {
  flex: 1 1 50%;
}
</style>
