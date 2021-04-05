<template>
  <div class="flex-grow-1 d-flex justify-content-center align-items-center">
    <RegisterForm />
  </div>
</template>

<script>
import RegisterForm from "../components/RegisterForm";

export default {
  name: "register",
  components: { RegisterForm },
};
</script>