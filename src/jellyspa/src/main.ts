import { createApp } from "vue";
import App from "./App.vue";
import "bootstrap/dist/css/bootstrap.css";
import "bootstrap/dist/js/bootstrap.bundle.js";
import i18n from "./i18n";
import { createPinia } from "pinia";

const app = createApp(App);

i18n(app);

app.use(createPinia());

app.mount("#app");
