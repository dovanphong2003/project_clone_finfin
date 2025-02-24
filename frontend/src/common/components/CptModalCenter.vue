<template>
  <div v-if="visible" class="modal-overlay" @click="close">
    <div class="scroll">
      <div ref="modalContent" class="modal-content" @click.stop>
        <div class="top_modal">
          <div class="title">
            {{ title }}
          </div>
          <button class="modal-close" @click="close">&times;</button>
        </div>
        <div class="main_content_modal">
          <slot></slot>
        </div>
      </div>
    </div>
  </div>
</template>
<script setup>
import { ref, onMounted, watch } from 'vue'
const props = defineProps({
  show: {
    type: Boolean,
    default: false
  },
  handleShowFalse: {
    type: void Function,
    required: true
  },
  handleSetCheckChangeDataFalse: {
    type: void Function
  },
  title: {
    type: String,
    required: true
  }
})
const visible = ref(props.show)
const modalContent = ref(null)

const open = () => {
  visible.value = true
  setTimeout(() => {
    if (modalContent.value) {
      modalContent.value.classList.add('visible')
    }
  }, 100)
}

const close = () => {
  if (modalContent.value) {
    modalContent.value.classList.remove('visible')
    props.handleShowFalse()
    if (props.handleSetCheckChangeDataFalse) {
      props.handleSetCheckChangeDataFalse()
    }
  }
  setTimeout(() => {
    visible.value = false
  }, 300)
}

watch(() => {
  if (props.show) {
    open()
  } else {
    close()
  }
})

onMounted(() => {
  if (props.show) {
    open()
  }
})
</script>

<style scoped lang="scss">
.modal-overlay {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background: rgba(0, 0, 0, 0.5);
  display: flex;
  justify-content: center;
  align-items: center;
  z-index: 10;
  transition: opacity 0.3s ease;
  .scroll {
    overflow: auto;
    max-height: 94vh;
    border-radius: 10px;
  }
}

.modal-content {
  background: white;
  transform: scale(0.8);
  opacity: 0;
  transition:
    transform 0.3s ease,
    opacity 0.3s ease;
  .top_modal {
    display: flex;
    align-items: center;
    justify-content: space-between;
    padding: 20px;
    .title {
      font-size: 16px;
      text-transform: uppercase;
      font-weight: 600;
    }
  }
  .main_content_modal {
    padding: 20px;
    padding: 20px 60px;
  }
}

.modal-content.visible {
  transform: scale(1);
  opacity: 1;
}

.modal-close {
  background: none;
  border: none;
  font-size: 30px;
  padding: 4px 12px;
  cursor: pointer;
}
</style>
