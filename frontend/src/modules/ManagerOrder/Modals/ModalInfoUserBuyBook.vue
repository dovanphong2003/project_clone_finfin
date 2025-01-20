<script setup lang="ts">
const props = defineProps({
  infoSeller: {
    type: Object as () => any,
    required: true
  }
})
</script>
<template>
  <div class="content_modal">
    <div class="seller-info-container">
      <h2>Thông Tin Người Bán</h2>
      <p><span class="label">Tên:</span> <span class="info" id="sellerName">
        {{infoSeller.name }}
      </span></p>
      <p><span class="label">Email:</span> <span class="info" id="sellerEmail">
        {{infoSeller.email }}
      </span></p>
      <p><span class="label">Tuổi:</span> <span class="info" id="sellerAge">
        {{infoSeller.age }}
      </span></p>
      <p><span class="label">Giới tính:</span> <span class="info" id="sellerGender">
        {{infoSeller.gender }}
      </span></p>
      <p><span class="label">Vai trò ID:</span> <span class="info" id="sellerRoleId">
        {{infoSeller.role_id }}
      </span></p>
    </div>
  </div>
</template>
<style lang="scss" scoped>
.content_modal {
  width: 80vw;
  height: 80vh;
  .seller-info-container {
      background-color: white;
      padding: 20px;
      border-radius: 8px;
      width: 350px;
      margin: 0 auto;
      box-sizing: border-box;
    }

    .seller-info-container h2 {
      color: #333;
      text-align: center;
      margin-bottom: 15px;
    }

    .seller-info-container p {
      color: #555;
      font-size: 16px;
      margin: 5px 0;
      padding: 10px;
      font-weight: 600;
    }

    .label {
      font-weight: bold;
      color: #333;
    }

    .info {
      color: #007BFF;
    }

    .gender {
      color: #ff69b4; /* Màu cho giới tính nữ */
    }

    .gender.male {
      color: #1e90ff; /* Màu cho giới tính nam */
    }

    .btn {
      background-color: #007BFF;
      color: white;
      padding: 8px 16px;
      border: none;
      border-radius: 5px;
      cursor: pointer;
      margin-top: 15px;
      width: 100%;
      text-align: center;
    }

    .btn:hover {
      background-color: #0056b3;
    }
}
</style>
