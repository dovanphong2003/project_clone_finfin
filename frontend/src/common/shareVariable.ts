// Tạo một biến MODULES để lưu các module
export const MODULES = {
    BOOKS: 'Books',
    CATEGORIES: 'Categories',
    AUTHORS: 'Authors',
    PUBLISHERS: 'Publishers'
} as const; // Chú ý thêm 'as const' để MODULES trở thành một kiểu literal

// Định nghĩa type cho từng permission (API)
type DataPermission = {
    type: 'GET' | 'POST' | 'PUT' | 'DELETE';
    api: string;
    des: string;
};

// Định nghĩa type cho cấu trúc objectDataAllPermission
type ObjectDataAllPermission = {
    permissionName: keyof typeof MODULES; // Chỉ nhận các giá trị trong MODULES
    dataPermission: DataPermission[]; // Mảng các API
};

// Cấu trúc dữ liệu
// Tạo một hàm để sinh chuỗi số ngẫu nhiên 5 chữ số
const generateRandomId = (): number => {
    return Math.floor(10000 + Math.random() * 90000); // Sinh số ngẫu nhiên 5 chữ số
  };
  
  // Tạo cấu trúc dữ liệu với thuộc tính id
export  const AllPermission: ObjectDataAllPermission[] = [
    {
      permissionName: 'BOOKS',
      dataPermission: [
        {
          type: 'GET',
          api: '/api/Book',
          des: 'get book data'
        },
        {
          type: 'POST',
          api: '/api/Book',
          des: 'create new book'
        },
        {
          type: 'PUT',
          api: '/api/Book',
          des: 'update book data'
        },
        {
          type: 'DELETE',
          api: '/api/Book',
          des: 'delete book'
        }
      ]
    },
    {
      permissionName: 'CATEGORIES',
      dataPermission: [
        {
          type: 'GET',
          api: '/api/Category',
          des: 'get category data'
        },
        {
          type: 'POST',
          api: '/api/Category',
          des: 'create new category'
        },
        {
          type: 'PUT',
          api: '/api/Category',
          des: 'update category data'
        },
        {
          type: 'DELETE',
          api: '/api/Category',
          des: 'delete category'
        }
      ]
    },
    {
      permissionName: 'AUTHORS',
      dataPermission: [
        {
          type: 'GET',
          api: '/api/Author',
          des: 'get author data'
        },
        {
          type: 'POST',
          api: '/api/Author',
          des: 'create new author'
        },
        {
          type: 'PUT',
          api: '/api/Author',
          des: 'update author data'
        },
        {
          type: 'DELETE',
          api: '/api/Author',
          des: 'delete author'
        }
      ]
    },
    {
      permissionName: 'PUBLISHERS',
      dataPermission: [
        {
          type: 'GET',
          api: '/api/Publisher',
          des: 'get publisher data'
        },
        {
          type: 'POST',
          api: '/api/Publisher',
          des: 'create new publisher'
        },
        {
          type: 'PUT',
          api: '/api/Publisher',
          des: 'update publisher data'
        },
        {
          type: 'DELETE',
          api: '/api/Publisher',
          des: 'delete publisher'
        }
      ]
    }
  ];
  
