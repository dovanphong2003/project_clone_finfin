<script setup lang="ts">
import { useListRoleStore } from '@/stores/listStores/listRole'
import {
  handleLoading,
  handleLoadingNotication,
  handleLoadingNoticationError
} from '@/common/functions/loading'
import { ref } from 'vue'
import { IRole } from '@/common/interface'
import { createdIdAuto } from '@/common/functions/createIdAuto';
import axiosInstance from '@/services/axiosService';
import { format } from 'date-fns';

const props = defineProps({
  arrayConvertPermission: {
    type: Object as () => any,
    required: true
  }
})
console.log("quyền: ",props.arrayConvertPermission)
const store = useListRoleStore()
const form$ = ref<any>(null)
const toggledIndices = ref<number[]>([])
const toggledIndicesParent = ref<number[]>([])
const submitForm = async (e) => {
  e.preventDefault()
  console.log(toggledIndices)
  await form$.value.validate()
  if (form$.value.messageBag.baseErrors.length == 0) {
    const valueUpToStore: IRole = {
      role_id: createdIdAuto(),
      name: form$.value.data.name,
      status: form$.value.data.toggle,
      description: form$.value.data.description,
      arrIdPermission: toggledIndices.value,
      createdAt: new Date(),
      updatedAt: undefined,
      isDeleted:false,
    }
    try {
    const result = await axiosInstance.post('/api/Role', {...valueUpToStore,updatedAt:null})
    if (result.data.isSuccess) {
      store.addRole({
        ...valueUpToStore,
        createdAt: format(new Date(), "yyyy-MM-dd'T'HH:mm:ss.SSS"),
      } as any)
      handleLoadingNotication('Tạo thành công', 600, 'top-right')
      toggledIndices.value = []
    toggledIndicesParent.value = []
    form$.value.reset()
    } else {
      handleLoadingNoticationError('Tạo không thành công!', 600, 'top-center')
    }
  } catch (error) {
    handleLoadingNoticationError('Có lỗi đã xảy ra:' + error, 600, 'top-right')
  }
  } else {
    handleLoadingNoticationError('Vui lòng kiểm tra lại !', 500, 'top-center')
  }
}

const handleClick = (id: number): void => {
  const position = toggledIndices.value.indexOf(id)
  if (position === -1) {
    toggledIndices.value.push(id)
  } else {
    toggledIndices.value.splice(position, 1)
  }
}
const handleClickParent = (parentIndex: number) => {
  const permission = props.arrayConvertPermission[parentIndex]
  const positionParent = toggledIndicesParent.value.indexOf(parentIndex)
  if (positionParent === -1) {
    toggledIndicesParent.value.push(parentIndex)
    permission.dataPermission.forEach((item) => {
      const position = toggledIndices.value.indexOf(item.id)
      if (position === -1) {
        toggledIndices.value.push(item.id)
      }
    })
  } else {
    toggledIndicesParent.value.splice(positionParent, 1)
    permission.dataPermission.forEach((item) => {
      const position = toggledIndices.value.indexOf(item.id)
      if (!(position === -1)) {
        toggledIndices.value.splice(position, 1)
      }
    })
  }
}
const handleClickImg = (e) => {
  e.target.classList.toggle('rotate-90')
  e.target.parentElement.parentElement.parentElement.querySelector('ul').classList.toggle('hidden')
}
</script>
<template>
  <div class="content_modal">
    <!--form info role-->
    <Vueform ref="form$">
      <TextElement
        name="name"
        label="Tên Role"
        :columns="{
          container: 6
        }"
        :rules="['required']"
        :messages="{
          required: 'Tên Role không được để trống'
        }"
      />
      <ToggleElement
        :width="200"
        name="toggle"
        :columns="{
          container: 6
        }"
        align="left"
        label="Trạng Thái"
        :labels="{
          on: 'ON',
          off: 'OFF'
        }"
      />
      <TextElement
        name="description"
        label="Miêu tả"
        :rules="['required']"
        :messages="{
          required: 'Miêu tả không được để trống'
        }"
      />
    </Vueform>
    <div class="noti_content_modal">
      <b>Quyền Hạn:</b>
      <p>các quyền hạn được phép cho vai trò này</p>
    </div>
    <!--form detail role user-->
    <ul>
      <li
        class="li_content_modal"
        v-for="(permission, index) in props.arrayConvertPermission"
        :key="index"
      >
        <div class="panel-body panel-body_group">
          <!--Only code you need is this label-->
          <div class="info_group_permission">
            <img @click="handleClickImg" src="/img/right-arrow.png" alt="image" />
            <p>{{ permission.permissionName }}</p>
          </div>
          <label class="switch">
            <input :class="{ toggle: toggledIndicesParent.includes(index) }" type="checkbox" />
            <div @click="handleClickParent(index)" class="slider round"></div>
          </label>
        </div>
        <ul class="ul_permissions hidden">
          <li v-for="item in permission.dataPermission" :key="item.id">
            <div class="panel-body">
              <!--Only code you need is this label-->
              <label class="switch">
                <input :class="{ toggle: toggledIndices.includes(item.id) }" type="checkbox" />
                <div @click="handleClick(item.id)" class="slider round"></div>
              </label>
              <div class="info_switch">
                <p>{{ item.des }}</p>
                <span>
                  <p
                    :class="{
                      outstanding: true,
                      blue: item.type === 'GET',
                      green: item.type === 'POST',
                      black: item.type === 'PATCH',
                      red: item.type === 'DELETE'
                    }"
                  >
                    {{ item.type }}
                  </p>
                  <p>{{ item.api }}</p>
                </span>
              </div>
            </div>
          </li>
        </ul>
      </li>
    </ul>
    <div class="footer_content_modal">
      <button @click="submitForm" class="create_bnt-footer_content_modal">Tạo mới</button>
    </div>
  </div>
</template>
<style lang="scss" scoped>
.content_modal {
  width: 800px;
  .noti_content_modal {
    display: flex;
    padding: 16px 0px;
    margin: 16px 0px;
    border-top: 1px solid #efefef;
    border-bottom: 1px solid #efefef;
    b {
      margin-right: 12px;
    }
  }
  ul {
    .li_content_modal {
      border: 1px solid #dedede;
      // padding: 10px;
    }
    .ul_permissions {
      display: flex;
      flex-wrap: wrap;
      padding: 10px;
      li {
        width: 50%;
      }
    }
  }
  .panel-body_group {
    display: flex;
    align-items: center;
    justify-content: space-between;
    background-color: #efefef84;
    border: 1px solid #efefef;
    padding: 10px;
    .info_group_permission {
      display: flex;
      align-items: center;
      img {
        height: 20px;
        cursor: pointer;
        padding: 4px;
        margin-right: 4px;
      }
      img:hover {
        background-color: #fff;
        border: 1px solid #606060;
        border-radius: 4px;
      }
      p {
        font-size: 16px;
        font-weight: 500;
        color: $color_default_for_text;
      }
    }
  }
  .panel-body {
    display: flex;
    margin: 10px 0px;
    padding: 12px 6px;
    border: 1px solid #ededed;
    .switch {
      position: relative;
      display: inline-block;
      width: 60px;
      height: 28px;
    }

    .switch input {
      display: none;
    }
    .info_switch {
      display: flex;
      flex-direction: column;
      margin-left: 12px;
      justify-content: center;
      p {
        font-size: 14px;
        color: $color_default_for_text;
        font-weight: 500;
      }
      span {
        padding-top: 10px;
        display: flex;
        p {
          padding-right: 8px;
        }
        .outstanding {
          font-size: 16px;
          font-weight: 700;
        }
      }
    }
    .slider {
      position: absolute;
      cursor: pointer;
      top: 0;
      left: 0;
      right: 0;
      bottom: 0;
      background-color: #c0c0c0;
      -webkit-transition: 0.4s;
      transition: 0.4s;
    }

    .slider:before {
      position: absolute;
      content: '';
      height: 24px;
      width: 24px;
      left: 2px;
      bottom: 2px;
      background-color: white;
      -webkit-transition: 0.4s ease;
      transition: 0.4s ease;
    }

    .toggle + .slider {
      background-color: #0180e8;
    }

    .toggle:focus + .slider {
      box-shadow: 0 0 1px #0180e8;
    }

    .toggle + .slider:before {
      -webkit-transform: translateX(32px);
      -ms-transform: translateX(32px);
      transform: translateX(32px);
    }

    .slider.round {
      border-radius: 28px;
    }

    .slider.round:before {
      border-radius: 50%;
    }
  }
  .footer_content_modal {
    display: flex;
    align-items: center;
    justify-content: center;
    padding: 20px 0px;
    button {
      padding: 12px 16px;
      margin: 0px;
      width: 100%;
      cursor: pointer;
    }
    .create_bnt-footer_content_modal {
      border: 1.6px solid $color_border_button;
      background-color: #fff;
      color: $color_default_for_text;
      font-weight: 600;
      font-size: 14px;
      opacity: 0.8;
    }
    .create_bnt-footer_content_modal:hover {
      color: $color_default_for_hover_text;
      opacity: 1.2;
      background-color: #f3faff;
    }
  }
}
</style>
