<script setup lang="ts">
import { RouterLink } from 'vue-router'
</script>
<template>
  <div class="not_product">
    <p>Hiện chưa có sản phẩm</p>
    <div class="line"></div>
    <div class="total_money">
      <p>TỔNG TIỀN:</p>
      <p>0đ</p>
    </div>
    <div class="button_submit">
      <RouterLink class="route_link" to="#">
        <button class="check_cart">XEM GIỎ HÀNG</button>
      </RouterLink>
      <RouterLink class="route_link" to="#">
        <button class="pay_price">THANH TOÁN</button>
      </RouterLink>
    </div>
  </div>
</template>
<style lang="scss" scoped>
@import '@/common/mixin/mixinButton.scss';
.not_product {
  p {
    font-size: 14px;
    color: $color_default_for_text;
    padding: 25px 0px 40px 0px;
    font-weight: 400;
  }
  .line {
    width: 100%;
    height: 2px;
    border-radius: 10px;
    background-color: $color_default_for_text;
  }
  .total_money {
    display: flex;
    justify-content: space-between;
    padding: 20px 0px;
    p {
      font-size: 14px;
      color: $color_default_for_text;
      font-weight: 400;
      padding: 0px;
    }
  }
  .button_submit {
    display: flex;
    justify-content: space-between;
    .route_link {
      width: 48%;
      height: 50px;
      button {
        @include btn-border-drawing;
        width: 100%;
        height: 50px;
        border: none;
        outline: none;
        cursor: pointer;
        background-color: $color_button;
        color: white;
        font-size: 12px;
        font-weight: 300;
      }
    }
    .route_link:active {
      button {
        opacity: 0.8;
      }
    }
  }
}
</style>
