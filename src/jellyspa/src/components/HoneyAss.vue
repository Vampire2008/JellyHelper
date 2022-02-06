<template>
    <Card>
        <template v-slot:title>
            <WowHeadLinkVue link="item=170069" />
        </template>
        <template v-slot:default>
            <div class="row mb-2">
                <div class="col text-center">
                    <div class="btn-group">
                        <button
                            type="button"
                            class="btn btn-outline-secondary"
                            :class="{ 'active': !step2 }"
                            @click="step2 = false"
                        >{{ t('HoneyAss.Step1') }}</button>
                        <button
                            type="button"
                            class="btn btn-outline-secondary"
                            :class="{ 'active': step2 }"
                            @click="step2 = true"
                        >{{ t('HoneyAss.Step2') }}</button>
                    </div>
                </div>
            </div>
            <div class="row mb-2">
                <div class="col">
                    <label for="currentCount" class="form-label">{{ t('HoneyAss.Current') }}:</label>
                    <input
                        type="number"
                        min="0"
                        class="form-control"
                        id="currentCount"
                        v-model="currentCount"
                    />
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <span>{{ t('HoneyAss.Left') }}: </span>
                    <span>{{ left }}</span>
                </div>
            </div>
        </template>
    </Card>
</template>

<script setup lang="ts">
import { useMainStore } from "@/stores/mainStore";
import { ref, watch } from "vue";
import { useI18n } from "vue-i18n";
import WowHeadLinkVue from "./WowHeadLink.vue";
import Card from "./ui/Card.vue";

const mainStore = useMainStore();

const { t } = useI18n();

const step2 = ref(localStorage.getItem("step2") === "true");
const currentCount = ref(Number(localStorage.getItem("currentCount")));
const left = ref(0);

function calculateLeft() {
    const leftPoints = (step2.value ? 7000 : 10500) - Number(currentCount.value);
    left.value = Math.ceil(leftPoints / 5 - mainStore.totalThinJelly);

    if (left.value < 0) {
        left.value = 0;
    }
}

mainStore.$subscribe(calculateLeft);
watch([step2, currentCount], calculateLeft);
watch(step2, () => localStorage.setItem('step2', step2.value.toString()));
watch(currentCount, () => localStorage.setItem('currentCount', currentCount.value.toString()));
calculateLeft();
</script>