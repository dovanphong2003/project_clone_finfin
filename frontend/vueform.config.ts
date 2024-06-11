import en from '@vueform/vueform/locales/en'
import vueform from '@vueform/vueform/dist/vueform'
import { defineConfig } from '@vueform/vueform'

// You might place these anywhere else in your project
import '@vueform/vueform/dist/vueform.nodark.css'

export default defineConfig({
  classHelpers: true,
  theme: vueform,
  locales: { en },
  locale: 'en'
})
