<template>
  <b-card
    @click="
      $router.push({ name: 'brewery', params: { id: brewery.brewery_id } })
    "
    no-body
    class="frosty-porter text-foam card-size m-1 pointer"
    style="max-width: 40%"
  >
    <b-card-header class="text-center h3">{{ brewery.name }}</b-card-header>
    <b-row class="m-2 row-height">
      <b-col class="col-4 d-none d-md-block">
        <b-card-img
          :src="brewery.logo"
          class="rounded-circle img-fluid"
        ></b-card-img>
      </b-col>
      <b-col
        class="d-flex flex-column align-items-center justify-content-center testing"
      >
        <b-card-text class="">{{ brewery.history }}</b-card-text>
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
  max-height: 10rem;
}
.testing {
  display: block;
  text-overflow: ellipsis;
  overflow: auto;
  max-height: 5rem;
}
.testing::-webkit-scrollbar {
  background-color: rgba(221, 192, 143, 0.3);
  border-radius: 2rem;
}
.testing::-webkit-scrollbar-thumb {
  background-color: rgba(48, 22, 17, 0.3);
  border-radius: 2rem;
}

.pointer {
  cursor: pointer;
}
.row-height {
  min-height: 107.98px;
  align-items: center;
}
</style>
