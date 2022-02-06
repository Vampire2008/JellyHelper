<template>
<div class="d-flex flex-column root-container">
    <Toolbar />
    <div class="container mt-2">
        <div class="row row-cols-1 row-cols-md-3 gy-2">
            <Jelly />
            <HoneyAss />
            <OtherItems />
        </div>
    </div>
    <Footer />
    </div>
</template>

<script setup lang="ts">
import Jelly from "./components/Jelly.vue";
import Toolbar from "./components/Toolbar.vue";
import HoneyAss from "./components/HoneyAss.vue";
import OtherItems from "./components/OtherItems.vue";
import Footer from "./components/Footer.vue";
</script>

<style>
    .root-container {
        min-height: 100vh;
    }
</style>