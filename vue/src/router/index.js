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
      path: '/',
      name: 'home',
      component: Home,
      meta: {
        requiresAuth: false
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
        is_admin: true,
      }
    }
  ]
})

router.beforeEach((to, from, next) => {
  // Determine if the route requires Authentication
  const requiresAuth = to.matched.some(x => x.meta.requiresAuth);
  const requiresAdmin = to.matched.some(x => x.meta.is_admin);

  if (requiresAdmin && !store.getters.isAdmin) {
    next({name: 'home'});
  }
  // If it does and they are not logged in, send the user to "/login"
  else if (requiresAuth && !store.getters.isLoggedIn) {
    next({name: 'home'});
  } else {
    // Else let them go to their next destination
    next();
  }
});

export default router;
