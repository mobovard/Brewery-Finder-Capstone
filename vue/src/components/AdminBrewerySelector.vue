<template>
  <div>
    <h4 class="text-foam text-center">Select Brewery</h4>
    <b-table
      class="text-foam"
      striped
      borderless
      small
      :items="breweries"
    ></b-table>
  </div>
</template>

<script>
export default {
  computed: {
    breweries() {
      return this.$store.getters.adminBreweries.map((brewery) => {
        return { name: brewery.name, status: brewery.active ? 'Active' : 'Inactive' };
      });
    },
  },
};
</script>

<style></style>
