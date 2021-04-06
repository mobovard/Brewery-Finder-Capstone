<template>
  <div :class="this.class">
    <div v-if="hasError">{{ errMsg }}</div>
    <div
      class="d-flex flex-wrap justify-content-around"
      v-if="!hasError"
    >
      <BeerCard
        v-for="beer in $store.state.beers"
        :key="beer.brewery_id"
        :beer="beer"
      />
    </div>
  </div>
</template>

<script>
import breweriesServices from "../services/BreweriesService";
import BeerCard from "./BeerCard";

export default {
  props: [ "class" ],
  components: { BeerCard },
  data() {
    return {
      errMsg: "",
    };
  },
  created() {
    breweriesServices
      .getBeers(this.$route.params.id)
      .then((resp) => {
        this.$store.commit("SET_aEERS", resp.data);
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
