<script setup lang="ts">
import { ref } from 'vue'
import { RouterLink } from 'vue-router'
const email = ref('')
const password = ref('')

const handleLogin = (event: Event) => {
  // Perform login logic here
  event.preventDefault()
}
</script>

<template>
  <div class="login">
    <div class="title_login">
      <h1>Đăng nhập</h1>
      <div class="line"></div>
    </div>
    <form>
      <h2>Thông tin đăng nhập</h2>
      <input type="email" v-model="email" placeholder="Email" />
      <input type="password" v-model="password" placeholder="Mật khẩu" />
      <div class="bnt-info_redirect">
        <button @click="handleLogin">Đăng nhập</button>
        <div class="info_redirect">
          <span
            ><RouterLink class="route_link" to="/forget-password">Quên mật khẩu?</RouterLink></span
          >

          <span class="register"
            ><p>hoặc</p>
            <RouterLink class="route_link" to="/register">Đăng kí</RouterLink></span
          >
        </div>
      </div>
    </form>
  </div>
</template>

<style lang="scss" scoped>
@import '@/common/mixin/mixinButton.scss';
.login {
  display: flex;
  justify-content: space-between;
  padding: 0px 80px;
  height: 80vh;
  .title_login {
    display: flex;
    // align-items: center;
    flex-direction: column;
    justify-content: center;
    h1 {
      font-size: 54px;
      font-weight: 600;
      padding: 0px 70px;
      padding-bottom: 50px;
      cursor: default;
    }
    width: 50%;
    .line {
      display: block;
      width: 20%;
      height: 5px;
      background-color: $color_default_for_text;
      border-radius: 10px;
      margin-left: 70px;
    }
  }
  form {
    display: flex;
    flex-direction: column;
    justify-content: start;
    padding-top: 120px;
    align-items: self-start;
    width: 50%;
    h2 {
      font-size: 18px;
      font-weight: 600;
      color: $color_default_for_text;
    }
    input {
      width: 90%;
      height: 55px;
      margin: 14px 0px;
      padding: 0px 10px;
      border: 1px solid $color_border_input;
      border-radius: 0px;
      font-size: 16px;
    }
    .bnt-info_redirect {
      display: flex;
      align-items: center;
      width: 100%;
      button {
        width: 28%;
        @include btn-border-drawing;
        height: 55px;
        margin: 10px 0px;
        border: none;
        font-size: 16px;
        color: white;
        background-color: $color_button;
        font-weight: 600;
        cursor: pointer;
      }
      .info_redirect {
        padding-left: 20px;
        display: flex;
        align-items: start;
        flex-direction: column;
        justify-content: center;
        span {
          padding: 4px 0px;
          .route_link {
            color: $color_default_for_text;
            text-decoration: none;
            font-size: 14px;
            font-weight: 500;
          }
          .route_link:hover {
            color: $color_default_for_hover_text;
          }
        }
        .register {
          display: flex;
          p {
            color: #a1a1a1;
            padding-right: 4px;
            font-size: 14px;
          }
        }
      }
    }
  }
}
// css button
//=== Drawing effect
</style>
