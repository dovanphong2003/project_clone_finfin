<script setup lang="ts">
import { defineProps } from 'vue'
import type { IPermission } from '@/common/interface'
import { useListPermissionStore } from '@/stores/listStores/listPermission'
import { handleLoading, handleLoadingNotication } from '@/common/functions/loading'

const props = defineProps({
  objPermission: {
    type: Object as () => IPermission,
    required: true
  }
})

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

const store = useListPermissionStore()

const formatFormData = ({ name, api, method, module }) => {
  handleLoading(600)
  const dataEdit: IPermission = {
    name: name,
    api: api,
    method: method,
    module: module,
    createdAt: '2022-02-26T17:08:14.008Z',
    updatedAt: '2024-06-26T17:08:14.008Z'
  }
  const nameOrigin = props.objPermission.name
  console.log('name origin: ', nameOrigin)
  store.editPermission(dataEdit, nameOrigin)
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
        :default="objPermission.name"
      />
      <TextElement
        name="api"
        :columns="{
          container: 6
        }"
        label="API"
        :rules="['required']"
        :messages="{
          required: 'Không được bỏ trống api'
        }"
        :default="objPermission.api"
      />
      <SelectElement
        name="method"
        :columns="{
          container: 6
        }"
        label="Phương Thức"
        :rules="['required']"
        :messages="{
          required: 'Không được bỏ trống phương thức'
        }"
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
        :default="objPermission.method"
      />
      <SelectElement
        name="module"
        label="Modules"
        :items="items"
        :default="objPermission.module"
        :rules="['required']"
        :messages="{
          required: 'Không được bỏ trống module'
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
