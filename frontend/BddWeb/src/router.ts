import { createRouter, createWebHistory } from "vue-router";
import Home from "./components/Home.vue";
import Auth from "./components/Auth.vue";

const routes = [
  { path: "/", component: Home },
  { path: "/prijava", component: Auth },
  { path: "/registracija", component: Auth },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
