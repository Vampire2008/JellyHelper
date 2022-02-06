import { defineStore } from 'pinia';

export const useMainStore = defineStore('main', {
    state: () => ({
        thinJelly: Number(localStorage.getItem("thinJelly")),
        richJelly: Number(localStorage.getItem("richJelly")),
        royalJelly: Number(localStorage.getItem("royalJelly"))
    }),
    getters: {
        totalThinJelly: (state) => state.thinJelly + state.richJelly * 4 + state.royalJelly * 8
    }
});
