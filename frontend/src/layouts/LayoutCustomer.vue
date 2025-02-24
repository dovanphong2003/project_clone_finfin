<template>
  <div class="layout-customer">
    <CptHeader />
    <CptNavigation />
    <div class="layout-customer__content_main">
      <router-view name="routeCustomer" />
    </div>
    <CptFooter />
  </div>
</template>
<script lang="ts" setup>
import CptFooter from './components/CptFooter.vue'
import CptHeader from './components/CptHeader.vue'
import CptNavigation from './components/CptNavigation.vue'
</script>
<style lang="scss" scoped></style>
