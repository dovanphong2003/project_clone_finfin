<script lang="ts" setup>
import type { IBook } from '@/common/interface'
import { ref, Ref } from 'vue'
import CptQuill from '@/common/components/CptQuill.vue'
import { useListBookStore } from '@/stores/listStores/listBook'
import { handleLoadingNotication, handleLoadingNoticationWarning } from '@/common/functions/loading'

const props = defineProps<{
  bookData: IBook
}>()

const store = useListBookStore()

const changeContentCode = (content: string) => {
  contentCode.value = content
}
const contentBookOfProps: Ref<string> = ref(props.bookData.content)
const contentCode: Ref<string> = ref(props.bookData.content)
const handleEditContentBook = () => {
  if (contentBookOfProps.value !== contentCode.value) {
    store.editBook({ ...props.bookData, content: contentCode.value })
    handleLoadingNotication('Cập nhật thành công!', 1000, 'top-center')
    contentBookOfProps.value = contentCode.value
  } else {
    handleLoadingNoticationWarning('Không có gì thay đổi', 1000, 'top-center')
  }
}
</script>
<template>
  <div class="container_editor_content_book">
    <div class="bnt">
      <button @click="handleEditContentBook">Cập nhật chỉnh sửa</button>
    </div>
    <h1>{{ bookData.name }}</h1>
    <div class="main_content">
      <div class="editor_content">
        <CptQuill :contentDefault="contentCode" @changeContentCode="changeContentCode" />
      </div>
      <div v-html="contentCode" class="content_book"></div>
    </div>
  </div>
</template>
<style lang="scss">
@import '@/common/mixin/mixinButton.scss';
.container_editor_content_book {
  width: 80vw;
  min-height: 70vh;
  overflow: hidden;
  .bnt {
    display: block;
    text-align: end;
    button {
      @include btn-border-drawing;
      background-color: $color_button;
      color: #fff;
      padding: 16px 16px;
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
  h1 {
    font-size: 20px;
    color: $color_default_for_text;
    text-align: center;
    padding-bottom: 6px;
    border-bottom: 1px solid #2b2b2b;
  }
  .main_content {
    overflow: hidden;
    display: flex;
    justify-content: space-between;
    .editor_content {
      width: 34%;
      padding: 12px 20px;
      border-left: 1px dotted #2b2b2b;
      border-bottom: 1px dotted #2b2b2b;
    }
    .content_book {
      border: 1px dotted #2b2b2b;
      width: 60%;
      padding: 12px 20px;
      img {
        width: 100%;
        height: 100%;
      }
    }
  }
}
</style>
