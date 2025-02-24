import type { ICategory } from '@/common/interface'
import { defineStore } from 'pinia'

export const useListCategoryStore = defineStore('listCategory', {
  state: () => {
    return {
      items: [] as ICategory[]
    }
  },
  getters: {
    // Define your getters here
  },
  actions: {
    // since we rely on `this`, we cannot use an arrow function
    addCategory(val: ICategory) {
      this.items.push(val)
    },
    deleteCategory(category_id: number) {
      this.items = this.items.filter((item: ICategory) => item.category_id !== category_id)
    },
    editCategory(val: any, id: number) {
      console.log('val: ', val)
      const index = this.items.findIndex((item: ICategory) => item.category_id === id)
      if (index !== -1) {
        this.items[index] = { ...this.items[index], ...val }
      }
    }
  }
})
