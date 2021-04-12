<template>
  <b-form class="d-grid" @submit.prevent="isAdd ? addBeer() : updateBeer()">
    <h4 class="text-foam text-center mt-2 mb-3">{{isAdd ? "Add" : "Update"}} a Beer</h4>
    <p class="alert alert-warning text-center" v-if="respMsg">{{ respMsg }}</p>

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
    <div class="mt-2 d-flex justify-content-end">
        <button type="submit" class="btn bg-porter text-foam text-wheat-h" v-if="isAdd">
          Add
        </button>
        <button type="submit" class="btn bg-porter text-foam text-wheat-h" v-if="!isAdd">
          Update
        </button>
        <button
          class="btn bg-porter text-foam text-wheat-h ml-2"
          @click.prevent="setBeer"
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
            this.respMsg = `No Brewery with ID ${this.beerId} exists. Please Add instead`;
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
      breweriesService
        .addBeer(this.beer)
        .then(() => {
          this.respMsg = "Successfully added Beer";
          this.setBeer();
        })
        .catch((err) => {
          this.respMsg = "Unable to add Beer";
          console.log(err);
        });
    },
    updateBeer() {
      breweriesService
        .updateBeer(this.beer)
        .then(() => {
          this.respMsg = "Successfully updated Beer";
          this.setBeer();
        })
        .catch(err => {
          this.respMsg = "Unable to update Beer";
          console.log(err);
        })
    }
  },
};
</script>

<style></style>
