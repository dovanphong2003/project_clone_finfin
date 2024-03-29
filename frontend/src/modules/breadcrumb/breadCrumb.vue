<script setup lang="ts">
import { RouterLink, useRoute } from 'vue-router'
const route = useRoute()
let path = ''
if (route.path === '/trading-campaign') {
  path = 'Giao dịch thực chiến'
} else if (route.path === '/all-book') {
  path = 'Tất cả sản phẩm'
} else if (route.path === '/good-book') {
  path = 'Sách hay'
} else if (route.path === '/book-trading') {
  path = 'Sách giao dịch'
} else if (route.path === '/investment-books') {
  path = 'Sách đầu tư'
}
</script>
<template>
  <div class="breadcrumb">
    <ul>
      <li><RouterLink class="route_link" to="/home">Trang chủ</RouterLink></li>
      <li class="sign">/</li>
      <li><RouterLink class="route_link" to="/all-book">Danh mục</RouterLink></li>
      <li class="sign">/</li>
      <li>
        <RouterLink class="route_link breadcrumb_path_current" to="#">{{
          path.replace(/\//, '')
        }}</RouterLink>
      </li>
    </ul>
  </div>
</template>
<style lang="scss">
.breadcrumb {
  padding: 10px 15px;
  ul {
    display: flex;
    padding: 0px 4px;
    li {
      list-style: none;
      .route_link {
        color: $color_default_for_text;
        text-decoration: none;
        font-weight: 300;
        font-size: 13px;
      }
      .breadcrumb_path_current {
        cursor: default;
        color: #777;
      }
    }
    .sign {
      font-size: 13px;
      padding: 0px 8px;
      color: $color_default_for_text;
      font-weight: 100;
    }
  }
}
</style>
