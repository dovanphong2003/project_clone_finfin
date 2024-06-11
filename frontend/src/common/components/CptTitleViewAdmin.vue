<script setup lang="ts">
defineProps({
  title: {
    type: String,
    required: true
  }
})
</script>
<template>
  <div class="top-dashboard block_element_shadow">
    <img src="/img/dashboard.png" alt="icon điều khiển" />
    <h4>{{ title }}</h4>
  </div>
</template>
<style scoped lang="scss">
.top-dashboard {
  display: flex;
  align-items: center;
  padding: 24px;
  margin-bottom: 30px;
  img {
    width: 27px;
    height: 27px;
  }
  h4 {
    margin-left: 10px;
    font-size: 18px;
    display: block;
    font-weight: 600;
  }
}
</style>
