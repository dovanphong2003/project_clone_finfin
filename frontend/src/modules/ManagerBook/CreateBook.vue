<template>
  <div @click="handleTest" class="action">Button test call api</div>
  <div @click="showModal = true" class="action">
    <button><span>+</span>Thêm mới</button>
  </div>
  <CptModalCenter title="Tạo thêm sách" :show="showModal" :handleShowFalse="handleShowFalse">
    <ModalCreateBook> </ModalCreateBook>
  </CptModalCenter>
</template>
<script setup lang="ts">
import CptModalCenter from '@/common/components/CptModalCenter.vue'
import ModalCreateBook from '@/modules/ManagerBook/Modals/ModalCreateBook.vue'
import { ref } from 'vue'
import axiosInstance from '@/services/axiosService'

const handleTest = () => {
  console.log('test call api')
  axiosInstance
    .get('/api/Category')
    .then((response) => {
      console.log(response.data)
    })
    .catch((error) => {
      console.error('Lỗi khi gọi API:', error)
    })
}
const showModal = ref(false)

// handle set show = false;
const handleShowFalse = () => {
  showModal.value = false
}
</script>
<style lang="scss" scoped>
@import '@/common/mixin/mixinButton.scss';

.action {
  button {
    @include btn-border-drawing;
    background-color: $color_button;
    color: #fff;
    padding: 10px 24px;
    cursor: pointer;
    border: none;
    border-radius: 10px;
    span {
      padding-right: 8px;
      font-weight: 700;
      font-size: 16px;
    }
  }
  &:active {
    opacity: 0.8;
  }
}
</style>
