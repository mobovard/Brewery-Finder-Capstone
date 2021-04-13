<template>
  <div>
    <b-img :src="$store.state.brewery.brewery_img" class="bg-img" />
    <div class="frosty-foam p-3 rounded text-center text-porter">
      <h1>{{ beer.name }}</h1>
      <div class="d-flex justify-content-center">
        <h4
          class="pointer"
          @click="
            $router.push({
              name: 'brewery',
              params: { id: $route.params.breweryId },
            })
          "
        >
          {{ $store.state.brewery.name }}
        </h4>
      </div>
      <div
        v-if="
          $store.getters.isAdmin ||
            ($store.getters.isBrewer &&
              $store.state.adminBreweryIds.includes(
                $store.state.brewery.brewery_id
              ))
        "
        class="d-flex justify-content-end"
      >
        <b-link
          class="btn bg-wheat text-porter text-porter-h"
          :to="{ name: 'updateBeer', params: { beerId: beerId } }"
          >Edit Beer</b-link
        >
      </div>
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
                   <b-row>
              <b-col>
                <AddReviewForm />
              </b-col>
            </b-row>
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
        <BeerReviews/>
      </div>
    </div>
  </div>
</template>

<script>
import AddReviewForm from "../components/AddReviewForm";
import BeerReviews from "../components/BeerReviews";
export default {
  components: {
    AddReviewForm,
    BeerReviews
  },
  props: {
    breweryId: { type: Number },
    beerId: { type: Number },
  },
  computed: {
    beer() {
      return this.$store.getters.getBeer(this.beerId);
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
  position: fixed;
  left: 0;
  top: 0;
  height: 100vh;
  width: 100vw;
  object-fit: cover;
  z-index: 0;
}
</style>
