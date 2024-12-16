<script setup lang="ts">
import { defineProps } from 'vue'
import type { IPermission } from '@/common/interface'
import { useListPermissionStore } from '@/stores/listStores/listPermission'
import { handleLoading, handleLoadingNotication, handleLoadingNoticationError } from '@/common/functions/loading'
import { MODULES } from '@/common/shareVariable';
import axiosInstance from '@/services/axiosService';
import { removeMatchingFields } from '@/common/functions/removeMatchingFields';

const props = defineProps({
  objPermission: {
    type: Object as () => IPermission,
    required: true
  }
})
const items = Object.keys(MODULES).map((key) => {
  return ({
  label: key,
  value: MODULES[key]
})})

const store = useListPermissionStore()

const formatFormData = async ({ name, path, method, module,description }) => {
  if(path === props.objPermission.path && 
  name === props.objPermission.name && 
  method === props.objPermission.method && 
  module === props.objPermission.module && 
  description === props.objPermission.description  ) 
  {
    handleLoadingNoticationError('Không có sự thay đổi nào cả!', 600, 'top-center')
    return;
  }
  const resultFill = {
    ...removeMatchingFields({name,
      path,
      method: method,
      module: module,
      description: description}, props.objPermission),
    }
    const dataSendServer: any = {
      id:props.objPermission.permission_id,
              FieldsToUpdate: { ...resultFill,
      updatedAt: new Date(),
      updatedBy:12353453, }
            }
  try {
    const result = await axiosInstance.patch('/api/Permission', dataSendServer)
    if (result.data.isSuccess) {
      store.editPermission({
        permission_id:props.objPermission.permission_id,
     ...resultFill,
      updatedAt: new Date(),
      updatedBy:12353453,
      } as any, props.objPermission.permission_id)
      handleLoadingNotication('Cập nhật thành công', 600, 'top-right')
    } else {
      handleLoadingNoticationError('Cập nhật không thành công!', 600, 'top-center')
    }
  } catch (error) {
    handleLoadingNoticationError('Có lỗi đã xảy ra:' + error, 600, 'top-right')
  }
  
}
</script>
<template>
  <div class="modal_content_right">
    <Vueform :endpoint="false"  :format-data="formatFormData">
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
        name="path"
        :columns="{
          container: 6
        }"
        label="api"
        :rules="['required']"
        :messages="{
          required: 'Không được bỏ trống api'
        }"
        :default="objPermission.path"
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
      <TextElement
        name="description"
        :columns="{
          container: 12
        }"
        label="Mô tả"
        :rules="['max:100']"
        :messages="{
          max: 'Mô tả không được vượt quá 100 ký tự',
        }"
        :default="objPermission.description"
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
