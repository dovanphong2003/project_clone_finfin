<script setup lang="ts">
import type { ICategory } from '@/common/interface'
import { useListCategoryStore } from '@/stores/listStores/listCategory'
import { handleLoading, handleLoadingNotication } from '@/common/functions/loading'
import { createdIdAuto } from '@/common/functions/createIdAuto'
const store = useListCategoryStore()

const formatFormData = ({ is_active, name, parent_id }) => {
  handleLoadingNotication('Tạo thành công', 600, 'top-right')

  // data use update for frontend, if data send to server --> add password.
  const dataCreateCategory: ICategory = {
    category_id: createdIdAuto(),
    name: name,
    parent_id: Number(parent_id) ? parent_id : null,
    is_active: is_active,
    is_delete: 0,
    createdAt: new Date(),
    updatedAt: new Date()
  }
  console.log('data: ', dataCreateCategory)
  store.addCategory(dataCreateCategory)
  return {
    // return obj use send to server
  }
}
</script>
<template>
  <div class="content_modal">
    <Vueform :format-data="formatFormData">
      <StaticElement name="divider" tag="hr" />
      <TextElement
        name="name"
        :columns="{
          container: 6
        }"
        :rules="['required', 'max:255']"
        :messages="{
          required: 'Không được bỏ trống tên chủ đề',
          max: 'chủ đề không được vượt quá 255 kí tự'
        }"
        label="Tên chủ đề"
        placeholder="name..."
      />
      <ToggleElement
        name="is_active"
        :columns="{
          container: 4
        }"
        align="left"
        label="Trạng Thái"
        :labels="{
          on: 'ACTIVE',
          off: 'OFF'
        }"
      />
      <TextElement
        name="parent_id"
        label="Parent_id"
        :columns="{
          container: 12
        }"
      />
      <ButtonElement
        name="submit"
        button-label="Tạo Mới"
        :submits="true"
        :columns="{
          container: 6
        }"
      />
      <ButtonElement
        name="reset"
        button-label="Đặt Lại"
        :secondary="true"
        :resets="true"
        :columns="{
          container: 6
        }"
      />
    </Vueform>
  </div>
</template>
<style lang="scss" scoped>
.content_modal {
  width: 800px;
  padding-bottom: 60px;
  margin-bottom: 40px;
}
</style>
