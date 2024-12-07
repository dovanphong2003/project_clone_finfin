export interface IBook {
  id: string
  name: string
  image: string
  content: string
  price: string
  author: string
  category: string
  createdAt: string
  updatedAt: string
  promotion?: string
  status: 'active' | 'disable'
}

export interface IUser {
  name: string
  email: string
  age: string
  gender: string
  address?: string
  role: string
  createdAt: string
  updatedAt: string
}

export interface IRole {
  nameRole: string
  status: boolean
  description: string
  objPermission: string[]
  createdAt: string
  updatedAt: string
}

export interface IPermission {
  name: string
  api: string
  method: string
  module: string
  createdAt: string
  updatedAt: string
}

export interface ICoupon {
  coupon_id: string
  coupon_code: string
  discount: number
  quantity: number
  status: 'active' | 'expired' | 'disable'
  access: 'public' | 'private'
  expiry_date: Date
  createdAt: Date
  updatedAt: Date
}

export interface ICategory {
  category_id: number
  name: string
  parent_id: number | null | string
  createdAt: Date
  updatedAt: Date
  is_active: boolean
  isDeleted: boolean
}

export interface IAuthor {
  author_id: number
  name: string
  bio: string | null
  createdAt: Date
  updatedAt: Date | null
  isDeleted: boolean
}

export interface IPublisher {
  publisher_id: number
  name: string
  address: string | null
  contact_number: string | null
  email: string
  website: string | null
  createdAt: Date
  updatedAt: Date
  isDeleted: boolean
}
