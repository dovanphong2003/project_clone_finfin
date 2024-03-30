<script setup lang="ts">
import { ref } from 'vue'
import type { Ref } from 'vue'
import { RouterLink } from 'vue-router'

// import module search book
import SearchBook from '@/modules/searchBook/SearchBook.vue'
const imageUrl: Ref<string> = ref('/img/image_logo.png')
const activeModalSearch: Ref<boolean> = ref(false)
const disableModalSearch: Ref<boolean> = ref(false)

// handle event click icon search
const handleClickSearch = async () => {
  activeModalSearch.value = true
  disableModalSearch.value = false
}
const handleClickCloseModal = async () => {
  activeModalSearch.value = false
  disableModalSearch.value = true
}
</script>
<template>
  <header>
    <div class="top_header">
      <p><strong>Liên hệ: 0989.888.393 - 0931.434.030 - 096.8855.477</strong></p>
    </div>
    <div class="main_header">
      <div class="box_content-main_header"></div>
      <div class="logo-main_header">
        <RouterLink class="router_link" to="#">
          <img :src="imageUrl" class="logo" alt="logo"
        /></RouterLink>
      </div>
      <div class="setting_icon-main_header">
        <RouterLink class="router_link" to="/login"
          ><img class="icon" src="/icon/profile-user.png" alt=""
        /></RouterLink>
        <RouterLink class="router_link" to="#"
          ><img class="icon" src="/icon/cart.png" alt=""
        /></RouterLink>
        <RouterLink @click="handleClickSearch" class="router_link" to="#">
          <SearchBook />
        </RouterLink>
      </div>
    </div>
  </header>
  <div
    :class="[
      activeModalSearch ? 'active_modal' : '',
      disableModalSearch ? 'disable_scroll_modal' : '',
      'modal_search'
    ]"
  >
    <div @click="handleClickCloseModal" class="shadow_modal"></div>
    <div
      :class="[
        activeModalSearch ? 'active_modal' : '',
        disableModalSearch ? 'disable_scroll_modal' : '',
        'modal'
      ]"
    >
      <div @click="handleClickCloseModal" class="close_modal"></div>
    </div>
  </div>
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
      .icon:hover {
        opacity: 0.7;
      }
    }
  }
}
.modal_search {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  z-index: 5;
  transform: translate(100%, 0%);
  .shadow_modal {
    display: inline-block;
    width: 100%;
    height: 100%;
    background-color: rgba(0, 0, 0, 0.5);
  }
  .modal {
    position: absolute;
    right: 0;
    top: 0;
    width: 35%;
    height: 100%;
    transform: translate(100%, 0%);
    background-color: white;
    border-radius: 10px;
    z-index: 10;
  }
}
.disable_scroll_modal {
  animation: slideLefttToRight 0.5s forwards;
}
.active_modal {
  display: block;
  animation: slideRightToLeft 0.5s forwards;
}

// animation
@keyframes slideRightToLeft {
  0% {
    transform: translate(100%, 0%);
  }
  100% {
    transform: translate(0%, 0%);
  }
}

//
@keyframes slideLefttToRight {
  0% {
    transform: translate(0%, 0%);
  }
  100% {
    transform: translate(100%, 0%);
  }
}
</style>
