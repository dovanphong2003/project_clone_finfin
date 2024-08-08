import type { IPermission } from '@/common/interface'
import { defineStore } from 'pinia'

export const useListPermissionStore = defineStore('listPermission', {
  state: () => {
    return {
      items: [
        {
          name: 'Fetch user1',
          api: '/user-get',
          method: 'GET',
          module: 'ROLES',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z'
        },
        {
          name: 'Fetch user2',
          api: '/user-post',
          method: 'POST',
          module: 'ROLES',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z'
        },
        {
          name: 'Fetch user3',
          api: '/user-patch',
          method: 'PATCH',
          module: 'ROLES',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z'
        },
        {
          name: 'Fetch user4',
          api: '/user-delete',
          method: 'DELETE',
          module: 'ROLES',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z'
        },
        {
          name: 'Fetch user5',
          api: '/user',
          method: 'POST',
          module: 'ROLES',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z'
        },
        {
          name: 'Fetch user6',
          api: '/user',
          method: 'POST',
          module: 'ROLES',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z'
        },
        {
          name: 'Fetch user7',
          api: '/user',
          method: 'POST',
          module: 'ROLES',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z'
        },
        {
          name: 'Fetch user8',
          api: '/user',
          method: 'POST',
          module: 'ROLES',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z'
        },
        {
          name: 'Fetch user9',
          api: '/user',
          method: 'POST',
          module: 'ROLES',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z'
        },
        {
          name: 'Fetch user10',
          api: '/user',
          method: 'POST',
          module: 'ROLES',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z'
        },
        {
          name: 'Fetch user11',
          api: '/user',
          method: 'POST',
          module: 'ROLES',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z'
        },
        {
          name: 'Fetch user12',
          api: '/user',
          method: 'POST',
          module: 'ROLES',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z'
        },
        {
          name: 'Fetch user13',
          api: '/user',
          method: 'POST',
          module: 'ROLES',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z'
        },
        {
          name: 'Fetch user14',
          api: '/user',
          method: 'POST',
          module: 'ROLES',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z'
        },
        {
          name: 'Fetch user15',
          api: '/user',
          method: 'POST',
          module: 'ROLES',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z'
        }
      ] as IPermission[]
    }
  },
  getters: {
    // Define your getters here
  },
  actions: {
    // since we rely on `this`, we cannot use an arrow function
    addPermission(val: IPermission) {
      this.items.push(val)
    },
    deletePermission(email: string) {},
    editPermission(val: IPermission, nameOrigin: string) {
      console.log('val: ', val)
      const index = this.items.findIndex((item) => item.name === nameOrigin)
      if (index !== -1) {
        this.items[index] = val
      }
    }
  }
})
