const delay = 500;
let timeout: number | null = null;

export default function() {
    if (timeout) {
        return;
    }
    timeout = setTimeout(() => timeout = null, delay);
    (window as any).$WowheadPower.refreshLinks();
}