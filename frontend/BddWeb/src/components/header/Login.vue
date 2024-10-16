<script setup lang="ts">
import { useI18n } from "vue-i18n";
import { useAuthStore } from "../../stores/auth";

const { t } = useI18n();

const authStore = useAuthStore();

const handleLogout = () => {
  authStore.onLogout();
};
</script>

<template>
  <div
    v-if="authStore.isLoggedIn"
    class="dsy-dropdown dsy-dropdown-end dsy-dropdown-hover"
  >
    <button class="dsy-btn m-1">
      {{ t("header.greeting") }}, {{ authStore.userInfo?.displayName }}
    </button>
    <ul
      tabindex="0"
      class="dsy-menu dsy-dropdown-content z-[1] w-52 rounded-box bg-base-100 p-2 text-base-content shadow"
    >
      <li>
        <button>
          {{ t("header.userAccount") }}
          <span class="material-symbols-outlined ml-auto"> person </span>
        </button>
      </li>
      <li>
        <button @click="handleLogout">
          {{ t("header.logout") }}
          <span class="material-symbols-outlined ml-auto"> logout </span>
        </button>
      </li>
    </ul>
  </div>
  <RouterLink v-else to="/prijava" class="dsy-btn">
    {{ t("header.login") }}
  </RouterLink>
</template>
