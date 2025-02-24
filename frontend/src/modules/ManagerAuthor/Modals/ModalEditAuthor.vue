<script setup lang="ts">
import { defineProps } from 'vue'
import type { IAuthor } from '@/common/interface'
import { useListAuthorStore } from '@/stores/listStores/listAuthor'
import {
  handleLoading,
  handleLoadingNotication,
  handleLoadingNoticationError
} from '@/common/functions/loading'
import axiosInstance from '@/services/axiosService'
import { removeMatchingFields } from '@/common/functions/removeMatchingFields'
const props = defineProps({
  objAuthor: {
    type: Object as () => any,
    required: true
  }
})
const store = useListAuthorStore()
</script>
<template>
  <div class="modal_content_right">
    <Vueform
      :endpoint="
        async (FormData, form$) => {
          handleLoading(600)
          try {
            const resultFill = {
              ...removeMatchingFields(form$.data, props.objAuthor),
              updatedAt: new Date().toLocaleString()
            }
            if (resultFill.bio == '') {
              resultFill.bio = null
            }
            const dataSendServer: any = {
              id: props.objAuthor.author_id,
              FieldsToUpdate: { ...resultFill, updatedAt: new Date() }
            }
            console.log('data send server: ',dataSendServer)
            const result = await axiosInstance.patch('/api/Author', dataSendServer)
            console.log('result: ', result.data)
            if (result.data.isSuccess) {
              handleLoadingNotication('cập nhật thành công', 600, 'top-center')
              store.editAuthor(resultFill, props.objAuthor.author_id)
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
        name="author_id"
        :rules="['required']"
        label="mã tác giả"
        :default="objAuthor.author_id"
        :submit="false"
        disabled
      />
      <TextElement
        name="name"
        label="Tên"
        :columns="{
          container: 12
        }"
        :rules="['required']"
        :messages="{
          required: 'Không được bỏ trống tên tác giả'
        }"
        :default="objAuthor.name"
      />
      <TextElement
        name="bio"
        label="Giới thiệu"
        :columns="{
          container: 12
        }"
        :default="objAuthor.bio ? objAuthor.bio : ''"
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
