<template>
  <div>
    <b-img :src="$store.state.brewery.brewery_img" class="bg-img" />
    <div class="frosty-porterdk p-3 rounded">
      <div class="text-foam d-flex flex-column align-items-center">
        <h1>{{ $store.state.brewery.name }}</h1>
      </div>
      <b-link
        class="btn bg-porter text-foam text-wheat-h"
        v-if="$store.getters.isAdmin"
        :to="{
          name: 'updateBrewery',
          params: { breweryId: $store.state.brewery.brewery_id },
        }"
      > Update
      </b-link>
    </div>

    <div class="d-grid mt-3">
      <b-row class="m-0">
        <BeerList class="col" />
      </b-row>
      <b-row class="m-0">
        <b-col class="frosty-porterdk p-3 mr-2 mt-2 rounded">
          <img class="img-fluid" :src="$store.state.brewery.logo" />
          <div class="hours-table">
            <b-table
              class="text-foam"
              striped
              borderless
              small
              :items="hoo"
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
import breweriesServices from "../services/BreweriesService";
import BeerList from "./BeerList";

export default {
  components: { BeerList },
  data() {
    return {
      hoo: [],
    };
  },
  created() {
    breweriesServices
      .getBrewery(this.$route.params.id)
      .then((resp) => {
        this.$store.commit("SET_BREWERY", resp.data);

        // creates list version of hours of op
        for (const [day, time] of Object.entries(
          this.$store.state.brewery.hoursOfOperation
        )) {
          this.hoo.push({ Day: day, Hours: time });
        }
      })
      .catch((err) => {
        console.log(err);
      });
  },
};
</script>

<style scoped>
.bg-img {
  position: fixed;
  left: 0;
  top: 0;
  height: 100vh;
  width: 100vw;
  object-fit: cover;
  z-index: 0;
}
</style>