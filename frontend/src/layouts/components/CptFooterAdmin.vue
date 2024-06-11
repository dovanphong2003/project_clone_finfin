<script setup lang="ts"></script>
<template>
  <footer>
    <div class="footer_bottom">
      <p>Copyright © 2024 <RouterLink class="router_link" to="#">WinWin</RouterLink></p>
    </div>
  </footer>
</template>
<style lang="scss" scoped>
.footer_bottom {
  border-top: 1px solid #eaeaea8a;
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
</style>
