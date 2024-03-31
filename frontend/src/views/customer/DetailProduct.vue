<script setup lang="ts"></script>
<template>
  <div class="detail_product">
    <div class="main_detail_product">
      <div class="product_gallary">
        <img src="/img/book/book_1.webp" alt="" />
      </div>
      <div class="info_detail_product"></div>
    </div>
  </div>
</template>
<style lang="scss" scoped>
.main_detail_product {
  height: 2000px;
  position: relative;
  .product_gallary {
    width: 48%;
    position: sticky;
    float: left;
    top: 0px;
  }
  .info_detail_product {
    width: 52%;
  }
}
</style>
