import HomeView from '../views/customer/HomeView.vue'
import BookTradingView from '../views/customer/BookTradingView.vue'
import { createWebHistory, createRouter } from 'vue-router'
const routes = [
  { path: '/', redirect: '/home' },
  { path: '/home', component: HomeView, name: 'Home' },
  { path: '/book-trading', component: BookTradingView, name: 'BookTrading' }
]

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes
})
export default router
