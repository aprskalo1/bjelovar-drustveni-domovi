<script setup lang="ts">
import Search from "./Search.vue";

import { onMounted, onUnmounted, ref } from "vue";

const landingImg = ref<HTMLElement | null>(null);
const landingImgHeight = ref(0);

onMounted(() => {
  const resizeObserver = new ResizeObserver((entries) => {
    for (let entry of entries) {
      if (entry.target === landingImg.value) {
        landingImgHeight.value = entry.contentRect.height * 1.5 - 30;
      }
    }
  });
  resizeObserver.observe(landingImg.value!);
  onUnmounted(() => {
    resizeObserver.unobserve(landingImg.value!);
    resizeObserver.disconnect();
  });
});
</script>

<template>
  <div>
    <div
      class="relative overflow-hidden lg:!h-auto"
      :style="{ height: landingImgHeight + 'px' }"
    >
      <img
        src="/pictures/landing.webp?url"
        alt=""
        class="landing-img opacity-75 shadow-xl"
        ref="landingImg"
      />
      <div
        class="absolute top-24 w-full bg-white/50 px-8 py-6 text-center text-white backdrop-blur-sm [text-shadow:0_0_3px_black] lg:top-32 lg:bg-transparent lg:text-left lg:backdrop-blur-none"
      >
        <div class="pb-5 text-4xl font-extrabold lg:text-6xl">
          Rezerviraj društveni dom
        </div>
        <div class="text-xl">Mjesta za događaje koje pamtiš</div>
      </div>
    </div>
    <Search />
    <div class="bg-red-500 p-8">ahahhaha</div>
  </div>
</template>

<style scoped>
.landing-img {
  transform: scale(1.5) translateY(30%);
  transform-origin: bottom;
  transition: transform 0.5s;
}
@screen lg {
  .landing-img {
    transform: none;
  }
}
</style>
