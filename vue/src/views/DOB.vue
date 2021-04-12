<template>
  <div class="frosty-porterdk text-foam mx-auto my-auto p-2 text-center">
    <h1 class="text-wheat">Welcome to Brewery Finder</h1>
    <h2>Are you over 21?</h2>
    <button
      class="btn bg-porter text-foam text-wheat-h"
      @click="
        $store.commit('SET_AGE_OVER_21');
        $router.push({ name: 'home' });
      "
    >
      Yes
    </button>
    <b-link
      href="https://www.google.com/"
      class="btn bg-porter text-foam text-wheat-h ml-2"
    >
      No
    </b-link>
  </div>
</template>

<script>
export default {};
</script>
