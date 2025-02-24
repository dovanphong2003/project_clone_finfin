<script setup>
// vue slide by https://antoniandre.github.io/vueper-slides/
import { VueperSlides, VueperSlide } from 'vueperslides'
import 'vueperslides/dist/vueperslides.css'

defineProps({
  arrayImage: {
    type: Array,
    required: true
  },
  heightSlide: {
    type: String,
    required: true
  }
})
</script>
<template>
  <vueper-slides
    :fixed-height="heightSlide"
    lazy
    lazy-load-on-drag
    :dragging-distance="70"
    prevent-y-scroll
  >
    <vueper-slide v-for="(slide, i) in arrayImage" :key="i" :image="slide.imageUrl">
      <template #loader>
        <i class="icon icon-loader spinning"></i>
        <span>Loading...</span>
      </template>
    </vueper-slide>
  </vueper-slides>
</template>
<style lang="scss" scoped></style>
