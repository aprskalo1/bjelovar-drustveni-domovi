<script setup lang="ts">
import { computed, onMounted, ref } from "vue";
import { useRoute } from "vue-router";
import Language from "./Language.vue";
import Links from "./Links.vue";
import Login from "./Login.vue";
import Title from "./Title.vue";

const route = useRoute();
const isLandingPage = computed(() => route.path === "/");

const stickyDiv = ref<HTMLElement | null>(null);
const isSticky = ref(false);

onMounted(() => {
  if (!stickyDiv.value) return;
  const observer = new IntersectionObserver(
    ([e]) => (isSticky.value = e.intersectionRatio < 1),
    { threshold: [1] },
  );
  observer.observe(stickyDiv.value!);
});
</script>

<template>
  <div class="sticky top-[-1px] z-10 h-0" ref="stickyDiv">
    <div
      class="flex w-full flex-wrap items-center justify-between gap-5 p-4 lg:p-8 transition-all duration-300"
      :class="{
        'text-base-content': !isLandingPage,
        'text-white': isLandingPage && !isSticky,
        'shadow-md backdrop-blur-md bg-white/75 text-base-content !py-3': isSticky,
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
  </div>
</template>
