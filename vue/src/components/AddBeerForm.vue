<template>
  <b-form class="d-grid">
    <b-row>
      <b-col>
        <h4 class="text-foam text-center mt-2 mb-3">Add a Beer</h4>
      </b-col>
    </b-row>
        <b-row>
      <b-col>
        <h5 class="text-foam text-left mt-2 mb-3">Beer Information:</h5>
      </b-col>
    </b-row>
    <b-row>
      <b-col>
        <label for="Name" class="sr-only">Name</label>
        <b-form-input id="Name" placeholder="Beer Name" class="mb-3">
        </b-form-input>
      </b-col>
    </b-row>

    <b-row>
      <b-col>
        <label for="beer_type" class="sr-only">Beer Type</label>
        <b-form-input id="beer_type" placeholder="Beer Type" class="mb-3">
        </b-form-input>
      </b-col>
    </b-row>

    <b-row>
      <b-col>
        <label for="abv" class="sr-only">ABV</label>
        <b-form-input id="abv" placeholder="ABV" class="mb-3"> </b-form-input>
      </b-col>
    </b-row>

    <b-row>
      <b-col>
        <label for="description" class="sr-only">Beer Description</label>
        <b-form-input
          id="description"
          placeholder="Beer Description"
          class="mb-3"
        >
        </b-form-input>
      </b-col>
    </b-row>

    <b-row>
      <b-col>
        <label for="img" class="sr-only">Beer Img </label>
        <b-form-input id="img" placeholder="Beer image link" class="mb-3">
        </b-form-input>
      </b-col>
    </b-row>

    <!-- Need to link the active / inactive checkbox to the database -->
    <b-row>
      <b-col>
        <label for="active" class="sr-only">Active</label>
        <b-form-checkbox id="active" class="mb-3 text-foam">
          Add v-model as if the beer is active or inactive
        </b-form-checkbox>
      </b-col>
    </b-row>
    <!-- Add Beer Buttons -->
    <b-row class="mt-2">
      <b-col class="d-flex justify-content-end">
        <button type="submit" class="btn bg-porter text-foam text-wheat-h">
          Add
        </button>
        <button class="btn bg-porter text-foam text-wheat-h ml-2">
          Cancel
        </button>
      </b-col>
    </b-row>
  </b-form>
</template>

<script>
// import breweriesService from "../services/BreweriesService";
export default {};
</script>

<style>
</style>