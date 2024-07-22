import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'vndCurrency' })
export class VndCurrencyPipe implements PipeTransform {
  transform(value: number): string {
    if (isNaN(value)) {
      return 'N/A';
    }

    let valueStr = value.toString();
    let [integerPart, decimalPart] = valueStr.split('.');
    integerPart = integerPart.replace(/\B(?=(\d{3})+(?!\d))/g, ',');

    if (decimalPart && parseInt(decimalPart) !== 0) {
      return `${integerPart}.${decimalPart} ₫`;
    }
    return `${integerPart} ₫`;
  }

  formatterVND(value: number): string {
    return `${value}`.replace(/\B(?=(\d{3})+(?!\d))/g, '.');
  }
}
