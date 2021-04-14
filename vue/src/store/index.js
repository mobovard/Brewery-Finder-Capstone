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
    reviews: [],
    users: [],
    favoriteBreweries: [],
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
    ADD_BREWERY(state, brewery) {
      state.breweries.push(brewery);
    },
    SET_BEERS(state, beers) {
      state.beers = beers;
    },
    SET_REVIEWS(state, reviews) {
      state.reviews = reviews;
    },
    ADD_REVIEW(state, review) {
       state.reviews.push(review) 
      },
    SET_AGE_OVER_21(state) {
      state.ageVerified = true;
    },
    SET_USERS(state, users) {
      state.users = users;
    },
    UPDATE_USER(state, user) {
      state.users = state.users.map(u => (u.userId === user.userId) ? user : u);
    },
    SET_FAVORITE_BREWERIES(state, breweries) {
      state.favoriteBreweries = breweries;
    },
    ADD_FAVORITE_BREWERY(state, breweryId) {
      if (!state.favoriteBreweries.includes(breweryId)) state.favoriteBreweries.push(breweryId);
    },
    REMOVE_FAVORITE_BREWERY(state, breweryId) {
      if (state.favoriteBreweries.includes(breweryId)) {
        state.favoriteBreweries.splice(state.favoriteBreweries.indexOf(breweryId), 1);
      }
    }
  },
  getters: {
    isLoggedIn(state) {
      return state.token != '';
    },
    isBrewer(state) {
      return state.token != '' && state.user.role === 'Brewer';
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
    },
    adminBreweries(state, getters) {
      return state.breweries.filter(brewery => getters.isAdmin || (getters.isBrewer && brewery.user_id === state.user.userId));
    },
    hasAccess: (state, getters) => (id) => {
      return getters.isAdmin || (getters.isBrewer && getters.adminBreweries.map(b => b.brewery_id).includes(id));
    },
    activeBreweries(state) {
      return state.breweries.filter(brewery => brewery.active);
    },
    activeBeers(state) {
      return state.beers.filter(beer => beer.active);
    },
    brewers(state) {
      return state.users.filter(user => user.role === 'Brewer' || user.role === 'Admin')
    },
    getUser: state => id => {
      return state.users.find(user => user.userId === id);
    },
    isFavoriteBrewery: state => id => {
      return state.favoriteBreweries.includes(id);
    }
  }
})
