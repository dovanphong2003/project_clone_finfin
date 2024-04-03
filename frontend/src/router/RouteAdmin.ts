import HomeView from '../views/admin/HomeView.vue'
// if route admin --- checkAuth = true, check role = admin
const routerAdmin = [
  {
    path: '/admin-home',
    component: HomeView,
    name: 'AdminHome',
    meta: { roleUser: 'admin', checkAuth: true }
  }
]
export default routerAdmin
