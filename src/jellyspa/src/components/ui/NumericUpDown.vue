<template>
    <div class="input-group">
        <button class="btn btn-outline-secondary" type="button" @click="minus">-</button>
        <input
            type="number"
            class="form-control"
            :value="props.modelValue"
            :min="props.min"
            @input="$emit('update:modelValue', ($event as any).target.value)"
        />
        <button class="btn btn-outline-secondary" type="button" @click="plus">+</button>
    </div>
</template>

<script setup lang="ts">
const props = defineProps<{ modelValue: number, min?: number }>();

const emit = defineEmits(['update:modelValue']);

function plus() {
    emit('update:modelValue',props.modelValue + 1);
}

function minus() {
    let newValue = props.modelValue - 1;
    if (props.min !== undefined && props.min !== null && newValue < props.min) {
        newValue = props.min;
    }
    emit('update:modelValue', newValue);
}
</script>