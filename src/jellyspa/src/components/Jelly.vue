<template>
    <Card>
        <template v-slot:title>{{ t("count") }}</template>
        <template v-slot:default>
            <div class="row">
                <label class="col-sm-7 col-form-label">
                    <WowHeadLink link="item=169106"></WowHeadLink>
                </label>
                <div class="col-sm-5">
                    <NumericUpDown v-model="thinJelly" :min="0"></NumericUpDown>
                </div>
            </div>
            <div class="row mt-1">
                <label for="richJelly" class="col-sm-7 col-form-label">
                    <WowHeadLink link="item=168825"></WowHeadLink>
                </label>
                <div class="col-sm-5">
                    <NumericUpDown v-model="richJelly" :min="0"></NumericUpDown>
                </div>
            </div>
            <div class="row mt-1">
                <label for="royalJelly" class="col-sm-7 col-form-label">
                    <WowHeadLink link="item=168828"></WowHeadLink>
                </label>
                <div class="col-sm-5">
                    <NumericUpDown v-model="royalJelly" :min="0"></NumericUpDown>
                </div>
            </div>
        </template>
    </Card>
</template>

<script setup lang="ts">
import { useMainStore } from "@/stores/mainStore";
import { storeToRefs } from "pinia";
import { useI18n } from "vue-i18n";

import WowHeadLink from "./WowHeadLink.vue";
import Card from "./ui/Card.vue";
import NumericUpDown from "./ui/NumericUpDown.vue";

const mainStore = useMainStore();

const { thinJelly, richJelly, royalJelly } = storeToRefs(mainStore);

const { t } = useI18n();

mainStore.$subscribe(() => {
    localStorage.setItem('thinJelly', mainStore.thinJelly.toString());
    localStorage.setItem('richJelly', mainStore.richJelly.toString());
    localStorage.setItem('royalJelly', mainStore.royalJelly.toString());
})
</script>
