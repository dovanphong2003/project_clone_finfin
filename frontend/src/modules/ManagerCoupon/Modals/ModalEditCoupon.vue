<script setup lang="ts">
import { defineProps } from 'vue'
import type { ICoupon } from '@/common/interface'
import { useListCouponStore } from '@/stores/listStores/listCoupon'
import { handleLoading, handleLoadingNotication } from '@/common/functions/loading'

const props = defineProps({
  objCoupon: {
    type: Object as () => ICoupon,
    required: true
  }
})

const store = useListCouponStore()

const formatFormData = ({ status, access, discount, quantity, expiry_date }) => {
  handleLoading(600)
  const dataEdit: ICoupon = {
    coupon_id: props.objCoupon.coupon_id,
    coupon_code: props.objCoupon.coupon_code,
    discount: discount,
    quantity: quantity,
    status: status ? 'active' : 'disable',
    access: access,
    expiry_date: new Date(expiry_date),
    createdAt: props.objCoupon.createdAt,
    updatedAt: new Date()
  }
  store.editCoupon(dataEdit)
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
        name="coupon_code"
        :rules="['required']"
        label="Tên mã"
        :default="objCoupon.coupon_code"
        :submit="false"
        disabled
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
        :default="objCoupon.expiry_date"
      />
      <ToggleElement
        name="status"
        :columns="{
          container: 6
        }"
        align="left"
        label="Trạng Thái"
        :labels="{
          on: 'ACTIVE',
          off: 'OFF'
        }"
        :default="objCoupon.status == 'active' ? true : false"
      />
      <SliderElement name="discount" label="Giảm giá ( % )" :default="30" :rules="['required']" />
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
        :default="objCoupon.access"
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
        :default="objCoupon.quantity"
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
