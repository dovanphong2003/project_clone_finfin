<script setup lang="ts">
import CptHeaderAdmin from './components/CptHeaderAdmin.vue'
import CptFooterAdmin from './components/CptFooterAdmin.vue'
import CptSideBarAdmin from './components/CptSideBarAdmin.vue'
import CptTitleViewAdmin from '@/common/components/CptTitleViewAdmin.vue'
import { ref, type Ref } from 'vue'
import { useRouter } from 'vue-router'
import { onMounted } from 'vue'
const router = useRouter()
const title: Ref<string> = ref('Loading...')
router.afterEach((to) => {
  title.value = to.meta.title || 'Loading...'
})
</script>
<template>
  <div class="layout-admin">
    <CptHeaderAdmin />
    <div class="container">
      <div class="side_bar">
        <CptSideBarAdmin />
      </div>
      <div @click="handleOnclick" class="layout-admin__content">
        <CptTitleViewAdmin :title="title" />
        <router-view name="routeAdmin" />
      </div>
    </div>
    <CptFooterAdmin />
  </div>
</template>
<style lang="scss" scoped>
.layout-admin {
  background-color: #fafbfe;
  .container {
    width: 95%;
    padding-right: 15px;
    padding-left: 15px;
    padding-bottom: 60px;
    margin-right: auto;
    margin-left: auto;
    display: flex;
    .side_bar {
      width: 22%;
      min-height: 500px;
      border-right: 1px solid #eaeaea8a;
    }
    .layout-admin__content {
      width: 78%;
      min-height: 100vh;
      padding: 20px;
      padding: 0px 0px 0px 30px;
    }
  }
}
</style>
