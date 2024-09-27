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
const checkEditContentBook: Ref<boolean> = ref(false)

const handleClickCloseModalVertical = async () => {
  activeModalVertical.value = false
  disableModalVertical.value = true
  bookData.value = {
    id: '',
    name: '',
    content:
      '<p>Bộ sách&nbsp;<strong style="color: rgb(230, 126, 34);">"Kỹ năng và Phương pháp Giao dịch&nbsp;của các Trader Quản lý&nbsp;Quỹ "</strong><span style="color: rgb(230, 126, 34);">&nbsp;</span>tổng hợp các tựa sách giao dịch Forex nổi tiếng được viết bởi các Nhà Quản lý Quỹ, lượng kiến thức và kinh nghiệm chắc chắn sẽ rất lớn và bổ ích từ những cá nhân đã đạt vị trí cao và được công nhận trên Thế giới. Bộ sách bao gồm 3&nbsp;tựa&nbsp;như sau:</p><p class="ql-align-center"><img src="https://file.hstatic.net/1000297486/file/combo34_e4173f9080d04c90ac23c4f508602cf3_grande.jpg"></p><p>&nbsp;</p><h2><span style="color: rgb(0, 153, 204);">Khám Phá Nghệ Thuật Giao Dịch Tiền Tệ Chuyên Nghiệp</span></h2><p><strong><em>Khám phá Nghệ thuật Giao dịch Tiền tệ Chuyên nghiệp</em></strong>&nbsp;khái quát hầu như tất cả những yếu tố từ cơ bản nhất đến chuyên sâu nhất dành cho một FX Trader thành công, bao gồm:</p><ul><li>Vì sao giao dịch Forex được xem là nghệ thuật chứ không phải khoa học.</li><li>Câu chuyện “làm nghề” của một FX Trader cho ngân hàng - quỹ đầu cơ.</li><li>Những điểm mốc quan trọng trong lịch sử của thị trường Forex.</li><li>Cấu trúc thị trường Forex có gì đáng chú ý.</li><li>Phân tích cơ bản - Fundamental Analysis - thị trường Forex như thế nào để hiệu quả thông qua phân tích vĩ mô.</li><li>Cách thức giao dịch theo tin tức trên thị trường Forex.</li><li>Cách một FX Trader chuyên nghiệp sử dụng phân tích kỹ thuật, đặc biệt tác giả có chia sẻ 07 thiết lập giao dịch hiệu quả cao mà bản thân sử dụng.</li><li>Phân tích Liên thị trường - Intermarket Analysis - được sử dụng ra sao trên thị trường Forex.</li><li>Cách quản lý rủi ro, tính toán lượng vị thế giao dịch như thế nào để đạt hiệu quả cao mà không quá nguy hiểm đến tài khoản giao dịch.</li><li>Cách thức thấu hiểu bản thân để trở thành một FX Trader thành công.</li></ul><p>Đặc biệt là<strong>&nbsp;</strong><strong style="color: rgb(211, 84, 0);"><em>25 quy tắc giao dịch cá nhân</em></strong>&nbsp;đã giúp Brent Donnelly tồn tại gần 30 năm trong ngành cũng được ông chia sẻ trong sách.</p><p>Tham khảo chi tiết tại:&nbsp;<a href="https://finfin.vn/products/kham-pha-nghe-thuat-giao-dich-tien-te-chuyen-nghiep" rel="noopener noreferrer" target="_blank" style="background-color: transparent; color: rgb(204, 0, 153);">https://finfin.vn/products/kham-pha-nghe-thuat-giao-dich-tien-te-chuyen-nghiep</a></p><p>&nbsp;</p><p><strong style="color: rgb(0, 153, 204);">Đánh Bại Thị Trường Forex</strong></p><p>Từng làm việc trên cả thị trường liên ngân hàng (interbank) lẫn thị trường nhỏ lẻ (retail sector), tác giả Agustin Silvani đề cập nhiều vấn đề tổng quát và quan trọng như:</p><ul><li>Cấu trúc vận hành thị trường forex.</li><li>Nhận diện và đối phó các chiêu trò của dealer, hiểu nôm na là môi giới kiêm lái giá.</li><li>Những kinh nghiệm giúp trở thành trader Top 10%.</li><li>Các mẹo hay để giao dịch tốt hơn.</li><li>Kỹ thuật giao dịch chống lại hành vi thao túng giá.</li><li>Tham khảo chi tiết tại:&nbsp;<a href="https://finfin.vn/products/danh-bai-thi-truong-forex" rel="noopener noreferrer" target="_blank" style="background-color: transparent; color: rgb(204, 0, 153);">https://finfin.vn/products/danh-bai-thi-truong-forex</a></li></ul><p>&nbsp;</p><p><strong style="color: rgb(0, 153, 204);">Thực hành Phân tích Fibonacci</strong></p><p>Một quyển sách không thể&nbsp;bỏ qua được viết bởi bà&nbsp;Constance Brown - một tác giả giỏi&nbsp;thật sự ở mặt thực chiến lẫn học thuật.&nbsp;</p><ul><li>Sách nằm trong Top các quyển sách hay nhất về chủ đề Fibonacci trên Amazon.</li><li>Sách đã đoạt Huy chương vàng trong hạng mục Axiom Business Book Awards năm 2009.</li><li>Sách được Bloomberg Press thuộc hãng tin Bloomberg xuất bản và chọn vào chuỗi sách Bloomberg Market Essentials: Technical Analysis (tạm dịch Các yếu tố cần thiết cho thị trường của Bloomberg: Phân tích Kỹ thuật).</li></ul><p>Tựa sách cung cấp cho độc giả những kiến thức mà chúng ta có thể áp dụng ngay lập tức bao gồm:</p><ul><li>GIỚI THIỆU cách dùng tỷ lệ Fibonacci để dự báo mục tiêu giá.</li><li>CUNG CẤP các ví dụ chi tiết và các bối cảnh thực, trên thị trường thực.&nbsp;</li><li>GIẢI THÍCH về tầm quan trọng của tỉ lệ thức khi phân tích biểu đồ.</li><li>CẢNH BÁO các nhà giao dịch về những lỗi lầm thường gặp.</li><li>MÔ TẢ cách xác định những tín hiệu sai.</li></ul><p><br></p><p>Kỹ thuật giao dịch được đề cập trong sách là sự kết hợp giữa phân tích hành vi giá - price action - trong tổng thể phối hợp với các tỷ lệ Fibonacci nhằm giúp trader đưa ra kế hoạch giao dịch hiệu quả, rủi ro thấp.</p><p><br></p><p>Tham khảo chi tiết tại:&nbsp;&nbsp;<a href="https://finfin.vn/products/danh-bai-thi-truong-forex" rel="noopener noreferrer" target="_blank" style="background-color: transparent; color: rgb(204, 0, 153);">https://finfin.vn/products/thuc-hanh-phan-tich-fibonacci</a></p>',
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
const showModal = ref(false)
const checkHandleEdit = ref(false)
const checkHandleView = ref(false)
// handle set show = false;
const handleShowFalse = () => {
  showModal.value = false
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
  content:
    '<p>Bộ sách&nbsp;<strong style="color: rgb(230, 126, 34);">"Kỹ năng và Phương pháp Giao dịch&nbsp;của các Trader Quản lý&nbsp;Quỹ "</strong><span style="color: rgb(230, 126, 34);">&nbsp;</span>tổng hợp các tựa sách giao dịch Forex nổi tiếng được viết bởi các Nhà Quản lý Quỹ, lượng kiến thức và kinh nghiệm chắc chắn sẽ rất lớn và bổ ích từ những cá nhân đã đạt vị trí cao và được công nhận trên Thế giới. Bộ sách bao gồm 3&nbsp;tựa&nbsp;như sau:</p><p class="ql-align-center"><img src="https://file.hstatic.net/1000297486/file/combo34_e4173f9080d04c90ac23c4f508602cf3_grande.jpg"></p><p>&nbsp;</p><h2><span style="color: rgb(0, 153, 204);">Khám Phá Nghệ Thuật Giao Dịch Tiền Tệ Chuyên Nghiệp</span></h2><p><strong><em>Khám phá Nghệ thuật Giao dịch Tiền tệ Chuyên nghiệp</em></strong>&nbsp;khái quát hầu như tất cả những yếu tố từ cơ bản nhất đến chuyên sâu nhất dành cho một FX Trader thành công, bao gồm:</p><ul><li>Vì sao giao dịch Forex được xem là nghệ thuật chứ không phải khoa học.</li><li>Câu chuyện “làm nghề” của một FX Trader cho ngân hàng - quỹ đầu cơ.</li><li>Những điểm mốc quan trọng trong lịch sử của thị trường Forex.</li><li>Cấu trúc thị trường Forex có gì đáng chú ý.</li><li>Phân tích cơ bản - Fundamental Analysis - thị trường Forex như thế nào để hiệu quả thông qua phân tích vĩ mô.</li><li>Cách thức giao dịch theo tin tức trên thị trường Forex.</li><li>Cách một FX Trader chuyên nghiệp sử dụng phân tích kỹ thuật, đặc biệt tác giả có chia sẻ 07 thiết lập giao dịch hiệu quả cao mà bản thân sử dụng.</li><li>Phân tích Liên thị trường - Intermarket Analysis - được sử dụng ra sao trên thị trường Forex.</li><li>Cách quản lý rủi ro, tính toán lượng vị thế giao dịch như thế nào để đạt hiệu quả cao mà không quá nguy hiểm đến tài khoản giao dịch.</li><li>Cách thức thấu hiểu bản thân để trở thành một FX Trader thành công.</li></ul><p>Đặc biệt là<strong>&nbsp;</strong><strong style="color: rgb(211, 84, 0);"><em>25 quy tắc giao dịch cá nhân</em></strong>&nbsp;đã giúp Brent Donnelly tồn tại gần 30 năm trong ngành cũng được ông chia sẻ trong sách.</p><p>Tham khảo chi tiết tại:&nbsp;<a href="https://finfin.vn/products/kham-pha-nghe-thuat-giao-dich-tien-te-chuyen-nghiep" rel="noopener noreferrer" target="_blank" style="background-color: transparent; color: rgb(204, 0, 153);">https://finfin.vn/products/kham-pha-nghe-thuat-giao-dich-tien-te-chuyen-nghiep</a></p><p>&nbsp;</p><p><strong style="color: rgb(0, 153, 204);">Đánh Bại Thị Trường Forex</strong></p><p>Từng làm việc trên cả thị trường liên ngân hàng (interbank) lẫn thị trường nhỏ lẻ (retail sector), tác giả Agustin Silvani đề cập nhiều vấn đề tổng quát và quan trọng như:</p><ul><li>Cấu trúc vận hành thị trường forex.</li><li>Nhận diện và đối phó các chiêu trò của dealer, hiểu nôm na là môi giới kiêm lái giá.</li><li>Những kinh nghiệm giúp trở thành trader Top 10%.</li><li>Các mẹo hay để giao dịch tốt hơn.</li><li>Kỹ thuật giao dịch chống lại hành vi thao túng giá.</li><li>Tham khảo chi tiết tại:&nbsp;<a href="https://finfin.vn/products/danh-bai-thi-truong-forex" rel="noopener noreferrer" target="_blank" style="background-color: transparent; color: rgb(204, 0, 153);">https://finfin.vn/products/danh-bai-thi-truong-forex</a></li></ul><p>&nbsp;</p><p><strong style="color: rgb(0, 153, 204);">Thực hành Phân tích Fibonacci</strong></p><p>Một quyển sách không thể&nbsp;bỏ qua được viết bởi bà&nbsp;Constance Brown - một tác giả giỏi&nbsp;thật sự ở mặt thực chiến lẫn học thuật.&nbsp;</p><ul><li>Sách nằm trong Top các quyển sách hay nhất về chủ đề Fibonacci trên Amazon.</li><li>Sách đã đoạt Huy chương vàng trong hạng mục Axiom Business Book Awards năm 2009.</li><li>Sách được Bloomberg Press thuộc hãng tin Bloomberg xuất bản và chọn vào chuỗi sách Bloomberg Market Essentials: Technical Analysis (tạm dịch Các yếu tố cần thiết cho thị trường của Bloomberg: Phân tích Kỹ thuật).</li></ul><p>Tựa sách cung cấp cho độc giả những kiến thức mà chúng ta có thể áp dụng ngay lập tức bao gồm:</p><ul><li>GIỚI THIỆU cách dùng tỷ lệ Fibonacci để dự báo mục tiêu giá.</li><li>CUNG CẤP các ví dụ chi tiết và các bối cảnh thực, trên thị trường thực.&nbsp;</li><li>GIẢI THÍCH về tầm quan trọng của tỉ lệ thức khi phân tích biểu đồ.</li><li>CẢNH BÁO các nhà giao dịch về những lỗi lầm thường gặp.</li><li>MÔ TẢ cách xác định những tín hiệu sai.</li></ul><p><br></p><p>Kỹ thuật giao dịch được đề cập trong sách là sự kết hợp giữa phân tích hành vi giá - price action - trong tổng thể phối hợp với các tỷ lệ Fibonacci nhằm giúp trader đưa ra kế hoạch giao dịch hiệu quả, rủi ro thấp.</p><p><br></p><p>Tham khảo chi tiết tại:&nbsp;&nbsp;<a href="https://finfin.vn/products/danh-bai-thi-truong-forex" rel="noopener noreferrer" target="_blank" style="background-color: transparent; color: rgb(204, 0, 153);">https://finfin.vn/products/thuc-hanh-phan-tich-fibonacci</a></p>',
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
              @click="(checkHandleEdit = true), (showModal = true), (checkHandleView = false)"
              src="/icon/edit.png"
              alt="edit"
              style="margin: 0px 4px; padding: 6px 8px; height: 20px; cursor: pointer"
            />
            <img
              @click="(checkHandleView = true), (checkHandleEdit = false), (showModal = true)"
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
        <ModalViewContentBook v-if="checkHandleView" :bookData="bookData"> </ModalViewContentBook>
        <ModalEditContentBook v-else-if="checkHandleEdit" :bookData="bookData">
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
