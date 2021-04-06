<template>
  <div>
    <b-card class="d-grid text-porter bg-foam card-size">
      <b-row>
        <b-col>
          <b-card-img
            :src="beer.image"
            class="rounded-circle img-fluid"
          ></b-card-img>
        </b-col>
      </b-row>
      <b-row>
        <b-col class="text-center">
          <b-card-title>{{ beer.name }}</b-card-title>
          <b-card-text>{{ `${beer.abv}%` }}</b-card-text>
        </b-col>
      </b-row>
    </b-card>
  </div>
</template>

<script>
export default {
  props: ["beer"],
};
</script>

<style scoped>
.card-size {
  max-width: 10rem;
}
</style>
