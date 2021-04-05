<template>
  <div class="flex-grow-1 d-flex justify-content-center align-items-center">
    <LoginForm />
  </div>
</template>

<script>
import LoginForm from "../components/LoginForm.vue";

export default {
  name: "login",
  components: { LoginForm },
};
</script>