<script setup lang="ts">
import { ref } from 'vue'
import type Ref from 'vue'
const imageUrl: Ref<string> = ref('/img/image_logo.png')
</script>
<template>
  <header>
    <div class="top_header">
      <p><strong>Liên hệ: 0989.888.393 - 0931.434.030 - 096.8855.477</strong></p>
    </div>
    <div class="main_header">
      <div class="box_content-main_header"></div>
      <div class="logo-main_header">
        <route-link to="#"> <img :src="imageUrl" class="logo" alt="logo" /></route-link>
      </div>
      <div class="setting_icon-main_header">
        <route-link to="#"><img class="icon" src="/icon/profile-user.png" alt="" /></route-link>
        <route-link to="#"><img class="icon" src="/icon/cart.png" alt="" /></route-link>
        <route-link to="#"><img class="icon" src="/icon/search.png" alt="" /></route-link>
      </div>
    </div>
  </header>
</template>

<style lang="scss" scoped>
header {
  .top_header {
    padding: 6px 0px;
    background-color: #f3f3f3;
    padding-left: 15px;
    padding-right: 15px;
    p {
      text-align: center;
      strong {
        font-size: 14px;
        color: orange;
        cursor: default;
        font-weight: 500;
      }
    }
  }
  .main_header {
    display: flex;
    align-items: center;
    padding: 0px 60px;

    .box_content-main_header {
      flex: 1 0 0;
    }

    .logo-main_header {
      img {
        width: 250px;
        height: 100px;
        cursor: pointer;
      }
    }
    .setting_icon-main_header {
      flex: 1 0 0;
      text-align: right;
      .icon {
        margin: 8px 5px 0px;
        cursor: pointer;
      }
    }
  }
}
</style>
