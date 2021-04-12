<template>
  <div>
      <h4 class="text-foam text-center">Select Beer</h4>
    <table
      role="table"
      aria-busy="false"
      class="table b-table table-striped table-borderless table-sm text-foam"
    >
      <tbody role="rowgroup">
        <tr
          role="row"
          v-for="beer in beers"
          :key="beer.beer_id"
          class="text-wheat-h pointer"
          @click="
            $router.push({
              name: 'updateBeer',
              params: { beerId: beer.beer_id },
            })
          "
        >
          <td aria-colindex="1" role="cell">{{ beer.name }}</td>
          <td aria-colindex="1" role="cell">{{ breweryName(beer.brewery_id) }}</td>
          <td aria-colindex="2" role="cell">
            {{ beer.active ? "Active" : "Inactive" }}
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import breweriesService from "../services/BreweriesService";

export default {
  data() {
    return {
      beers: [],
    };
  },
  created() {
    this.$store.getters.adminBreweries.forEach((brewery) => {
      breweriesService
        .getBeers(brewery.brewery_id)
        .then((resp) => (this.beers = this.beers.concat(resp.data)));
    });
  },
  methods: {
      breweryName(breweryId) {
          return this.$store.state.breweries.find(brewery => breweryId === brewery.brewery_id).name;
      }
  }
};
</script>
