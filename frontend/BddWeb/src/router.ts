import { createRouter, createWebHistory } from "vue-router";
import AboutUs from "./components/AboutUs.vue";
import Auth from "./components/Auth.vue";
import Contact from "./components/Contact.vue";
import Home from "./components/Home.vue";

const routes = [
  { path: "/", component: Home },
  { path: "/prijava", component: Auth },
  { path: "/registracija", component: Auth },
  { path: "/kontakt", component: Contact },
  { path: "/o-nama", component: AboutUs },
  { path: "/:notFound(.*)", redirect: "/" },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
