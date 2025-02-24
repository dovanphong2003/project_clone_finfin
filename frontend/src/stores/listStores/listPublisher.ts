import type { IPublisher } from '@/common/interface'
import { defineStore } from 'pinia'

export const useListPublisherStore = defineStore('listPublisher', {
  state: () => {
    return {
      items: [] as IPublisher[]
    }
  },
  getters: {
    // Define your getters here
  },
  actions: {
    addPublisher(val: IPublisher) {
      this.items.push(val)
    },
    deletePublisher(publisher_id: number) {
      this.items = this.items.filter((item: IPublisher) => item.publisher_id !== publisher_id)
    },
    editPublisher(val: any, id: number) {
      const index = this.items.findIndex((item: IPublisher) => item.publisher_id === id)
      if (index !== -1) {
        this.items[index] = { ...this.items[index], ...val }
      }
    }
  }
})
