// src/services/axiosService.ts
import axios from 'axios'

const axiosInstance = axios.create({
  baseURL: 'https://localhost:7087', // Thay đổi baseURL theo API của bạn
  headers: {
    'Content-Type': 'application/json'
  }
})

export default axiosInstance
