<script lang="ts" setup>
import type { ClickRowArgument, Header } from 'vue3-easy-data-table'
import { useListUserStore } from '@/stores/listStores/listUser'
// cpt modal right
import ModalEditUser from '@/modules/ManagerUser/Modals/ModalEditUser.vue'
import { handleLoadingNotication, handleLoadingNoticationError } from '@/common/functions/loading'
import CreateUser from '@/modules/ManagerUser/CreateUser.vue'
import { Ref, ref } from 'vue'
import type { IUser } from '@/common/interface'
import CptModalRight from '@/common/components/CptModalRight.vue'
import axiosInstance from '@/services/axiosService'
const headers: Header[] = [
  { text: 'Hành động', value: 'handle', width: 130 },
  { text: 'ID', value: 'user_id', width: 100 },
  { text: 'Tên', value: 'name', sortable: true, width: 130 },
  { text: 'Email', value: 'email', width: 100 },
  { text: 'Tuổi', value: 'age' },
  { text: 'Giới tính', value: 'gender', width: 100 },
  { text: 'Vai trò', value: 'role_id', width: 150 },
  { text: 'Địa chỉ', value: 'address', width: 200 },
  { text: 'Ngày tạo', value: 'createdAt', width: 200 },
  { text: 'Người tạo', value: 'createdBy', width: 200 },
  { text: 'Ngày cập nhật', value: 'updatedAt', width: 200 },
  { text: 'Cập nhật bởi', value: 'updatedBy', width: 200 }
]
// store User
const storeUser = useListUserStore()
// call api get data all User and arr permission of User
const fncGetAllUser = async () => {
  try {
    const result = await axiosInstance.get('/api/User/extendedRole')
    storeUser.items = result.data.data
    console.log('result: ', result)
  } catch (error) {
    console.log('error: ', error)
    storeUser.items = []
  }
}
fncGetAllUser()
// search
const searchField = ref('')
const searchValue = ref('')

// set value IUser empty
const dataEmpty:IUser = {
user_id:0,
name:'',
email:'',
password:'',
age:0,
gender:undefined,
address:undefined,
role_id:0,
role_name:'',
refreshToken:'',
createdAt:new Date(),
updatedAt:new Date(),
isDeleted:false,
createdBy:0,
updatedBy:0,
deleteBy:0,
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
  UserData.value = dataEmpty
}

// handle deleteUser
const handleDeleteUser = () => {
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

// onclick
const UserData = ref<IUser>(dataEmpty)
const showRow = async (val: ClickRowArgument) => {
  if (checkDelete.value) {
    const result = await axiosInstance.delete('/api/User', {
      params: { id: val.user_id }
    })
    if (result.data.isSuccess) {
      handleLoadingNotication('Xóa thành công', 500, 'top-center')
      storeUser.deleteUser(val.user_id)
    } else {
      handleLoadingNoticationError('có lỗi xảy ra!', 500, 'top-center')
    }
    checkDelete.value = false
  } else {
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
        <CreateUser />
      </div>
      <EasyDataTable
        table-class-name="customize-table"
        theme-color="#042dc2"
        :headers="headers"
        :items="storeUser.items"
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
        <template #item-name="{ name }">
          <p
            style="
              display: -webkit-box;
              -webkit-box-orient: vertical;
              -webkit-line-clamp: 2;
              overflow: hidden;
              text-overflow: ellipsis;
              font-size: 13px;
            "
          >
            {{ name }}
          </p>
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
              @click="handleDeleteUser"
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
        <ModalEditUser
          v-if="activeModalVertical && UserData.name"
          :is="ModalEditUser"
          :objUser="UserData"
        ></ModalEditUser>
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
</style>
