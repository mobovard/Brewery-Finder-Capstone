<template>
  <div class="frosty-porter flex-grow-1 d-grid my-1 p-2">
    <b-row>
      <b-col md="3" lg="2">
        <button
          class="btn bg-porter text-foam text-wheat-h"
          @click="displayAddBrewery = !displayAddBrewery"
        >
          Add Brewery
        </button>
        <button
          class="btn bg-porter text-foam text-wheat-h"
          @click="displayAddBeer = !displayAddBeer"
        >
          Add Beer
        </button>
      </b-col>

      <b-col>
        <AddBreweryForm v-if="displayAddBrewery" />
        <AddBeerForm v-if="displayAddBeer" />
      </b-col>
    </b-row>
  </div>
</template>

<script>
import AddBreweryForm from "../components/AddBreweryForm";
import AddBeerForm from "../components/AddBeerForm";

export default {
  components: {
    AddBreweryForm,
    AddBeerForm,
  },
  data() {
    return {
      displayAddBrewery: false,
      displayAddBeer: false,
    };
  },
  methods: {

  }
};
</script>

<style></style>
