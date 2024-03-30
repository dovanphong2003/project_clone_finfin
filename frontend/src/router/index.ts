import { createWebHistory, createRouter } from 'vue-router'
import HomeView from '../views/customer/HomeView.vue'
import BookTradingView from '../views/customer/BookTradingView.vue'
import TradingCampaignView from '../views/customer/TradingCampaignView.vue'
import InvestmentBookView from '../views/customer/InvestmentBookView.vue'
import BookGoodView from '../views/customer/BookGoodView.vue'
import AllBookView from '../views/customer/AllBookView.vue'
import LoginView from '../views/customer/LoginView.vue'
import RegisterView from '../views/customer/RegisterView.vue'
import ForgetPasswordView from '../views/customer/ForgetPasswordView.vue'
const routes = [
  { path: '/', redirect: '/home' },
  { path: '/home', component: HomeView, name: 'Home' },
  { path: '/book-trading', component: BookTradingView, name: 'BookTrading' },
  { path: '/trading-campaign', component: TradingCampaignView, name: 'TradingCampaign' },
  { path: '/investment-books', component: InvestmentBookView, name: 'InvestmentBooksView' },
  { path: '/good-book', component: BookGoodView, name: 'GoodBook' },
  { path: '/all-book', component: AllBookView, name: 'AllBook' },
  { path: '/login', component: LoginView, name: 'Login' },
  { path: '/register', component: RegisterView, name: 'Register' },
  { path: '/forget-password', component: ForgetPasswordView, name: 'ForgetPassword' }
]

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes
})
export default router
