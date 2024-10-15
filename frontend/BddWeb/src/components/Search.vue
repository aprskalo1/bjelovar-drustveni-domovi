<script setup lang="ts">
/* import { onMounted, onUnmounted, ref } from "vue";

const searchDiv = ref<HTMLElement | null>(null);
const searchDivHeight = ref(0);

const emit =
  defineEmits<(event: "update:searchDivHeight", height: number) => void>();

onMounted(() => {
  const resizeObserver = new ResizeObserver((entries) => {
    for (let entry of entries) {
      if (entry.target === searchDiv.value) {
        searchDivHeight.value = entry.contentRect.height;
        emit("update:searchDivHeight", searchDivHeight.value);
      }
    }
  });
  resizeObserver.observe(searchDiv.value!);
  onUnmounted(() => {
    resizeObserver.unobserve(searchDiv.value!);
    resizeObserver.disconnect();
  });
}); */
</script>

<template>
  <div
    class="mx-auto w-1/2 -translate-x-1 -translate-y-[5rem] rounded-3xl bg-base-100 px-6 py-3 shadow-xl"
  >
    <div class="uppercase">Odaberi željeni period</div>
    <div class="relative flex flex-wrap gap-3">
      <div class="flex-1 rounded-md px-8 py-3 shadow-md">
        <label class="flex items-center">
          <div>Od</div>
          <input type="date" class="dsy-input w-full" />
        </label>
        <div class="text-neutral-500">Početak rezervacije</div>
      </div>
      <div class="flex-1 rounded-md px-8 py-3 shadow-md">
        <label class="flex items-center">
          <div>Do</div>
          <input type="date" class="dsy-input w-full" />
        </label>
        <div class="text-neutral-500">Kraj rezervacije</div>
      </div>
      <div
        class="absolute-center flex-center rounded-full bg-base-200 p-3 shadow-lg"
      >
        <span class="material-symbols-outlined"> swap_horiz </span>
      </div>
    </div>
    <div class="flex items-center py-2">
      Prikaži sve
      <span class="material-symbols-outlined"> arrow_drop_down </span>
    </div>
    <div
      class="absolute bottom-0 right-6 w-1/3 translate-y-1/2 text-xl uppercase"
    >
      <button class="dsy-btn w-full text-xl uppercase">
        Traži
        <span class="material-symbols-outlined"> arrow_downward </span>
      </button>
    </div>
  </div>
</template>
