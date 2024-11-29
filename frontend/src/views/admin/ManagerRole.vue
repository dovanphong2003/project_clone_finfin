<script lang="ts" setup>
import type { ClickRowArgument, Header } from 'vue3-easy-data-table'
import { useListRoleStore } from '@/stores/listStores/listRole'
import { handleLoadingNotication } from '@/common/functions/loading'
import { Ref, ref } from 'vue'
import type { IRole } from '@/common/interface'
import CreateRole from '@/modules/ManagerRole/CreateRole.vue'
import CptModalCenter from '@/common/components/CptModalCenter.vue'
import ModalEditRole from '@/modules/ManagerRole/Modals/ModalEditRole.vue'

// header for table
const headers: Header[] = [
  { text: 'Hành động', value: 'handle', width: 130 },
  { text: 'Vai trò', value: 'nameRole', sortable: true, width: 130 },
  { text: 'Ngày tạo', value: 'createdAt', width: 200 },
  { text: 'Cập nhật mới', value: 'updatedAt', width: 200 },
  { text: 'Trạng thái', value: 'status', width: 100 }
]

// store role
const storeRole = useListRoleStore()
// search
const searchField = ref('')
const searchValue = ref('')

const checkDelete: Ref<boolean> = ref(false)
// modal edit
const showModal = ref(false)

// handle set show = false;
const handleShowFalse = () => {
  showModal.value = false
}
const loading = ref(true)
setTimeout(() => {
  loading.value = false
}, 1000)

const RoleData = ref<IRole>({
  nameRole: '',
  status: false,
  description: '',
  objPermission: [],
  createdAt: '',
  updatedAt: ''
})
// onclickRow
const checkChangeData: Ref<boolean> = ref(false)
const handleSetCheckChangeDataFalse = () => {
  checkChangeData.value = false
}
const showRow = (val: ClickRowArgument) => {
  if (checkDelete.value) {
    handleLoadingNotication('Xóa thành công', 500, 'bottom-center')
    storeRole.deleteRole(val.nameRole)
    checkDelete.value = false
  } else {
    RoleData.value = val as any
    checkChangeData.value = true
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
        <CreateRole />
      </div>
      <EasyDataTable
        table-class-name="customize-table"
        theme-color="#042dc2"
        :headers="headers"
        :items="storeRole.allRole"
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

        <!--template for name, example name User,...-->
        <template #item-nameRole="{ nameRole }">
          <p
            style="
              display: -webkit-box;
              -webkit-box-orient: vertical;
              -webkit-line-clamp: 2;
              overflow: hidden;
              text-overflow: ellipsis;
              font-weight: 700;
              font-size: 13px;
            "
          >
            {{ nameRole }}
          </p>
        </template>

        <!--template for handle ( edit, delete )-->
        <template #item-handle>
          <div class="handle" style="width: 100%; text-align: center">
            <img
              @click="showModal = true"
              src="/icon/edit.png"
              alt="edit"
              style="margin: 0px 4px; padding: 6px 8px; height: 20px; cursor: pointer"
            />
            <img
              @click="checkDelete = true"
              src="/icon/delete.png"
              alt="delete"
              style="margin: 0px 4px; padding: 6px 8px; height: 20px; cursor: pointer"
            />
          </div>
        </template>

        <!--template for status ( active, disable )-->
        <template #item-status="{ status }">
          <div class="status">
            <div :class="[status ? 'active' : 'error']" style="padding: 4px 20px">
              {{ status ? 'Active' : 'Disable' }}
            </div>
          </div>
        </template>
      </EasyDataTable>
    </div>
  </div>
  <CptModalCenter
    :handleSetCheckChangeDataFalse="handleSetCheckChangeDataFalse"
    title="Chỉnh sửa Role"
    :show="showModal"
    :handleShowFalse="handleShowFalse"
  >
    <ModalEditRole v-if="checkChangeData && RoleData.nameRole" :objData="RoleData"> </ModalEditRole>
  </CptModalCenter>
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
