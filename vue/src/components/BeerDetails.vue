<template>
  <div>
    <b-img :src="$store.state.brewery.brewery_img" class="bg-img" />
    <div
      class="frosty-foam p-3 rounded text-center text-porter pointer"
      @click="
        $router.push({
          name: 'brewery',
          params: { id: $route.params.breweryId },
        })
      "
    >
      <h1>{{ beer.name }}</h1>
      <h4>{{ $store.state.brewery.name }}</h4>

      <div class="frosty-foam p-3 mt-2 rounded text-porter">
        <div class="d-flex flex-column align-items-left">
          <div class="flex-custom-img align-self-center">
            <img :src="beer.image" class="rounded-circle img-fluid mb-3" />
          </div>
          <div>
            <div class="d-flex flex-row align-items-baseline">
              <h3 class="text-belgian">{{ beer.beer_type }}</h3>
              <h3 class="ml-4 mr-5 text-belgian">ABV: ( {{ beer.abv }}% )</h3>
            </div>
            <div>
              <p class="text-porter">
                {{ beer.description }}
              </p>
            </div>
          </div>
          <b-link
            class="text-belgian text-fruit-h align-self-end"
            @click="
              $router.push({
                name: 'brewery',
                params: { id: $route.params.breweryId },
              })
            "
            >Go Back: {{ $store.state.brewery.name }}
          </b-link>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  computed: {
    beer() {
      return this.$store.state.beers.filter(
        (beer) => beer.beer_id == this.$route.params.beerId
      )[0];
    },
  },
};
</script>

<style scoped>
.flex-custom-img {
  max-width: 30rem;
}
.pointer {
  cursor: pointer;
}
.bg-img {
  position: absolute;
  left: 0;
  top:0;
  height:100vh;
  width:100vw;
  object-fit: cover;
  z-index: 0;
}
</style>