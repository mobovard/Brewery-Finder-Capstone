import Vue from 'vue'
import Router from 'vue-router'
import Home from '../views/Home.vue'
import Login from '../views/Login.vue'
import Logout from '../views/Logout.vue'
import Register from '../views/Register.vue'
import Brewery from '../views/Brewery.vue'
import Breweries from '../views/Breweries.vue'
import Beer from '../views/Beer.vue'
import Admin from '../views/Admin.vue'
import DOB from '../views/DOB.vue'
import AddUpdateBreweryForm from '../components/AddUpdateBreweryForm.vue'
import AddUpdateBeerForm from '../components/AddUpdateBeerForm.vue'
import AdminBrewerySelector from '../components/AdminBrewerySelector.vue'
import AdminBeerSelector from '../components/AdminBeerSelector.vue'
import EditUsers from '../components/EditUsers.vue'
import User from '../views/User.vue'
import store from '../store/index'

Vue.use(Router)

/**
 * The Vue Router is used to "direct" the browser to render a specific view component
 * inside of App.vue depending on the URL.
 *
 * It also is used to detect whether or not a route requires the user to have first authenticated.
 * If the user has not yet authenticated (and needs to) they are redirected to /login
 * If they have (or don't need to) they're allowed to go about their way.
 */

const router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/dob',
      name: 'dob',
      component: DOB,
      meta: {
        requiresAuth: false,
        dob_check: true,
      }
    },
    {
      path: '/',
      name: 'home',
      component: Home,
      meta: {
        requiresAuth: false,
      }
    },
    {
      path: "/login",
      name: "login",
      component: Login,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/logout",
      name: "logout",
      component: Logout,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/register",
      name: "register",
      component: Register,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/user",
      name: "user",
      component: User,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: '/breweries',
      name: 'breweries',
      component: Breweries,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: '/breweries/:id',
      name: 'brewery',
      component: Brewery,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: '/breweries/:breweryId/beers/:beerId',
      name: 'beer',
      component: Beer,
      props: true,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: '/admin',
      name: 'admin',
      component: Admin,
      meta: {
        requiresAuth: true,
        reqBrewer: true,
      },
      children: [
        {
          path: '/add-brewery',
          name: 'addBrewery',
          components: { adminForm: AddUpdateBreweryForm },
          meta: { reqAdmin: true }
        },
        {
          path: '/update-brewery',
          name: 'brewerySelector',
          components: { adminForm: AdminBrewerySelector }
        },
        {
          path: '/update-brewery/:breweryId',
          name: 'updateBrewery',
          components: { adminForm: AddUpdateBreweryForm },
          props: { adminForm: true }
        },
        {
          path: '/add-beer',
          name: 'addBeer',
          components: { adminForm: AddUpdateBeerForm },
        },
        {
          path: '/update-beer',
          name: 'beerSelector',
          components: { adminForm: AdminBeerSelector },
        },
        {
          path: '/update-beer/:beerId',
          name: 'updateBeer',
          components: { adminForm: AddUpdateBeerForm },
          props: { adminForm: true }
        },
        {
          path: '/users',
          name: 'editUsers',
          components: { adminForm: EditUsers },
          meta: { reqAdmin: true }
        }
      ]
    },
  ]
})

router.beforeEach((to, from, next) => {
  // Determine if the route requires Authentication or Admin access
  const requiresDobCheck = to.matched.some(x => !x.meta.dob_check);
  const requiresAuth = to.matched.some(x => x.meta.requiresAuth);
  const requiresAdmin = to.matched.some(x => x.meta.reqAdmin);
  const requiresBrewer = to.matched.some(x => x.meta.reqBrewer);

  // If it does and they are not logged in, send the user to "/login"
  if (requiresDobCheck && !store.getters.isOver21 && !store.getters.isLoggedIn) {
    next({ name: 'dob' });
  } else if ((requiresAdmin && !store.getters.isAdmin) // redirects to home if not admin
    || (requiresBrewer && !(store.getters.isBrewer || store.getters.isAdmin)) // redirects to home if not brewer (or admin)
    || (requiresAuth && !store.getters.isLoggedIn)) { // redirects to home if not logged in
    next({ name: 'home' });
  } else {
    // Else let them go to their next destination
    next();
  }
});

export default router;
