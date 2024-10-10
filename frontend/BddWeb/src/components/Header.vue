<script setup lang="ts">
const handleLogin = () => {
  console.log("Login");
};

const handleRegister = () => {
  console.log("Register");
};
</script>

<template>
  <div class="absolute flex w-full items-center justify-between gap-5 p-5 z-10">
    <div class="font-bold">Bjelovar Društveni Domovi</div>
    <div class="flex gap-3">
      <RouterLink to="/a">Link</RouterLink>
      <RouterLink to="/b">Link</RouterLink>
      <RouterLink to="/c">Link</RouterLink>
    </div>
    <div class="flex items-center gap-3">
      <RouterLink to="/registracija" @click="handleRegister">Registracija</RouterLink>
      <RouterLink to="/prijava" @click="handleLogin" class="dsy-btn">
        Prijava
      </RouterLink>
      <button class="flex items-center">
        HR
        <span class="material-symbols-outlined"> arrow_drop_down </span>
      </button>
    </div>
  </div>
</template>
