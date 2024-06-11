import { useLoading } from 'vue-loading-overlay'
import { toast } from 'vue3-toastify'
const $loading = useLoading({
  // options
})
export const handleLoadingNotication = async (
  content: string,
  timeMili: number,
  position: string
) => {
  const loader = $loading.show({})
  await setTimeout(() => {
    loader.hide()
    toast(content, {
      type: 'success',
      position: position ? position : 'bottom-center',
      dangerouslyHTMLString: true
    })
  }, timeMili)
}
export const handleLoading = async (timeMili: number) => {
  const loader = $loading.show({})
  await setTimeout(() => {
    loader.hide()
  }, timeMili)
}
