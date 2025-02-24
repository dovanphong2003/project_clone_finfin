import type { IAuthor } from '@/common/interface'
import { defineStore } from 'pinia'

export const useListAuthorStore = defineStore('listAuthor', {
  state: () => {
    return {
      items: [] as IAuthor[]
    }
  },
  getters: {
    // Define your getters here
  },
  actions: {
    addAuthor(val: IAuthor) {
      this.items.push(val)
    },
    deleteAuthor(author_id: number) {
      this.items = this.items.filter((item: IAuthor) => item.author_id !== author_id)
    },
    editAuthor(val: any, id: number) {
      const index = this.items.findIndex((item: IAuthor) => item.author_id === id)
      if (index !== -1) {
        this.items[index] = { ...this.items[index], ...val }
      }
    }
  }
})
