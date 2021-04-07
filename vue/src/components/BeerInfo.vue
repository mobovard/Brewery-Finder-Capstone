<template>
  <div>
    <div
      class="frosty-foam p-3 rounded text-center text-porter"
      @click="
        $router.push({
          name: 'brewery',
          params: { id: $route.params.breweryId },
        })
      "
    >
      <h1>{{ beer.name }}</h1>
      <h4>{{ $store.state.brewery.name }}</h4>
    </div>
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
          class="text-belgian align-self-end"
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
</style>