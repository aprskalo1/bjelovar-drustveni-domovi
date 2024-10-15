<script setup lang="ts">
import Header from "./components/header/Header.vue";
</script>

<template>
  <div
    class="relative mx-auto max-w-screen-2xl overflow-hidden bg-base-100 shadow-xl 2xl:my-6 2xl:rounded-3xl"
  >
    <Header />
    <RouterView />
  </div>
</template>
