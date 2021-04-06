<template>
  <div>
    <div class="frosty-porterdk p-3">
      <div class="text-foam d-flex flex-column align-items-center">
        <h1>{{ $store.state.brewery.name }}</h1>
        <h3>{{ $store.state.brewery.address }}</h3>
        <h4>{{ $store.state.brewery.phone_number }}</h4>
      </div>
    </div>

    <div class="d-grid mt-3">
      <b-row class="m-0">
        <BeerList class="col" />
      </b-row>
      <b-row class="m-0">
        <b-col class="frosty-porterdk p-3 mr-2 mt-2">
          <img class="img-fluid" :src="$store.state.brewery.brewery_img" />
          <div class="hours-table">
            <b-table
              class="text-foam"
              striped
              borderless
              small
              :items="$store.state.brewery.hours_of_operation"
            ></b-table>
          </div>
        </b-col>
        <b-col class="frosty-porterdk p-3 ml-2 mt-2 text-foam ">
          <p>{{ $store.state.brewery.history }}</p>
        </b-col></b-row
      >
    </div>
  </div>
</template>

<script>
//import breweriesServices from "../services/BreweriesService.vue";
import BeerList from "./BeerList";

export default {
  components: { BeerList },
  /*  created() {
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

<style></style>
