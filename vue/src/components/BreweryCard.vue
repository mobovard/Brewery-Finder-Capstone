<template>
  <b-card
    @click="
      $router.push({ name: 'brewery', params: { id: brewery.brewery_id } })
    "
    no-body
    class="frosty-porter text-foam card-size m-1 pointer"
  >
    <b-card-header class="text-center h3">{{ brewery.name }}</b-card-header>
    <b-row class="m-2">
      <b-col class="col-4 d-none d-md-block">
        <b-card-img
          :src="brewery.logo"
          class="rounded-circle img-fluid"
        ></b-card-img>
      </b-col>
      <b-col class="d-flex flex-column justify-content-center">
        <b-card-text>{{ brewery.history }}</b-card-text>
      </b-col>
    </b-row>
  </b-card>
</template>

<script>
export default {
  props: ["brewery"],
};
</script>

<style scoped>
.card-size {
  flex: 1 1 33%;
  max-width: 40rem;
}
.pointer {
  cursor: pointer;
}
</style>
