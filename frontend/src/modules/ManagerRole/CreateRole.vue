<template>
  <div @click="showModal = true" class="action">
    <button><span>+</span>Thêm mới</button>
  </div>
  <CptModalCenter title="Tạo thêm Role" :show="showModal" :handleShowFalse="handleShowFalse">
    <ModalCreateRole :arrayConvertPermission = "props.arrayConvertPermission"> </ModalCreateRole>
  </CptModalCenter>
</template>
<script setup lang="ts">
import CptModalCenter from '@/common/components/CptModalCenter.vue'
import ModalCreateRole from './Modals/ModalCreateRole.vue'
import { ref } from 'vue'
// props
const props = defineProps({
  arrayConvertPermission: {
    type: Object as () => any,
    required: true
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
