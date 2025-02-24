import type { IRole } from '@/common/interface'
import { defineStore } from 'pinia'
export const useListRoleStore = defineStore('listRole', {
  state: () => {
    return {
      items: [
      ] as IRole[]
    }
  },
  getters: {
    // Define your getters here
  },
  actions: {
    // since we rely on `this`, we cannot use an arrow function
    addRole(val: IRole) {
      this.items.push(val)
    },
    deleteRole(id: number) {
      this.items = this.items.filter((item) => item.role_id !== id)
    },
    editRole(val: any, id: number) {
     const index = this.items.findIndex((item: IRole) => item.role_id === id)
          if (index !== -1) {
            this.items[index] = { ...this.items[index], ...val }
          }
    }
  }
})
