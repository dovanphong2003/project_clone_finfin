<script setup lang="ts">
import { defineProps } from 'vue'
import type { IUser } from '@/common/interface'
import { useListUserStore } from '@/stores/listStores/listUser'
import { handleLoading, handleLoadingNotication } from '@/common/functions/loading'

const props = defineProps({
  objUser: {
    type: Object as () => IUser,
    required: true
  }
})

const store = useListUserStore()

const formatFormData = ({ name, age, selectGender, role, address }) => {
  handleLoading(600)
  const dataEdit: IUser = {
    name: name,
    email: props.objUser.email,
    age: age,
    gender: selectGender,
    address: address,
    role: role,
    createdAt: '2022-02-26T17:08:14.008Z',
    updatedAt: '2024-06-26T17:08:14.008Z'
  }
  store.editUser(dataEdit)
  return {
    // return obj use send to server
  }
}
</script>
<template>
  <div class="modal_content_right">
    <Vueform endpoint="/form/submit" method="post" :format-data="formatFormData">
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
        :default="objUser.name"
      />
      <TextElement
        name="age"
        :columns="{
          container: 6
        }"
        label="Tuổi"
        :rules="['nullable']"
        :default="objUser.age"
      />
      <SelectElement
        name="selectGender"
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
        :default="objUser.gender"
      />
      <TextElement
        name="address"
        label="Địa chỉ"
        :rules="['nullable']"
        :default="objUser.address"
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
        :default="objUser.role"
        :rules="['required']"
        :messages="{
          required: 'Không được bỏ trống vai trò'
        }"
      />
      <StaticElement name="divider_4" tag="hr" />
      <ButtonElement
        name="submit"
        :submits="true"
        :columns="{
          container: 4
        }"
        button-label="Cập nhật"
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
<style lang="scss" scoped></style>
