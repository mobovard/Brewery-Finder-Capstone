<template>
  <div class="frosty-porter text-foam">
    {{ $store.state.user.firstName }}
    {{ $store.state.user.lastName }}
    {{ $store.state.user.username }}
    {{ $store.state.user.email }}
    {{ $store.state.user.role }}
  </div>
</template>

<script>
export default {};
</script>

<style>
</style>