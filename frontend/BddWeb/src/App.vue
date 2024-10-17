<script setup lang="ts">
import Header from "./components/header/Header.vue";
</script>

<template>
  <div
    class="mx-auto max-w-screen-2xl overflow-clip bg-base-100 shadow-xl 2xl:my-6 2xl:rounded-3xl"
  >
    <Header />
    <RouterView class="px-8 pb-8 pt-24 lg:pt-32" />
  </div>
</template>
