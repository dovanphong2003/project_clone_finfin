export const createdIdAuto: () => number = () => {
  let result = 0
  for (let i = 0; i < 10; i++) {
    result = result * 10 + Math.floor(Math.random() * 10) // Tạo số ngẫu nhiên từ 0 đến 9 và ghép lại
  }
  return result
}
