export const removeMatchingFields = (obj1: any, obj2: any) => {
  // Hàm đệ quy để so sánh các object sâu (so sánh mọi trường hợp, kể cả các object lồng nhau)
  const deepEqual = (val1: any, val2: any): boolean => {
    if (val1 === val2) return true;  // So sánh trực tiếp nếu giống nhau (primitive types)
    if (typeof val1 !== 'object' || typeof val2 !== 'object') return false;  // Nếu một trong hai không phải object
    if (val1 === null || val2 === null) return false;  // Nếu một trong hai là null, không thể so sánh

    // So sánh số lượng keys của cả hai object
    const keys1 = Object.keys(val1);
    const keys2 = Object.keys(val2);
    if (keys1.length !== keys2.length) return false;  // Nếu số lượng keys khác nhau, không bằng nhau

    // So sánh từng key-value trong object
    for (const key of keys1) {
      if (!keys2.includes(key)) return false;  // Nếu key không có trong object2, không bằng nhau
      if (!deepEqual(val1[key], val2[key])) return false;  // Đệ quy so sánh các giá trị (nếu là object)
    }

    return true;  // Nếu tất cả các trường hợp trên không trả về false, nghĩa là chúng giống nhau
  };

  // Duyệt qua các key và value trong obj2
  Object.keys(obj2).forEach((key) => {
    if (Object.prototype.hasOwnProperty.call(obj1, key) && deepEqual(obj1[key], obj2[key])) {
      // Nếu trường trong obj1 và obj2 giống nhau (so sánh sâu), xóa trường đó khỏi obj1
      delete obj1[key];
    }
  });

  return obj1;  // Trả về object1 sau khi đã loại bỏ các trường giống nhau
};
