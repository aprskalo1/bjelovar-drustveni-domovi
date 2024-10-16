<script setup lang="ts">
import { useI18n } from "vue-i18n";
import { useAuthStore } from "../../stores/auth";

const { t } = useI18n();

const authStore = useAuthStore();
</script>

<template>
  <div v-if="authStore.isLoggedIn" class="dsy-btn">
    {{ t("header.greeting") }}, {{ authStore.userInfo?.displayName }}
  </div>
  <RouterLink v-else to="/prijava" class="dsy-btn">
    {{ t("header.login") }}
  </RouterLink>
</template>
