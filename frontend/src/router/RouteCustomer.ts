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
import PageNotFound from '../views/PageNotFound.vue'

const routerCustomer = [
  { path: '/home', component: HomeView, name: 'Home' },
  {
    path: '/book-trading',
    components: { routeAdmin: PageNotFound, routeCustomer: BookTradingView },
    name: 'BookTrading'
  },
  {
    path: '/trading-campaign',
    components: { routeAdmin: PageNotFound, routeCustomer: TradingCampaignView },

    name: 'TradingCampaign'
  },
  {
    path: '/investment-books',
    components: { routeAdmin: PageNotFound, routeCustomer: InvestmentBookView },
    name: 'InvestmentBooksView'
  },
  { path: '/good-book', component: BookGoodView, name: 'GoodBook' },
  {
    path: '/all-book',
    components: { routeAdmin: PageNotFound, routeCustomer: AllBookView },
    name: 'AllBook'
  },
  {
    path: '/login',
    components: { default: LoginView },
    name: 'Login'
  },
  {
    path: '/register',
    components: { default: RegisterView },
    name: 'Register'
  },
  {
    path: '/forget-password',
    components: { default: ForgetPasswordView },
    name: 'ForgetPassword'
  },
  {
    path: '/detail-product/:id',
    components: { routeAdmin: PageNotFound, routeCustomer: DetailProduct },

    name: 'DetailProduct'
  }
]
export default routerCustomer
