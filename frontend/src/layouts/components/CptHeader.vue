<script setup lang="ts">
import { ref } from 'vue'
import type { Ref } from 'vue'
import { RouterLink } from 'vue-router'
import CptModal from '../../common/components/CptModal.vue'
// import module search book
import SearchBook from '@/modules/searchBook/SearchBook.vue'
import ModalSearchBook from '@/modules/searchBook/ModalSearchBook.vue'

// import module cart
import IconCart from '@/modules/ModuleCart/IconCart.vue'
import ModalCart from '@/modules/ModuleCart/ModalCart.vue'
const imageUrl: Ref<string> = ref('/img/image_logo.png')

const titleModalSearch = 'TÌM KIẾM'
const titleModalCart = 'GIỎ HÀNG'
// state modal search
const activeModalSearch: Ref<boolean> = ref(false)
const disableModalSearch: Ref<boolean> = ref(false)

// state modal cart
const activeModalCart: Ref<boolean> = ref(false)
const disableModalCart: Ref<boolean> = ref(false)

// handle event click icon search
const handleClickSearch = async () => {
  activeModalSearch.value = true
  disableModalSearch.value = false
}

// handle event click icon cart
const handleClickCart = async () => {
  activeModalCart.value = true
  disableModalCart.value = false
}

// emit event when use click modal
const handleClickCloseModalSearch = async () => {
  activeModalSearch.value = false
  disableModalSearch.value = true
}

// emit event when use click modal
const handleClickCloseModalCart = async () => {
  activeModalCart.value = false
  disableModalCart.value = true
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
        <RouterLink class="router_link" to="/home">
          <img :src="imageUrl" class="logo" alt="logo"
        /></RouterLink>
      </div>
      <div class="setting_icon-main_header">
        <RouterLink class="router_link" to="/login"
          ><img class="icon" src="/icon/profile-user.png" alt=""
        /></RouterLink>
        <RouterLink @click="handleClickCart" class="router_link" to="#">
          <IconCart />
        </RouterLink>
        <RouterLink @click="handleClickSearch" class="router_link" to="#">
          <SearchBook />
        </RouterLink>
      </div>
    </div>
  </header>
  <!--modal search book-->
  <CptModal
    :title-modal="titleModalSearch"
    :active-modal="activeModalSearch"
    :disable-modal="disableModalSearch"
    @handle-click-close-modal="handleClickCloseModalSearch"
  >
    <ModalSearchBook />
  </CptModal>

  <!--modal cart-->
  <CptModal
    :title-modal="titleModalCart"
    :active-modal="activeModalCart"
    :disable-modal="disableModalCart"
    @handle-click-close-modal="handleClickCloseModalCart"
  >
    <ModalCart />
  </CptModal>
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
</style>
