<script setup lang="ts">
import Header from "./components/Header.vue";
</script>

<template>
  <div class="relative mx-5 my-3 overflow-hidden rounded-3xl bg-base-100">
    <Header />
    <RouterView />
  </div>
</template>
