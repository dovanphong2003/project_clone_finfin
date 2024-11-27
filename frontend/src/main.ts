import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import { createPinia } from 'pinia'
import './common/interceptionRoute'
import Vue3EasyDataTable from 'vue3-easy-data-table'
import 'vue3-easy-data-table/dist/style.css'
import Vueform from '@vueform/vueform'
import vueformConfig from '../vueform.config'
import Vue3Toastify, { type ToastContainerOptions } from 'vue3-toastify'
import { LoadingPlugin } from 'vue-loading-overlay'
import 'vue-loading-overlay/dist/css/index.css'

// config axios

const pinia = createPinia()
const app = createApp(App)

app.component('EasyDataTable', Vue3EasyDataTable)
app.use(pinia)
app.use(router)
app.use(Vueform, vueformConfig)
app.use(Vue3Toastify, {
  autoClose: 3000
} as ToastContainerOptions)
app.use(LoadingPlugin)
app.mount('#app')
