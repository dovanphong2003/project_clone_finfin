import HomeView from '../views/admin/HomeView.vue'
import PageNotFound from '../views/PageNotFound.vue'
import ManagerBook from '../views/admin/ManagerBook.vue'
import ManagerUser from '../views/admin/ManagerUser.vue'
import ManagerRole from '@/views/admin/ManagerRole.vue'
import ManagerPermission from '@/views/admin/ManagerPermission.vue'
import ManagerCoupon from '@/views/admin/ManagerCoupon.vue'
import ManagerPublisher from '@/views/admin/ManagerPublisher.vue'
import ManagerAuthor from '@/views/admin/ManagerAuthor.vue'
import ManagerCategory from '@/views/admin/ManagerCategory.vue'
import ManagerBuyBook from '@/views/admin/ManagerBuyBook.vue'
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
    path: '/admin-buy_book',
    components: { routeAdmin: ManagerBuyBook, routeCustomer: PageNotFound },
    name: 'ManagerBuyBook',
    meta: { checkAuth: true, title: 'Quản lí bán sách' }
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
  },
  {
    path: '/admin-coupon',
    components: { routeAdmin: ManagerCoupon, routeCustomer: PageNotFound },
    name: 'ManagerCoupon',
    meta: { checkAuth: true, title: 'Quản lí danh sách mã giảm giá' }
  },
  {
    path: '/admin-publisher',
    components: { routeAdmin: ManagerPublisher, routeCustomer: PageNotFound },
    name: 'ManagerPublisher',
    meta: { checkAuth: true, title: 'Quản lí danh sách nhà xuất bản' }
  },
  {
    path: '/admin-author',
    components: { routeAdmin: ManagerAuthor, routeCustomer: PageNotFound },
    name: 'ManagerAuthor',
    meta: { checkAuth: true, title: 'Quản lí danh sách tác giả' }
  },
  {
    path: '/admin-category',
    components: { routeAdmin: ManagerCategory, routeCustomer: PageNotFound },
    name: 'ManagerCategory',
    meta: { checkAuth: true, title: 'Quản lí danh sách chủ đề' }
  }
]
export default routerAdmin
