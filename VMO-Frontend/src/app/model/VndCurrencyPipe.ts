import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'vndCurrency' })
export class VndCurrencyPipe implements PipeTransform {
  transform(value: number): string {
    if (isNaN(value)) {
      return 'N/A';
    }

    // Làm tròn giá trị và chuyển sang chuỗi
    let valueStr = value.toString();

    // Tách phần nguyên và phần thập phân
    let [integerPart, decimalPart] = valueStr.split('.');

    // Thêm dấu phẩy cho phần nguyên
    integerPart = integerPart.replace(/\B(?=(\d{3})+(?!\d))/g, ',');

    // Nếu có phần thập phân và khác 0, thêm vào chuỗi kết quả
    if (decimalPart && parseInt(decimalPart) !== 0) {
      return `${integerPart}.${decimalPart} ₫`;
    }

    // Nếu không có phần thập phân hoặc phần thập phân bằng 0, chỉ trả về phần nguyên
    return `${integerPart} ₫`;
  }
}
