<script setup lang="ts">
import { defineProps, onBeforeMount, ref } from 'vue'
import type { IOrder, IUser } from '@/common/interface'
import { useListUserStore } from '@/stores/listStores/listUser'
import { handleLoading, handleLoadingNotication, handleLoadingNoticationError } from '@/common/functions/loading'
import axiosInstance from '@/services/axiosService'
import { removeMatchingFields } from '@/common/functions/removeMatchingFields'

const props = defineProps({
  objUser: {
    type: Object as () => IOrder,
    required: true
  }
})

const store = useListUserStore()
// call api get select role
const dataSelect = ref([])
const fncGetAllRole = async () => {
  try {
    const result = await axiosInstance.get('/api/Role')
    dataSelect.value = result.data.data.map((items) => {
      return {value:items.role_id,label:items.name}
    })
  } catch (error) {
    console.log('error: ', error)
  }
}
onBeforeMount(() => {
  fncGetAllRole();
});
const formatFormData = async ({ name, age,password, selectGender, role, address }) => {
  handleLoading(600)
  const dataEdit: any = {
    name: name,
    email: props.objUser.email,
    age: age,
    password:password,
    gender: selectGender,
    address: address,
    role_id: role,
    updatedBy: 6,
  }
  try {
            const resultFill = {
              ...removeMatchingFields(dataEdit, props.objUser),
              updatedAt: new Date().toLocaleString()
            }
            if (resultFill.address == '') {
              resultFill.address = null
            }
            if (resultFill.gender == '') {
              resultFill.gender = null
            }
            const dataSendServer: any = {
              id: props.objUser.user_id,
              FieldsToUpdate: { ...resultFill, updatedAt: new Date() }
            }
console.log("data: ",resultFill)
            const result = await axiosInstance.patch('/api/User', dataSendServer)
            console.log('result: ', result.data)
            if (result.data.isSuccess) {
              handleLoadingNotication('cập nhật thành công', 600, 'top-center')
              store.editUser(resultFill, props.objUser.user_id)
            } else {
              handleLoadingNoticationError('đã xảy ra lỗi!', 500, 'top-center')
            }
          } catch (error) {
            handleLoadingNoticationError('đã xảy ra lỗi!: ' + error, 500, 'top-center')
          }
}
</script>
<template>
  <div class="modal_content_right">
    <Vueform :endpoint="false" :format-data="formatFormData">
      <StaticElement name="divider_1" tag="hr" />
      <TextElement
        name="name"
        :rules="['required', 'max:255', 'string']"
        :messages="{
          required: 'Không được bỏ trống tên',
          max: 'Tên không được vượt quá 255 ký tự',
          string: 'Tên phải là chuỗi ký tự'
        }"
        label="Tên"
        :default="objUser.name"
      />  <TextElement
        name="password"
        :rules="['required', 'max:255',]"
        :messages="{
          required: 'Không được bỏ trống mật khẩu',
          max: 'Mật khẩu không được vượt quá 255 ký tự',
        }"
        label="Mật khẩu"
        :default="objUser.password"
      />
      <TextElement
        name="age"
        :columns="{
          container: 6
        }"
        :rules="['required']"
        :messages="{
          required: 'Không được bỏ trống tuổi',
        }"
        label="Tuổi"
        :default="objUser.age"
      />
      <SelectElement
        name="selectGender"
        :columns="{
          container: 6
        }"
        label="Giới tính"
        :rules="['nullable']"
        :items="[
          {
            value: 'Nam',
            label: 'Nam'
          },
          {
            value: 'Nữ',
            label: 'Nữ'
          },
          {
            value: 'Khác',
            label: 'Khác'
          }
        ]"
        :default="objUser.gender"
      />
      <TextElement
        name="address"
        label="Địa chỉ"
        :rules="['nullable']"
        :default="objUser.address"
      />
      <SelectElement
        name="role"
        label="Vai trò"
        :items="dataSelect"
        :default="objUser.role_id"
        :rules="['required']"
        :messages="{
          required: 'Không được bỏ trống vai trò'
        }"
      />
      <StaticElement name="divider_4" tag="hr" />
      <ButtonElement
        name="submit"
        :submits="true"
        :columns="{
          container: 4
        }"
        button-label="Cập nhật"
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
<style lang="scss" scoped></style>
