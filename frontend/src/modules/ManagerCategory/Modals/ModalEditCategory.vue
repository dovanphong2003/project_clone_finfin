<script setup lang="ts">
import { defineProps } from 'vue'
import type { ICategory } from '@/common/interface'
import { useListCategoryStore } from '@/stores/listStores/listCategory'
import {
  handleLoading,
  handleLoadingNotication,
  handleLoadingNoticationError
} from '@/common/functions/loading'
import axiosInstance from '@/services/axiosService'
import { removeMatchingFields } from '@/common/functions/removeMatchingFields'
const props = defineProps({
  objCategory: {
    type: Object as () => ICategory,
    required: true
  }
})
const store = useListCategoryStore()
</script>
<template>
  <div class="modal_content_right">
    <Vueform
      :endpoint="
        async (FormData, form$) => {
          handleLoading(600)
          try {
            const resultFill = {
              ...removeMatchingFields(form$.data, props.objCategory),
              updatedAt: new Date().toLocaleString()
            }
            if (resultFill.parent_id == '') {
              resultFill.parent_id = null
            } else if (typeof Number(resultFill.paremt_id) !== 'number') {
              handleLoadingNoticationError('đã xảy ra lỗi!', 500, 'top-center')
              return
            }
            if ('is_active' in resultFill) {
              if (resultFill.is_active === false) {
                resultFill.is_active = 'false'
              } else if (resultFill.is_active === true) {
                resultFill.is_active = 'true'
              }
            }
            const dataSendServer: any = {
              id: props.objCategory.category_id,
              FieldsToUpdate: { ...resultFill, updatedAt: new Date() }
            }
            const result = await axiosInstance.patch('/api/Category', dataSendServer)
            console.log('result: ', result.data)
            if (result.data.isSuccess) {
              handleLoadingNotication('cập nhật thành công', 600, 'top-center')
              store.editCategory(resultFill, props.objCategory.category_id)
            } else {
              handleLoadingNoticationError('đã xảy ra lỗi!', 500, 'top-center')
            }
          } catch (error) {
            handleLoadingNoticationError('đã xảy ra lỗi!: ' + error, 500, 'top-center')
          }
        }
      "
    >
      <StaticElement name="divider" tag="hr" />
      <TextElement
        name="category_id"
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
