<script lang="ts" setup>
import type { Header } from 'vue3-easy-data-table'
import tableViewAdmin from '@/common/components/tableViewAdmin.vue'

// cpt modal right
import ModalEditBook from '@/modules/ManagerBook/Modals/ModalEditBook.vue'
const headers: Header[] = [
  { text: 'Tên sách', value: 'name', sortable: true, width: 130 },
  { text: 'Hình ảnh', value: 'image', width: 100 },
  { text: 'Giá', value: 'price' },
  { text: 'Thể loại', value: 'category', width: 100 },
  { text: 'Ngày tạo', value: 'createdAt' },
  { text: 'Cập nhật mới', value: 'updatedAt' },
  { text: 'Giảm giá', value: 'promotion', width: 50 },
  { text: 'Trạng thái', value: 'status', width: 100 },
  { text: 'Hành động', value: 'handle', width: 130 }
]
</script>
<template>
  <div class="main-manager_book">
    <tableViewAdmin :headers="headers" :modal="ModalEditBook"> </tableViewAdmin>
  </div>
</template>
<style lang="scss" scoped>
@import '@/common/mixin/mixinButton.scss';
.main-manager_book {
}
</style>
