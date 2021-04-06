<template>
  <div>

    <div class="frosty-porter p-3">
      <div class="text-foam d-flex flex-column align-items-center">
        <h1>{{ $store.state.brewery.name }}</h1>
        <h3>{{ $store.state.brewery.address }}</h3>
        <h4>{{ $store.state.brewery.phone_number }}</h4>
      </div>
    </div>

    <div class="d-grid">
      <b-row class="m-0">
        <b-col class="frosty-belgian p-3 mt-4 mr-2">
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
        <b-col class="frosty-belgian p-3 mt-4 ml-2">
          <img
            class="img-fluid"
            :src="$store.state.brewery.brewery_img"
          /> </b-col
      ></b-row>
    </div>
  </div>
</template>

<script>
import breweriesServices from "../services/BreweriesService";
export default {
   created() {
    breweriesServices
      .getBrewery(this.$route.params.id)
      .then((resp) => {
        this.$store.commit("SET_BREWERY", resp.data);
        console.log(resp.data);
      })
      .catch((err) => {
        console.log(err);
      });
  },
};
</script>

<style>

</style>