<template>
  <div @click="showModal = true" class="action">
    <button><span>+</span>Thêm mới</button>
  </div>
  <CptModalCenter title="Tạo thêm sách" :show="showModal" :handleShowFalse="handleShowFalse">
    <ModalCreateBook :selectOptions="props.selectOptions"> </ModalCreateBook>
  </CptModalCenter>
</template>
<script setup lang="ts">
import CptModalCenter from '@/common/components/CptModalCenter.vue'
import { ISelectOptionsOfBook } from '@/common/interface';
import ModalCreateBook from '@/modules/ManagerBook/Modals/ModalCreateBook.vue'
import axiosInstance from '@/services/axiosService'
import { ref } from 'vue';
const props = defineProps({
  selectOptions: {
    type: Object as () => ISelectOptionsOfBook | any,
    required:true
  }
})

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
