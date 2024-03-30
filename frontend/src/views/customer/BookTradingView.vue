<script setup lang="ts">
import { ref, type Ref } from 'vue'
import breadCrumb from '../../modules/breadcrumb/breadCrumb.vue'
import CptProduct from '@/common/components/CptProduct.vue'
import sortFillListBook from '../../modules/sortFillListBook/sortFillListBook.vue'
const itemsImage: Ref = ref([
  '/img/book/book_2.webp',
  '/img/book/book_1.webp',
  '/img/book/book_1.webp',
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
  <div class="main_content-book_trading">
    <breadCrumb />
    <div class="top-main_content-all_book">
      <h1>Sách trading</h1>
      <sortFillListBook />
    </div>
    <div class="list_product">
      <CptProduct v-for="(image, index) in itemsImage" v-bind:key="index" :image="image" />
    </div>
  </div>
</template>
<style lang="scss" scoped>
.main_content-book_trading {
  .top-main_content-all_book {
    display: flex;
    align-items: center;
    justify-content: space-between;
    padding: 50px 15px 70px 15px;
    h1 {
      font-size: 24px;
      color: $color_default_for_text;
      font-weight: 600;
    }
  }
  .list_product {
    padding: 0px 10px;
    display: flex;
    flex-wrap: wrap;
    justify-content: center;
  }
}
</style>
