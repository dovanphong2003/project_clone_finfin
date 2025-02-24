<script setup lang="ts">
import { format } from 'date-fns'
import { useListAuthorStore } from '@/stores/listStores/listAuthor'
import {
  handleLoadingNotication,
  handleLoadingNoticationError,
  handleLoading
} from '@/common/functions/loading'
import { createdIdAuto } from '@/common/functions/createIdAuto'
import axiosInstance from '@/services/axiosService'
const store = useListAuthorStore()
const formatFormData = async ({ name, bio }) => {
  handleLoading(600)

  const dataCreateAuthor = {
    author_id: createdIdAuto(),
    name: name,
    bio: bio == '' ? null : bio,
    createdAt: new Date(),
    isDeleted: false
  }
  console.log('data: ', dataCreateAuthor)
  try {
    const result = await axiosInstance.post('/api/Author', dataCreateAuthor)
    if (result.data.isSuccess) {
      store.addAuthor({
        ...dataCreateAuthor,
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
          required: 'Không được bỏ trống tên Tác giả',
          max: 'chủ đề không được vượt quá 255 kí tự'
        }"
        label="Tên tác giả"
        placeholder="name..."
      />
      <TextElement
        name="bio"
        label="giới thiệu"
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
