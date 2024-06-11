<script setup lang="ts">
import { ref, defineProps, onMounted } from 'vue'
import IBook from '@/common/interface.ts'
import 'vue3-toastify/dist/index.css'
import { handleLoading, handleLoadingNotication } from '@/common/functions/loading.ts'
import { useListBookStore } from '@/stores/listStores/listBook.ts'
const props = defineProps({
  objBook: {
    type: Object as () => IBook,
    required: true
  }
})
// schema of form data
const schema = ref({})

// use get data of form
const form$ = ref(null)

// use upload image
const preview = ref('')
const image = ref({})

const store = useListBookStore()
const previewImage = (event) => {
  var input = event.target
  if (input.files) {
    var reader = new FileReader()
    reader.onload = (e) => {
      preview.value = e.target.result
    }
    image.value = input.files[0]
    reader.readAsDataURL(input.files[0])
  }
}

// submit form
const submitForm = () => {
  const dataForm = { ...form$.value.data, infoImage: image.value, base64Image: preview.value }
  const dataEdit: IBook = {
    id: props.objBook.id,
    name: form$.value.data.name,
    image:
      'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR053tL-FMuBpFToEfPhMYacjE1cvsATP_S6g&s',
    price: form$.value.data.price,
    author: props.objBook.author,
    category: form$.value.data.category,
    createdAt: '2022-08-28T17:08:14.008Z',
    updatedAt: '2030-08-26T17:08:14.008Z',
    promotion: form$.value.data.promotion + '%',
    status: form$.value.data.status ? 'active' : 'disable'
  }
  store.editBook(dataEdit)
  // loading...
  handleLoadingNotication('Cập nhật thành công!', 1000)
}

// reset form to natural
const resetForm = async () => {
  handleLoading(300)
  form$.value.update({
    // updates form data
    name: props.objBook.name,
    price: props.objBook.price,
    promotion: Number(props.objBook.promotion.replace('%', '')),
    category: props.objBook.category,
    status: props.objBook.status
  })
  preview.value = ''
  image.value = {}
}

onMounted(() => {
  schema.value = {
    divider: {
      type: 'static',
      tag: 'hr'
    },
    name: {
      type: 'text',
      rules: ['required', 'max:255'],
      columns: {
        default: {
          container: 6,
          label: 12,
          wrapper: 12
        },
        lg: {
          container: 12
        }
      },
      default: props.objBook.name,
      label: 'Tên sách'
    },
    price: {
      type: 'text',
      label: 'Giá sách',
      default: props.objBook.price,
      columns: {
        container: 6
      }
    },
    category: {
      type: 'select',
      label: 'Thể loại',
      items: [
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
      ],
      columns: {
        container: 6
      },
      default: props.objBook.category
    },
    promotion: {
      type: 'slider',
      label: 'Giảm giá',
      default: Number(props.objBook.promotion.replace('%', '')),
      min: 0,
      max: 100
    },
    status: {
      type: 'toggle',
      text: 'Trạng thái',
      default: props.objBook.status === 'active' ? true : false,
      columns: {
        container: 12
      }
    }
  }
})
</script>

<template>
  <div class="content_modal_right">
    <Vueform class="form_vue" :schema="schema" ref="form$"></Vueform>
    <form>
      <div class="form-group">
        <label for="my-file">
          <div class="btn">Thay đổi hình ảnh !</div>
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
          <img :src="preview ? preview : props.objBook.image" class="img-fluid" />
          <template v-if="preview">
            <p class="name_image">Tên ảnh: {{ image.name }}</p>
            <!-- <p class="mb-0">size: {{ image.size / 1024 }}KB</p> -->
          </template>
        </div>
      </div>
    </form>
    <div class="bnt_submit_and_reset">
      <button @click="submitForm" class="button-55 bnt_submit" role="button">Cập nhật</button>
      <button @click="resetForm" class="button-55 bnt_reset" role="button">Đặt lại</button>
    </div>
  </div>
</template>

<style scoped lang="scss">
.form_vue {
  margin-top: 0px !important;
}

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
        padding: 10px 12px;
        border: 2px solid #ccc;
        max-width: 100%;
        max-height: 200px;
      }
    }
  }
}

/** css for button */
.bnt_submit_and_reset {
  display: flex;
  justify-content: space-between;
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
