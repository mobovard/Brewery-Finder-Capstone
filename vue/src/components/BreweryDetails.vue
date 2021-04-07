<template>
  <div>
    <div class="frosty-porterdk p-3 rounded">
      <div class="text-foam d-flex flex-column align-items-center">
        <h1>{{ $store.state.brewery.name }}</h1>
      </div>
    </div>

    <div class="d-grid mt-3">
      <b-row class="m-0">
        <BeerList class="col" />
      </b-row>
      <b-row class="m-0">
        <b-col class="frosty-porterdk p-3 mr-2 mt-2 rounded">
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
        <b-col
          class="frosty-porterdk p-3 ml-2 mt-2 rounded text-foam d-flex flex-column justify-content-around"
        >
          <div>
            <h3>History</h3>
            <p>{{ $store.state.brewery.history }}</p>
          </div>
          <div>
            <h3>Contact Us</h3>
            <h5>{{ $store.state.brewery.address }}</h5>
            <h5>{{ $store.state.brewery.phone_number }}</h5>
            <h5>{{ $store.state.brewery.email }}</h5>
          </div>
        </b-col>
      </b-row>
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
