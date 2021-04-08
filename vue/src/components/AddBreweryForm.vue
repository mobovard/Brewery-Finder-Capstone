<template>
  <b-form class="d-grid">
    <b-row>
      <b-col>
        <h4 class="text-foam text-center mt-2 mb-3">Add a Brewery</h4>
      </b-col>
    </b-row>
    <b-row>
      <b-col>
        <h5 class="text-foam text-center">Brewery & Contact Info:</h5>
      </b-col>
    </b-row>
    <b-row>
      <b-col>
        <label for="brewery_name" class="sr-only">Brewery Name</label>
        <b-form-input
          id="brewery_name"
          v-model="brewery.name"
          placeholder="Brewery Name"
          required
          class="mb-3"
        >
        </b-form-input>
      </b-col>
      <b-col>
        <label for="address" class="sr-only">Brewery Address</label>
        <b-form-input
          id="address"
          v-model="brewery.address"
          placeholder="Brewery Address"
          class="mb-3"
        >
        </b-form-input>
      </b-col>
    </b-row>
    <b-row>
      <b-col>
        <label for="email" class="sr-only">Brewery Email</label>
        <b-form-input
          id="email"
          v-model="brewery.email"
          placeholder="Brewery Email"
          class="mb-3"
        >
        </b-form-input>
      </b-col>
      <b-col>
        <label for="phone" class="sr-only">Brewery Phone Number</label>
        <b-form-input
          id="phone"
          v-model="brewery.phone_number"
          placeholder="Brewery Phone Number"
          class="mb-3"
        >
        </b-form-input>
      </b-col>
    </b-row>
    <b-row>
      <b-col>
        <label for="img" class="sr-only">Brewery Image</label>
        <b-form-input
          id="img"
          v-model="brewery.brewery_img"
          placeholder="Brewery Image"
          class="mb-3"
        ></b-form-input>
      </b-col>
    </b-row>
    <!-- Hours of Operation -->
    <b-row>
      <b-col>
        <h5 class="text-foam text-center mt-2 mb-3">Hours of Operation:</h5>
      </b-col>
    </b-row>
    <b-row>
      <b-col>
        <label for="Monday" class="sr-only">Monday</label>
        <b-form-input
          id="Monday"
          v-model="brewery.hoursOfOperation.Monday"
          placeholder="Monday"
          class="mb-3"
        >
        </b-form-input>
      </b-col>
      <b-col>
        <label for="Tuesday" class="sr-only">Tuesday</label>
        <b-form-input
          id="Tuesday"
          v-model="brewery.hoursOfOperation.Tuesday"
          placeholder="Tuesday"
          class="mb-3"
        >
        </b-form-input>
      </b-col>
    </b-row>
    <b-row>
      <b-col>
        <label for="Wednesday" class="sr-only">Wednesday</label>
        <b-form-input
          id="Wednesday"
          v-model="brewery.hoursOfOperation.Wednesday"
          placeholder="Wednesday"
          class="mb-3"
        ></b-form-input>
      </b-col>
      <b-col>
        <label for="Thursday" class="sr-only">Thursday</label>
        <b-form-input
          id="Thursday"
          v-model="brewery.hoursOfOperation.Thursday"
          placeholder="Thursday"
          class="mb-3"
        >
        </b-form-input>
      </b-col>
    </b-row>
    <b-row>
      <b-col>
        <label for="Friday" class="sr-only">Friday</label>
        <b-form-input
          id="Friday"
          v-model="brewery.hoursOfOperation.Friday"
          placeholder="Friday"
          class="mb-3"
        ></b-form-input>
      </b-col>
      <b-col>
        <label for="Saturday" class="sr-only">Saturday</label>
        <b-form-input
          id="Saturday"
          v-model="brewery.hoursOfOperation.Saturday"
          placeholder="Saturday"
          class="mb-3"
        >
        </b-form-input>
      </b-col>
    </b-row>
    <b-row>
      <b-col class="col-sm-6">
        <label for="Sunday" class="sr-only">Sunday</label>
        <b-form-input
          id="Sunday"
          v-model="brewery.hoursOfOperation.Sunday"
          placeholder="Sunday"
          class="mb-3"
        >
        </b-form-input>
      </b-col>
    </b-row>
    <b-row>
      <b-col>
        <h5 class="text-foam text-center mt-2 mb-3">History:</h5>
        <label for="history" class="sr-only">History</label>
        <b-form-textarea
          id="history"
          v-model="brewery.history"
          placeholder="Enter brewery history"
        >
        </b-form-textarea>
      </b-col>
    </b-row>

    <button type="submit" class="btn bg-porter text-foam text-wheat-h">
      Add
    </button>
    <button class="btn bg-porter text-foam text-wheat-h">Cancel</button>
  </b-form>
</template>

<script>
export default {
  data() {
    return {
      brewery: {
        name: "",
        phone_number: "",
        email: "",
        address: "",
        history: "",
        active: true,
        brewery_img: "",
        user_id: "",
        hoursOfOperation: {
          Monday: "",
          Tuesday: "",
          Wednesday: "",
          Thursday: "",
          Friday: "",
          Saturday: "",
          Sunday: "",
        },
      },
    };
  },
};
</script>

<style></style>
