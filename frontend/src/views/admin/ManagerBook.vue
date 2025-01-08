<script lang="ts" setup>
import type { Header, ClickRowArgument } from 'vue3-easy-data-table'
import { onMounted, Ref, ref } from 'vue'
import CptModalRight from '@/common/components/CptModalRight.vue'
import { IBookExtended, ISelectOptionsOfBook } from '@/common/interface'
import ModalEditBook from '@/modules/ManagerBook/Modals/ModalEditBook.vue'
import CreateBook from '@/modules/ManagerBook/CreateBook.vue'
import { useListBookStore } from '@/stores/listStores/listBook'
import CptModalCenter from '@/common/components/CptModalCenter.vue'
import ModalViewContentBook from '@/modules/ManagerBook/Modals/ModalViewContentBook.vue'
import ModalEditContentBook from '@/modules/ManagerBook/Modals/ModalEditContentBook.vue'
import axiosInstance from '@/services/axiosService'
import { handleLoadingNotication, handleLoadingNoticationError } from '@/common/functions/loading'

// cpt modal right
const headers: Header[] = [
  { text: 'Hành động', value: 'handle', width: 130 },
  { text: 'Mã sách ISBN', value: 'ISBN', width: 130 },
  { text: 'Nội dung', value: 'content', width: 130 },
  { text: 'Tên sách', value: 'title', sortable: true, width: 130 },
  { text: 'Hình ảnh', value: 'imageUrl', width: 100 },
  { text: 'Giá', value: 'price' },
  { text: 'Chủ đề', value: 'category', width: 150 },
  { text: 'Tác giả', value: 'author', width: 150 },
  { text: 'Nhà xuất bản', value: 'publisher', width: 150 },
  { text: 'Tồn kho', value: 'stock_quantity', width: 100 },
  { text: 'Trạng thái', value: 'status', width: 100 },
  { text: 'Ngày nhập', value: 'ReceiveDate', width: 130 },
  { text: 'ID người tạo', value: 'createdBy', width: 100 },
  { text: 'Cập nhật', value: 'updatedAt',  width: 130 },
  { text: 'ID người cập nhật', value: 'updatedBy', width: 100 }
]

const store = useListBookStore()

const fncGetAllBookExtended = async () => {
  try {
    const result = await axiosInstance.get('/api/Book/extended')
const backendDataArray = result.data.data;
const books: IBookExtended[] = backendDataArray.map((backendData: any) => ({
  book_id: backendData.book_id,
  ISBN:backendData.isbn,
  title: backendData.title,
  imageUrl: backendData.imageUrl,
  price: backendData.price,
  category: {
    category_id: backendData.category_id,
    category_name: backendData.category_name
  },
  author: {
    author_id: backendData.author_id,
    author_name: backendData.author_name
  },
  publisher: {
    publisher_id: backendData.publisher_id,  
    publisher_name: backendData.publisher_name
  },
  stock_quantity: backendData.stock_quantity,
  content_data: backendData.content_data,
  status: backendData.status,
  ReceiveDate: new Date(backendData.receiveDate),  // Chuyển đổi chuỗi thành Date
  updatedAt: backendData.updatedAt ? new Date(backendData.updatedAt) : undefined,  // Kiểm tra nếu có updatedAt
  isDeleted: backendData.isDeleted,
  createdBy: backendData.createdBy,
  updatedBy: backendData.updatedBy ?? undefined,  // Nếu null thì trả về undefined
  deleteBy: backendData.deleteBy ?? undefined   // Nếu null thì trả về undefined
}));
console.log(books);
store.items = books
  } catch (error) {
    console.log('error: ', error)
    store.items = []
  }
}
fncGetAllBookExtended()

// get select option
const selectOptions = ref<ISelectOptionsOfBook | null>(null);
console.log("cjeck var: ",selectOptions.value)
console.log("check true: ",selectOptions.value ? "true" : "false")
  const fncGetValueOptions = async () => {
    try {
      const result = await axiosInstance.get('/api/Book/select-options')
      console.log('result: ', result)
      selectOptions.value = result.data.data[0]
    } catch (error) {
      console.log('error: ', error)
    }
  }
  fncGetValueOptions()
// search
const searchField = ref('')
const searchValue = ref('')

// modal
const titleModalVertical = 'Chỉnh sửa thông tin'
const activeModalVertical: Ref<boolean> = ref(false)
const disableModalVertical: Ref<boolean> = ref(false)
const checkDelete: Ref<boolean> = ref(false)
const checkEdit: Ref<boolean> = ref(false)

  const dataEmptyBook = {
    book_id : 0,
    ISBN:'',
   title: '', 
  imageUrl: '',
   price: 0,
   category: {
    category_id: 0,
    category_name:'',
   }, 
  author: {
    author_id : 0,
    author_name: '',
  },
   publisher: {
  publisher_id: 0 ,
   publisher_name: '', 
   },
   stock_quantity: 0, 
   content_data: undefined, 
   status: false, 
   ReceiveDate : new Date(),
   updatedAt: undefined,
   isDeleted : false,
   createdBy : 0,
   updatedBy: undefined, 
   deleteBy: undefined 
  }

const handleClickCloseModalVertical = async () => {
  activeModalVertical.value = false
  disableModalVertical.value = true
  // reset data component
  bookData.value = dataEmptyBook
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
  bookData.value =dataEmptyBook
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
const bookData = ref<IBookExtended>(
dataEmptyBook)
const showRow = async (val: ClickRowArgument) => {
  if (checkDelete.value) {
    const result = await axiosInstance.delete('/api/Book', { params: { id: val.book_id } })
    if (result.data.isSuccess) {
      handleLoadingNotication('Xóa thành công', 500, 'top-center')
      store.deleteBook(val.book_id)
    } else {
      handleLoadingNoticationError('có lỗi xảy ra!', 500, 'top-center')
    }
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
        <CreateBook  
        v-if="selectOptions"
          :selectOptions="selectOptions"/>
      </div>
      <EasyDataTable
        class="customize-table"
        theme-color="#042dc2"
        :headers="headers"
        :items="store.items.map(item => {
  return {
    ...item,
    publisher_id: item.publisher.publisher_id,
    publisher_name: item.publisher.publisher_name,
    category_id: item.category.category_id,
    category_name: item.category.category_name,
    author_id: item.author.author_id,
    author_name: item.author.author_name
  };
})"
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
            style="width: 200px; height: 160px; user-select: none; border: none"
          />
          <h2>Không tìm thấy dữ liệu !</h2>
        </template>

        <!--template for name, example name book,...-->
        <template #item-title="{ title }">
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
            {{ title }}
          </p>
        </template>

        <template #item-category="{ category }">
          <p
            style="
              display: -webkit-box;
              -webkit-box-orient: vertical;
              -webkit-line-clamp: 3;
              overflow: hidden;
              text-overflow: ellipsis;
              font-weight: 500;
            "
          >
            {{ category.category_id }}
            <br/>
            {{category.category_name }}
          </p>
        </template>

        <template #item-author="{ author }">
          <p
            style="
              display: -webkit-box;
              -webkit-box-orient: vertical;
              -webkit-line-clamp: 3;
              overflow: hidden;
              text-overflow: ellipsis;
              font-weight: 500;
            "
          >
          {{ author.author_id }}
            <br/>
            {{author.author_name }}
          </p>
        </template>

        <template #item-publisher="{ publisher }">
          <p
            style="
              display: -webkit-box;
              -webkit-box-orient: vertical;
              -webkit-line-clamp: 3;
              overflow: hidden;
              text-overflow: ellipsis;
              font-weight: 500;
            "
          >
          {{ publisher.publisher_id }}
            <br/>
            {{publisher.publisher_name }}
          </p>
        </template>

        <!--template for image, example image book,...-->
        <template #item-imageUrl="{ imageUrl }">
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
            <img :src="imageUrl" alt="hình ảnh sách" style="width: 60px; height: 70px; padding: 6px" />
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
            <div :class="[status  ? 'active' : 'error']" style="padding: 4px 20px">
              {{ status ? 'Active' : 'Disable' }}
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
          v-if="activeModalVertical && bookData.title && selectOptions"
          :is="ModalEditBook"
          :objBook="bookData"
          :selectOptions="selectOptions"
        ></ModalEditBook>
      </CptModalRight>

      <!-- for edit and view content of book-->
      <CptModalCenter
        :title="checkHandleEdit ? 'Chỉnh sửa nội dung sách' : 'Nội dung sách'"
        :show="showModal"
        :handleShowFalse="handleShowFalse"
      >
        <ModalViewContentBook v-if="checkHandleView && bookData.title" :bookData="bookData">
        </ModalViewContentBook>
        <ModalEditContentBook v-else-if="checkHandleEdit && bookData.title" :bookData="bookData">
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
