import { IBook } from './../../common/interface'
import { defineStore } from 'pinia'
import type { Header, Item } from 'vue3-easy-data-table'

export const useListBookStore = defineStore('listBook', {
  state: () => {
    return {
      items: [
        {
          id: 1,
          name: 'Khi người mình yêu khóc nắng khắp nối nhưng mây giăng kín trời !',
          image: 'https://i.pinimg.com/564x/39/82/ab/3982abbedd49c5bc1282776deb0dab85.jpg',
          price: '30',
          author: 'Tác giả !!!',
          category: 'giao dịch thực chiến',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z',
          promotion: '10%',
          status: 'disable'
        },
        {
          id: 2,
          name: 'Người đuổi theo hạnh phúc rồi tan vào trogn biển trời',
          image: 'https://i.pinimg.com/564x/39/82/ab/3982abbedd49c5bc1282776deb0dab85.jpg',
          price: '30',
          author: 'Tác giả !!!',
          category: 'giao dịch thực chiến',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z',
          promotion: '10%',
          status: 'active'
        },
        {
          id: 3,
          name: 'Canh',
          image: 'https://i.pinimg.com/564x/39/82/ab/3982abbedd49c5bc1282776deb0dab85.jpg',
          price: '30',
          author: 'Tác giả !!!',
          category: 'giao dịch thực chiến',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z',
          promotion: '10%',
          status: 'disable'
        },
        {
          id: 4,
          name: 'Dat',
          image: 'https://i.pinimg.com/564x/39/82/ab/3982abbedd49c5bc1282776deb0dab85.jpg',
          price: '30',
          author: 'Tác giả !!!',
          category: 'giao dịch thực chiến',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z',
          promotion: '10%',
          status: 'active'
        },
        {
          id: 5,
          name: 'Stephen Curry5',
          image: 'https://i.pinimg.com/564x/39/82/ab/3982abbedd49c5bc1282776deb0dab85.jpg',
          price: '30',
          author: 'Tác giả !!!',
          category: 'giao dịch thực chiến',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z',
          promotion: '10%',
          status: 'disable'
        },
        {
          id: 6,
          name: 'Stephen Curry6',
          image: 'https://i.pinimg.com/564x/39/82/ab/3982abbedd49c5bc1282776deb0dab85.jpg',
          price: '30',
          author: 'Tác giả !!!',
          category: 'giao dịch thực chiến',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z',
          promotion: '10%',
          status: 'active'
        },
        {
          id: 7,
          name: 'Lebron James',
          image: 'https://i.pinimg.com/564x/39/82/ab/3982abbedd49c5bc1282776deb0dab85.jpg',
          price: '6',

          author: 'Tác giả !!!',
          category: 'F',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z',
          promotion: '40%',
          status: 'disable'
        },
        {
          id: 8,
          name: 'Kevin Durant',
          image: 'https://i.pinimg.com/564x/39/82/ab/3982abbedd49c5bc1282776deb0dab85.jpg',
          price: '7',

          author: 'Tác giả !!!',
          category: 'F',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z',
          promotion: 'Texas-Austin',
          status: '30%'
        },
        {
          id: 9,
          name: 'Kevin Durant',
          image: 'https://i.pinimg.com/564x/39/82/ab/3982abbedd49c5bc1282776deb0dab85.jpg',
          price: '7',

          author: 'Tác giả !!!',
          category: 'F',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z',
          promotion: 'Texas-Austin',
          status: '30%'
        },
        {
          id: 10,
          name: 'Kevin Durant',
          image: 'https://i.pinimg.com/564x/39/82/ab/3982abbedd49c5bc1282776deb0dab85.jpg',
          price: '7',

          author: 'Tác giả !!!',
          category: 'F',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z',
          promotion: 'Texas-Austin',
          status: '30%'
        },
        {
          id: 11,
          name: 'Kevin Durant',
          image: 'https://i.pinimg.com/564x/39/82/ab/3982abbedd49c5bc1282776deb0dab85.jpg',
          price: '7',

          author: 'Tác giả !!!',
          category: 'F',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z',
          promotion: 'Texas-Austin',
          status: '30%'
        },
        {
          id: 12,
          name: 'Kevin Durant',
          image: 'https://i.pinimg.com/564x/39/82/ab/3982abbedd49c5bc1282776deb0dab85.jpg',
          price: '7',

          author: 'Tác giả !!!',
          category: 'F',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z',
          promotion: 'Texas-Austin',
          status: '30%'
        },
        {
          id: 13,
          name: 'Kevin Durant',
          image: 'https://i.pinimg.com/564x/39/82/ab/3982abbedd49c5bc1282776deb0dab85.jpg',
          price: '7',

          author: 'Tác giả !!!',
          category: 'F',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z',
          promotion: 'Texas-Austin',
          status: '30%'
        },
        {
          id: 14,
          name: 'Kevin Durant',
          image: 'https://i.pinimg.com/564x/39/82/ab/3982abbedd49c5bc1282776deb0dab85.jpg',
          price: '7',

          author: 'Tác giả !!!',
          category: 'F',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z',
          promotion: 'Texas-Austin',
          status: '30%'
        },
        {
          id: 15,
          name: 'Kevin Durant',
          image: 'https://i.pinimg.com/564x/39/82/ab/3982abbedd49c5bc1282776deb0dab85.jpg',
          price: '7',

          author: 'Tác giả !!!',
          category: 'F',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z',
          promotion: 'Texas-Austin',
          status: '30%'
        },
        {
          id: 16,
          name: 'Kevin Durant',
          image: 'https://i.pinimg.com/564x/39/82/ab/3982abbedd49c5bc1282776deb0dab85.jpg',
          price: '7',

          author: 'Tác giả !!!',
          category: 'F',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z',
          promotion: 'Texas-Austin',
          status: '30%'
        },
        {
          id: 17,
          name: 'Kevin Durant',
          image: 'https://i.pinimg.com/564x/39/82/ab/3982abbedd49c5bc1282776deb0dab85.jpg',
          price: '7',

          author: 'Tác giả !!!',
          category: 'F',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z',
          promotion: 'Texas-Austin',
          status: '30%'
        },
        {
          id: 18,
          name: 'Kevin Durant',
          image: 'https://i.pinimg.com/564x/39/82/ab/3982abbedd49c5bc1282776deb0dab85.jpg',
          price: '7',

          author: 'Tác giả !!!',
          category: 'F',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z',
          promotion: 'Texas-Austin',
          status: '30%'
        },
        {
          id: 19,
          name: 'Kevin Durant',
          image: 'https://i.pinimg.com/564x/39/82/ab/3982abbedd49c5bc1282776deb0dab85.jpg',
          price: '7',

          author: 'Tác giả !!!',
          category: 'F',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z',
          promotion: 'Texas-Austin',
          status: '30%'
        },
        {
          id: 20,
          name: 'Kevin Durant',
          image: 'https://i.pinimg.com/564x/39/82/ab/3982abbedd49c5bc1282776deb0dab85.jpg',
          price: '7',

          author: 'Tác giả !!!',
          category: 'F',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z',
          promotion: 'Texas-Austin',
          status: '30%'
        },
        {
          id: 21,
          name: 'Kevin Durant',
          image: 'https://i.pinimg.com/564x/39/82/ab/3982abbedd49c5bc1282776deb0dab85.jpg',
          price: '7',

          author: 'Tác giả !!!',
          category: 'F',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z',
          promotion: 'Texas-Austin',
          status: '30%'
        },
        {
          id: 22,
          name: 'Kevin Durant',
          image: 'https://i.pinimg.com/564x/39/82/ab/3982abbedd49c5bc1282776deb0dab85.jpg',
          price: '7',

          author: 'Tác giả !!!',
          category: 'F',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z',
          promotion: 'Texas-Austin',
          status: '30%'
        },
        {
          id: 23,
          name: 'Kevin Durant',
          image: 'https://i.pinimg.com/564x/39/82/ab/3982abbedd49c5bc1282776deb0dab85.jpg',
          price: '7',

          author: 'Tác giả !!!',
          category: 'F',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z',
          promotion: 'Texas-Austin',
          status: '30%'
        },
        {
          id: 24,
          name: 'Kevin Durant',
          image: 'https://i.pinimg.com/564x/39/82/ab/3982abbedd49c5bc1282776deb0dab85.jpg',
          price: '7',

          author: 'Tác giả !!!',
          category: 'F',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z',
          promotion: 'Texas-Austin',
          status: '30%'
        },
        {
          id: 25,
          name: 'Kevin Durant',
          image: 'https://i.pinimg.com/564x/39/82/ab/3982abbedd49c5bc1282776deb0dab85.jpg',
          price: '7',

          author: 'Tác giả !!!',
          category: 'F',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z',
          promotion: 'Texas-Austin',
          status: '30%'
        },
        {
          id: 26,
          name: 'Kevin Durant',
          image: 'https://i.pinimg.com/564x/39/82/ab/3982abbedd49c5bc1282776deb0dab85.jpg',
          price: '7',

          author: 'Tác giả !!!',
          category: 'F',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z',
          promotion: 'Texas-Austin',
          status: '30%'
        },

        {
          id: 27,
          name: 'Anh ba bao',
          image: 'https://i.pinimg.com/564x/39/82/ab/3982abbedd49c5bc1282776deb0dab85.jpg',
          price: 34,
          author: 'Tác giả !!!',
          category: 'F',
          createdAt: '2022-02-26T17:08:14.008Z',
          updatedAt: '2024-06-26T17:08:14.008Z',
          promotion: '20%',
          status: 'disable',
          country: 'Greece'
        }
      ] as Item[]
    }
  },
  getters: {
    // Define your getters here
  },
  actions: {
    // since we rely on `this`, we cannot use an arrow function
    addBook(val: IBook) {
      console.log('data: ', val)
      this.items.push({ id: Math.floor(100000 + Math.random() * 900000), ...val })
    },
    deleteBook(id: Number) {
      this.items = this.items.filter((item) => item.id !== id)
    },
    editBook(val: IBook) {
      console.log('val: ', val)
      const index = this.items.findIndex((item) => item.id === val.id)
      if (index !== -1) {
        this.items[index] = val
      }
    }
  }
})
