<script setup lang="ts">
import type { ICoupon } from '@/common/interface'
import { useListCouponStore } from '@/stores/listStores/listCoupon'
import { handleLoading, handleLoadingNotication } from '@/common/functions/loading'
const store = useListCouponStore()

const formatFormData = ({ coupon_code, status, access, discount, quantity, expiry_date }) => {
  handleLoadingNotication('Tạo thành công', 600, 'top-right')

  // data use update for frontend, if data send to server --> add password.
  const dataCreateCoupon: ICoupon = {
    coupon_id: 'ID FAKE NEW',
    coupon_code,
    status: status ? 'active' : 'disable',
    access,
    discount,
    quantity,
    expiry_date: new Date(expiry_date),
    createdAt: new Date('2023-09-08'),
    updatedAt: new Date('2023-09-08')
  }
  console.log('hâ: ', dataCreateCoupon)
  store.addCoupon(dataCreateCoupon)
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
        name="coupon_code"
        :columns="{
          container: 6
        }"
        :rules="['required', 'max:55']"
        :messages="{
          required: 'Không được bỏ trống mã giảm giá',
          max: 'mã không được vượt quá 55 kí tự'
        }"
        label="Tên mã"
        placeholder="code..."
      />
      <DateElement
        name="expiry_date"
        label="Ngày hết hạn"
        :rules="['required']"
        :messages="{
          required: 'Không được bỏ trống ngày hết hạn'
        }"
        :columns="{
          container: 6
        }"
      />
      <ToggleElement
        name="status"
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
      <SliderElement
        name="discount"
        label="Giảm giá ( % )"
        :default="50"
        :columns="{
          container: 8
        }"
        :rules="['required']"
        :messages="{
          required: 'Không được bỏ trống mức giảm giá'
        }"
      />
      <SelectElement
        name="access"
        :search="true"
        :native="false"
        label="Loại truy cập"
        autocomplete="off"
        :columns="{
          container: 6
        }"
        :items="[
          {
            value: 'public',
            label: 'public'
          },
          {
            value: 'private',
            label: 'private'
          }
        ]"
        :rules="['required']"
        :messages="{
          required: 'Không được bỏ trống loại truy cập'
        }"
      />
      <TextElement
        name="quantity"
        label="Số Lượng"
        :columns="{
          container: 6
        }"
        :rules="['required']"
        :messages="{
          required: 'Không được bỏ trống số lượng'
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
