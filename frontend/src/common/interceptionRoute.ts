import _ from 'lodash'
import { useUserInfoStore } from '@/stores/listStores/userInfo'
import router from '../router/index'
router.beforeEach(async (to, from, next) => {
  console.log('haha')
  const userInfo = useUserInfoStore()
  // if user must login
  if (to.matched.some((record) => record.meta.checkAuth) && _.isEmpty(userInfo.name)) {
    next({ name: 'Login' })

    // if user have login
  } else if (!_.isEmpty(userInfo.name)) {
    console.log(to.name)
    if (to.name === 'Login' || to.name === 'Register' || to.name === 'ForgetPassword' || to.name === '/') {
    console.log(3)
      if (userInfo.role === 'customer') {
        console.log(1);
        next({ path: '/home' })
      } else if (userInfo.role === 'admin') {
        console.log(2);
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
