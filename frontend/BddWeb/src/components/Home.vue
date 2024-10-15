<script setup lang="ts">
import Search from "./Search.vue";

/* const searchDivHeight = ref(0);
const handleSearchHeightUpdate = (height: number) => {
  searchDivHeight.value = height;
}; */
</script>

<template>
  <div>
    <div class="relative">
      <img
        src="/pictures/landing.webp?url"
        alt=""
        class="scale-[2] opacity-75 shadow-xl lg:scale-100"
      />
      <div
        class="absolute top-6 ml-8 text-white [text-shadow:0_0_3px_black] lg:top-32"
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
