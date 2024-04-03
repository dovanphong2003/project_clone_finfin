import { defineStore } from 'pinia'

export const useUserInfoStore = defineStore('userInfo', {
  state: () => ({
    name: 'do van phong',
    role: 'admin'
  }),
  getters: {
    // Define your getters here
  },
  actions: {
    // Define your actions here
  }
})
