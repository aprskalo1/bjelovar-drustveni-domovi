<script setup lang="ts">
import { useI18n } from "vue-i18n";

const { t } = useI18n();
</script>

<template>
  <div
    class="relative mx-auto w-full bg-base-100 px-6 py-3 shadow-xl lg:w-1/2 lg:-translate-x-1 lg:-translate-y-[7rem] lg:rounded-3xl"
  >
    <!-- <div class="uppercase">Odaberi željeni period</div> -->
    <div class="relative flex flex-wrap gap-3">
      <div class="flex-1 rounded-md px-8 py-3 shadow-md">
        <label class="flex items-center">
          <div>{{ t("home.searchBox.from") }}</div>
          <input type="date" class="dsy-input ml-2 w-full" />
        </label>
        <div class="text-nowrap text-neutral-500">
          {{ t("home.searchBox.fromDescription") }}
        </div>
      </div>
      <div class="flex-1 rounded-md px-8 py-3 shadow-md">
        <label class="flex items-center">
          <div>{{ t("home.searchBox.to") }}</div>
          <input type="date" class="dsy-input ml-2 w-full" />
        </label>
        <div class="text-nowrap text-neutral-500">
          {{ t("home.searchBox.toDescription") }}
        </div>
      </div>
      <div
        class="absolute-center flex-center rounded-full bg-base-200 p-3 shadow-lg"
      >
        <span class="material-symbols-outlined"> swap_horiz </span>
      </div>
    </div>
    <div class="flex items-center py-2">
      {{ t("home.searchBox.showAll") }}
      <span class="material-symbols-outlined"> arrow_drop_down </span>
    </div>
    <div
      class="absolute bottom-0 right-6 w-1/3 translate-y-1/2 text-xl uppercase"
    >
      <button
        class="bg-skyBlue hover:bg-skyBlue/50 dsy-btn w-full text-xl uppercase"
      >
        {{ t("home.searchBox.search") }}
        <span class="material-symbols-outlined"> arrow_downward </span>
      </button>
    </div>
  </div>
</template>
