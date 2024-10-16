<script setup lang="ts">
import { useI18n } from "vue-i18n";

const { t } = useI18n();
</script>

<template>
  <RouterLink
    to="/kontakt"
    class="link link-hover underline underline-offset-4"
    >{{ t("header.contact") }}</RouterLink
  >
  <RouterLink to="/o-nama" class="link link-hover underline underline-offset-4">
    {{ t("header.aboutUs") }}</RouterLink
  >
</template>
