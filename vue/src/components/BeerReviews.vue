<template>
  <div class="rating d-grid">
    <div class="frosty-foam p-3 mt-2 rounded text-porter" v-if="averageRating !== 0">
      <h6>
        Avg Rating:
        <img
          src="../img/hops.png"
          class="ratingHops mr-1"
          v-for="n in Math.floor(averageRating)"
          v-bind:key="n"
        />
      </h6>
    </div>
    <div
      v-for="review in reviews"
      v-bind:key="review.rating_id"
      class="frosty-foam p-3 mt-2 rounded text-porter"
    >
      <b-row class="mx-0">
        <div class="mr-1">
          <img
            src="../img/hops.png"
            class="ratingHops mr-1"
            v-for="n in review.rating"
            v-bind:key="n"
          />
        </div>
        <div>
          <h5>
            {{ review.title }}
          </h5>
        </div>
      </b-row>
      <b-row class="mb-1 mx-0">{{ review.review }}</b-row>
      <b-row class="d-flex justify-content-end mx-0">
        <div>- {{ review.username }}</div>
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
    averageRating() {
      let sum = this.reviews.reduce((currentSum, review) => {
        return currentSum + review.rating;
      }, 0);
      if (sum === 0) {
        return 0;
      } else {
        return sum / this.reviews.length;
      }
    },
  },
};
</script>

<style scoped>
.ratingHops {
  max-height: 1.25rem;
}
</style>