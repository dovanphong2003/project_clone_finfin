<script lang="ts" setup>
import type { IBook } from '@/common/interface'
const props = defineProps<{
  bookData: IBook
}>()
</script>
<template>
  <div class="container_view_content_book">
    <h1>{{ bookData.name }}</h1>
    <div v-html="bookData.content" class="content_book"></div>
  </div>
</template>
<style lang="scss">
.container_view_content_book {
  width: 80vw;
  min-height: 70vh;
  h1 {
    font-size: 20px;
    color: $color_default_for_text;
    text-align: center;
    padding-bottom: 6px;
    border-bottom: 1px solid #2b2b2b;
  }
  .content_book {
    padding-bottom: 30px;
    border-bottom: 1px solid #2b2b2b;
    margin-bottom: 30px;
    img {
      width: 100%;
      height: 100%;
    }
  }
}
</style>
