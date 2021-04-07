<template>
  <div class="frosty-porter text-foam mx-auto my-auto p-2">
    <h1>Home</h1>
    <p>You must be authenticated to see this</p>
  </div>
</template>

<script>

export default {
  components: {},
  name: "home",
  created() {
    console.log(this.$store.state.user);
  }
};
</script>
