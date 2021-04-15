<template>
  <b-form class="d-grid" @submit.prevent="isAdd ? addBeer() : updateBeer()">
    <h4 class="text-foam text-center mt-2 mb-3">
      {{ isAdd ? "Add" : "Update" }} a Beer
    </h4>
    <p class="alert alert-danger text-center" v-if="errMsg">{{ errMsg }}</p>
    <p class="alert alert-success text-center" v-if="respMsg">{{ respMsg }}</p>

    <h5 class="text-foam text-left mt-2 mb-3">Beer Information:</h5>

    <b-row>
      <b-col>
        <label for="Name" class="sr-only">Name</label>
        <b-form-input
          id="Name"
          placeholder="Beer Name"
          class="mb-3"
          v-model="beer.name"
        >
        </b-form-input>
      </b-col>
      <b-col>
        <label for="beer_type" class="sr-only">Beer Type</label>
        <b-form-input
          id="beer_type"
          placeholder="Beer Type"
          class="mb-3"
          v-model="beer.beer_type"
        >
        </b-form-input>
      </b-col>
    </b-row>

    <b-row>
      <b-col>
        <label for="img" class="sr-only">Beer Img</label>
        <b-form-input
          id="img"
          placeholder="Beer image link"
          class="mb-3"
          v-model="beer.image"
        >
        </b-form-input>
      </b-col>
      <b-col>
        <label for="abv" class="sr-only">ABV</label>
        <b-form-input
          id="abv"
          placeholder="ABV"
          class="mb-3"
          v-model.number="beer.abv"
        ></b-form-input>
      </b-col>
    </b-row>

    <label for="description" class="sr-only">Beer Description</label>
    <b-form-textarea
      id="description"
      placeholder="Beer Description"
      class="mb-3"
      v-model="beer.description"
    >
    </b-form-textarea>

    <b-row>
      <b-col>
        <label for="breweryId" class="sr-only">Brewery ID</label>
        <b-form-select
          v-model="beer.brewery_id"
          :disabled="!$store.getters.isAdmin && !isAdd"
        >
          <b-form-select-option disabled>Choose a Brewery</b-form-select-option>
          <b-form-select-option
            v-for="brewery in $store.getters.adminBreweries"
            :key="brewery.brewery_id"
            :value="brewery.brewery_id"
            >{{ brewery.name }}
          </b-form-select-option>
        </b-form-select>
      </b-col>
      <b-col>
        <label for="active" class="sr-only">Beer Availability</label>
        <b-form-checkbox
          id="active"
          class="mb-3 text-foam"
          v-model="beer.active"
        >
          {{ beer.active ? "Currently available" : "Not currently available" }}
        </b-form-checkbox>
      </b-col>
    </b-row>

    <!-- Add Beer Buttons -->
    <div class="mt-2 d-flex justify-content-end">
      <button
        type="submit"
        class="btn frosty-foam text-foam text-wheat-h"
        v-if="isAdd"
      >
        Add
      </button>
      <button
        type="submit"
        class="btn frosty-foam text-foam text-wheat-h"
        v-if="!isAdd"
      >
        Update
      </button>
      <button
        class="btn frosty-foam text-foam text-wheat-h ml-2"
        @click.prevent="$router.push({ name: 'admin' })"
      >
        Cancel
      </button>
    </div>
  </b-form>
</template>

<script>
import breweriesService from "../services/BreweriesService";

export default {
  props: {
    beerId: { type: Number },
    breweryId: { type: Number },
  },
  data() {
    return {
      beer: {},
      errMsg: "",
      respMsg: "",
    };
  },
  created() {
    if (!this.isAdd) {
      // finds beer in store if it exists
      let b = this.$store.getters.getBeer(this.beerId);
      if (b) {
        // if beer was found, sets brewery objects in current component
        this.setBeer(b);
      } else {
        // if brewery not found, calls API for information
        breweriesService
          .getBeer(this.beerId)
          .then((resp) => {
            this.setBeer(resp.data);
          })
          .catch((err) => {
            this.errMsg = `No Brewery with ID ${this.beerId} exists. Please Add instead`;
            console.log(err);
          });
      }
    } else {
      this.setBeer();
    }
  },
  computed: {
    isAdd() {
      return !this.beerId;
    },
  },
  methods: {
    setBeer(beer) {
      this.beer = beer ?? {};
    },
    addBeer() {
      this.errMsg = "";
      this.respMsg = "";
      breweriesService
        .addBeer(this.beer)
        .then(() => {
          this.respMsg = "Successfully added Beer";
          this.setBeer();
        })
        .catch((err) => {
          this.errMsg = "Unable to add Beer";
          console.log(err);
        });
    },
    updateBeer() {
      this.errMsg = "";
      this.respMsg = "";
      breweriesService
        .updateBeer(this.beer)
        .then(() => {
          this.respMsg = "Successfully updated Beer";
        })
        .catch((err) => {
          this.errMsg = "Unable to update Beer";
          console.log(err);
        });
    },
  },
};
</script>

<style></style>
