<script setup lang="ts">
import type { IPermission } from '@/common/interface'
import { useListPermissionStore } from '@/stores/listStores/listPermission'
import { handleLoading, handleLoadingNotication, handleLoadingNoticationError } from '@/common/functions/loading'
import { MODULES } from '@/common/shareVariable';
import { createdIdAuto } from '@/common/functions/createIdAuto';
import axiosInstance from '@/services/axiosService';
import { format } from 'date-fns'
const store = useListPermissionStore()

const formatFormData = async ({ name, path, method, module,description }) => {
  // data to store
  const dataCreatePermission: any = {
    permission_id:createdIdAuto(),
    name,
    path,
    method,
    module,
    description: description == '' ? null : description,
    createdAt: new Date(),
    createdBy: 123858645,
    isDeleted: false,
  }
  console.log('data: ', dataCreatePermission)
  try {
    const result = await axiosInstance.post('/api/Permission', dataCreatePermission)
    if (result.data.isSuccess) {
      store.addPermission({
        ...dataCreatePermission,
        createdAt: format(new Date(), "yyyy-MM-dd'T'HH:mm:ss.SSS"),
        updatedAt: undefined,
        updatedBy: undefined,
        deleteBy: undefined,
      } as any)
      handleLoadingNotication('Tạo thành công', 600, 'top-right')
    } else {
      handleLoadingNoticationError('Tạo không thành công!', 600, 'top-center')
    }
  } catch (error) {
    handleLoadingNoticationError('Có lỗi đã xảy ra:' + error, 600, 'top-right')
  }
}


const items = Object.keys(MODULES).map((key) => ({
  label: key,
  value: MODULES[key]
}))
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
        label="Tên quyền hạn"
        :columns="{
          container: 6
        }"
        placeholder="Nhập tên..."
      />
      <TextElement
        name="path"
        label="API"
        :rules="['required', 'max:255']"
        :messages="{
          required: 'Không được bỏ trống api',
          max: 'api không được vượt quá 255 ký tự'
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
      <TextElement
        name="description"
        label="Mô tả"
        :rules="['max:255']"
        :messages="{
          max: 'Mô tả không được vượt quá 100 ký tự'
        }"
        :columns="{
          container: 12
        }"
        placeholder="Nhập mô tả..."
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
