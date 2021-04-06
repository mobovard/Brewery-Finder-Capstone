<template>
  <div class="d-flex">
    <div v-if="hasError">{{ errMsg }}</div>
    <div class="flex-grow-1 d-md-flex flex-wrap justify-content-center m-2" v-if="!hasError">
      <BreweryCard
        v-for="brewery in $store.state.breweries"
        :key="brewery.brewery_id"
        :brewery="brewery"
      />
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
  },
};
</script>

<style></style>