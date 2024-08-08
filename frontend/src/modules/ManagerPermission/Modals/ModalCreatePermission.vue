<script setup lang="ts">
import type { IPermission } from '@/common/interface'
import { useListPermissionStore } from '@/stores/listStores/listPermission'
import { handleLoading, handleLoadingNotication } from '@/common/functions/loading'
const store = useListPermissionStore()

const formatFormData = ({ name, api, method, module }) => {
  handleLoadingNotication('Tạo thành công', 600, 'top-right')

  // data use update for frontend, if data send to server --> add password.
  const dataCreatePermission: IPermission = {
    name,
    api,
    method,
    module,
    createdAt: '2022-02-26T17:08:14.008Z',
    updatedAt: '2024-06-26T17:08:14.008Z'
  }
  store.addPermission(dataCreatePermission)
  return {
    // return obj use send to server
  }
}

// data fake for module
const ALL_MODULES = {
  AUTH: 'AUTH',
  COMPANIES: 'COMPANIES',
  FILES: 'FILES',
  JOBS: 'JOBS',
  PERMISSIONS: 'PERMISSIONS',
  RESUMES: 'RESUMES',
  ROLES: 'ROLES',
  USERS: 'USERS',
  SUBSCRIBERS: 'SUBSCRIBERS'
}
const items = Object.keys(ALL_MODULES).map((key) => ({
  label: key,
  value: ALL_MODULES[key]
}))
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
        label="Tên quyền hạn"
        :columns="{
          container: 6
        }"
        placeholder="Nhập tên..."
      />
      <TextElement
        name="api"
        label="API"
        :rules="['required', 'max:255']"
        :messages="{
          required: 'Không được bỏ trống api',
          max: 'Email không được vượt quá 255 ký tự'
        }"
        :columns="{
          container: 6
        }"
        placeholder="Nhập api..."
      />
      <SelectElement
        name="method"
        label="Phương Thức"
        :items="[
          {
            value: 'GET',
            label: 'GET'
          },
          {
            value: 'POST',
            label: 'POST'
          },
          {
            value: 'PATCH',
            label: 'PATCH'
          },
          {
            value: 'DELETE',
            label: 'DELETE'
          }
        ]"
        :rules="['required']"
        :messages="{
          required: 'Không được bỏ trống phương thức'
        }"
        :columns="{
          container: 6
        }"
        placeholder="Chọn phương thức..."
      />
      <SelectElement
        name="module"
        :columns="{
          container: 6
        }"
        :rules="['required']"
        :messages="{
          required: 'Không được bỏ trống module'
        }"
        label="Module"
        :items="items"
        placeholder="Chọn module"
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
  width: 800px;
  margin-bottom: 40px;
}
</style>
