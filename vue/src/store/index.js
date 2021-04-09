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
      "brewery_id": 1,
      "name": "Northern Row",
      "phone_number": "(513)321-1234",
      "email": "northernrow@gmail.com",
      "address": "123 beer st",
      "history": "MadTree puts purpose in every pour. Founded in 2013, MadTree has always been driven to craft great beer - but more importantly - to build something bigger than themselves and the high-quality beer they produce. Since the beginning, MadTree has cared deeply about creating meaningful connections with their communities. They embrace their namesake and work to celebrate and protect nature while reducing their impact on the environment. They are proud members of 1% for the Planet, with a commitment to donate 1% of sales to non-profits focused on environmental sustainability. The craftspeople at MadTree wake up every day to connect people to nature and each other. MadTree. Inspiring Madness. Rooted in Purpose.",
      "active": true,
      "brewery_img": "https://cdn.citybeat.com/files/base/scomm/cb/image/2019/05/960w/NorthernRowBrewing_HB_15.5cdb2e7194008.jpg",
      "user_id": 2,
      "hoursOfOperation": {
          "Monday": "10-5",
          "Tuesday": "10-5",
          "Wednesday": "10-5",
          "Thursday": "10-5",
          "Friday": "10-5",
          "Saturday": "10-9",
          "Sunday": "10-9"
      }
  },
    beers: [],
    bg_image: ""
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
    SET_BACKGROUND(state, image) {
      state.bg_image = image;
    }
  },
  getters: {
    isLoggedIn(state) {
      return state.token != '';
    },
    isAdmin(state) {
      return state.token != '' && state.user.role === 'Admin';
    }
  }
})
