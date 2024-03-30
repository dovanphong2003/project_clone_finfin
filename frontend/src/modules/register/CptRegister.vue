<script setup lang="ts">
import { ref } from 'vue'
import { RouterLink } from 'vue-router'
const name = ref('')
const email = ref('')
const password = ref('')
const ConfirmPassword = ref('')

const handleRegister = (event: Event) => {
  // Perform register logic here
  event.preventDefault()
}
</script>

<template>
  <div class="register">
    <div class="title_register">
      <h1>Tạo tài khoản</h1>
      <div class="line"></div>
    </div>
    <form>
      <h2>Thông tin đăng ký</h2>
      <input type="text" v-model="name" placeholder="Họ và tên" />
      <div class="box_gender">
        <div class="label">
          <label for="">Giới tính: </label>
        </div>
        <div class="input_male">
          <input type="radio" name="gender" value="male" /> <span>Nam</span>
        </div>
        <div class="input_female">
          <input type="radio" name="gender" value="female" /> <span>Nữ</span>
        </div>
      </div>
      <input type="email" v-model="email" placeholder="Email" />
      <input type="password" v-model="password" placeholder="Mật khẩu" />
      <input type="password" v-model="ConfirmPassword" placeholder="Nhập lại mật khẩu" />
      <div class="bnt-info_redirect">
        <button @click="handleRegister">Đăng ký</button>
        <div class="info_redirect">
          <span
            ><RouterLink class="route_link" to="/forget-password">Quên mật khẩu?</RouterLink></span
          >

          <span class="login"
            ><p>hoặc</p>
            <RouterLink class="route_link" to="/login">Đăng nhập</RouterLink></span
          >
        </div>
      </div>
    </form>
  </div>
</template>

<style lang="scss" scoped>
@import '@/common/mixin/mixinButton.scss';
.register {
  display: flex;
  justify-content: space-between;
  padding: 0px 80px;
  height: 80vh;
  .title_register {
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
    .box_gender {
      display: flex;
      align-items: center;
      .input_male,
      .label,
      .input_female {
        display: flex;
        align-items: center;
        input {
          width: 16px;
          height: 20px;
          margin: 8px 0px;
          margin-right: 4px;
          padding: 0px 10px;
          border: 1px solid $color_border_input;
          border-radius: 0px;
        }
        span {
          padding-right: 12px;
          color: $color_default_for_text;
          font-size: 14px;
          font-weight: 600;
        }
      }
      .label {
        padding-right: 20px;
        color: $color_default_for_text;
        font-size: 14px;
        font-weight: 600;
      }
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
        .login {
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
</style>
