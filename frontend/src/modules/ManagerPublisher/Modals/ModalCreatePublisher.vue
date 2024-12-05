<script setup lang="ts">
import { format } from 'date-fns'
import { useListPublisherStore } from '@/stores/listStores/listPublisher'
import {
  handleLoadingNotication,
  handleLoadingNoticationError,
  handleLoading
} from '@/common/functions/loading'
import { createdIdAuto } from '@/common/functions/createIdAuto'
import axiosInstance from '@/services/axiosService'
const store = useListPublisherStore()
const formatFormData = async ({ name, address, email, contact_number, website }) => {
  handleLoading(600)
  const dataCreatePublisher = {
    publisher_id: createdIdAuto(),
    name: name,
    address: address === '' ? null : address,
    email: email,
    contact_number: contact_number === '' ? null : contact_number,
    website: website === '' ? null : website,
    isDeleted: false,
    createdAt: new Date(),
    updatedAt: new Date()
  }
  console.log('data: ', dataCreatePublisher)
  try {
    const result = await axiosInstance.post('/api/Publisher', dataCreatePublisher)
    if (result.data.isSuccess) {
      store.addPublisher({
        ...dataCreatePublisher,
        createdAt: format(new Date(), "yyyy-MM-dd'T'HH:mm:ss.SSS"),
        updatedAt: format(new Date(), "yyyy-MM-dd'T'HH:mm:ss.SSS")
      } as any)
      handleLoadingNotication('Tạo thành công', 600, 'top-right')
    } else {
      handleLoadingNoticationError('Tạo không thành công!', 600, 'top-center')
    }
  } catch (error) {
    handleLoadingNoticationError('Có lỗi đã xảy ra:' + error, 600, 'top-right')
  }
}
</script>
<template>
  <div class="content_modal">
    <Vueform :endpoint="false" :format-data="formatFormData">
      <StaticElement name="divider" tag="hr" />
      <TextElement
        name="name"
        :columns="{
          container: 12
        }"
        :rules="['required', 'max:255']"
        :messages="{
          required: 'Không được bỏ trống tên nhà xuất bản',
          max: 'không được vượt quá 255 kí tự'
        }"
        label="Tên nhà xuất bản"
        placeholder="name..."
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
