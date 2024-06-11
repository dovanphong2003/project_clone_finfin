import _ from 'lodash'
import { useUserInfoStore } from '@/stores/listStores/userInfo'
import router from '../router/index.ts'
router.beforeEach(async (to, from, next) => {
  const userInfo = useUserInfoStore()
  // if user must login
  if (to.matched.some((record) => record.meta.checkAuth) && _.isEmpty(userInfo.name)) {
    next({ name: 'Login' })
    // if user have login
  } else if (!_.isEmpty(userInfo.name)) {
    if (
      to.name === 'Login' ||
      to.name === 'Register' ||
      to.name === 'ForgetPassword' ||
      to.name === 'Home'
    ) {
      if (userInfo.role === 'customer') {
        next({ path: '/home' })
      } else if (userInfo.role === 'admin') {
        next({ path: '/admin-home' })
      }
    } else {
      next()
    }
  } else if (to.name === '/') {
    next('/home')
  } else {
    next()
  }
})
