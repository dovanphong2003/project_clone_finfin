<script setup lang="ts">
import { ref, type Ref } from 'vue'
import breadCrumb from '../../modules/breadcrumb/breadCrumb.vue'
import CptProduct from '@/common/components/CptProduct.vue'
const itemsImage: Ref = ref([
  '/img/book/book_2.webp',
  '/img/book/book_2.webp',
  '/img/book/book_2.webp',
  '/img/book/book_2.webp',
  '/img/book/book_2.webp',
  '/img/book/book_1.webp',
  '/img/book/book_2.webp',
  '/img/book/book_2.webp',
  '/img/book/book_1.webp',
  '/img/book/book_1.webp',
  '/img/book/book_1.webp',
  '/img/book/book_1.webp'
])
</script>
<template>
  <div class="main_content-all_book">
    <breadCrumb />
    <h1>Tất cả sản phẩm</h1>
    <div class="list_product">
      <CptProduct v-for="(image, index) in itemsImage" v-bind:key="index" :image="image" />
    </div>
  </div>
</template>
<style lang="scss" scoped>
.main_content-all_book {
  h1 {
    padding: 50px 15px 70px 15px;

    font-size: 24px;
    color: $color_default_for_text;
    font-weight: 600;
  }
  .list_product {
    padding: 0px 10px;
    display: flex;
    flex-wrap: wrap;
    justify-content: center;
  }
}
</style>
