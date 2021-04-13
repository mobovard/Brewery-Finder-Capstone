<template>
<div class="rating d-grid">
    
    <div v-for="review in reviews" v-bind:key="review.rating_id">
        <b-row>
            <b-col>
    
    <img src="../img/hops.png"
    class="ratingHops"
    v-bind:title="review.rating"
    v-for="n in review.rating"
    v-bind:key="n"
    />
            </b-col>
            <b-col>
{{review.title}}
            </b-col>
        </b-row>
        <b-row>{{review.review}}</b-row>
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
.ratingHops{
    max-height: 1rem;
}
</style>