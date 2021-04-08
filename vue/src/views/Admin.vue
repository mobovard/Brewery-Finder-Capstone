<template>
  <div class="frosty-porter flex-grow-1 d-grid my-1 p-2">
    <b-row>
      <b-col md="3" lg="2">
        <button
          class="btn bg-porter text-foam text-wheat-h"
          @click="displayAddBrewery = !displayAddBrewery"
          >Add Brewery</button
        >
      </b-col>

      <b-col>
        <AddBreweryForm v-if="displayAddBrewery" />
      </b-col>
    </b-row>
  </div>
</template>

<script>
import AddBreweryForm from "../components/AddBreweryForm";

export default {
  components: { AddBreweryForm },
  data() {
    return {
      displayAddBrewery: false,
    };
  },
};
</script>

<style></style>
