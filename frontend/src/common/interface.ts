export interface IBook {
  id: string
  name: string
  image: string
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
