<template>
  <div class="frosty-porter flex-grow-1 d-grid my-1 p-2">
    <b-row>
      <b-col md="4" lg="3">
        <b-link
          class="btn btn-block frosty-foam text-foam text-wheat-h mt-2"
          v-if="$store.getters.isAdmin"
          :to="{ name: 'editUsers' }"
        >
          Edit Users
        </b-link>

        <b-link
          class="btn btn-block frosty-foam text-foam text-wheat-h mt-2"
          v-if="$store.getters.isAdmin"
          @click="resetToInitial()"
          :to="{ name: 'addBrewery' }"
        >
          Add Brewery
        </b-link>

        <b-link
          class="btn btn-block frosty-foam text-foam text-wheat-h mt-2"
          :to="{ name: 'brewerySelector' }"
        >
          Update Brewery
        </b-link>

        <b-link
          class="btn btn-block frosty-foam text-foam text-wheat-h mt-2"
          :to="{ name: 'addBeer' }"
        >
          Add Beer
        </b-link>

        <b-link
          class="btn btn-block frosty-foam text-foam text-wheat-h mt-2"
          :to="{ name: 'beerSelector' }"
        >
          Update Beer
        </b-link>
        <b-form-input
          ref="beerId"
          class="mt-2"
          v-if="displayBeerIdSelector"
          v-model.number="beerId"
          placeholder="Beer ID"
          @keyup.enter="
            $router.push({
              name: 'updateBeer',
              params: { beerId: beerId },
            });
            resetToInitial();
          "
        ></b-form-input>
      </b-col>

      <b-col>
        <router-view name="adminForm" :key="$route.fullPath" />
      </b-col>
    </b-row>
  </div>
</template>

<script>
import breweriesService from "../services/BreweriesService";

export default {
  data() {
    return {
      breweryId: -Infinity,
      beerId: -Infinity,
    };
  },
  created() {
    breweriesService
      .getBreweries()
      .then((resp) => {
        this.$store.commit("SET_BREWERIES", resp.data);
      })
      .catch((err) => console.log(err));
    breweriesService
      .getUsers()
      .then((resp) => {
        this.$store.commit("SET_USERS", resp.data);
      })
      .catch((err) => console.log(err));
  },
  computed: {
    displayBreweryIdSelector() {
      return this.breweryId != -Infinity;
    },
    displayBeerIdSelector() {
      return this.beerId != -Infinity;
    },
  },
  methods: {
    resetToInitial() {
      this.breweryId = -Infinity;
      this.beerId = -Infinity;
    },
  },
};
</script>
