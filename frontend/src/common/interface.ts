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
  ISBN?:string;
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

// interface for buy book
// Interface cho thông tin người bán
export interface InfoSeller {
  user_id: number; // ID của người bán
  name: string; // Tên người bán
  email: string; // Email người bán
  age: number; // Tuổi người bán
  gender: string; // Giới tính
  role_id: number; // Vai trò của người bán
}

// Interface cho thông tin đơn hàng
export interface IOrder {
  order_id: number; // ID của đơn hàng
  user_id: number | null; // ID người dùng (có thể null)
  status: string; // Trạng thái đơn hàng
  order_date: string; // Ngày đặt hàng (ISO 8601 format)
  createdAt: string; // Ngày tạo đơn hàng
  updatedAt: string | null; // Ngày cập nhật đơn hàng (có thể null)
  isDeleted: boolean; // Cờ đánh dấu đã xóa
  cart_id: number | null; // ID giỏ hàng (có thể null)
  shippingAddress: string; // Địa chỉ giao hàng
  paymentMethod: string; // Phương thức thanh toán
  seller: number; // ID người bán
  infoSeller: InfoSeller; // Thông tin người bán
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
user_id:number;
name:string;
email:string;
password:string;
age:number;
gender?:string;
address?:string;
role_id:number;
role_name:string;
refreshToken:string;
createdAt:Date;
updatedAt:Date;
isDeleted:boolean;
createdBy:number;
updatedBy:number;
deleteBy:number;
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
