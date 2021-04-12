<template>
  <div class="frosty-porter flex-grow-1 d-grid my-1 p-2">
    <b-row>
      <b-col md="4" lg="3">
        <b-link
          class="btn btn-block bg-porter text-foam text-wheat-h mt-2"
          v-if="$store.getters.isAdmin"
          @click="resetToInitial()"
          :to="{ name: 'addBrewery' }"
        >
          Add Brewery
        </b-link>

        <b-link
          class="btn btn-block bg-porter text-foam text-wheat-h mt-2"
          @click="
            breweryId = (displayBreweryIdSelector) ? -Infinity : null;
            if (displayBreweryIdSelector) $nextTick(() => $refs.brewId.focus());
          "
        >
          Update Brewery
        </b-link>
        <b-form-input
          ref="brewId"
          class="mt-2"
          v-if="displayBreweryIdSelector"
          v-model.number="breweryId"
          placeholder="Brewery ID"
          @keyup.enter="
            $router.push({
              name: 'updateBrewery',
              params: { breweryId: breweryId },
            });
            resetToInitial();
          "
        ></b-form-input>

        <b-link
          class="btn btn-block bg-porter text-foam text-wheat-h mt-2"
          :to="{ name: 'addBeer' }"
        >
          Add Beer
        </b-link>

        <b-link
          class="btn btn-block bg-porter text-foam text-wheat-h mt-2"
          @click="
            beerId = (displayBeerIdSelector) ? -Infinity : null;
            if (displayBeerIdSelector) $nextTick(() => $refs.beerId.focus());
          "
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
export default {
  data() {
    return {
      breweryId: -Infinity,
      beerId: -Infinity,
    };
  },
  created() {
    console.log(this.$store.getters.adminBreweries);
  },
  computed: {
    displayBreweryIdSelector() {
      return this.breweryId != -Infinity;
    },
    displayBeerIdSelector() {
      return this.beerId != -Infinity;
    }
  },
  methods: {
    resetToInitial() {
      this.breweryId = -Infinity;
      this.beerId = -Infinity;
    }
  }
};
</script>
