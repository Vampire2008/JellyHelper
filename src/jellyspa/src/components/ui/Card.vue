<template>
    <div class="col">
        <div class="card h-100">
            <div class="card-header text-center">
                <slot name="title"></slot>
            </div>
            <div class="card-body">
                <slot></slot>
            </div>
        </div>
    </div>
</template>
