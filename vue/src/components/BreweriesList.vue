<template>
  <div>
    <div v-if="hasError" class="alert alert-danger">{{ errMsg }}</div>
    <div v-if="!hasError">
      <div class="d-flex mt-2 justify-content-end">
        <label for="filter" class="sr-only">Search Brewery</label>
        <b-form-input
          id="filter"
          v-model="filter"
          placeholder="Search"
          class="w-25"
        ></b-form-input>
      </div>
      <div class="d-flex">
        <div class="flex-grow-1 d-md-flex flex-wrap justify-content-center m-2">
          <BreweryCard
            v-for="brewery in filteredBreweries"
            :key="brewery.brewery_id"
            :brewery="brewery"
          />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import breweriesServices from "../services/BreweriesService";
import BreweryCard from "./BreweryCard";

export default {
  components: { BreweryCard },
  data() {
    return {
      filter: "",
      errMsg: "",
    };
  },
  created() {
    breweriesServices
      .getBreweries()
      .then((resp) => {
        this.$store.commit("SET_BREWERIES", resp.data);
      })
      .catch((err) => {
        this.errMsg = err.message;
        console.log(err);
      });
  },
  computed: {
    hasError() {
      return this.errMsg != "";
    },
    filteredBreweries() {
      return this.$store.getters.activeBreweries.filter((brewery) =>
        brewery.name.toLowerCase().includes(this.filter.toLowerCase())
        || brewery.history.toLowerCase().includes(this.filter.toLowerCase())
      );
    },
  },
};
</script>

<style></style>
