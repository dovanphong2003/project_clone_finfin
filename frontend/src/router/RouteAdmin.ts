import HomeView from '../views/admin/HomeView.vue'
import PageNotFound from '../views/PageNotFound.vue'
import ManagerBook from '../views/admin/ManagerBook.vue'
import ManagerUser from '../views/admin/ManagerUser.vue'
import ManagerRole from '@/views/admin/ManagerRole.vue'
import ManagerPermission from '@/views/admin/ManagerPermission.vue'
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
  },
  {
    path: '/admin-role',
    components: { routeAdmin: ManagerRole, routeCustomer: PageNotFound },
    name: 'ManagerRole',
    meta: { checkAuth: true, title: 'Quản lí vai trò người dùng' }
  },
  {
    path: '/admin-permission',
    components: { routeAdmin: ManagerPermission, routeCustomer: PageNotFound },
    name: 'ManagerPermission',
    meta: { checkAuth: true, title: 'Quản lí danh sách quyền hạn' }
  }
]
export default routerAdmin
