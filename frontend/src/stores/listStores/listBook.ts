import { type IBookExtended } from './../../common/interface'
import { defineStore } from 'pinia'
import type { Item } from 'vue3-easy-data-table'

export const useListBookStore = defineStore('listBook', {
  state: () => {
    return {
      items: [] as IBookExtended[]
    }
  },
  getters: {
    // Define your getters here
  },
  actions: {
    // since we rely on `this`, we cannot use an arrow function
    addBook(val: IBookExtended) {
      console.log("val: ",val)
      this.items.push(val)
    },
    deleteBook(id: number) {
      this.items = this.items.filter((item: IBookExtended) => item.book_id !== id)
    },
    editBook(val: any,id: number) {
      const index = this.items.findIndex((item: IBookExtended) => item.book_id === id)
      if (index !== -1) {
        this.items[index] = { ...this.items[index], ...val }
      }
    }
  }
})
