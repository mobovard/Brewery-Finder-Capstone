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
    brewery: {},
    beers: [],
    ageVerified: false,
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
    },
    SET_BEERS(state, beers) {
      state.beers = beers;
    },
    SET_AGE_OVER_21(state) {
      state.ageVerified = true;
    }
  },
  getters: {
    isLoggedIn(state) {
      return state.token != '';
    },
    isAdmin(state) {
      return state.token != '' && state.user.role === 'Admin';
    },
    isOver21(state) {
      return state.ageVerified; 
    },
    getBrewery: (state) => (id) => {
      return state.breweries.find(brewery => brewery.brewery_id === id);
    },
    getBeer: state => id => {
      return state.beers.find(beer => beer.beer_id === id);
    }
  }
})
