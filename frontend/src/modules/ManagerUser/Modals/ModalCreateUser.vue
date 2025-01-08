<script setup lang="ts">
import { defineProps, onBeforeMount, ref } from 'vue'
import type { CreateUserDTO } from '@/common/DTO/user.DTO'
import type { IUser } from '@/common/interface'
import { useListUserStore } from '@/stores/listStores/listUser'
import { handleLoading, handleLoadingNotication, handleLoadingNoticationError } from '@/common/functions/loading'
import axiosInstance from '@/services/axiosService'
import { add } from 'lodash'
import { format } from 'date-fns'
import { createdIdAuto } from '@/common/functions/createIdAuto'
const store = useListUserStore()

// call api get select role
const dataSelect = ref([])
const fncGetAllRole = async () => {
  try {
    const result = await axiosInstance.get('/api/Role')
    dataSelect.value = result.data.data.map((items) => {
      return {value:items.role_id,label:items.name}
    })
  } catch (error) {
    console.log('error: ', error)
  }
}
onBeforeMount(() => {
  fncGetAllRole();
});
const formatFormData = async ({ name, password, email, age, gender, role_id, address }) => {
  // data use update for frontend, if data send to server --> add password.
  const dataCreateUser = {
    user_id:createdIdAuto(),
    name,
    password,
    email,
    age,
    gender: gender == '' ? null : gender,
    role_id:role_id,
    address: address == '' ? null : address,
    createdAt: new Date(),
    createdBy:6,
  }
  try {
    const result = await axiosInstance.post('/api/User', dataCreateUser)
    if (result.data.isSuccess) {
      store.addUser({
        ...dataCreateUser,
        createdAt: format(new Date(), "yyyy-MM-dd'T'HH:mm:ss.SSS"),
        updatedAt: undefined,
        updatedBy: undefined,
        deleteBy: undefined,
      } as any)
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
}
</script>
<template>
  <div class="content_modal">
    <Vueform
      add-class="vf-edit-profile"
      :endpoint="false"
      :format-data="formatFormData"
    >
      <StaticElement name="divider_1" tag="hr" />
      <TextElement
        name="name"
        :rules="['required', 'max:255', 'string']"
        :messages="{
          required: 'Không được bỏ trống tên',
          max: 'Tên không được vượt quá 255 ký tự',
          string: 'Tên phải là chuỗi ký tự'
        }"
        label="Tên"
        :columns="{
          container: 6
        }"
        placeholder="Nhập tên..."
      />
      <TextElement
        name="password"
        label="Mật khẩu"
        :rules="['required', 'max:100']"
        :messages="{
          required: 'Không được bỏ trống mật khẩu',
          max: 'Mật khẩu được vượt quá 100 ký tự'
        }"
        input-type="password"
        :columns="{
          container: 6
        }"
        placeholder="Nhập mật khẩu..."
      />
      <TextElement
        name="email"
        input-type="email"
        label="Email"
        :rules="['required', 'max:255', 'email']"
        :messages="{
          required: 'Không được bỏ trống Email',
          max: 'Email không được vượt quá 255 ký tự',
          email: 'Email không đúng định dạng'
        }"
        :columns="{
          container: 6
        }"
        placeholder="Nhập email..."
      />
      <SelectElement
        name="role_id"
        label="Vai trò"
        :items="dataSelect"
        :rules="['required']"
        :messages="{
          required: 'Không được bỏ trống vai trò'
        }"
        :columns="{
          container: 6
        }"
        placeholder="Chọn vai trò..."
      />
      <TextElement
        name="age"
        :columns="{
          container: 6
        }"
        label="Tuổi"
        :rules="['nullable']"
        placeholder="Nhập tuổi..."
      />
      <SelectElement
        name="gender"
        :columns="{
          container: 6
        }"
        label="Giới tính"
        :rules="['nullable']"
        :items="[
          {
            value: 'Nam',
            label: 'Nam'
          },
          {
            value: 'Nữ',
            label: 'Nữ'
          },
          {
            value: 'Khác',
            label: 'Khác'
          }
        ]"
        placeholder="Chọn giới tính..."
      />
      <TextElement
        name="address"
        label="Địa chỉ"
        :rules="['nullable']"
        placeholder="Nhập địa chỉ..."
      />
      <ButtonElement
        name="submit"
        :submits="true"
        :columns="{
          container: 3
        }"
        button-label="Tạo mới"
      />
      <ButtonElement
        name="reset"
        :secondary="true"
        :resets="true"
        :columns="{
          container: 4
        }"
        align="left"
        button-label="Đặt lại"
      />
    </Vueform>
  </div>
</template>
<style lang="scss" scoped>
.content_modal {
  width: 1000px;
}
</style>
