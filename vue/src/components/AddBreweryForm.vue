<template>
  <b-form class="d-grid">
    <b-row>
      <b-col>
        <h4 class="text-foam text-center">Add a Brewery</h4>
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
        ></b-form-input>

        <label for="address" class="sr-only">Brewery Address</label>
        <b-form-input
          id="address"
          v-model="brewery.address"
          placeholder="Brewery Address"
        ></b-form-input>

        <label for="email" class="sr-only">Brewery Email</label>
        <b-form-input
          id="email"
          v-model="brewery.email"
          placeholder="Brewery Email"
        ></b-form-input>

        <label for="phone" class="sr-only">Brewery Phone Number</label>
        <b-form-input
          id="phone"
          v-model="brewery.phone_number"
          placeholder="Brewery Phone Number"
        ></b-form-input>

        <label for="img" class="sr-only">Brewery Image</label>
        <b-form-input
          id="img"
          v-model="brewery.brewery_img"
          placeholder="Brewery Image"
        ></b-form-input>
      </b-col>

      <!-- Hours of Operation -->
      <b-col>
        <h5 class="text-foam">Hours of Operation:</h5>
        <label for="Monday" class="sr-only">Monday</label>
        <b-form-input
          id="Monday"
          v-model="brewery.hoursOfOperation.Monday"
          placeholder="Monday"
        ></b-form-input>

        <label for="Tuesday" class="sr-only">Tuesday</label>
        <b-form-input
          id="Tuesday"
          v-model="brewery.hoursOfOperation.Tuesday"
          placeholder="Tuesday"
        ></b-form-input>

        <label for="Wednesday" class="sr-only">Wednesday</label>
        <b-form-input
          id="Wednesday"
          v-model="brewery.hoursOfOperation.Wednesday"
          placeholder="Wednesday"
        ></b-form-input>

        <label for="Thursday" class="sr-only">Thursday</label>
        <b-form-input
          id="Thursday"
          v-model="brewery.hoursOfOperation.Thursday"
          placeholder="Thursday"
        ></b-form-input>

        <label for="Friday" class="sr-only">Friday</label>
        <b-form-input
          id="Friday"
          v-model="brewery.hoursOfOperation.Friday"
          placeholder="Friday"
        ></b-form-input>

        <label for="Saturday" class="sr-only">Saturday</label>
        <b-form-input
          id="Saturday"
          v-model="brewery.hoursOfOperation.Saturday"
          placeholder="Saturday"
        ></b-form-input>

        <label for="Sunday" class="sr-only">Sunday</label>
        <b-form-input
          id="Sunday"
          v-model="brewery.hoursOfOperation.Sunday"
          placeholder="Sunday"
        ></b-form-input>
      </b-col>
    </b-row>
    <b-row>
        <b-col>
            <b-form-textarea
                id="history"
                v-model="brewery.history"
            ></b-form-textarea>
        </b-col>
    </b-row>

    <button type="submit" class="btn bg-porter text-foam">Add</button>
    <button class=" btn bg-porter text-foam">Cancel</button>
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
