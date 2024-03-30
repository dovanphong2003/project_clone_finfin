<script setup lang="ts">
import { ref } from 'vue'
import { RouterLink, useRoute } from 'vue-router'
const route = useRoute()
const activeClass = ref('active')
const classDefault_route_link = ref('router_link')
</script>

<template>
  <nav class="navigation">
    <ul class="navigation__list">
      <RouterLink
        :class="[route.path === '/home' ? activeClass : '', classDefault_route_link]"
        to="/home"
      >
        <li class="navigation__item">Trang chủ</li>
      </RouterLink>
      <RouterLink
        :class="[route.path === '/trading-campaign' ? activeClass : '', classDefault_route_link]"
        to="/trading-campaign"
      >
        <li class="navigation__item">Giao dịch thực chiến</li>
      </RouterLink>
      <RouterLink
        :class="[route.path === '/book-trading' ? activeClass : '', classDefault_route_link]"
        to="/book-trading"
      >
        <li class="navigation__item">Sách trading</li>
      </RouterLink>
      <RouterLink
        :class="[route.path === '/investment-books' ? activeClass : '', classDefault_route_link]"
        to="/investment-books"
      >
        <li class="navigation__item">Sách đầu tư</li>
      </RouterLink>
      <RouterLink
        :class="[route.path === '/good-book' ? activeClass : '', classDefault_route_link]"
        to="/good-book"
      >
        <li class="navigation__item">Sách hay</li>
      </RouterLink>
      <RouterLink
        :class="[route.path === '/all-book' ? activeClass : '', classDefault_route_link]"
        to="/all-book"
      >
        <li class="navigation__item">Tất cả sản phẩm</li>
      </RouterLink>
    </ul>
  </nav>
</template>

<style lang="scss" scoped>
.navigation {
  padding: 0px 60px;
  padding-bottom: 16px;
  padding-top: 4px;
  border-bottom: 1px solid #ededed;
  .navigation__list {
    text-align: center;
    .router_link {
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
      background-clip: text;
      -webkit-text-fill-color: transparent;
      transition: all 0.3s ease-in-out;
    }
    .router_link:before {
      content: '';
      background: $color_default_for_hover_text_to_color;
      display: block;
      position: absolute;
      bottom: -3px;
      left: 12px;
      width: 0;
      height: 2px;
      transition: all 0.3s ease-in-out;
    }
    .router_link:hover {
      background-position: 0;
    }
    .router_link:hover::before {
      width: 80%;
    }
  }
}

// active
.active {
  background-position: 0 !important;
}
.active::before {
  width: 80% !important;
}
</style>
