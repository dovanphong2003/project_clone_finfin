import type { IRole } from '@/common/interface'
import { defineStore } from 'pinia'
export const useListRoleStore = defineStore('listRole', {
  state: () => {
    return {
      allRole: [
        {
          nameRole: 'ADMIN',
          status: true,
          description: 'Các quyền sử dụng của admin',
          objPermission: [
            '/api/v1/companies1',
            '/api/v1/companies2',
            '/api/v1/companies3',
            '/api/v1/companies4',
            '/api/v1/companies5',
            '/api/v1/companies6',
            '/api/v1/companies7',
            '/api/v1/companies8',
            '/api/v1/companies9',
            '/api/v1/companies10',
            '/api/v1/companies11',
            '/api/v1/companies12',
            '/api/v1/companies13',
            '/api/v1/companies14',
            '/api/v1/companies15',
            '/api/v1/companies16',
            '/api/v1/companies17',
            '/api/v1/companies18',
            '/api/v1/companies19',
            '/api/v1/companies20'
          ],
          createdAt: '2024-02-26T17:08:14.008Z',
          updatedAt: '2024-08-26T17:08:14.008Z'
        },
        {
          nameRole: 'CUSTOMER',
          status: true,
          description: 'Các quyền sử dụng của customer',
          objPermission: [
            '/api/v1/companies16',
            '/api/v1/companies17',
            '/api/v1/companies18',
            '/api/v1/companies19',
            '/api/v1/companies20'
          ],
          createdAt: '2024-02-26T17:08:14.008Z',
          updatedAt: '2024-08-26T17:08:14.008Z'
        },
        {
          nameRole: 'ADMIN LEVEL 2',
          status: true,
          description: 'Các quyền sử dụng của Admin level 2',
          objPermission: [
            '/api/v1/companies1',
            '/api/v1/companies2',
            '/api/v1/companies3',
            '/api/v1/companies4',
            '/api/v1/companies5',
            '/api/v1/companies6',
            '/api/v1/companies7',
            '/api/v1/companies8',
            '/api/v1/companies9',
            '/api/v1/companies10',
            '/api/v1/companies16',
            '/api/v1/companies17',
            '/api/v1/companies18',
            '/api/v1/companies19',
            '/api/v1/companies20'
          ],
          createdAt: '2024-02-26T17:08:14.008Z',
          updatedAt: '2024-08-26T17:08:14.008Z'
        }
      ] as IRole[]
    }
  },
  getters: {
    // Define your getters here
  },
  actions: {
    // since we rely on `this`, we cannot use an arrow function
    addRole(val: IRole) {
      this.allRole.push(val)
    },
    deleteRole(nameRole: string) {
      this.allRole = this.allRole.filter((item) => item.nameRole !== nameRole)
    },
    editRole(val: IRole, nameRole: string) {
      const index = this.allRole.findIndex((item) => item.nameRole === nameRole)
      if (index !== -1) {
        this.allRole[index] = val
      }
    }
  }
})
