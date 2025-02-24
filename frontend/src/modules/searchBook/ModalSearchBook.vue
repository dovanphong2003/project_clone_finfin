<script setup lang="ts">
// handle when onclick search
const handleSubmitForm = (event: Event) => {
  event.preventDefault()
}
</script>
<template>
  <form @submit="handleSubmitForm" class="form_modal" action="">
    <input type="text" placeholder="Tìm kiếm sản phẩm..." />
    <button class="search_bnt"><img src="/icon/search.png" alt="" /></button>
  </form>
</template>
<style lang="scss" scoped>
.form_modal {
  display: flex;
  input {
    height: 55px;
    padding: 0px 8px;
    font-size: 15px;
    color: $color_default_for_text;
    width: 80%;
    border: none;
    outline: none;
    background-color: #f5f5f5;
  }
  .search_bnt {
    border: none;
    outline: none;
    background-color: #f5f5f5;
    width: 20%;
    text-align: center;
    padding: 0;
    img {
      cursor: pointer;
      height: 24px;
      width: 24px;
      opacity: 0.4;
    }
    img:hover {
      opacity: 1;
    }
    img:active {
      opacity: 0.6;
    }
  }
}
</style>
