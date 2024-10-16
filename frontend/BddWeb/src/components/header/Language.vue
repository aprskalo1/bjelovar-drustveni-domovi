<script setup lang="ts">
import { useI18n } from "vue-i18n";

const { t } = useI18n();

const changeLocale = (locale: string) => {
  localStorage.setItem("locale", locale);
  document.title = t("appName");
};

document.title = t("appName");
</script>

<template>
  <select
    class="dsy-select bg-transparent text-xl *:text-base-content"
    v-model="$i18n.locale"
    @change="changeLocale(($event!.target as HTMLSelectElement).value)"
  >
    <option value="hr">HR</option>
    <option value="en">EN</option>
  </select>
</template>
