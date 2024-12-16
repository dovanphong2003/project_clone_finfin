// Định nghĩa interface INFO_API
interface INFO_API {
    api: string;
    method: string;
    module: string;
}

// Định nghĩa type cho cấu trúc của ALL_PERMISSION
type ALL_PERMISSION_TYPE = {
    PERMISSION_BOOK: INFO_API[];
    PERMISSION_CATEGORY: INFO_API[];
    PERMISSION_AUTHOR: INFO_API[];
    PERMISSION_PUBLISHER: INFO_API[];
};

// Tạo một biến MODULES để lưu các module
export const MODULES = {
    BOOKS: 'Books',
    CATEGORIES: 'Categories',
    AUTHORS: 'Authors',
    PUBLISHERS: 'Publishers'
};

// Cấu trúc ALL_PERMISSION với các mảng tương ứng cho mỗi phần
export const ALL_PERMISSION: ALL_PERMISSION_TYPE = {
    PERMISSION_BOOK: [
        { api: '/api/Book', method: 'GET', module: MODULES.BOOKS },
        { api: '/api/Book', method: 'POST', module: MODULES.BOOKS },
        { api: '/api/Book', method: 'PUT', module: MODULES.BOOKS },
        { api: '/api/Book', method: 'DELETE', module: MODULES.BOOKS }
    ],
    PERMISSION_CATEGORY: [
        { api: '/api/Category', method: 'GET', module: MODULES.CATEGORIES },
        { api: '/api/Category', method: 'POST', module: MODULES.CATEGORIES },
        { api: '/api/Category', method: 'PUT', module: MODULES.CATEGORIES },
        { api: '/api/Category', method: 'DELETE', module: MODULES.CATEGORIES }
    ],
    PERMISSION_AUTHOR: [
        { api: '/api/Author', method: 'GET', module: MODULES.AUTHORS },
        { api: '/api/Author', method: 'POST', module: MODULES.AUTHORS },
        { api: '/api/Author', method: 'PUT', module: MODULES.AUTHORS },
        { api: '/api/Author', method: 'DELETE', module: MODULES.AUTHORS }
    ],
    PERMISSION_PUBLISHER: [
        { api: '/api/Publisher', method: 'GET', module: MODULES.PUBLISHERS },
        { api: '/api/Publisher', method: 'POST', module: MODULES.PUBLISHERS },
        { api: '/api/Publisher', method: 'PUT', module: MODULES.PUBLISHERS },
        { api: '/api/Publisher', method: 'DELETE', module: MODULES.PUBLISHERS }
    ]
};
