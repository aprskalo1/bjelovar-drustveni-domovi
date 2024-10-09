<script setup lang="ts">
import { ref } from "vue";

const message = ref("");

fetch("https://localhost:7283/api/auth/get")
  .then((response) => response.text())
  .then((data) => {
    console.log(data);
    message.value = data;
  });
</script>

<template>
  {{ message }}
</template>
