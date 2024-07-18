<script setup lang="ts">
import { defineProps } from 'vue'
import type { CreateUserDTO } from '@/common/DTO/user.DTO'
import type { IUser } from '@/common/interface'
import { useListUserStore } from '@/stores/listStores/listUser'
import { handleLoading, handleLoadingNotication } from '@/common/functions/loading'
const store = useListUserStore()

const formatFormData = ({ name, password, email, age, gender, role, address }) => {
  handleLoadingNotication('Tạo thành công', 600, 'top-right')

  // data use update for frontend, if data send to server --> add password.
  const dataCreateUser: IUser = {
    name,
    email,
    age,
    gender,
    role,
    address,
    createdAt: '2022-02-26T17:08:14.008Z',
    updatedAt: '2024-06-26T17:08:14.008Z'
  }
  console.log('data: ', dataCreateUser)
  store.addUser(dataCreateUser)
  return {
    // return obj use send to server
  }
}
</script>
<template>
  <div class="content_modal">
    <Vueform
      add-class="vf-edit-profile"
      endpoint="/form/submit"
      method="post"
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
        name="role"
        label="Vai trò"
        :items="[
          {
            value: 'admin',
            label: 'admin'
          },
          {
            value: 'customer',
            label: 'customer'
          }
        ]"
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
