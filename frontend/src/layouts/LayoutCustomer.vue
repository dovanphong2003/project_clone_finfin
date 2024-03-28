<template>
  <div class="layout-customer">
    <CptHeader />
    <CptNavigation />
    <div class="layout-customer__content_main">
      <CpnSlideShow />
      <router-view />
    </div>
    <CptFooter />
  </div>
</template>
<script lang="ts" setup>
import CptFooter from './components/CptFooter.vue'
import CptHeader from './components/CptHeader.vue'
import CptNavigation from './components/CptNavigation.vue'
import CpnSlideShow from '../modules/slideShow/CptSlideShow.vue'
</script>
<style lang="scss" scoped>
.layout-customer__content_main {
  height: 1000px;
}
</style>
