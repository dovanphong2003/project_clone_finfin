<template>
  <nav class="navigation">
    <ul class="navigation__list">
      <route-link to="#">
        <li class="navigation__item">Trang chủ</li>
      </route-link>
      <route-link to="#">
        <li class="navigation__item">Giao dịch thực chiến</li>
      </route-link>
      <route-link to="#">
        <li class="navigation__item">Sách trading</li>
      </route-link>
      <route-link to="#">
        <li class="navigation__item">Sách đầu tư</li>
      </route-link>
      <route-link to="#">
        <li class="navigation__item">Sách hay</li>
      </route-link>
      <route-link to="#">
        <li class="navigation__item">Tất cả sản phẩm</li>
      </route-link>
    </ul>
  </nav>
</template>

<script setup lang="ts">
import { ref } from 'vue'
</script>

<style lang="scss" scoped>
.navigation {
  padding: 0px 60px;
  padding-bottom: 16px;
  padding-top: 4px;
  .navigation__list {
    text-align: center;
    route-link {
      padding: 4px 12px;
      font-size: 15px;
      font-weight: 600;
      cursor: pointer;
      color: $color_default_for_text;
      background-image: linear-gradient(
        to right,
        $color_default_for_hover_text_to_color,
        $color_default_for_hover_text 50%,
        #000 50%
      );
      background-size: 200% 100%;
      background-position: -100%;
      display: inline-block;
      position: relative;
      -webkit-background-clip: text;
      -webkit-text-fill-color: transparent;
      transition: all 0.3s ease-in-out;
    }
    route-link:before {
      content: '';
      background: $color_default_for_hover_text_to_color;
      display: block;
      position: absolute;
      bottom: -3px;
      left: 0;
      width: 0;
      height: 2px;
      transition: all 0.3s ease-in-out;
    }
    route-link:hover {
      background-position: 0;
    }
    route-link:hover::before {
      width: 100%;
    }
  }
}
</style>
