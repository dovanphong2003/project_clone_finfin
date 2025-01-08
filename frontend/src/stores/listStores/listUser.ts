import type { IUser } from '@/common/interface'
import { defineStore } from 'pinia'
import type { Item } from 'vue3-easy-data-table'

export const useListUserStore = defineStore('listUser', {
  state: () => {
    return {
      items: [] as IUser[]
    }
  },
  getters: {
    // Define your getters here
  },
  actions: {
    // since we rely on `this`, we cannot use an arrow function
    addUser(val: IUser) {
      this.items.push(val)
    },
     deleteUser(id: number) {
          this.items = this.items.filter((item) => item.user_id !== id)
        },
        editUser(val: any, id: number) {
         const index = this.items.findIndex((item: IUser) => item.user_id === id)
              if (index !== -1) {
                this.items[index] = { ...this.items[index], ...val }
              }
        }
  }
})
