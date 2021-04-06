<template>
  <b-card>
    <b-card-img :src="brewery.brewery_img" class="img-fluid"></b-card-img>
    <b-card-title>{{ brewery.name }}</b-card-title>
  </b-card>
</template>

<script>
export default {
  props: ["brewery"],
};
</script>

<style></style>
