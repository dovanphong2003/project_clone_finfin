  <script setup lang="ts">
  import { computed, defineProps, onBeforeMount, ref } from 'vue'
  import type { IOrder } from '@/common/interface'
  import { handleLoading, handleLoadingNotication, handleLoadingNoticationError } from '@/common/functions/loading'
  import axiosInstance from '@/services/axiosService'
  import { add } from 'lodash'
  import { format } from 'date-fns'
  import { createdIdAuto } from '@/common/functions/createIdAuto'
  import { useListOrderStore } from '@/stores/listStores/listBookSold'
  const store = useListOrderStore()

  // call api get select role
  const dataSelect = ref([])
  const fncGetAllBook = async () => {
    try {
      const result = await axiosInstance.get('/api/Book/extended')
      dataSelect.value = result.data.data.map((items) => {
        return { book_id:items.book_id, title: items.title, price: items.price }
      })
    } catch (error) {
      console.log('error: ', error)
    }
  }
  onBeforeMount(() => {
    fncGetAllBook();
  });
  // Dữ liệu cho sách đã chọn, số lượng và giỏ hàng
  const selectedBook = ref(null);
  const quantity = ref(1);
  const cart = ref<any[]>([]);

  // Thêm sách vào giỏ hàng
  const addToCart = () => {
    if (selectedBook.value && quantity.value > 0) {
      const cartItem = {
        book: selectedBook.value,
        quantity: quantity.value
      };
      cart.value.push(cartItem);
      quantity.value = 1; // Reset số lượng
      selectedBook.value = null; // Reset sách đã chọn
    }
  };
  // Tính tổng tiền của giỏ hàng
  const totalAmount = computed(() => {
    return cart.value.reduce((total, item) => total + item.quantity * item.book.price, 0);
  });
  // Xác nhận đơn hàng
  const confirmOrder = async () => {
    alert("Đơn hàng đã được xác nhận!");
    console.log("cart:" ,cart.value);
    const addOrder = {
      order_id:createdIdAuto(),
      data:cart.value,
      createdAt: new Date(),
      createdBy:6,
    }
    try {
      console.log("data send: ",addOrder)
      const result = await axiosInstance.post('/api/BookSold', addOrder)
      if (result.data.isSuccess) {
        cart.value = []; // Xóa giỏ hàng sau khi xác nhận
        handleLoadingNotication('Tạo thành công', 600, 'top-right')
      } else {
        handleLoadingNoticationError('Tạo không thành công!', 600, 'top-center')
        console.log("error: ",result.data)
      }
    } catch (error) {
      if (error && (error as any).response && (error as any).response.data && (error as any).response.data.message) {
      handleLoadingNoticationError((error as any).response.data.message, 600, 'top-right')
  } else {
      handleLoadingNoticationError('Có lỗi đã xảy ra', 600, 'top-right')
  }

    }
    

  };
</script>
<template>
  <div class="content_modal">
  <div id="appli">
    <h1>Thêm Sách Vào Đơn Hàng</h1>
    
    <!-- Chọn sách -->
    <div>
      <label for="book">Chọn sách:</label>
      <select v-model="selectedBook">
        <option v-for="book in dataSelect as any " :key="book.book_id" :value="book">{{ book.title }}</option>
      </select>
    </div>
    
    <!-- Chọn số lượng -->
    <div>
      <label for="quantity">Số lượng:</label>
      <input type="number" v-model="quantity" min="1" />
    </div>
    
    <!-- Nút thêm vào giỏ hàng -->
    <button @click="addToCart">Thêm vào đơn hàng</button>
    
    <!-- Hiển thị thông tin giỏ hàng -->
    <div v-if="cart.length">
      <h2>Đơn hàng</h2>
      <hr>
      <ul>
        <li v-for="(item, index) in cart" :key="index">
          {{ item.quantity }} x {{ item.book.title }} - Tổng: {{ item.quantity * item.book.price }} VND
          <hr>
        </li>
      </ul>
      <!-- Tổng tiền -->
      <p><strong>Tổng tiền: {{ totalAmount }} VND</strong></p>
    </div>
    <!-- Nút xác nhận -->
    <button @click="confirmOrder" :disabled="cart.length === 0">Xác nhận và tạo đơn hàng</button>
  </div>
  </div>
</template>
<style lang="scss" scoped>
.content_modal {
  width: 700px;

h1 {
  text-align: center;
  color: #222222;
  padding-bottom: 40px;
}
h2 {
  color: #222222;
  padding-top: 30px;
  font-size: 20px;
}

label {
  font-weight: bold;
}

select, input {
  margin: 10px 0;
  padding: 8px;
  width: 100%;
  border: 1px solid #ccc;
  border-radius: 4px;
}

button {
  background-color: #007BFF;
  color: white;
  padding: 10px;
  margin-bottom: 30px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  width: 100%;
  margin-top: 10px;
}

button:hover {
  background-color: #0056b3;
}

button:disabled {
  background-color: #cccccc;
  cursor: not-allowed;
}

ul {
  padding-left: 20px;
}

li {
  margin-bottom: 10px;
}
p {
  font-size: 18px;
  font-weight: bold;
  margin-top: 20px;
  text-align: right;
}
}
</style>
