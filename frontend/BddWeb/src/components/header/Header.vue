<script setup lang="ts">
import { computed } from "vue";
import { useRoute } from "vue-router";
import Links from "./Links.vue";
import Login from "./Login.vue";
import Title from "./Title.vue";
import Language from "./Language.vue";

const route = useRoute();
const isLandingPage = computed(() => route.path === "/");
</script>

<template>
  <div
    class="absolute z-10 flex w-full flex-wrap items-center justify-between gap-5 p-4 lg:p-8"
    :class="{
      'bg-base-300 text-base-content shadow-md': !isLandingPage,
      'text-white': isLandingPage,
    }"
  >
    <Title />
    <div class="hidden justify-center gap-6 lg:flex">
      <Links />
    </div>
    <div class="hidden items-center justify-center gap-3 lg:flex">
      <Login />
      <Language />
    </div>
    <div class="dsy-drawer dsy-drawer-end w-auto lg:hidden">
      <input id="main-drawer" type="checkbox" class="dsy-drawer-toggle" />
      <div class="dsy-drawer-content">
        <label for="main-drawer">
          <span class="material-symbols-outlined lg:hidden"> menu </span>
        </label>
      </div>
      <div class="dsy-drawer-side">
        <label
          for="main-drawer"
          aria-label="close sidebar"
          class="dsy-drawer-overlay"
        ></label>
        <ul
          class="dsy-menu flex min-h-full w-80 items-center bg-base-200 p-4 text-base-content"
        >
          <Title class="mb-6" />
          <div class="flex items-center justify-center gap-3">
            <Login />
          </div>
          <div class="flex flex-col gap-3 text-xl">
            <Links />
          </div>
        </ul>
      </div>
    </div>
  </div>
</template>
