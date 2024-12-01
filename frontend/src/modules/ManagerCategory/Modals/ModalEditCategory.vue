<script setup lang="ts">
import { defineProps } from 'vue'
import type { ICategory } from '@/common/interface'
import { useListCategoryStore } from '@/stores/listStores/listCategory'
import { handleLoading, handleLoadingNotication } from '@/common/functions/loading'

const props = defineProps({
  objCategory: {
    type: Object as () => ICategory,
    required: true
  }
})

const store = useListCategoryStore()

const formatFormData = ({ is_active, parent_id }) => {
  handleLoading(600)
  const dataEdit: ICategory = {
    category_id: props.objCategory.category_id,
    name: props.objCategory.name,
    parent_id: Number(parent_id) ? parent_id : null,
    is_active: is_active,
    is_delete: 0,
    createdAt: props.objCategory.createdAt,
    updatedAt: new Date()
  }
  store.editCategory(dataEdit)
  return {
    // return obj use send to server
  }
}
</script>
<template>
  <div class="modal_content_right">
    <Vueform endpoint="/form/submit" method="post" :format-data="formatFormData">
      <StaticElement name="divider" tag="hr" />
      <TextElement
        name="Category_code"
        :rules="['required']"
        label="mã chủ đề"
        :default="objCategory.category_id"
        :submit="false"
        disabled
      />
      <ToggleElement
        name="is_active"
        :columns="{
          container: 6
        }"
        align="left"
        label="Trạng Thái"
        :labels="{
          on: 'ON',
          off: 'OFF'
        }"
        :default="objCategory.is_active ? true : false"
      />
      <TextElement
        name="name"
        label="Tên"
        :columns="{
          container: 12
        }"
        :rules="['required']"
        :messages="{
          required: 'Không được bỏ trống tên chủ đề'
        }"
        :default="objCategory.name"
      />
      <TextElement
        name="parent_id"
        label="Parent_id"
        :columns="{
          container: 12
        }"
        :default="objCategory.parent_id ? objCategory.parent_id : ''"
      />
      <ButtonElement
        name="submit"
        button-label="Submit"
        :submits="true"
        :columns="{
          container: 6
        }"
      />
      <ButtonElement
        name="reset"
        button-label="Reset"
        :secondary="true"
        :resets="true"
        :columns="{
          container: 6
        }"
      />
    </Vueform>
  </div>
</template>
<style lang="scss" scoped></style>
