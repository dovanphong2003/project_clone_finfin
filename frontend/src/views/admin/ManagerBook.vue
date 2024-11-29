<script lang="ts" setup>
import type { Header, ClickRowArgument } from 'vue3-easy-data-table'
import { Ref, ref } from 'vue'
import CptModalRight from '@/common/components/CptModalRight.vue'
import { IBook } from '@/common/interface'
import ModalEditBook from '@/modules/ManagerBook/Modals/ModalEditBook.vue'
import CreateBook from '@/modules/ManagerBook/CreateBook.vue'
import { useListBookStore } from '@/stores/listStores/listBook'
import CptModalCenter from '@/common/components/CptModalCenter.vue'
import ModalViewContentBook from '@/modules/ManagerBook/Modals/ModalViewContentBook.vue'
import ModalEditContentBook from '@/modules/ManagerBook/Modals/ModalEditContentBook.vue'

// cpt modal right
const headers: Header[] = [
  { text: 'Hành động', value: 'handle', width: 130 },
  { text: 'Nội dung', value: 'content', width: 130 },
  { text: 'Tên sách', value: 'name', sortable: true, width: 130 },
  { text: 'Hình ảnh', value: 'image', width: 100 },
  { text: 'Giá', value: 'price' },
  { text: 'Thể loại', value: 'category', width: 100 },
  { text: 'Ngày tạo', value: 'createdAt' },
  { text: 'Cập nhật mới', value: 'updatedAt' },
  { text: 'Giảm giá', value: 'promotion', width: 50 },
  { text: 'Trạng thái', value: 'status', width: 100 }
]

const store = useListBookStore()
// search
const searchField = ref('')
const searchValue = ref('')

// modal
const titleModalVertical = 'Chỉnh sửa thông tin'
const activeModalVertical: Ref<boolean> = ref(false)
const disableModalVertical: Ref<boolean> = ref(false)
const checkDelete: Ref<boolean> = ref(false)
const checkEdit: Ref<boolean> = ref(false)

const handleClickCloseModalVertical = async () => {
  activeModalVertical.value = false
  disableModalVertical.value = true

  // reset data component
  bookData.value = {
    id: '',
    name: '',
    content: '',
    image: '',
    price: '0',
    author: '',
    category: '',
    createdAt: '',
    updatedAt: '',
    status: 'disable'
  }
}

// handle delete book
const handleDeleteBook = () => {
  checkDelete.value = true
}

// handle edit book
const handleClickVertical = async () => {
  checkEdit.value = true
  activeModalVertical.value = true
  disableModalVertical.value = false
}

///////////////

// handle for content book
const showModal: Ref<boolean> = ref(false)
const checkHandleEdit: Ref<boolean> = ref(false)
const checkHandleView: Ref<boolean> = ref(false)

// handle set show = false;
const handleShowFalse = () => {
  showModal.value = false

  // reset data component
  bookData.value = {
    id: '',
    name: '',
    content: '',
    image: '',
    price: '0',
    author: '',
    category: '',
    createdAt: '',
    updatedAt: '',
    status: 'disable'
  }
}
// handle edit content book
const handleEditContentBook = async () => {
  checkHandleEdit.value = true
  showModal.value = true
  checkHandleView.value = false
}

const handleViewContentBook = async () => {
  checkHandleView.value = true
  checkHandleEdit.value = false
  showModal.value = true
}
////////////////////

const loading = ref(true)
setTimeout(() => {
  loading.value = false
}, 1000)

// onclick
const bookData = ref<IBook>({
  id: '',
  name: '',
  image: '',
  content: '',
  price: '0',
  author: '',
  category: '',
  createdAt: '',
  updatedAt: '',
  status: 'disable'
})
const showRow = (val: ClickRowArgument) => {
  console.log('val: ', val)
  if (checkDelete.value) {
    store.deleteBook(val.id)
    checkDelete.value = false
  } else {
    delete val.indexInCurrentPage
    bookData.value = val as any
  }
}
</script>
<template>
  <div class="main-manager_book">
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
        <CreateBook />
      </div>
      <EasyDataTable
        class="customize-table"
        theme-color="#042dc2"
        :headers="headers"
        :items="store.items"
        alternating
        header-text-direction="center"
        body-text-direction="center"
        border-cell
        buttons-pagination
        :loading="loading"
        :rows-per-page="10"
        :rows-items="[10, 15, 20, 25]"
        show-index-symbol="TT"
        rows-per-page-message="Số hàng"
        show-index
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
            style="width: 200px; height: 160px; user-select: none; border: none"
          />
          <h2>Không tìm thấy dữ liệu !</h2>
        </template>

        <!--template for name, example name book,...-->
        <template #item-name="{ name }">
          <p
            style="
              display: -webkit-box;
              -webkit-box-orient: vertical;
              -webkit-line-clamp: 2;
              overflow: hidden;
              text-overflow: ellipsis;
              font-weight: 500;
            "
          >
            {{ name }}
          </p>
        </template>

        <!--template for image, example image book,...-->
        <template #item-image="{ image }">
          <div
            class="img"
            style="
              width: 100%;

              display: flex;
              align-items: center;
              justify-content: center;
              cursor: pointer;
            "
          >
            <img :src="image" alt="hình ảnh sách" style="width: 60px; height: 70px; padding: 6px" />
          </div>
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
              @click="handleDeleteBook"
              src="/icon/delete.png"
              alt="delete"
              style="margin: 0px 4px; padding: 6px 8px; height: 20px; cursor: pointer"
            />
          </div>
        </template>

        <!--template for contentBook ( edit, delete )-->
        <template #item-content>
          <div class="contentBook" style="width: 100%; text-align: center">
            <img
              @click="handleEditContentBook"
              src="/icon/edit.png"
              alt="edit"
              style="margin: 0px 4px; padding: 6px 8px; height: 20px; cursor: pointer"
            />
            <img
              @click="handleViewContentBook"
              src="/icon/view.png"
              alt="view"
              style="margin: 0px 4px; padding: 6px 8px; height: 20px; cursor: pointer"
            />
          </div>
        </template>
        <!--template for status ( active, disable )-->
        <template #item-status="{ status }">
          <div class="status">
            <div :class="[status == 'active' ? 'active' : 'error']" style="padding: 4px 20px">
              {{ status == 'active' ? 'Active' : 'Disable' }}
            </div>
          </div>
        </template>
      </EasyDataTable>
      <CptModalRight
        :title-modal="titleModalVertical"
        :active-modal="activeModalVertical"
        :disable-modal="disableModalVertical"
        @handle-click-close-modal="handleClickCloseModalVertical"
      >
        <ModalEditBook
          v-if="activeModalVertical && bookData.name"
          :is="ModalEditBook"
          :objBook="bookData"
        ></ModalEditBook>
      </CptModalRight>

      <!-- for edit and view content of book-->
      <CptModalCenter
        :title="checkHandleEdit ? 'Chỉnh sửa nội dung sách' : 'Nội dung sách'"
        :show="showModal"
        :handleShowFalse="handleShowFalse"
      >
        <ModalViewContentBook v-if="checkHandleView && bookData.name" :bookData="bookData">
        </ModalViewContentBook>
        <ModalEditContentBook v-else-if="checkHandleEdit && bookData.name" :bookData="bookData">
        </ModalEditContentBook>
      </CptModalCenter>
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
    --easy-table-header-font-size: 12px;
    --easy-table-header-font-color: #252a2b;
    --easy-table-body-row-font-color: #252a2b;
    img:hover {
      border: 1px solid #0000008e;
    }

    img:active {
      background-color: rgb(255, 255, 255);
    }
    .status {
      text-align: center;
      .error {
        color: #cf2b0a;
        border-radius: 4px;
        background-color: rgba(207, 23, 10, 0.18);
        border: 1px solid red;
      }
      .active {
        color: #0acf97;
        border-radius: 4px;
        background-color: rgba(10, 207, 151, 0.18);
        border: 1px solid #00bc87;
      }
    }
  }
}
</style>
