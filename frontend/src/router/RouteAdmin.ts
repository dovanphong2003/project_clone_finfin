import HomeView from '../views/admin/HomeView.vue'
import PageNotFound from '../views/PageNotFound.vue'
import ManagerBook from '../views/admin/ManagerBook.vue'
import ManagerUser from '../views/admin/ManagerUser.vue'
// if route admin --- checkAuth = true, check role = admin
const routerAdmin = [
  {
    path: '/admin-home',
    components: { routeAdmin: HomeView, routeCustomer: PageNotFound },
    name: 'AdminHome',
    meta: { checkAuth: true, title: 'Bảng điều khiển' }
  },
  {
    path: '/admin-book',
    components: { routeAdmin: ManagerBook, routeCustomer: PageNotFound },
    name: 'ManagerBook',
    meta: { checkAuth: true, title: 'Quản lí sách' }
  },
  {
    path: '/admin-user',
    components: { routeAdmin: ManagerUser, routeCustomer: PageNotFound },
    name: 'ManagerUser',
    meta: { checkAuth: true, title: 'Quản lí người dùng' }
  }
]
export default routerAdmin
