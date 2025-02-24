import { defineStore } from 'pinia'

export const useUserInfoStore = defineStore('userInfo', {
  state: () => ({
    name: 'DO VAN PHONG',
    role: 'admin'
  }),
  getters: {
    // Define your getters here
  },
  actions: {
    // Define your actions here
  }
})
