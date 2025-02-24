import en from '@vueform/vueform/locales/en'
import vueform from '@vueform/vueform/dist/vueform'
import { defineConfig } from '@vueform/vueform'
import '@vueform/vueform/dist/vueform.nodark.css'
import axios from 'axios'

axios.defaults.headers.post = {
  'Content-Type': 'application/json'
}
export default defineConfig({
  classHelpers: true,
  theme: vueform,
  locales: { en },
  locale: 'en',
  axios
})