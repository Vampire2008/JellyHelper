<template>
    <nav class="navbar navbar-expand navbar-light bg-light">
        <div class="container">
            <a class="navbar-brand" href="#">Jelly helper</a>
            <ul class="navbar-nav ms-auto">
                <li class="nav-item">
                    <a href="https://github.com/Vampire2008" class="nav-link d-flex align-items-center" target="_blank">
                        <GitHub class="me-1" />
                        <span>Source</span>
                    </a>
                </li>
            </ul>
            <form class="d-flex">
                <div class="row align-items-center">
                    <div class="col-auto">
                        <label for="lang-selector" class="form-label col-form-label">{{ i18n.t('Language') }}</label>
                    </div>
                    <div class="col-auto">
                        <select class="form-select-sm" name="lang-selector" id="lang-selector" v-model="i18n.locale.value">
                            <option v-for="locale in i18n.availableLocales" :key="locale" :value="locale">{{ (langMap as any)[locale] }}</option>
                        </select>
                    </div>
                </div>
            </form>
        </div>
    </nav>
</template>

<script setup lang="ts">
import { useI18n } from "vue-i18n";
import GitHub from "../icons/GitHub.vue";

const i18n = useI18n();

const langMap = {
    "en": "English",
    "ru": "Русский"
};
</script>