<script lang="ts" setup>
import type { ClickRowArgument, Header } from 'vue3-easy-data-table'
// cpt modal right
import ModalEditOrder from '@/modules/ManagerOrder/Modals/ModalEditOrder.vue'
import { handleLoadingNotication, handleLoadingNoticationError } from '@/common/functions/loading'
import CreateOrder from '@/modules/ManagerOrder/CreateOrder.vue'
import { Ref, ref } from 'vue'
import type { IOrder } from '@/common/interface'
import CptModalRight from '@/common/components/CptModalRight.vue'
import axiosInstance from '@/services/axiosService'
import { useListOrderStore } from '@/stores/listStores/listBookSold'
import CptModalCenter from '@/common/components/CptModalCenter.vue'
import ModalInfoUserBuyBook from '@/modules/ManagerOrder/Modals/ModalInfoUserBuyBook.vue'
const headers: Header[] = [
  { text: 'Hành động', value: 'handle', width: 130 },
  { text: 'Mã hóa đơn', value: 'order_id', width: 100 },
  { text: 'Người mua', value: 'user_id', width: 130 },
  { text: 'Người bán', value: 'seller', width: 150 },
  { text: 'Trạng thái', value: 'status', width: 100 },
  { text: 'Địa chỉ gửi đến', value: 'shippingAddress', width: 200 },
  { text: 'Thanh toán', value: 'paymentMethod', width: 150 },
  { text: 'Ngày đặt', value: 'order_date', width: 200 },
  { text: 'Ngày tạo', value: 'createdAt', width: 200 },
  { text: 'Ngày cập nhật', value: 'updatedAt', width: 200 },
]
// store Order
const storeOrder = useListOrderStore()
// call api get data all Order and arr permission of Order
const fncGetAllOrder = async () => {
  try {
    const result = await axiosInstance.get('/api/BookSold/extended')
    storeOrder.items = result.data.data
    console.log('result: ', result)
  } catch (error) {
    console.log('error: ', error)
    storeOrder.items = []
  }
}
fncGetAllOrder()
// search
const searchField = ref('')
const searchValue = ref('')

// set value IOrder empty
const dataEmpty:IOrder = {
  order_id:0, // ID của đơn hàng
  user_id:null,// ID người dùng (có thể null)
  status: '',// Trạng thái đơn hàng
  order_date: new Date(),// Ngày đặt hàng (ISO 8601 format)
  createdAt: new Date(),// Ngày tạo đơn hàng
  updatedAt: null,// Ngày cập nhật đơn hàng (có thể null)
  isDeleted: false,// Cờ đánh dấu đã xóa
  cart_id:null,// ID giỏ hàng (có thể null)
  shippingAddress:null,// Địa chỉ giao hàng
  paymentMethod: '',// Phương thức thanh toán
  seller: null, // ID người bán
  infoSeller:null,// Thông tin người bán
}
// modal
const titleModalVertical = 'Chỉnh sửa thông tin'
const activeModalVertical: Ref<boolean> = ref(false)
const disableModalVertical: Ref<boolean> = ref(false)
const checkDelete: Ref<boolean> = ref(false)
const checkEdit: Ref<boolean> = ref(false)
const handleClickCloseModalVertical = async () => {
  activeModalVertical.value = false
  disableModalVertical.value = true
  OrderData.value = dataEmpty
}

// handle deleteOrder
const handleDeleteOrder = () => {
  checkDelete.value = true
}

// handle edit
const handleClickVertical = async () => {
  checkEdit.value = true
  activeModalVertical.value = true
  disableModalVertical.value = false
}
const showModal = ref(false)

// handle set show = false;
const handleShowFalse = () => {
  showModal.value = false
}

const loading = ref(true)
setTimeout(() => {
  loading.value = false
}, 1000)

// onclick
const OrderData = ref<IOrder>(dataEmpty)
const showRow = async (val: ClickRowArgument) => {
  if (checkDelete.value) {
    const result = await axiosInstance.delete('/api/Order', {
      params: { id: val.Order_id }
    })
    if (result.data.isSuccess) {
      handleLoadingNotication('Xóa thành công', 500, 'top-center')
      storeOrder.deleteOrder(val.Order_id)
    } else {
      handleLoadingNoticationError('có lỗi xảy ra!', 500, 'top-center')
    }
    checkDelete.value = false
  } else {
    OrderData.value = val as any
  }
}
</script>
<template>
  <div class="main-manager_Order">
    <div class="table">
      <div class="header_table">
        <div class="searching">
          <div class="input_1">
            <span>Tìm kiếm theo cột: </span>
            <select v-model="searchField">
              <option value="" selected disabled hidden>Lựa chọn</option>
              <option v-for="(obj, index) in headers" :key="index" :value="obj.value">
                {{ obj.text }}
              </option>
            </select>
          </div>
          <div class="input_2">
            <!-- <span>Từ tìm kiếm: </span> -->
            <input placeholder="nhập từ tìm kiếm" type="text" v-model="searchValue" />
          </div>
        </div>
        <CreateOrder />
      </div>
      <EasyDataTable
        table-class-name="customize-table"
        theme-color="#042dc2"
        :headers="headers"
        :items="storeOrder.items"
        alternating
        header-text-direction="center"
        body-text-direction="center"
        border-cell
        buttons-pagination
        :loading="loading"
        :rows-per-page="10"
        :rows-items="[10, 15, 20, 25]"
        rows-per-page-message="Số hàng"
        @click-row="showRow"
        sort-by="sortBy"
        sort-type="sortType"
        :search-field="searchField"
        :search-value="searchValue"
      >
        <!--template when not found data-->
        <template #empty-message>
          <img
            class="img_not_found_data"
            src="https://i.pinimg.com/originals/71/3a/32/713a3272124cc57ba9e9fb7f59e9ab3b.gif"
            style="width: 200px; height: 160px; Order-select: none; border: none"
          />
          <h2>Không tìm thấy dữ liệu !</h2>
        </template>

        <!--template for seller, example seller Order,...-->
        <template #item-seller="{ seller, infoSeller }">
          <p @click="showModal = true"
            style="
              display: -webkit-box;
              -webkit-box-orient: vertical;
              -webkit-line-clamp: 2;
              overflow: hidden;
              text-overflow: ellipsis;
              font-size: 13px;
              font-weight: 600;
              color: blue;
              text-decoration: underline;
              cursor: pointer;
            "
          >
          {{ seller }}
        </p>
           <div class="content_infoSeller">
            <CptModalCenter title="" :show="showModal" :handleShowFalse="handleShowFalse">
              <ModalInfoUserBuyBook :infoSeller="infoSeller"> </ModalInfoUserBuyBook>
             
            </CptModalCenter>
           </div>
        </template>
        <template #item-email="{ email }">
          <p
            style="
              display: -webkit-box;
              -webkit-box-orient: vertical;
              -webkit-line-clamp: 3;
              overflow: hidden;
              text-overflow: ellipsis;
              font-size: 13px;
            "
          >
            {{ email }}
            
          </p>
        </template>
        <!--template for handle ( edit, delete )-->
        <template #item-handle>
          <div class="handle" style="width: 100%; text-align: center">
            <img
              @click="handleClickVertical"
              src="/icon/edit.png"
              alt="edit"
              style="margin: 0px 4px; padding: 6px 8px; height: 20px; cursor: pointer"
            />
            <img
              @click="handleDeleteOrder"
              src="/icon/delete.png"
              alt="delete"
              style="margin: 0px 4px; padding: 6px 8px; height: 20px; cursor: pointer"
            />
          </div>
        </template>

        <template #item-role_id="{ role_id,role_name }">
          <p
            style="
              display: -webkit-box;
              -webkit-box-orient: vertical;
              -webkit-line-clamp: 3;
              overflow: hidden;
              text-overflow: ellipsis;
              font-weight: 700;
              font-size: 13px;
              color:forestgreen;
            "
          >
            {{ role_id }}   <br>  {{ role_name }}
          </p>
        </template>
      </EasyDataTable>
      <CptModalRight
        :title-modal="titleModalVertical"
        :active-modal="activeModalVertical"
        :disable-modal="disableModalVertical"
        @handle-click-close-modal="handleClickCloseModalVertical"
      >
        <ModalEditOrder
          v-if="activeModalVertical && OrderData.status"
          :is="ModalEditOrder"
          :objOrder="OrderData"
        ></ModalEditOrder>
      </CptModalRight>
    </div>
  </div>
</template>
<style lang="scss" scoped>
@import '@/common/mixin/mixinButton.scss';
.table {
  .header_table {
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 8px 20px;
    .searching {
      display: flex;
      flex-direction: column;
      // align-items: center;
      .input_1,
      .input_2 {
        padding: 8px 20px 8px 0px;
        input {
          height: 20px;
        }
        span {
          font-size: 14px;
          color: $color_default_for_text;
        }
      }
    }
  }
  .customize-table {
    --easy-table-header-height: 50px;
    --easy-table-header-font-size: 13px;
    --easy-table-header-font-color: #252a2b;
    --easy-table-body-row-font-color: #252a2b;
    --easy-table-body-row-height: 60px;
    img:hover {
      border: 1px solid #0000008e;
    }

    img:active {
      background-color: rgb(255, 255, 255);
    }
  }
}
.content_infoSeller {
  opacity: 1;
}
</style>
