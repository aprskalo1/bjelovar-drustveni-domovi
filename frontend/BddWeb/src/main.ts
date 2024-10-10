import VWave from "v-wave";
import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import "./styles/main.css";
import { createPinia } from "pinia";

const pinia = createPinia();

createApp(App).use(pinia).use(router).use(VWave, {}).mount("#app");
