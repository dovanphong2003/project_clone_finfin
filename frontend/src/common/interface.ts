export interface IBook {
  id: string
  name: string
  image: string
  price: string
  author: string
  category: string
  createdAt: string
  updatedAt: string
  promotion?: string // Thuộc tính promotion có thể không được xác định, nên sử dụng dấu ?
  status: 'active' | 'disable' // Thuộc tính status chỉ có thể là 'active' hoặc 'disable'
}
