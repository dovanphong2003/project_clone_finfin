import type { IPermission } from '@/common/interface'
import { defineStore } from 'pinia'

export const useListPermissionStore = defineStore('listPermission', {
  state: () => {
    return {
     items: [] as IPermission[]
    }
  },
  getters: {
    // Define your getters here
  },
    actions: {
      addPermission(val: IPermission) {
        this.items.push(val)
      },
      deletePermission(permission_id: number) {
        this.items = this.items.filter((item: IPermission) => item.permission_id !== permission_id)
      },
      editPermission(val: any, id: number) {
        const index = this.items.findIndex((item: IPermission) => item.permission_id === id)
        if (index !== -1) {
          this.items[index] = { ...this.items[index], ...val }
        }
      }
    }
})
