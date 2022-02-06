<template>
    <Card>
        <template v-slot:title>{{ t('OtherItems.Title') }}</template>
        <template v-slot:default>
            <div class="row mb-2">
                <div class="col">
                    <label class="form-label">{{ t('OtherItems.SelectItem') }}:</label>
                    <div class="dropdown">
                        <button
                            ref="dropDownToggle"
                            class="btn btn-outline-secondary dropdown-toggle w-100 list-button"
                            type="button"
                            data-bs-toggle="dropdown"
                            @click="open"
                        >
                            <WowHeadLink :link="`item=${selectedItem.id}`" :prevent="true" />
                        </button>
                        <ul class="dropdown-menu w-100">
                            <li>
                                <a
                                    class="dropdown-item"
                                    href="#"
                                    v-for="item in itemsList"
                                    :key="item.id"
                                    @click="selectItem(item)"
                                >
                                    <WowHeadLink :link="`item=${item.id}`" :prevent="true" />
                                </a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="row mb-2">
                <div class="col">
                    <div>{{ t('OtherItems.Cost') }}:</div>
                    <div v-if="selectedItem.thinCost > 0">
                        <WowHeadLink link="item=169106" />:
                        <span>{{ selectedItem.thinCost }}</span>
                    </div>
                    <div v-if="selectedItem.richCost > 0">
                        <WowHeadLink link="item=168825" />:
                        <span>{{ selectedItem.richCost }}</span>
                    </div>
                    <div v-if="selectedItem.royalCost > 0">
                        <WowHeadLink link="item=168828" />:
                        <span>{{ selectedItem.royalCost }}</span>
                    </div>
                </div>
            </div>
            <div class="row mb-2">
                <div class="col">
                    <span>{{ t('HoneyAss.Left') }}: </span>
                    <span>{{ left }}</span>
                </div>
            </div>
            <div class="row mb-2">
                <div class="col">
                    <div>{{ t('OtherItems.Formulas') }}:</div>
                    <div class="row gx-1">
                        <div class="col">
                            <WowHeadLink link="item=169106" class="me-1" />
                            <span>x 8</span>
                        </div>
                        <div class="col-auto">-&gt;</div>
                        <div class="col">
                            <WowHeadLink link="item=168828" />
                        </div>
                    </div>
                    <div class="row gx-1">
                        <div class="col">
                            <WowHeadLink link="item=168828" class="me-1" />
                        </div>
                        <div class="col-auto">-&gt;</div>
                        <div class="col">
                            <WowHeadLink link="item=169106" class="me-1" />
                            <span>x 8</span>
                        </div>
                    </div>
                    <div class="row gx-1">
                        <div class="col">
                            <WowHeadLink link="item=169106" class="me-1" />
                            <span>x 4</span>
                        </div>
                        <div class="col-auto">-&gt;</div>
                        <div class="col">
                            <WowHeadLink link="item=168825" />
                        </div>
                    </div>
                </div>
            </div>
        </template>
    </Card>
</template>

<script setup lang="ts">
import { onMounted, ref, watch, type Ref } from "vue";
import WowHeadLink from "./WowHeadLink.vue";
import Dropdown from "bootstrap/js/dist/dropdown";
import { useI18n } from "vue-i18n";
import { useMainStore } from "@/stores/mainStore";
import Card from "./ui/Card.vue";

interface IItem {
    id: number;
    thinCost: number;
    richCost: number;
    royalCost: number;
}

const { t } = useI18n();

const itemsList: IItem[] = [
    {
        id: 172383,
        thinCost: 0,
        richCost: 0,
        royalCost: 35
    },
    {
        id: 169862,
        thinCost: 5,
        richCost: 0,
        royalCost: 0
    },
    {
        id: 169395,
        thinCost: 15,
        richCost: 0,
        royalCost: 0
    },
    {
        id: 169109,
        thinCost: 0,
        richCost: 20,
        royalCost: 0
    },
    {
        id: 169141,
        thinCost: 0,
        richCost: 0,
        royalCost: 25
    }
];

const mainStore = useMainStore();

const dropDownToggle: Ref<HTMLElement | null> = ref(null);

const selectedItemId = Number(localStorage.getItem("selectedItem"));

let selectedItemIndex = selectedItemId
    ? itemsList.findIndex(i => i.id === selectedItemId)
    : 0;

if (selectedItemIndex < 0) {
    selectedItemIndex = 0;
}

const selectedItem = ref(itemsList[selectedItemIndex]);
const left = ref(0);

function selectItem(item: IItem) {
    selectedItem.value = item;
}

function open() {
    dropdown.value?.toggle();
}

function calculateLeft() {
    if (selectedItem.value.royalCost > 0) {
        left.value = selectedItem.value.royalCost - mainStore.royalJelly - Math.floor(mainStore.thinJelly / 8);
    } else if (selectedItem.value.thinCost > 0) {
        left.value = selectedItem.value.thinCost - mainStore.thinJelly - mainStore.royalJelly * 8;
    } else if (selectedItem.value.richCost > 0) {
        left.value = selectedItem.value.richCost - mainStore.richJelly - Math.floor(mainStore.thinJelly / 4) - mainStore.royalJelly * 2;
    }

    if (left.value < 0) {
        left.value = 0;
    }
}

const dropdown: Ref<Dropdown | null> = ref(null);

onMounted(() => {
    // eslint-disable-next-line @typescript-eslint/no-non-null-assertion
    dropdown.value = new Dropdown(dropDownToggle.value!);
});

mainStore.$subscribe(calculateLeft);
watch(selectedItem, calculateLeft);
watch(selectedItem, () => localStorage.setItem("selectedItem", selectedItem.value.id.toString()))
calculateLeft();
</script>

<style>
.list-button.show {
    color: var(--bs-secondary) !important;
    background-color: white !important;
}

.list-button:active {
    color: var(--bs-secondary) !important;
    background-color: white !important;
}

.list-button:hover {
    color: var(--bs-secondary) !important;
    background-color: white !important;
}
</style>