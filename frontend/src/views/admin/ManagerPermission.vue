<script lang="ts" setup>
import type { ClickRowArgument, Header } from 'vue3-easy-data-table'
// cpt modal right
import ModalEditPermission from '@/modules/ManagerPermission/Modals/ModalEditPermission.vue'
import { handleLoadingNotication, handleLoadingNoticationError } from '@/common/functions/loading'
import { ref, type Ref } from 'vue'
import type { IPermission } from '@/common/interface'
import CptModalRight from '@/common/components/CptModalRight.vue'
import { useListPermissionStore } from '@/stores/listStores/listPermission'
import CreatePermission from '@/modules/ManagerPermission/CreatePermission.vue'
import axiosInstance from '@/services/axiosService'
const headers: Header[] = [
  { text: 'Hành động', value: 'handle', width: 130 },
  { text: 'ID', value: 'permission_id', sortable: true, width: 130 },
  { text: 'Tên', value: 'name', sortable: true, width: 130 },
  { text: 'API', value: 'path' },
  { text: 'Phương Thức', value: 'method', width: 100 },
  { text: 'Module', value: 'module', width: 100 },
  { text: 'Mô tả', value: 'description', width: 200 },
  { text: 'Ngày tạo', value: 'createdAt', width: 200 },
  { text: 'Cập nhật mới', value: 'updatedAt', width: 200 },
  { text: 'Người tạo', value: 'createdBy', width: 200 },
  { text: 'Người cập nhật', value: 'updatedBy', width: 200 }
]
const store = useListPermissionStore()
const fncGetAllPermission = async () => {
  try {
    const result = await axiosInstance.get('/api/Permission')
    store.items = result.data.data
    console.log('result: ', result)
  } catch (error) {
    console.log('error: ', error)
    store.items = []
  }
}
fncGetAllPermission()
// search
const searchField = ref('')
const searchValue = ref('')

// modal
const titleModalVertical = 'Chỉnh sửa thông tin'
const activeModalVertical: Ref<boolean> = ref(false)
const disableModalVertical: Ref<boolean> = ref(false)
const checkDelete: Ref<boolean> = ref(false)
const checkEdit: Ref<boolean> = ref(false)

const dataEmpty:IPermission = {
  permission_id: 0,
  name: '',
  path: '',
  method: '',
  module: '',
  description:'',
  createdAt: new Date(),
  updatedAt: undefined,
  isDeleted:false,
  createdBy: 0,
  updatedBy:0,
}
// onclick
const UserData = ref<IPermission>(dataEmpty)
const handleClickCloseModalVertical = async () => {
  activeModalVertical.value = false
  disableModalVertical.value = true
  UserData.value = dataEmpty
}

// handle deletePermission
const handleDeletePermission = () => {
  checkDelete.value = true
}

// handle edit
const handleClickVertical = async () => {
  checkEdit.value = true
  activeModalVertical.value = true
  disableModalVertical.value = false
}

const loading = ref(true)
setTimeout(() => {
  loading.value = false
}, 1000)

const showRow = async (val: ClickRowArgument) => {
  if (checkDelete.value) {
    const result = await axiosInstance.delete('/api/Permission', { params: { id: val.permission_id } })
    if (result.data.isSuccess) {
      handleLoadingNotication('Xóa thành công', 500, 'top-center')
      store.deletePermission(val.permission_id)
    } else {
      handleLoadingNoticationError('có lỗi xảy ra!', 500, 'top-center')
    }
    checkDelete.value = false
  } else {
    delete val.indexInCurrentPage
    UserData.value = val as any
  }
}
</script>
<template>
  <div class="main-manager_User">
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
        <CreatePermission />
      </div>
      <EasyDataTable
        table-class-name="customize-table"
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

        <!--template for name, example name User,...-->
        <template #item-name="{ name }">
          <p
            style="
              display: -webkit-box;
              -webkit-box-orient: vertical;
              -webkit-line-clamp: 2;
              overflow: hidden;
              text-overflow: ellipsis;
              font-weight: 500;
              text-align: left;
            "
          >
            {{ name }}
          </p>
        </template>
        <template #item-api="{ api }">
          <p
            style="
              display: -webkit-box;
              -webkit-box-orient: vertical;
              -webkit-line-clamp: 2;
              overflow: hidden;
              max-width: 500px;
              text-overflow: ellipsis;
              text-align: left;
              font-weight: 500;
            "
          >
            {{ api }}
          </p>
        </template>
        <template #item-method="{ method }">
          <p
            style="font-weight: 800"
            :class="{
              blue: method === 'GET',
              green: method === 'POST',
              black: method === 'PATCH',
              red: method === 'DELETE'
            }"
          >
            {{ method }}
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
              @click="handleDeletePermission"
              src="/icon/delete.png"
              alt="delete"
              style="margin: 0px 4px; padding: 6px 8px; height: 20px; cursor: pointer"
            />
          </div>
        </template>
      </EasyDataTable>
      <CptModalRight
        :title-modal="titleModalVertical"
        :active-modal="activeModalVertical"
        :disable-modal="disableModalVertical"
        @handle-click-close-modal="handleClickCloseModalVertical"
      >
        <ModalEditPermission
          v-if="activeModalVertical && UserData.name"
          :is="ModalEditPermission"
          :objPermission="UserData"
        ></ModalEditPermission>
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
