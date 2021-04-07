<template>
  <div>
    <div class="frosty-porterdk p-3">
      <div class="text-foam d-flex flex-column align-items-center">
        <h1>{{ beer.name }}</h1>
      </div>
    </div>
  </div>
</template>

<script>
export default {
    created(){
        console.log("I was created")
    },
    
  computed: {
    beer() {
      return this.$store.state.beers.filter(
        (beer) => beer.id === this.$route.params.beerId
      )[0];
    },
  },
};
</script>

<style>
</style>