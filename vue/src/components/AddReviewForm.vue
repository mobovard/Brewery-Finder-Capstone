<template>
  <div>
    <button
      class="btn frosty-porter text-foam text-wheat-h"
      @click="displayAddReviewForm = !displayAddReviewForm"
    >
      Add a Review?
    </button>
    <b-form class="d-grid" v-if="displayAddReviewForm">
      <b-row>
        <b-col>
          <h4 class="text-foam text-center mt-2 mb-3">
            Review {{ $store.state.brewery.name }}
          </h4>
        </b-col>
      </b-row>

      <b-row>
        <b-col>
          <label class="d-flex align-self-start" for="title">Title:</label>
          <b-form-input
            id="title"
            type="text"
            v-model="newReview.title"
            class="mb-3"
          />
        </b-col>
      </b-row>
      <b-row>
        <b-col>
          <label class="d-flex align-self-start" for="review">Review: </label>
          <b-form-textarea
            class="mb-3"
            id="review"
            v-model="newReview.review"
          ></b-form-textarea>
        </b-col>
      </b-row>

      <b-row>
        <b-col class="d-flex justify-content-start align-items-center">
          <label class="mr-2" for="rating">Rating:</label>
          <b-form-select
            id="rating"
            v-model.number="newReview.rating"
            :select-size="1"
            size="sm"
            class="selectRating"
          >
            <option value="1">1 Hops</option>
            <option value="2">2 Hops</option>
            <option value="3">3 Hops</option>
            <option value="4">4 Hops</option>
            <option value="5">5 Hops</option>
          </b-form-select>
        </b-col>
      </b-row>
      <!-- Buttons -->
      <b-row>
        <b-col>
          <button
            class="btn frosty-porter text-foam text-wheat-h mt-2 ml-2"
            v-on:click.prevent="
              resetForm();
              displayAddReviewForm = false;
            "
            type="cancel"
          >
            Cancel
          </button>
          <button
            @click.prevent="
              addNewReview();
              resetForm();
            "
            class="btn frosty-porter text-foam text-wheat-h mt-2 ml-2"
            type="submit"
          >
            Submit
          </button>
        </b-col>
      </b-row>
    </b-form>
  </div>
</template>

<script>
import BreweriesService from "../services/BreweriesService";
export default {
  name: "addReview",
  data() {
    return {
      newReview: {
        rating: 0,
        title: "",
        review: "",
        user_id: this.$store.state.user.userId,
        beer_id: this.$route.params.beerId,
        username: this.$store.state.user.username,
      },
      displayAddReviewForm: false,
    };
  },
  methods: {
    addNewReview() {
      console.log(this.newReview);
      BreweriesService.addReview(this.newReview)
        .then((resp) => {
          this.$store.commit("ADD_REVIEW", resp.data);
        })
        .catch((err) => {
          console.log(err);
        });
      this.displayAddReviewForm = false;
    },
    resetForm() {
      this.newReview = {};
    },
  },
};
</script>

<style scoped>
.selectRating {
  max-width: 4rem;
}
</style>
