<script setup lang="ts"></script>
import { RouterLink } from 'vue-router'
<template>
  <footer class="footer">
    <div class="footer_main">
      <div class="container">
        <div class="row">
          <div class="footer-col">
            <h4>Công ty</h4>
            <ul>
              <li><RouterLink class="router_link" to="#">Về chúng tôi</RouterLink></li>
              <li><RouterLink class="router_link" to="#">Địa chỉ văn phòng</RouterLink></li>
              <li><RouterLink class="router_link" to="#">Dịch vụ</RouterLink></li>
              <li><RouterLink class="router_link" to="#">Chương trình</RouterLink></li>
            </ul>
          </div>
          <div class="footer-col">
            <h4>Hỗ trợ</h4>
            <ul>
              <li><RouterLink class="router_link" to="#">Câu hỏi</RouterLink></li>
              <li><RouterLink class="router_link" to="#">Vận chuyển</RouterLink></li>
              <li><RouterLink class="router_link" to="#">Trả lại</RouterLink></li>
              <li><RouterLink class="router_link" to="#">Trạng thái đơn hàng</RouterLink></li>
              <li><RouterLink class="router_link" to="#">Thanh Toán</RouterLink></li>
            </ul>
          </div>
          <div class="footer-col">
            <h4>Liên kết</h4>
            <ul>
              <li><RouterLink class="router_link" to="#">Facebook</RouterLink></li>
              <li><RouterLink class="router_link" to="#">Tiktok</RouterLink></li>
              <li><RouterLink class="router_link" to="#">Youtube</RouterLink></li>
              <li><RouterLink class="router_link" to="#">Instagram</RouterLink></li>
            </ul>
          </div>
          <div class="footer-col">
            <h4>Fanpage</h4>
            <div class="social-links"></div>
          </div>
        </div>
      </div>
    </div>
    <div class="footer_bottom">
      <p>Copyright © 2024 <RouterLink class="router_link" to="#">WinWin</RouterLink></p>
    </div>
  </footer>
</template>

<style lang="scss" scoped>
.container {
  max-width: 1170px;
  margin: auto;
}
.row {
  display: flex;
  flex-wrap: wrap;
  justify-content: space-between;
}
ul {
  list-style: none;
}
.footer_main {
  background-color: #ffffff;
  border-top: 1px solid #e7e7e7;
  border-bottom: 1px solid #e7e7e7;
  padding: 40px 0px 30px 0px;
}
.footer-col {
  width: 20%;
  padding: 0 15px;
}
.footer-col h4 {
  font-size: 18px;
  color: $color_default_for_text;
  text-transform: capitalize;
  margin-bottom: 35px;
  font-weight: 500;
  position: relative;
  cursor: default;
}
.footer-col h4::before {
  content: '';
  position: absolute;
  left: 0;
  bottom: -10px;
  background-color: $color_default_for_hover_text;
  height: 2px;
  box-sizing: border-box;
  width: 50px;
}
.footer-col ul li:not(:last-child) {
  margin-bottom: 10px;
}
.footer-col ul li .router_link {
  font-size: 15px;
  text-transform: capitalize;
  text-decoration: none;
  font-weight: 400;
  color: $color_default_for_text;
  display: block;
  cursor: pointer;
  transition: all 0.3s ease;
}
.footer-col ul li .router_link:hover {
  color: $color_default_for_hover_text;
  padding-left: 8px;
}
.footer_bottom {
  text-align: center;
  padding: 20px 0px;
  font-size: 15px;
  color: $color_default_for_text;
  .router_link {
    cursor: pointer;
    text-decoration: none;
    color: $color_default_for_text;
  }
}
/*responsive*/
@media (max-width: 767px) {
  .footer-col {
    width: 50%;
    margin-bottom: 30px;
  }
}
@media (max-width: 574px) {
  .footer-col {
    width: 100%;
  }
}
</style>
