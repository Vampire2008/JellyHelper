import type { App } from "vue";
import { createI18n } from "vue-i18n";
import messages from "@intlify/vite-plugin-vue-i18n/messages";

export default function (app: App): void {

    const i18n = createI18n({
        legacy: false,
        locale: navigator.language.substring(0, 2),
        fallbackLocale: "en",
        messages
    });

    app.use(i18n);
}
