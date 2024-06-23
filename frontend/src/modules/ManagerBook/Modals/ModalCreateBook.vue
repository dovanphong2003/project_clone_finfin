<script setup lang="ts">
import { ref } from 'vue'
import 'vue3-toastify/dist/index.css'
import { handleLoading, handleLoadingNotication } from '@/common/functions/loading'
import { useListBookStore } from '@/stores/listStores/listBook'

// use get data of form
const form$ = ref(null)
// use upload image
const preview = ref('')
const image = ref<Partial<ImageFile>>({}) // Partial để có thể khởi tạo rỗng
const notiImageEmpty = ref(false)
const store = useListBookStore()
interface ImageFile {
  name: string
  size: number
  type: string
  lastModified: number
}
// fnc
const previewImage = (event) => {
  var input = event.target
  if (input.files) {
    var reader = new FileReader()
    reader.onload = (e) => {
      const result = e.target?.result
      if (typeof result === 'string') {
        preview.value = result
      }
    }
    image.value = input.files[0]
    reader.readAsDataURL(input.files[0])
    notiImageEmpty.value = false
    ;(form$.value as any).messageBag.clearPrepended('errors') // clears prepended errors
  }
}

// submit form
const submitForm = async () => {
  try {
    // Nếu validation
    if (!image.value.name) notiImageEmpty.value = true
    const dataForm = {
      ...(form$.value as any).data,
      infoImage: image.value,
      base64Image: preview.value
    }
    console.log('haha: ', { ...(form$.value as any).data })
    if (
      dataForm.author &&
      dataForm.base64Image &&
      dataForm.name &&
      dataForm.price &&
      dataForm.category &&
      dataForm.infoImage &&
      dataForm.infoImage.name
    ) {
      store.addBook({
        ...(form$.value as any).data,
        promotion: (form$.value as any).data.promotion + '%',
        status: (form$.value as any).data.status ? 'active' : 'disable',
        createdAt: '2026-02-26T17:08:14.008Z',
        updatedAt: '2028-06-26T17:08:14.008Z',
        image:
          'https://www.vam.ac.uk/dw/image/v2/BDFC_PRD/on/demandware.static/-/Sites-VAM_MasterShop/default/dw87c877b6/pdp-images/products/168123-fragile-beauty-exhibition-book-cover.png?sw=520&sh=520'
      })
      handleLoadingNotication('Tạo thành công!', 800, 'top-right')
      resetForm()
    } else {
      ;(form$.value as any)
        .validate()(form$.value as any)
        .validate()
      if (notiImageEmpty.value) {
        ;(form$.value as any).messageBag.prepend('Ảnh không được để trống')
      }
    }
    // Thực hiện các hành động khác như gửi dữ liệu tới server
    // ...
  } catch (error) {
    console.error('Validation error: ', error)
  }
}

// reset form to natural
const resetForm = async () => {
  ;(form$.value as any)
    .reset()(form$.value as any)
    .messageBag.clearPrepended('errors') // clears prepended errors
  notiImageEmpty.value = false
  preview.value = ''
  image.value = {}
  handleLoading(300)
}
</script>

<template>
  <div class="content_modal">
    <Vueform ref="form$" validate-on="change">
      <StaticElement name="divider" tag="hr" />
      <TextElement
        name="name"
        :rules="['required', 'max:255']"
        :messages="{
          required: 'Không được bỏ trống tên',
          max: 'Tên không được vượt quá 255 ký tự'
        }"
        :columns="{
          default: {
            container: 6,
            label: 12,
            wrapper: 12
          },
          lg: {
            container: 6
          }
        }"
        label="Tên sách"
      />
      <TextElement
        name="price"
        label="Giá"
        :columns="{
          container: 6
        }"
        placeholder="eg: 500,000đ"
        :rules="['required']"
        :messages="{
          required: 'Giá không được để trống'
        }"
      />
      <TextElement
        name="author"
        label="Tác giả"
        :columns="{
          container: 6
        }"
        :rules="['required']"
        :messages="{
          required: 'Tác giả không được để trống'
        }"
      />
      <SelectElement
        name="category"
        label="Thể loại"
        :items="[
          {
            value: 'giao dịch thực chiến',
            label: 'giao dịch thực chiến'
          },
          {
            value: 'Sách hay',
            label: 'Sách hay'
          },
          {
            value: 'Sách giao dịch',
            label: 'Sách giao dịch'
          },
          {
            value: 'Sách đầu tư',
            label: 'Sách đầu tư'
          }
        ]"
        :columns="{
          container: 6
        }"
        :rules="['required']"
        :messages="{
          required: 'Thể loại không được để trống'
        }"
      />
      <ToggleElement
        name="status"
        :columns="{
          container: 6
        }"
        align="left"
        label="Trạng thái"
      />
      <SliderElement
        name="promotion"
        label="Giảm giá"
        :min="0"
        :max="100"
        :default="0"
        :columns="{
          lg: {
            container: 6
          }
        }"
      />
    </Vueform>
    <form>
      <div class="form-group">
        <label for="my-file">
          <div class="btn">Chọn ảnh cho sách!</div>
          <p
            v-if="notiImageEmpty"
            style="text-align: center; padding-top: 6px; padding-bottom: 4px; color: red"
          >
            Ảnh không được để trống
          </p>
        </label>
        <input
          type="file"
          accept="image/*"
          @change="previewImage"
          class="form-control-file"
          id="my-file"
          style="visibility: hidden"
        />
        <div class="preview_image">
          <img
            :src="
              preview
                ? preview
                : `https://st4.depositphotos.com/14953852/24787/v/450/depositphotos_247872612-stock-illustration-no-image-available-icon-vector.jpg`
            "
            class="img-fluid"
          />
          <template v-if="preview">
            <p class="name_image">Tên ảnh: {{ image.name }}</p>
            <!-- <p class="mb-0">size: {{ image.size / 1024 }}KB</p> -->
          </template>
        </div>
      </div>
    </form>
    <div class="bnt_submit_and_reset">
      <button @click="submitForm" class="button-55 bnt_submit" role="button">Tạo sách</button>
      <button @click="resetForm" class="button-55 bnt_reset" role="button">Đặt lại</button>
    </div>
  </div>
</template>

<style scoped lang="scss">
.content_modal {
  width: 1000px;

  form {
    margin-top: 20px;
    .form-group {
      .btn {
        text-align: center;
        padding: 10px 40px;
        border: 1px solid #ccc;
        cursor: pointer;
      }
      .preview_image {
        text-align: center;
        img {
          padding: 4px 6px;
          border: 2px solid #ccc;
          max-width: 100%;
          max-height: 140px;
        }
      }
    }
  }
}

/** css for button */
.bnt_submit_and_reset {
  display: flex;
  justify-content: center;
  margin: 0px 20px;
  padding-top: 20px;
  padding-bottom: 40px;
  .button-55 {
    align-self: center;
    background-color: #fff;
    background-image: none;
    background-position: 0 90%;
    background-repeat: repeat no-repeat;
    background-size: 4px 3px;
    border-radius: 15px 225px 255px 15px 15px 255px 225px 15px;
    border-style: solid;
    border-width: 2px;
    box-shadow: rgba(0, 0, 0, 0.2) 15px 28px 25px -18px;
    box-sizing: border-box;
    color: #41403e;
    cursor: pointer;
    display: inline-block;
    font-family: Neucha, sans-serif;
    font-size: 1rem;
    line-height: 23px;
    outline: none;
    padding: 0.75rem;
    text-decoration: none;
    transition: all 235ms ease-in-out;
    border-bottom-left-radius: 15px 255px;
    border-bottom-right-radius: 225px 15px;
    border-top-left-radius: 255px 15px;
    border-top-right-radius: 15px 225px;
    user-select: none;
    -webkit-user-select: none;
    touch-action: manipulation;
    padding-left: 20px;
    padding-right: 20px;
    min-width: 140px;
    border-color: #0000008c;
  }
  .bnt_submit {
    margin-right: 10px;
  }
  .bnt_reset {
    margin-left: 10px;
  }
  .button-55:hover {
    box-shadow: rgba(0, 0, 0, 0.3) 2px 8px 8px -5px;
    transform: translate3d(0, 2px, 0);
  }
  .button-55:focus {
    box-shadow: rgba(0, 0, 0, 0.3) 2px 8px 4px -6px;
  }
  .button-55:active {
    box-shadow: rgba(0, 0, 0, 0.769) 2px 8px 4px -6px;
    border-color: rgb(17, 27, 38);
  }
}
</style>
