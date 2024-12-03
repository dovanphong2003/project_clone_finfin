export const removeMatchingFields = (obj1: any, obj2: any) => {
  // Duyệt qua các key và value trong object2
  Object.keys(obj2).forEach((key) => {
    if (Object.prototype.hasOwnProperty.call(obj1, key) && obj1[key] === obj2[key]) {
      // Nếu trường trong object1 và object2 giống nhau, xóa trường đó khỏi object1
      delete obj1[key]
    }
  })

  return obj1
}
