<template>
  <div class="rating d-grid">
    <div v-for="review in reviews" v-bind:key="review.rating_id" class="frosty-foam p-3 mt-2 rounded text-porter">
      <b-row class="mx-0">
        <b-col-sm>
          <img
            src="../img/hops.png"
            class="ratingHops mr-1"
            v-bind:title="review.rating"
            v-for="n in review.rating"
            v-bind:key="n"
          />
        </b-col-sm>
        <b-col>
          <h5>
          {{ review.title }}
          </h5>
        </b-col>
      </b-row>
      <b-row class="mb-1 mx-0">{{ review.review }}</b-row>
      <b-row class="d-flex justify-content-end mx-0">
        <div>
        - {{review.username}}
        </div>
      </b-row>
    </div>
  </div>
</template>

<script>
import breweriesServices from "../services/BreweriesService";
export default {
  created() {
    breweriesServices
      .getReviews(this.$route.params.beerId)
      .then((resp) => {
        this.$store.commit("SET_REVIEWS", resp.data);
      })
      .catch((err) => {
        console.log(err);
      });
  },
  computed: {
    reviews() {
      return this.$store.state.reviews;
    },
  },
};
</script>

<style scoped>
.ratingHops {
  max-height: 1.25rem;
}
</style>