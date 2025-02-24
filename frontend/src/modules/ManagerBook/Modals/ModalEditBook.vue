<script setup lang="ts">
import { ref, defineProps, onMounted } from 'vue'
import type { IBookExtended, ISelectOptionsOfBook } from '@/common/interface'
import 'vue3-toastify/dist/index.css'
import { handleLoading, handleLoadingNotication } from '@/common/functions/loading'
import { useListBookStore } from '@/stores/listStores/listBook'
import axiosInstance from '@/services/axiosService'
import Swal from 'sweetalert2'
import { removeMatchingFields } from '@/common/functions/removeMatchingFields'
const props = defineProps({
  objBook: {
    type: Object as () => IBookExtended,
    required: true
  },
  selectOptions: {
    type: Object as () => ISelectOptionsOfBook | any,
    required:true
  }
})
console.log("objL ",props.objBook)
const handleSuccessAndReload = async () => {
  // Hiển thị thông báo với SweetAlert2
  await Swal.fire({
    title: 'Sửa thành công!',
    icon: 'success',
    confirmButtonText: 'OK'
  });

  // Reload trang sau khi người dùng bấm OK
  window.location.reload();
};
// schema of form data
const schema = ref({})

// use get data of form
const form$ = ref(null)

interface ImageFile {
  name: string
  size: number
  type: string
  lastModified: number
}
// use upload image
const preview = ref('')
const image = ref<Partial<ImageFile>>({}) // Partial để có thể khởi tạo rỗng
const notiImageEmpty = ref(false)
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
    console.log('hehe:', input.files[0])
    image.value = input.files[0]
    reader.readAsDataURL(input.files[0])
  }
}

// submit form
const submitFormEdit = async () => {
  const dataMatch = {...props.objBook,category:props.objBook.category.category_id, author: props.objBook.author.author_id, publisher: props.objBook.publisher.publisher_id}
  try {
    // Nếu validation
    if (!image.value.name && !image.value) notiImageEmpty.value = true; // Kiểm tra nếu không có ảnh và không có ảnh mới
    const dataForm = {
      ...(form$.value as any).data,
      ISBN:(form$.value as any).data.ISBN == '' ? null : (form$.value as any).data.ISBN,
      updatedBy: 123456788,  // Có thể là ID của người chỉnh sửa
      updatedAt: new Date(), // Thời gian cập nhật
      price: Number((form$.value as any).data.price),
      stock_quantity: Number((form$.value as any).data.stock_quantity),
    };
console.log(1);
    if (
      dataForm.author &&
      dataForm.title &&
      dataForm.category &&
      dataForm.stock_quantity
    ) {
      console.log(2);

      let imageUrl = 'https://zilo.vn/wp-content/uploads/2022/03/hinh-anh-gai-xinh-tiktok-1.jpg';
      
      // Nếu người dùng thay đổi ảnh, thì upload ảnh mới
      // if (image.value && image.value.name) {
      //   const formData = new FormData();
      //   formData.append('file', image.value as any);

      //   const response = await axiosInstance.post('/api/File/upload_image', formData, {
      //     headers: {
      //       'Content-Type': 'multipart/form-data', 
      //     },
      //   });
        
      //   imageUrl = response.data; 
      // } else {
      //   imageUrl =  props.objBook.imageUrl; 
      // }
      const fillData = removeMatchingFields(dataForm, dataMatch);
              if (fillData.author) {
          fillData.author_id = fillData.author;  // Thêm author_id
          delete fillData.author;                 // Xóa author
        }

        if (fillData.category) {
          fillData.category_id = fillData.category;  // Thêm category_id
          delete fillData.category;                  // Xóa category
        }

        if (fillData.publisher) {
          fillData.publisher_id = fillData.publisher;  // Thêm publisher_id
          delete fillData.publisher;                   // Xóa publisher
        }
      const dataSendServer = {
        id:props.objBook.book_id,  // Giữ nguyên book_id khi chỉnh sửa
        FieldsToUpdate:{ ...fillData, imageUrl }
      }
      console.log("data send server: ",dataSendServer)
      const result = await axiosInstance.patch('/api/Book', dataSendServer);
      console.log(3);

      if (result.data.isSuccess) {
        resetForm();
        handleSuccessAndReload();
      } else {
        console.error('Error updating book: ', result.data.message);
      }
    } else {
      (form$.value as any).validate();
      if (notiImageEmpty.value) {
        (form$.value as any).messageBag.prepend('Ảnh không được để trống');
      }
    }
  } catch (error) {
    console.error('Validation error: ', error);
  }
};


// reset form to natural
const resetForm = async () => {
  (form$.value as any).update({
    // updates form data
    name: props.objBook.title,
    price: props.objBook.price,
    category: props.objBook.category,
    status: props.objBook.status,
    ISBN:props.objBook.ISBN
  })
  preview.value = ''
  image.value = {}
  handleLoading(300)
}

onMounted(() => {
  schema.value = {
    divider: {
      type: 'static',
      tag: 'hr'
    },
    title: {
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
      default: props.objBook.title,
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
    stock_quantity: {
      type: 'text',
      label: 'Tồn kho',
      default: props.objBook.stock_quantity,
      columns: {
        container: 6
      }
    },
    
    category: {
      type: 'select',
      label: 'Chủ đề',
      items: props.selectOptions?.categories ? props.selectOptions.categories.map(category => ({
    value: category.id,
    label: category.name
  })) : [],
      columns: {
        container: 12
      },
      default: props.objBook.category.category_id
    },
    publisher: {
      type: 'select',
      label: 'Nhà xuất bản',
      items: props.selectOptions?.publishers ? props.selectOptions.publishers.map(publisher => ({
    value: publisher.id,
    label: publisher.name
  })) : [],
      columns: {
        container: 12
      },
      default: props.objBook.publisher.publisher_id
    },
    author: {
      type: 'select',
      label: 'Tác giả',
      items: props.selectOptions?.authors ? props.selectOptions.authors.map(author => ({
    value: author.id,
    label: author.name
  })) : [],
      columns: {
        container: 12
      },
      default: props.objBook.author.author_id
    },
    ISBN: {
      type: 'text',
      rules: ['max:255'],
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
      default: props.objBook.ISBN,
      label: 'ISBN'
    },
    status: {
      type: 'toggle',
      text: 'Trạng thái',
      default: props.objBook.status  ? true : false,
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
          <img :src="preview ? preview : props.objBook.imageUrl" class="img-fluid" />
          <template v-if="preview">
            <p class="name_image">Tên ảnh: {{ image.name }}</p>
            <!-- <p class="mb-0">size: {{ image.size / 1024 }}KB</p> -->
          </template>
        </div>
      </div>
    </form>
    <div class="bnt_submit_and_reset">
      <button @click="submitFormEdit" class="button-55 bnt_submit" role="button">Cập nhật</button>
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
