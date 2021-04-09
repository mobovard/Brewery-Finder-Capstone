<template>
  <div class="frosty-porter flex-grow-1 d-grid my-1 p-2">
    <b-row>
      <b-col md="3" lg="2">
        <button
          class="btn btn-block bg-porter text-foam text-wheat-h"
          @click="hideForms(); displayAddBrewery = true"
        >
          Add Brewery
        </button>
        <button
          class="btn btn-block bg-porter text-foam text-wheat-h mt-md-2"
          @click="hideForms(); displayAddBeer = true"
        >
          Add Beer
        </button>
      </b-col>

      <b-col>
        <AddBreweryForm add v-if="displayAddBrewery" />
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
    hideForms() {
      this.displayAddBrewery = false;
      this.displayAddBeer = false;
    }
  }
};
</script>
