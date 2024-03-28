<script setup>
// vue slide by https://antoniandre.github.io/vueper-slides/
import { ref } from 'vue'
import { VueperSlides, VueperSlide } from 'vueperslides'
import 'vueperslides/dist/vueperslides.css'
const slides = [
  { imageUrl: ref('/img/slide_show/slideshow_1.webp').value, link: '/home' },
  { imageUrl: ref('/img/slide_show/slideshow_2.webp').value, link: '/book-trading' },
  { imageUrl: ref('/img/slide_show/slideshow_3.webp').value, link: '/' },
  { imageUrl: ref('/img/slide_show/slideshow_4.webp').value, link: '/' }
]
</script>
<template>
  <vueper-slides lazy lazy-load-on-drag :fixed-height="true" autoplay>
    <vueper-slide v-for="(slide, i) in slides" :key="i" :image="slide.imageUrl" :link="slide.link">
      <template #loader>
        <i class="icon icon-loader spinning"></i>
        <span>Loading...</span>
      </template>
    </vueper-slide>
  </vueper-slides>
</template>
<style lang="scss" scoped>
.vueperslides--fixed-height {
  height: 300px;
}
</style>
