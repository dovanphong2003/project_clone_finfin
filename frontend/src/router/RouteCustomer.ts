import HomeView from '../views/customer/HomeView.vue'
import BookTradingView from '../views/customer/BookTradingView.vue'
import TradingCampaignView from '../views/customer/TradingCampaignView.vue'
import InvestmentBookView from '../views/customer/InvestmentBookView.vue'
import BookGoodView from '../views/customer/BookGoodView.vue'
import AllBookView from '../views/customer/AllBookView.vue'
import LoginView from '../views/customer/LoginView.vue'
import RegisterView from '../views/customer/RegisterView.vue'
import ForgetPasswordView from '../views/customer/ForgetPasswordView.vue'
import DetailProduct from '../views/customer/DetailProduct.vue'
const routerCustomer = [
  { path: '/home', component: HomeView, name: 'Home', meta: { roleUser: 'customer' } },
  {
    path: '/book-trading',
    component: BookTradingView,
    name: 'BookTrading',
    meta: { roleUser: 'customer' }
  },
  {
    path: '/trading-campaign',
    component: TradingCampaignView,
    name: 'TradingCampaign',
    meta: { roleUser: 'customer' }
  },
  {
    path: '/investment-books',
    component: InvestmentBookView,
    name: 'InvestmentBooksView',
    meta: { roleUser: 'customer' }
  },
  { path: '/good-book', component: BookGoodView, name: 'GoodBook', meta: { roleUser: 'customer' } },
  {
    path: '/all-book',
    component: AllBookView,
    name: 'AllBook',
    meta: { roleUser: 'customer' }
  },
  {
    path: '/login',
    component: LoginView,
    name: 'Login'
  },
  {
    path: '/register',
    component: RegisterView,
    name: 'Register'
  },
  {
    path: '/forget-password',
    component: ForgetPasswordView,
    name: 'ForgetPassword'
  },
  {
    path: '/detail-product/:id',
    component: DetailProduct,
    name: 'DetailProduct',
    meta: { roleUser: 'customer' }
  }
]
export default routerCustomer
