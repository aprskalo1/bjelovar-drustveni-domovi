<script setup lang="ts">
import Links from "./Links.vue";
</script>

<template>
  <div
    class="absolute z-10 flex w-full flex-wrap items-center justify-between gap-5 p-4 text-white lg:bg-transparent lg:p-8"
  >
    <RouterLink to="/" class="flex items-center gap-3 font-bold">
      <img src="/favicon.png" alt="" class="h-8" />
      <div class="text-xs lg:text-base">Bjelovar Društveni Domovi</div>
    </RouterLink>
    <div
      class="order-last flex basis-full justify-center gap-6 lg:order-none lg:basis-auto"
    >
      <Links />
    </div>
    <div class="flex items-center justify-center gap-3">
      <RouterLink to="/prijava" class="dsy-btn text-xs lg:text-base">
        Prijava
      </RouterLink>
      <button class="flex items-center">
        HR
        <span class="material-symbols-outlined"> arrow_drop_down </span>
      </button>
    </div>
  </div>
</template>
