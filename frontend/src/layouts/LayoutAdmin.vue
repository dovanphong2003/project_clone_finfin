<template>
  <div class="layout-admin">
    <CptHeaderAdmin />
    <div class="layout-admin__content">
      <router-view />
    </div>
    <CptFooterAdmin />
  </div>
</template>
<script setup lang="ts">
import CptHeaderAdmin from './components/CptHeaderAdmin.vue'
import CptFooterAdmin from './components/CptFooterAdmin.vue'
</script>
<style lang="scss" scoped></style>
