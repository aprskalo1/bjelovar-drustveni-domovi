<script setup lang="ts">
import { useAuthStore } from "../../stores/auth";

const authStore = useAuthStore();
</script>

<template>
  <div v-if="authStore.isLoggedIn" class="dsy-btn">
    Pozdrav, {{ authStore.userInfo?.displayName }}
  </div>
  <RouterLink v-else to="/prijava" class="dsy-btn"> Prijava </RouterLink>
  <button class="flex items-center">
    HR
    <span class="material-symbols-outlined"> arrow_drop_down </span>
  </button>
</template>
