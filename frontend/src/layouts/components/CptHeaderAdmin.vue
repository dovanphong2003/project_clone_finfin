<script setup lang="ts">
import { ref } from 'vue'
import type { Ref } from 'vue'
import { RouterLink } from 'vue-router'
const showOptionsUser: Ref<boolean> = ref(false)
const showOptions = () => {
  showOptionsUser.value = !showOptionsUser.value
}
</script>
<template>
  <header>
    <div class="header_admin">
      <div class="left_header">
        <RouterLink to="/admin-home"> <img src="/logo_samurai.png" alt="ảnh logo" /></RouterLink>
      </div>
      <div class="right_header">
        <button>Visit website</button>
        <div class="box_user">
          <div @click="showOptions" class="user">
            <img src="/img/avatar_admin.png" alt="avatar admin" />
            <span>
              <p class="user__name">Đỗ văn phong</p>
              <p class="name_role">Admin</p>
            </span>
          </div>
          <div v-if="showOptionsUser" class="options_user">
            <p>Welcome!</p>
            <ul>
              <RouterLink class="route_link" to="">
                <li><img src="/img/user.png" alt="tài khoản" /><span>Tài khoản</span></li>
              </RouterLink>
              <RouterLink class="route_link" to="">
                <li><img src="/img/logout.png" alt="đăng xuất" /><span>Đăng xuất</span></li>
              </RouterLink>
            </ul>
          </div>
        </div>
      </div>
    </div>
  </header>
</template>
<style lang="scss" scoped>
.header_admin {
  background-color: #313a46;
  margin-bottom: 40px;
  min-height: 70px;
  display: flex;
  justify-content: space-between;
  border-bottom: 1px solid #ededed;
  align-items: center;
  .left_header {
    margin-left: 40px;
    display: flex;
    align-items: center;
    img {
      width: 250px;
      margin-right: 40px;
      height: 60px;
    }
  }
  .right_header {
    align-items: center;
    height: 100%;
    margin-right: 40px;
    display: flex;
    button {
      background-color: #313a46;
      display: flex;
      align-items: center;
      justify-content: center;
      outline: none;
      border: none;
      color: #fff;
      background-color: #3a4553d3;
      font-size: 14px;
      cursor: pointer;
      height: 70px;
      padding: 20px 40px;
      &:hover {
        background-color: #2f3843;
      }
      &:active {
        background-color: #424e5c;
      }
    }
    .box_user {
      position: relative;
      .user {
        user-select: none;
        background-color: #3a4553d3;
        cursor: pointer;
        padding: 0px 20px;
        height: 70px;
        display: flex;
        align-items: center;
        justify-content: center;
        margin-left: 30px;
        img {
          height: 32px;
          border-radius: 50%;
          margin-right: 8px;
        }
        span {
          p {
            color: #fff;
            font-size: 14px;
          }
          .user__name {
            font-weight: 500;
          }
        }
        &:hover {
          background-color: #2f3843;
        }
        &:active {
          background-color: #424e5c;
        }
      }
      .options_user {
        position: absolute;
        width: 100%;
        background-color: #fff;
        top: 65px;
        box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
        border-radius: 6px;
        p {
          font-size: 12px;
          padding: 15px 20px;
          font-weight: 600;
          cursor: default;
        }
        ul {
          .route_link {
            font-size: 14px;
            text-decoration: none;
            color: $color_default_for_text;
            li {
              padding: 14px 25px;
              border: 1px solid #edededa2;
              display: flex;
              align-items: center;
              img {
                height: 16px;
                width: 16px;
                padding-right: 6px;
              }
            }
            li:hover {
              background-color: #f8f9fa;
              font-weight: 500;
            }
          }
        }
      }
    }
  }
}
</style>
