<template>
  <div>
    <div class="frosty-porter p-3">
      <div class="brew-contactinfo text-foam d-flex flex-column">
        <h1>{{ $store.state.brewery.name }}</h1>
        <h3>{{ $store.state.brewery.address }}</h3>
        <h4>{{ $store.state.brewery.phone_number }}</h4>
      </div>
    </div>
    <div class="brew-info">
      <picture>
        <img class="brew-img" :src="$store.state.brewery.brewery_img" />
      </picture>
    </div>
  </div>
</template>

<script>
//import breweriesServices from "../services/BreweriesService";
export default {
  /* created() {
    breweriesServices
      .getBrewery(this.$route.params.id)
      .then((resp) => {
        this.$store.commit("SET_BREWERY", resp.data);
        console.log(resp.data);
      })
      .catch((err) => {
        console.log(err);
      });
  },*/
};
</script>

<style>
</style>