import type { IUser } from '@/common/interface'
import { defineStore } from 'pinia'
import type { Item } from 'vue3-easy-data-table'

export const useListUserStore = defineStore('listUser', {
  state: () => {
    return {
      items: [
        {
          name: 'Do van Phong1',
          email: 'Dodaiphong299@gmail.com1',
          age: '12',
          gender: 'Nam',
          address: 'huong mac - tu son - bac ninh',
          role: 'admin',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z'
        },
        {
          name: 'Do van Phong2',
          email: 'Dodaiphong299@gmail.com2',
          age: '12',
          gender: 'Nam',
          address: 'huong mac - tu son - bac ninh',
          role: 'admin',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z'
        },
        {
          name: 'Do van Phong3',
          email: 'Dodaiphong299@gmail.com3',
          age: '12',
          gender: 'Nam',
          address: 'huong mac - tu son - bac ninh',
          role: 'admin',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z'
        },
        {
          name: 'Do van Phong4',
          email: 'Dodaiphong299@gmail.com4',
          age: '12',
          gender: 'Nam',
          address: 'huong mac - tu son - bac ninh',
          role: 'admin',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z'
        },
        {
          name: 'Do van Phong5',
          email: 'Dodaiphong299@gmail.com5',
          age: '12',
          gender: 'Nam',
          address: 'huong mac - tu son - bac ninh',
          role: 'admin',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z'
        },
        {
          name: 'Do van Phong6',
          email: 'Dodaiphong299@gmail.com6',
          age: '12',
          gender: 'Nam',
          address: 'huong mac - tu son - bac ninh',
          role: 'admin',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z'
        },
        {
          name: 'Do van Phong7',
          email: 'Dodaiphong299@gmail.com7',
          age: '12',
          gender: 'Nam',
          address: 'huong mac - tu son - bac ninh',
          role: 'admin',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z'
        },
        {
          name: 'Do van Phong8',
          email: 'Dodaiphong299@gmail.com8',
          age: '12',
          gender: 'Nam',
          address: 'huong mac - tu son - bac ninh',
          role: 'admin',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z'
        },
        {
          name: 'Do van Phong9',
          email: 'Dodaiphong299@gmail.com9',
          age: '12',
          gender: 'Nam',
          address: 'huong mac - tu son - bac ninh',
          role: 'admin',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z'
        },
        {
          name: 'Do van Phong10',
          email: 'Dodaiphong299@gmail.com10',
          age: '12',
          gender: 'Nam',
          address: 'huong mac - tu son - bac ninh',
          role: 'admin',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z'
        },
        {
          name: 'Do van Phong11',
          email: 'Dodaiphong299@gmail.com11',
          age: '12',
          gender: 'Nam',
          address: 'huong mac - tu son - bac ninh',
          role: 'admin',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z'
        },
        {
          name: 'Do van Phong12',
          email: 'Dodaiphong299@gmail.com12',
          age: '12',
          gender: 'Nam',
          address: 'huong mac - tu son - bac ninh',
          role: 'admin',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z'
        },
        {
          name: 'Do van Phong13',
          email: 'Dodaiphong299@gmail.com13',
          age: '12',
          gender: 'Nam',
          address: 'huong mac - tu son - bac ninh',
          role: 'admin',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z'
        },
        {
          name: 'Do van Phong14',
          email: 'Dodaiphong299@gmail.com14',
          age: '12',
          gender: 'Nam',
          address: 'huong mac - tu son - bac ninh',
          role: 'admin',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z'
        },
        {
          name: 'Do van Phong15',
          email: 'Dodaiphong299@gmail.com15',
          age: '12',
          gender: 'Nam',
          address: 'huong mac - tu son - bac ninh',
          role: 'admin',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z'
        },
        {
          name: 'Do van Phong16',
          email: 'Dodaiphong299@gmail.com16',
          age: '12',
          gender: 'Nam',
          address: 'huong mac - tu son - bac ninh',
          role: 'admin',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z'
        },
        {
          name: 'Do van Phong17',
          email: 'Dodaiphong299@gmail.com17',
          age: '12',
          gender: 'Nam',
          address: 'huong mac - tu son - bac ninh',
          role: 'admin',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z'
        },
        {
          name: 'Do van Phong18',
          email: 'Dodaiphong299@gmail.com18',
          age: '12',
          gender: 'Nam',
          address: 'huong mac - tu son - bac ninh',
          role: 'admin',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z'
        },
        {
          name: 'Do van Phong19',
          email: 'Dodaiphong299@gmail.com19',
          age: '12',
          gender: 'Nam',
          address: 'huong mac - tu son - bac ninh',
          role: 'admin',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z'
        },
        {
          name: 'Do van Phong20',
          email: 'Dodaiphong299@gmail.com20',
          age: '12',
          gender: 'Nam',
          address: 'huong mac - tu son - bac ninh',
          role: 'admin',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z'
        },
        {
          name: 'Do van Phong21',
          email: 'Dodaiphong299@gmail.com21',
          age: '12',
          gender: 'Nam',
          address: 'huong mac - tu son - bac ninh',
          role: 'admin',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z'
        }
      ] as Item[]
    }
  },
  getters: {
    // Define your getters here
  },
  actions: {
    // since we rely on `this`, we cannot use an arrow function
    addUser(val: IUser) {
      console.log('data: ', val)
      this.items.push(val)
    },
    deleteUser(email: string) {
      this.items = this.items.filter((item) => item.email !== email)
    },
    editUser(val: IUser) {
      console.log('val: ', val)
      const index = this.items.findIndex((item) => item.email === val.email)
      if (index !== -1) {
        this.items[index] = val
      }
    }
  }
})
