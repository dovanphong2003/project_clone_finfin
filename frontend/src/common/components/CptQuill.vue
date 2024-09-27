<template>
  <QuillEditor
    v-model:content="content"
    toolbar="full"
    theme="snow"
    contentType="html"
    @textChange="$emit('changeContentCode', content)"
    class="custom-quill-editor"
  />
</template>

<script setup>
import axios from 'axios'
import { ref } from 'vue'
import { QuillEditor, Quill } from '@vueup/vue-quill'
import '@vueup/vue-quill/dist/vue-quill.snow.css'
import '@vueup/vue-quill/dist/vue-quill.bubble.css'
import ImageUploader from 'quill-image-uploader'
import QuillBetterTable from 'quill-better-table'

const props = defineProps({
  changeContentCode: {
    type: Function,
    required: true
  },
  contentDefault: {
    type: String,
    required: true
  }
})
Quill.register(
  {
    'modules/better-table': QuillBetterTable
  },
  true
)

const content = ref(props.contentDefault)
</script>
<style lang="scss">
h2 {
  color: aqua;
}
</style>
