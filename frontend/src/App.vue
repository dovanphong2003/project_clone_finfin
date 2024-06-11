<script setup lang="ts">
import LayoutCustomer from './layouts/LayoutCustomer.vue'
import LayoutAdmin from './layouts/LayoutAdmin.vue'
import { useUserInfoStore } from '@/stores/listStores/userInfo'

const roleUser = useUserInfoStore().role
</script>
<template>
  <LayoutCustomer v-if="roleUser && roleUser === 'customer'" />
  <!-- Render LayoutAdmin nếu roleUser là admin -->
  <LayoutAdmin v-else-if="roleUser && roleUser === 'admin'" />
  <!-- Mặc định, render LayoutCustomer -->
  <LayoutCustomer v-else />
</template>
<style lang="scss" scoped>
// @import './../node_modules/@vueform/vueform/dist/vueform.css';
</style>
