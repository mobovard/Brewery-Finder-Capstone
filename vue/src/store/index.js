import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

/*
 * The authorization header is set for axios when you login but what happens when you come back or
 * the page is refreshed. When that happens you need to check for the token in local storage and if it
 * exists you should set the header so that it will be attached to each request
 */
const currentToken = localStorage.getItem('token')
const currentUser = JSON.parse(localStorage.getItem('user'));

if (currentToken != null) {
  axios.defaults.headers.common['Authorization'] = `Bearer ${currentToken}`;
}

export default new Vuex.Store({
  state: {
    token: currentToken || '',
    user: currentUser || {},
    breweries: [],
    brewery: {
      brewery_id: 1,
      name: 'A Brewery',
      phone_number: "123-456-7890",
      email: "breweryemail@email.com",
      address: "123 A St.",
      history: "this is a sample history of this brewery",
      active: true,
      brewery_img: "https://images.unsplash.com/photo-1528823872057-9c018a7a7553?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80",
      hours_of_operation: [
        { Day: "Monday", Hours: "11AM - 11PM" },
        { Day: "Tuesday", Hours: "11AM - 11PM" },
        { Day: "Wednesday", Hours: "11AM - 11PM" },
        { Day: "Thursday", Hours: "11AM - 11PM" },
        { Day: "Friday", Hours: "11AM - 1AM" },
        { Day: "Saturday", Hours: "11AM - 1AM" },
        { Day: "Sunday", Hours: "11AM - 11PM" }
      ],
      user_id: 2
    }
  },

  mutations: {
    SET_AUTH_TOKEN(state, token) {
      state.token = token;
      localStorage.setItem('token', token);
      axios.defaults.headers.common['Authorization'] = `Bearer ${token}`
    },
    SET_USER(state, user) {
      state.user = user;
      localStorage.setItem('user', JSON.stringify(user));
    },
    LOGOUT(state) {
      localStorage.removeItem('token');
      localStorage.removeItem('user');
      state.token = '';
      state.user = {};
      axios.defaults.headers.common = {};
    },
    SET_BREWERIES(state, breweries) {
      state.breweries = breweries;
    },
    SET_BREWERY(state, brewery) {
      state.brewery = brewery;
    }
  },
  getters: {
    isLoggedIn(state) {
      return state.token != '';
    }
  }
})
