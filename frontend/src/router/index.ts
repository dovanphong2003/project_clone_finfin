import { createWebHistory, createRouter } from 'vue-router'
import routerCustomer from './RouteCustomer'
import routerAdmin from './RouteAdmin'
import PageNotFound from '../views/PageNotFound.vue'
const routes = [
  { path: '/', redirect: '/home' },
  ...routerCustomer,
  ...routerAdmin,
  { path: '/page-not-found', component: PageNotFound, name: 'PageNotFound' },
  { path: '/:pathMatch(.*)*', redirect: '/page-not-found' }
] as any
const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes
})
export default router
