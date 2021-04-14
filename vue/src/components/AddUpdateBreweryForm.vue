<template>
  <b-form
    class="d-grid"
    @submit.prevent="isAdd ? addBrewery() : updateBrewery()"
  >
    <b-row>
      <b-col>
        <h4 class="text-foam text-center mt-2 mb-3">
          {{ isAdd ? "Add" : "Update" }} a Brewery
        </h4>
      </b-col>
    </b-row>

    <b-row v-if="respMsg || errMsg">
      <b-col>
        <p class="alert alert-danger text-center" v-if="errMsg">{{ errMsg }}</p>
        <p class="alert alert-success text-center" v-if="respMsg">{{ respMsg }}</p>
      </b-col>
    </b-row>

    <!-- BREWERY INFO -->
    <b-row>
      <b-col>
        <h5 class="text-foam text-center">Brewery Info:</h5>
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
        <label for="logo" class="sr-only">Brewery Logo</label>
        <b-form-input
          id="logo"
          v-model="brewery.logo"
          placeholder="Brewery Logo"
          class="mb-3"
        ></b-form-input>
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
      <b-col>
        <label for="active" class="sr-only">Inactive</label>
        <b-form-checkbox
          id="active"
          v-model="brewery.active"
          class="mb-3 text-foam"
        >
          Currently {{ brewery.active ? "Active" : "Inactive" }} Brewery
        </b-form-checkbox>
      </b-col>
    </b-row>

    <b-row>
      <b-col>
        <label for="brewer" class="sr-only">User ID of Brewer</label>
        <b-form-select v-model="brewery.user_id">
          <b-form-select-option disabled>Choose a Brewer</b-form-select-option>
          <b-form-select-option
            v-for="brewer in $store.getters.brewers"
            :key="brewer.userId"
            :value="brewer.userId"
            >{{ brewer.username }}
          </b-form-select-option>
        </b-form-select>
      </b-col>
      <b-col> </b-col>
    </b-row>
    <b-row>
      <b-col> </b-col>
      <b-col> </b-col>
    </b-row>

    <b-row>
      <!-- CONTACT INFO -->
      <b-col>
        <h5 class="text-foam text-center mt-2 mb-3">Contact Info</h5>
        <label for="address" class="sr-only">Street Address</label>
        <b-form-input
          id="address"
          v-model="brewery.address"
          placeholder="Street Address"
          class="mb-3"
        >
        </b-form-input>
        <div class="d-flex">
          <label for="city" class="sr-only">City</label>
          <b-form-input
            id="city"
            v-model="brewery.city"
            placeholder="City"
            class="mb-3 mr-1"
          >
          </b-form-input>
          <label for="state" class="sr-only">State</label>
          <b-form-input
            id="state"
            v-model="brewery.state"
            placeholder="State"
            class="mb-3 ml-1"
          >
          </b-form-input>
        </div>
        <label for="zipcode" class="sr-only">ZIP Code</label>
        <b-form-input
          id="zipcode"
          v-model="brewery.zipcode"
          placeholder="ZIP Code"
          class="mb-3"
        >
        </b-form-input>
        <label for="phone" class="sr-only">Brewery Phone Number</label>
        <b-form-input
          id="phone"
          v-model="brewery.phone_number"
          placeholder="Brewery Phone Number"
          class="mb-3"
        >
        </b-form-input>
        <label for="email" class="sr-only">Brewery Email</label>
        <b-form-input
          id="email"
          v-model="brewery.email"
          placeholder="Brewery Email"
          class="mb-3"
        >
        </b-form-input>
      </b-col>

      <!-- HOURS OF OPERATION -->
      <b-col class="d-grid">
        <h5 class="text-foam text-center mt-2 mb-3">Hours of Operation:</h5>
        <b-row>
          <b-col>
            <label for="Monday" class="sr-only">Monday</label>
            <b-form-input
              id="Monday"
              v-model="hoursOfOperation.Monday"
              placeholder="Monday"
              class="mb-3"
            >
            </b-form-input>
          </b-col>
          <b-col>
            <label for="Tuesday" class="sr-only">Tuesday</label>
            <b-form-input
              id="Tuesday"
              v-model="hoursOfOperation.Tuesday"
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
              v-model="hoursOfOperation.Wednesday"
              placeholder="Wednesday"
              class="mb-3"
            ></b-form-input>
          </b-col>
          <b-col>
            <label for="Thursday" class="sr-only">Thursday</label>
            <b-form-input
              id="Thursday"
              v-model="hoursOfOperation.Thursday"
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
              v-model="hoursOfOperation.Friday"
              placeholder="Friday"
              class="mb-3"
            ></b-form-input>
          </b-col>
          <b-col>
            <label for="Saturday" class="sr-only">Saturday</label>
            <b-form-input
              id="Saturday"
              v-model="hoursOfOperation.Saturday"
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
              v-model="hoursOfOperation.Sunday"
              placeholder="Sunday"
              class="mb-3"
            >
            </b-form-input>
          </b-col>
        </b-row>
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
    <b-row class="mt-2">
      <b-col class="d-flex justify-content-end">
        <button
          type="submit"
          class="btn bg-porter text-foam text-wheat-h"
          v-if="isAdd"
        >
          Add
        </button>
        <button
          type="submit"
          class="btn bg-porter text-foam text-wheat-h"
          v-if="!isAdd"
        >
          Update
        </button>
        <button
          class="btn bg-porter text-foam text-wheat-h ml-2"
          @click.prevent="$router.push({ name: 'admin' })"
        >
          Cancel
        </button>
      </b-col>
    </b-row>
  </b-form>
</template>

<script>
import BreweriesService from "../services/BreweriesService";
import breweriesService from "../services/BreweriesService";
export default {
  props: {
    breweryId: { type: Number },
  },
  data() {
    return {
      brewery: {},
      hoursOfOperation: {},
      errMsg: "",
      respMsg: "",
    };
  },
  created() {
    if (!this.isAdd) {
      // finds brewery in store if it exists
      let b = this.$store.getters.getBrewery(this.breweryId);
      if (b) {
        // if brewery was found, sets brewery objects in current component
        this.setBrewery(b);
      } else {
        // if brewery not found, calls API for information
        breweriesService
          .getBrewery(this.breweryId)
          .then((resp) => {
            this.setBrewery(resp.data);
          })
          .catch((err) => {
            this.errMsg = `No Brewery with ID ${this.breweryId} exists. Please Add instead`;
            console.log(err);
          });
      }
    } else {
      this.setBrewery();
    }
  },
  computed: {
    isAdd() {
      return !this.breweryId;
    },
    fullBrewery() {
      return { ...this.brewery, hoursOfOperation: this.hoursOfOperation };
    },
  },
  methods: {
    setBrewery(brewery) {
      this.brewery = brewery ?? {};
      this.hoursOfOperation = brewery?.hoursOfOperation ?? {};
    },
    addBrewery() {
      breweriesService
        .addBrewery(this.fullBrewery)
        .then(resp => {
          this.respMsg = "Successfully added Brewery";
          this.$store.commit("ADD_BREWERY", resp.data);
          this.setBrewery(resp.data);
        })
        .catch((err) => {
          this.errMsg = "Unable to add Brewery";
          console.log(err);
        });
    },
    updateBrewery() {
      BreweriesService.updateBrewery(this.fullBrewery)
        .then((resp) => {
          if (resp.status === 200) {
            this.respMsg = "Successfully updated Brewery";
          }
          this.setBrewery(resp.data);
        })
        .catch((err) => {
          this.errMsg = "Unable to update Brewery";
          console.log(err);
        });
    },
  },
};
</script>
