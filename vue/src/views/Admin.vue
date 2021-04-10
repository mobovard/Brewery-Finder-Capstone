<template>
  <div class="frosty-porter flex-grow-1 d-grid my-1 p-2">
    <b-row>
      <b-col md="3" lg="2">
        <button
          class="btn btn-block bg-porter text-foam text-wheat-h"
          @click="
            hideForms();
            displayAddBrewery = true;
          "
        >
          Add Brewery
        </button>
        <button
          class="btn btn-block bg-porter text-foam text-wheat-h"
          @click="
            breweryId = null;
            displayUpdateBrewery = false;
            displayUpdateSelector = !displayUpdateSelector;
            if (displayUpdateSelector) $nextTick(() => $refs.breweryId.focus());
          "
        >
          Update Brewery
        </button>
        <b-form-input
          ref="breweryId"
          class="mt-2"
          v-if="displayUpdateSelector"
          v-model.number="breweryId"
          placeholder="Brewery ID"
          @keyup.enter="
            hideForms();
            displayUpdateBrewery = true;
          "
        ></b-form-input>
        <button
          class="btn btn-block bg-porter text-foam text-wheat-h mt-md-2"
          @click="
            hideForms();
            displayAddBeer = true;
          "
        >
          Add Beer
        </button>
        <button
          class="btn btn-block bg-porter text-foam text-wheat-h"
          @click="
            beerId = null;
            displayUpdateBeer = false;
            displayUpdateBeerSelector = !displayUpdateBeerSelector;
            if (displayUpdateBeerSelector) $nextTick(() => $refs.beerId.focus());
          "
        >
          Update Beer
        </button>
        <b-form-input
          ref="beerId"
          class="mt-2"
          v-if="displayUpdateBeerSelector"
          v-model.number="beerId"
          placeholder="Beer ID"
          @keyup.enter="
            hideForms();
            displayUpdateBeer = true;
          "
        ></b-form-input>
      </b-col>

      <b-col>
        <AddUpdateBreweryForm v-if="displayAddBrewery" />
        <AddUpdateBreweryForm
          :breweryId="breweryId"
          v-if="displayUpdateBrewery"
          :key="breweryId"
        />
        <AddUpdateBeerForm v-if="displayAddBeer" />
        <AddUpdateBeerForm :beerId="beerId" v-if="displayUpdateBeer" :key="beerId" />
      </b-col>
    </b-row>
  </div>
</template>

<script>
import AddUpdateBreweryForm from "../components/AddUpdateBreweryForm";
import AddUpdateBeerForm from "../components/AddUpdateBeerForm";

export default {
  components: {
    AddUpdateBreweryForm,
    AddUpdateBeerForm,
  },
  data() {
    return {
      breweryId: null,
      beerId: null,
      displayUpdateSelector: false,
      displayUpdateBeerSelector: false,
      displayAddBrewery: false,
      displayUpdateBrewery: false,
      displayAddBeer: false,
      displayUpdateBeer: false,
    };
  },
  methods: {
    hideForms() {
      this.displayUpdateSelector = false;
      this.displayUpdateBeerSelector = false;
      this.displayAddBrewery = false;
      this.displayUpdateBrewery = false;
      this.displayAddBeer = false;
      this.displayUpdateBeer = false;
    },
  },
};
</script>
