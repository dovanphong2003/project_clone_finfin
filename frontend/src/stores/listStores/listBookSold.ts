import type { IOrder } from '@/common/interface'
import { defineStore } from 'pinia'
import type { Item } from 'vue3-easy-data-table'

export const useListOrderStore = defineStore('listOrder', {
  state: () => {
    return {
      items: [] as IOrder[]
    }
  },
  getters: {
    // Define your getters here
  },
  actions: {
    // since we rely on `this`, we cannot use an arrow function
    addOrder(val: IOrder) {
      this.items.push(val)
    },
     deleteOrder(id: number) {
          this.items = this.items.filter((item) => item.order_id !== id)
        },
        editOrder(val: any, id: number) {
         const index = this.items.findIndex((item: IOrder) => item.order_id === id)
              if (index !== -1) {
                this.items[index] = { ...this.items[index], ...val }
              }
        }
  }
})
