<script setup lang="ts">
defineProps<{
  image?: string
}>()
import { RouterLink } from 'vue-router'
</script>
<template>
  <div class="product">
    <RouterLink class="route_link" to="#">
      <div class="glass-shine-effect">
        <img :src="image" alt="" />
      </div>
      <div class="content_product">
        <p>
          Thực hành Phân tích Fibonacci - Hướng dẫn Phương pháp từ Nhà Quản Lý Quỹ kiêm Học giả CMT
        </p>
        <div class="price">296,000₫</div>
      </div>
    </RouterLink>
  </div>
</template>
<style lang="scss" scoped>
.product {
  display: flex;
  justify-content: center;
  max-width: 25%;
  padding: 0px 20px;
  margin-bottom: 50px;
  width: 250px;
  .route_link {
    text-decoration: none;
    img {
      width: 100%;
      height: 250px;
    }
    .content_product {
      max-width: 250px;
      padding: 20px 0px;
      p {
        color: $color_default_for_text;
        font-size: 14px;
        text-align: center;

        // css for hidden when text more 2 line
        overflow: hidden;
        text-overflow: ellipsis;
        display: -webkit-box;
        -webkit-line-clamp: 2; /* number of lines to show */
        line-clamp: 2;
        -webkit-box-orient: vertical;
      }
      p:hover {
        color: $color_default_for_hover_text;
      }
      .price {
        display: block;
        color: $color_default_for_text;
        font-size: 16px;
        font-weight: 600;
        text-align: center;
        padding-top: 8px;
      }
    }
  }
}

// css Mirror Shine on Hover for image
.glass-shine-effect {
  background-color: rgba(255, 255, 255, 0.15);
  // box-shadow: 0 8px 32px 0 rgba(107, 107, 107, 0.37);
  backdrop-filter: blur(6px); // Just for effect
  border-radius: 10px;
  border: 1px solid rgba(255, 255, 255, 0.18);
  width: 250px;
  height: 250px;
  cursor: pointer;
  position: relative;
  transition: transform 200ms ease;
  overflow: hidden;
  &:before {
    content: '';
    position: absolute;
    height: 150%;
    width: 50px;
    transform: rotate(30deg);
    background-color: rgba(255, 255, 255, 0.2);
    left: -100px;
  }
  &:hover {
    transform: scale(1.1);
    &:before {
      transition: left 500ms ease;
      left: 250px;
    }
  }
}
</style>
