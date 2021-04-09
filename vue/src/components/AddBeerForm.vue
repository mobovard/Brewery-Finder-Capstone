<template>
  <b-form class="d-grid" @submit.prevent="addBeer">
    <h4 class="text-foam text-center mt-2 mb-3">Add a Beer</h4>

    <h5 class="text-foam text-left mt-2 mb-3">Beer Information:</h5>

    <label for="Name" class="sr-only">Name</label>
    <b-form-input
      id="Name"
      placeholder="Beer Name"
      class="mb-3"
      v-model="beer.name"
    >
    </b-form-input>

    <label for="beer_type" class="sr-only">Beer Type</label>
    <b-form-input
      id="beer_type"
      placeholder="Beer Type"
      class="mb-3"
      v-model="beer.beer_type"
    >
    </b-form-input>

    <label for="abv" class="sr-only">ABV</label>
    <b-form-input
      id="abv"
      placeholder="ABV"
      class="mb-3"
      v-model.number="beer.abv"
    ></b-form-input>

    <label for="description" class="sr-only">Beer Description</label>
    <b-form-input
      id="description"
      placeholder="Beer Description"
      class="mb-3"
      v-model="beer.description"
    >
    </b-form-input>

    <label for="img" class="sr-only">Beer Img</label>
    <b-form-input
      id="img"
      placeholder="Beer image link"
      class="mb-3"
      v-model="beer.image"
    >
    </b-form-input>

    <label for="breweryId" class="sr-only">Brewery ID</label>
    <b-form-input
      id="breweryId"
      placeholder="Brewery ID"
      class="mb-3"
      v-model.number="beer.brewery_id"
    >
    </b-form-input>

    <label for="active" class="sr-only">Beer Availability</label>
    <b-form-checkbox id="active" class="mb-3 text-foam" v-model="beer.active">
      {{ beer.active ? "Currently available" : "Not currently available" }}
    </b-form-checkbox>
    <!-- Add Beer Buttons -->
    <b-row class="mt-2">
      <b-col class="d-flex justify-content-end">
        <button type="submit" class="btn bg-porter text-foam text-wheat-h">
          Add
        </button>
        <button
          class="btn bg-porter text-foam text-wheat-h ml-2"
          @click.prevent="clearBeer"
        >
          Cancel
        </button>
      </b-col>
    </b-row>
  </b-form>
</template>

<script>
import breweriesService from "../services/BreweriesService";

export default {
  data() {
    return {
      beer: {},
    };
  },
  created() {
    this.clearBeer;
  },
  methods: {
    clearBeer() {
      this.beer = {
        name: null,
        description: null,
        image: null,
        abv: null,
        brewery_id: null,
        beer_type: null,
        active: false,
      };
    },
    addBeer() {
      breweriesService
        .addBeer(this.beer)
        .then((resp) => {
          console.log(resp);
        })
        .catch((err) => {
          console.log(err);
        });
    },
  },
};
</script>

<style></style>
