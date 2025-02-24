<script setup lang="ts">
import { ref, type Ref } from 'vue'
interface Select {
  value: string
  name: string
}
const selects: Select[] = [
  {
    value: 'outstanding',
    name: 'Sản phẩm nổi bật'
  },
  {
    value: 'price_low_to_high',
    name: 'Giá: tăng dần'
  },
  {
    value: 'price_high_to_low',
    name: 'Giá: giảm dần'
  },
  {
    value: 'name_a_to_z',
    name: 'Tên: A-Z'
  },
  {
    value: 'name_z_to_a',
    name: 'Tên: Z-A'
  },
  {
    value: 'old',
    name: 'Cũ nhất'
  },
  {
    value: 'new',
    name: 'Mới nhất'
  },
  {
    value: 'best_seller',
    name: 'Bán chạy nhất'
  }
]
const valueSelect: Ref<string> = ref('haha')
const changeSelect = (event: any) => {
  valueSelect.value = event.target.value
}
</script>
<template>
  <div class="sort_fill">
    <select @change="changeSelect($event)" name="select_book" id="select_book">
      <option value="" selected disabled>Lựa chọn sắp xếp</option>
      <option v-for="select in selects" :value="select.value" :key="select.value">
        {{ select.name }}
      </option>
    </select>
  </div>
</template>
<style lang="scss" scoped>
#select_book {
  border: none;
  outline: none;
  cursor: pointer;
  border-bottom: 1px solid #000;
  padding: 6px 0px;
  padding-right: 20px;
  option {
    color: $color_default_for_text;
    font-size: 14px;
    font-weight: 400;
  }
}
</style>
