<template>
  <div>
    <b-card
      @click="
        $router.push({
          name: 'beer',
          params: { breweryId: $route.params.id, beerId: beer.beer_id },
        })
      "
      no-body
      class="d-grid text-porter frosty-foam card-size m-1 p-1 pointer"
    >
      <div class="row m-0 max-height-img p-1 d-flex justify-content-around">
        <b-card-img
          :src="beer.image"
          class="rounded-circle custom-img"
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
.max-height-img {
  height: 50%;
}
.custom-img {
  max-width: 10rem;
  max-height: 100%;
  object-fit: cover;
}
.card-size {
  max-width: 15rem;
  height: 15rem;
}
.flex-custom {
  flex: 1 1 50%;
}
.pointer {
  cursor: pointer;
}
</style>
