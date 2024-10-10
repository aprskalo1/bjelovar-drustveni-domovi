<script setup lang="ts">
import { ref } from "vue";
import Header from "./components/Header.vue";

const message = ref("");

fetch("https://localhost:7283/api/auth/get")
  .then((response) => response.text())
  .then((data) => {
    console.log(data);
    message.value = data;
  });
</script>

<template>
  <div class="relative mx-5 my-3 overflow-hidden rounded-3xl bg-base-100">
    <Header />
    <RouterView />
  </div>
</template>
