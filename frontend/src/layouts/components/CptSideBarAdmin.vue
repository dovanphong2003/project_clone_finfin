<script setup lang="ts">
import { RouterLink } from 'vue-router'

const LIST_LI_NAVIGATION = [
  {
    name_li: 'Bảng điều khiển',
    icon: '/img/dashboard.png',
    link: 'AdminHome'
  },
  {
    name_li: 'Quản lí sách',
    icon: '/img/icon_navigation/book.png',
    link: 'ManagerBook'
  },
  {
    name_li: 'Quản lí bán sách',
    icon: '/img/icon_navigation/sell.png',
    link: 'ManagerBuyBook'
  },
  {
    name_li: 'Chủ đề',
    icon: '/img/icon_navigation/category.png',
    link: 'ManagerCategory'
  },
  {
    name_li: 'Tác giả',
    icon: '/img/icon_navigation/author.png',
    link: 'ManagerAuthor'
  },
  {
    name_li: 'Nhà xuất bản',
    icon: '/img/icon_navigation/publisher.png',
    link: 'ManagerPublisher'
  },
  {
    name_li: 'Người dùng',
    icon: '/img/icon_navigation/management.png',
    link: 'ManagerUser'
  },
  {
    name_li: 'Vai trò',
    icon: '/img/icon_navigation/role.png',
    link: 'ManagerRole'
  },
  {
    name_li: 'Quyền Hạn',
    icon: '/img/icon_navigation/key.png',
    link: 'ManagerPermission'
  },
  { name_li: 'Mã giảm giá', icon: '/img/icon_navigation/voucher.png', link: 'ManagerCoupon' }
]
</script>
<template>
  <div class="side_bar-admin block_element_shadow">
    <div class="top_sidebar">
      <img src="/img/avatar_admin.png" alt="image user admin" />
      <p class="name_admin">Đỗ Văn Phong</p>
    </div>
    <div class="main_sidebar">
      <p>ĐIỀU HƯỚNG</p>
      <ul class="list_menu">
        <li v-for="(item, index) in LIST_LI_NAVIGATION" :key="index">
          <RouterLink class="route_link" :to="{ name: item.link }">
            <div class="content--icon">
              <img :src="item.icon" alt="" />
              <span>
                {{ item.name_li }}
              </span>
            </div>
            <img class="arrow_right" src="/img/right-arrow.png" alt=""
          /></RouterLink>
        </li>
      </ul>
    </div>
  </div>
</template>
<style lang="scss" scoped>
.side_bar-admin {
  min-height: 100vh;
  height: 100%;
  .top_sidebar {
    display: flex;
    align-items: center;
    justify-content: center;
    flex-direction: column;
    padding: 30px 20px;
    img {
      width: 42px;
      height: 42px;
      border-radius: 50%;
    }
    p {
      padding-top: 8px;
      font-size: 14px;
      font-weight: 600;
      color: $color_default_for_text;
    }
  }
  .main_sidebar {
    p {
      padding: 15px 30px;
      font-size: 12px;
      font-weight: 600;
      color: $color_default_for_text;
      border-bottom: 1px solid #efefef97;
    }
    ul {
      li {
        .route_link {
          display: flex;
          align-items: center;
          justify-content: space-between;
          text-decoration: none;
          color: $color_default_for_text;
          padding: 20px 30px;
          &:hover {
            color: $color_default_for_hover_text;
            border: 1px solid #8091ce6f;
            font-weight: 500;
          }
          .content--icon {
            display: flex;
            span {
              font-size: 14px;
            }
            img {
              margin-right: 12px;
              height: 18px;
              width: 18px;
            }
          }
          .arrow_right {
            height: 18px;
            width: 18px;
          }
        }
      }
    }
  }
}
</style>
