import type { ICoupon } from '@/common/interface'
import { defineStore } from 'pinia'

export const useListCouponStore = defineStore('listCoupon', {
  state: () => {
    return {
      items: [
        {
          coupon_id: '12345',
          coupon_code: 'COUPON1234',
          discount: 15,
          quantity: 200,
          status: 'active',
          access: 'public',
          expiry_date: new Date('2024-12-31'),
          createdAt: new Date('2023-09-08'),
          updatedAt: new Date('2023-09-08')
        },
        {
          coupon_id: '23456',
          coupon_code: 'COUPON5678',
          discount: 25,
          quantity: 100,
          status: 'expired',
          access: 'private',
          expiry_date: new Date('2023-06-30'),
          createdAt: new Date('2023-02-01'),
          updatedAt: new Date('2023-06-01')
        },
        {
          coupon_id: '34567',
          coupon_code: 'COUPON9101',
          discount: 20,
          quantity: 500,
          status: 'disable',
          access: 'public',
          expiry_date: new Date('2024-05-15'),
          createdAt: new Date('2023-08-15'),
          updatedAt: new Date('2023-09-01')
        },
        {
          coupon_id: '45678',
          coupon_code: 'COUPON1123',
          discount: 50,
          quantity: 250,
          status: 'active',
          access: 'private',
          expiry_date: new Date('2024-01-31'),
          createdAt: new Date('2023-09-08'),
          updatedAt: new Date('2023-09-08')
        },
        {
          coupon_id: '56789',
          coupon_code: 'COUPON1314',
          discount: 10,
          quantity: 300,
          status: 'active',
          access: 'public',
          expiry_date: new Date('2024-07-30'),
          createdAt: new Date('2023-04-15'),
          updatedAt: new Date('2023-08-01')
        },
        {
          coupon_id: '67890',
          coupon_code: 'COUPON1516',
          discount: 100,
          quantity: 50,
          status: 'expired',
          access: 'private',
          expiry_date: new Date('2023-08-10'),
          createdAt: new Date('2023-01-01'),
          updatedAt: new Date('2023-08-10')
        },
        {
          coupon_id: '78901',
          coupon_code: 'COUPON1718',
          discount: 5,
          quantity: 1000,
          status: 'disable',
          access: 'public',
          expiry_date: new Date('2024-09-01'),
          createdAt: new Date('2023-09-01'),
          updatedAt: new Date('2023-09-05')
        },
        {
          coupon_id: '89012',
          coupon_code: 'COUPON1920',
          discount: 75,
          quantity: 400,
          status: 'active',
          access: 'private',
          expiry_date: new Date('2024-03-30'),
          createdAt: new Date('2023-07-20'),
          updatedAt: new Date('2023-08-25')
        },
        {
          coupon_id: '90123',
          coupon_code: 'COUPON2122',
          discount: 25,
          quantity: 600,
          status: 'disable',
          access: 'public',
          expiry_date: new Date('2024-10-05'),
          createdAt: new Date('2023-09-01'),
          updatedAt: new Date('2023-09-02')
        },
        {
          coupon_id: '101234',
          coupon_code: 'COUPON2324',
          discount: 30,
          quantity: 700,
          status: 'active',
          access: 'private',
          expiry_date: new Date('2024-12-25'),
          createdAt: new Date('2023-03-01'),
          updatedAt: new Date('2023-07-15')
        },
        {
          coupon_id: '112345',
          coupon_code: 'COUPON2526',
          discount: 35,
          quantity: 150,
          status: 'expired',
          access: 'public',
          expiry_date: new Date('2023-07-15'),
          createdAt: new Date('2023-01-01'),
          updatedAt: new Date('2023-07-01')
        },
        {
          coupon_id: '123456',
          coupon_code: 'COUPON2728',
          discount: 60,
          quantity: 900,
          status: 'active',
          access: 'private',
          expiry_date: new Date('2024-02-20'),
          createdAt: new Date('2023-05-15'),
          updatedAt: new Date('2023-07-10')
        },
        {
          coupon_id: '134567',
          coupon_code: 'COUPON2930',
          discount: 50,
          quantity: 450,
          status: 'active',
          access: 'public',
          expiry_date: new Date('2024-08-30'),
          createdAt: new Date('2023-02-25'),
          updatedAt: new Date('2023-09-01')
        },
        {
          coupon_id: '145678',
          coupon_code: 'COUPON3132',
          discount: 40,
          quantity: 850,
          status: 'disable',
          access: 'private',
          expiry_date: new Date('2024-06-15'),
          createdAt: new Date('2023-04-10'),
          updatedAt: new Date('2023-08-30')
        },
        {
          coupon_id: '156789',
          coupon_code: 'COUPON3334',
          discount: 12,
          quantity: 700,
          status: 'expired',
          access: 'public',
          expiry_date: new Date('2023-05-25'),
          createdAt: new Date('2023-01-01'),
          updatedAt: new Date('2023-05-01')
        },
        {
          coupon_id: '167890',
          coupon_code: 'COUPON3536',
          discount: 20,
          quantity: 950,
          status: 'active',
          access: 'private',
          expiry_date: new Date('2024-09-10'),
          createdAt: new Date('2023-03-20'),
          updatedAt: new Date('2023-07-20')
        },
        {
          coupon_id: '178901',
          coupon_code: 'COUPON3738',
          discount: 18,
          quantity: 350,
          status: 'disable',
          access: 'public',
          expiry_date: new Date('2024-04-05'),
          createdAt: new Date('2023-08-05'),
          updatedAt: new Date('2023-09-01')
        },
        {
          coupon_id: '189012',
          coupon_code: 'COUPON3940',
          discount: 90,
          quantity: 200,
          status: 'active',
          access: 'private',
          expiry_date: new Date('2024-01-01'),
          createdAt: new Date('2023-09-01'),
          updatedAt: new Date('2023-09-01')
        },
        {
          coupon_id: '190123',
          coupon_code: 'COUPON4142',
          discount: 8,
          quantity: 100,
          status: 'active',
          access: 'public',
          expiry_date: new Date('2024-10-20'),
          createdAt: new Date('2023-08-01'),
          updatedAt: new Date('2023-08-10')
        },
        {
          coupon_id: '201234',
          coupon_code: 'COUPON4344',
          discount: 15,
          quantity: 300,
          status: 'expired',
          access: 'private',
          expiry_date: new Date('2023-09-01'),
          createdAt: new Date('2023-01-01'),
          updatedAt: new Date('2023-09-01')
        }
      ] as ICoupon[]
    }
  },
  getters: {
    // Define your getters here
  },
  actions: {
    // since we rely on `this`, we cannot use an arrow function
    addCoupon(val: ICoupon) {
      this.items.push(val)
    },
    deleteCoupon(coupon_code: string) {
      this.items = this.items.filter((item) => item.coupon_code !== coupon_code)
    },
    editCoupon(val: ICoupon) {
      console.log('val: ', val)
      const index = this.items.findIndex((item) => item.coupon_code === val.coupon_code)
      if (index !== -1) {
        this.items[index] = val
      }
    }
  }
})
