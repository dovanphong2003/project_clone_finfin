<template>
  <QuillEditor
    v-model:content="content"
    toolbar="full"
    theme="snow"
    contentType="html"
    class="custom-quill-editor"
    @update:content="handleContentUpdate"
  />
</template>

<script setup>
import { ref } from 'vue'
import { QuillEditor } from '@vueup/vue-quill'
import '@vueup/vue-quill/dist/vue-quill.snow.css'
import '@vueup/vue-quill/dist/vue-quill.bubble.css'

// content là một chuỗi HTML
const content = ref('<p></p>')

// Hàm để xử lý sự thay đổi khi nội dung thay đổi
const handleContentUpdate = (newContent) => {
  content.value = newContent
}
</script>
<style lang="scss">
h2 {
  color: aqua;
}
</style>
