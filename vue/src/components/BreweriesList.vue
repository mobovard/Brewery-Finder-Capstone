<template>
  <div>
      <BreweryCard v-for="brewery in $store.state.breweries" :key="brewery.brewery_id" :brewery="brewery" />
  </div>
</template>

<script>
//import breweriesServices from '../services/BreweriesService';
import BreweryCard from './BreweryCard';

export default {
    components: { BreweryCard },
    /*created() {
        breweriesServices.getBreweries()
            .then(resp => {
                this.$store.commit('SET_BREWERIES', resp.data);
                console.log(resp.data);
            })
            .catch(err => {
                console.log(err);
            })
    }*/
}
</script>

<style>

</style>