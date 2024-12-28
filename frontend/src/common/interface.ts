import { boolean, string } from "@vueform/vueform"

export interface ICategoryInfo {
  category_id: number;
  category_name: string;
}

export interface IAuthorInfo {
  author_id: number;
  author_name: string;
}

export interface IPublisherInfo {
  publisher_id: number;
  publisher_name: string;
}

export interface IBookExtended {
  book_id: number;
  title: string;
  imageUrl: string;
  price: number;
  category: ICategoryInfo;  // Thay đổi tên từ infoCategory thành category
  author: IAuthorInfo;      // Thay đổi tên từ author thành authorInfo
  publisher: IPublisherInfo; // Thay đổi tên từ publisher thành publisherInfo
  stock_quantity: number;
  content_data?: string;
  status: boolean;
  ReceiveDate: Date;
  updatedAt?: Date;
  isDeleted: boolean;
  createdBy: number;
  updatedBy?: number;
  deleteBy?: number;
}

export interface ISelectOption {
  id: number;
  name: string;
}

export interface ISelectOptionsOfBook {
  authors: ISelectOption[];
  categories: ISelectOption[];
  publishers: ISelectOption[];
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
  role_id:number
  name: string
  status: boolean
  description: string
  arrIdPermission: number[]
  createdAt: Date
  updatedAt?: Date
  isDeleted:boolean
}

export interface IPermission {
  permission_id: number
  name: string
  path: string
  method: string
  module: string
  description:string
  createdAt: Date
  updatedAt?: Date
  isDeleted:boolean
  createdBy: number;
  updatedBy?: number;
  deleteBy?: number;
}

export interface ICoupon {
  coupon_id: string
  coupon_code: string
  discount: number
  quantity: number
  status: 'active' | 'expired' | 'disable'
  access: '' | 'private'
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
