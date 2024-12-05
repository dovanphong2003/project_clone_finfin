<script setup lang="ts">
import { defineProps } from 'vue'
import type { IPublisher } from '@/common/interface'
import { useListPublisherStore } from '@/stores/listStores/listPublisher'
import {
  handleLoading,
  handleLoadingNotication,
  handleLoadingNoticationError
} from '@/common/functions/loading'
import axiosInstance from '@/services/axiosService'
import { removeMatchingFields } from '@/common/functions/removeMatchingFields'
const props = defineProps({
  objPublisher: {
    type: Object as () => any,
    required: true
  }
})
const store = useListPublisherStore()
</script>
<template>
  <div class="modal_content_right">
    <Vueform
      :endpoint="
        async (FormData, form$) => {
          handleLoading(600)
          try {
            const resultFill = {
              ...removeMatchingFields(form$.data, props.objPublisher),
              updatedAt: new Date().toLocaleString()
            }
            if (resultFill.contact_number == '') {
              resultFill.contact_number = null
            }
            if (resultFill.address == '') {
              resultFill.address = null
            }
            if (resultFill.website == '') {
              resultFill.website = null
            }
            const dataSendServer: any = {
              id: props.objPublisher.publisher_id,
              FieldsToUpdate: { ...resultFill, updatedAt: new Date() }
            }

            const result = await axiosInstance.patch('/api/Publisher', dataSendServer)
            console.log('result: ', result.data)
            if (result.data.isSuccess) {
              handleLoadingNotication('cập nhật thành công', 600, 'top-center')
              store.editPublisher(resultFill, props.objPublisher.publisher_id)
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
        name="publisher_id"
        :rules="['required']"
        label="mã nhà xuất bản"
        :default="objPublisher.publisher_id"
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
        :default="objPublisher.name"
      />
      <TextElement
        name="email"
        input-type="email"
        :rules="['required', 'email', 'max:100']"
        :messages="{
          required: 'Không được bỏ trống tên nhà xuất bản',
          email: 'Nhập đúng định dạng Email',
          max: 'Email không được vượt quá 100 kí tự'
        }"
        label="Email"
        :default="objPublisher.email"
      />
      <TextElement
        name="contact_number"
        label="Số điện thoại"
        :columns="{
          container: 6
        }"
        :rules="['max:20']"
        :messages="{
          max: 'Số điện thoại không được vượt quá 20 kí tự'
        }"
        :default="objPublisher.contact_number"
      />
      <TextElement
        name="address"
        label="Địa chỉ"
        :columns="{
          container: 6
        }"
        :rules="['max:200']"
        :messages="{
          max: 'Địa chỉ không được vượt quá 200 kí tự'
        }"
        :default="objPublisher.address"
      />
      <TextElement
        name="website"
        label="website"
        :columns="{
          container: 12
        }"
        :rules="['max:200']"
        :messages="{
          max: 'url Website không được vượt quá 500 kí tự'
        }"
        :default="objPublisher.website"
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
