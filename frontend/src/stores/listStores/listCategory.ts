import type { ICategory } from '@/common/interface'
import { defineStore } from 'pinia'

export const useListCategoryStore = defineStore('listCategory', {
  state: () => {
    return {
      items: [
        {
          category_id: 1,
          name: 'category 1',
          parent_id: null,
          createdAt: new Date(),
          updatedAt: new Date(),
          is_active: 1,
          is_delete: 0
        },
        {
          category_id: 2,
          name: 'category 2',
          parent_id: 1,
          createdAt: new Date(),
          updatedAt: new Date(),
          is_active: 1,
          is_delete: 0
        },
        {
          category_id: 3,
          name: 'category 3',
          parent_id: 1,
          createdAt: new Date(),
          updatedAt: new Date(),
          is_active: 1,
          is_delete: 0
        },
        {
          category_id: 4,
          name: 'category 4',
          parent_id: null,
          createdAt: new Date(),
          updatedAt: new Date(),
          is_active: 1,
          is_delete: 0
        },
        {
          category_id: 5,
          name: 'category 5',
          parent_id: null,
          createdAt: new Date(),
          updatedAt: new Date(),
          is_active: 1,
          is_delete: 0
        }
      ] as ICategory[]
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
      this.items = this.items.filter((item) => item.category_id !== category_id)
    },
    editCategory(val: ICategory) {
      console.log('val: ', val)
      const index = this.items.findIndex((item) => item.category_id === val.category_id)
      if (index !== -1) {
        this.items[index] = val
      }
    }
  }
})
