<script setup lang="ts">
import { ref, type Ref } from 'vue'
import CptProduct from '@/common/components/CptProduct.vue'
import CpnSlideShow from '../../modules/slideShow/CptSlideShow.vue'

// image for product
const itemsImage: Ref = ref([
  '/img/book/book_1.webp',
  '/img/book/book_1.webp',
  '/img/book/book_2.webp',
  '/img/book/book_1.webp',
  '/img/book/book_2.webp',
  '/img/book/book_1.webp',
  '/img/book/book_2.webp',
  '/img/book/book_2.webp',
  '/img/book/book_1.webp',
  '/img/book/book_1.webp',
  '/img/book/book_1.webp',
  '/img/book/book_1.webp'
])

// slide show
const slides = [
  { imageUrl: '/img/slide_show/slideshow_1.webp', link: '/home' },
  { imageUrl: '/img/slide_show/slideshow_2.webp', link: '/book-trading' },
  { imageUrl: '/img/slide_show/slideshow_3.webp', link: '/' },
  { imageUrl: '/img/slide_show/slideshow_4.webp', link: '/' }
]

// set height for slide show
const heightSlide = '300px'
</script>
<template>
  <div class="main_content-view_home">
    <CpnSlideShow :arrayImage="slides" :height-slide="heightSlide" />
    <h2 class="heading-view_home">Sản phẩm bán chạy</h2>
    <div class="container_list_product">
      <div class="list_product">
        <CptProduct v-for="(image, index) in itemsImage" v-bind:key="index" :image="image" />
      </div>
    </div>
  </div>
</template>
<style lang="scss" scoped>
.main_content-view_home {
  h2 {
    font-size: 38px;
    text-align: center;
    padding: 50px 0px;
    color: $color_default_for_text;
    // cursor: pointer;
  }
  h2:hover {
    color: $color_default_for_hover_text;
  }
  .container_list_product {
    display: flex;
    justify-content: center;
  }
  .list_product {
    padding: 0px 10px;
    display: flex;
    flex-wrap: wrap;
    justify-content: center;
  }
}
</style>
