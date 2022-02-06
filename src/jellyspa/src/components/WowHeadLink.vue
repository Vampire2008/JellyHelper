<template>
    <a :href="`https://${wowHeadDomain}.wowhead.com/${link}`"
        @click="onClick"
        :class="{ prevent }"
        >{{ link }}</a
    >
</template>

<script setup lang="ts">
import { computed, onUpdated } from "vue";
import { useI18n } from "vue-i18n";
import wowheadUpdate from "@/utils/WowheadUpdate";

const props = withDefaults(defineProps<{
    link: string;
    prevent?: boolean
}>(), {
    prevent: false
});

const i18n = useI18n();

const wowHeadDomain = computed(() => {
    const supportedLang = ["en", "ru", "de", "fr", "es", "it", "pt", "ko", "cn"];
    const lang = i18n.locale.value;
    const navigatorLang = navigator.language.substring(0, 2);

    if (lang !== navigatorLang && i18n.availableLocales.indexOf(navigatorLang) === -1 && supportedLang.indexOf(navigatorLang) > -1) {
        return navigatorLang;
    } else {
        return lang.replace("en", "wwww");
    }
});

onUpdated(wowheadUpdate);

function onClick(e: Event) {
    if (props.prevent) {
        e.preventDefault();
    }
}
</script>

<style>
.prevent {
    text-decoration: none !important;
    color: black;
}

.prevent:visited {
    color: black;
}
</style>
