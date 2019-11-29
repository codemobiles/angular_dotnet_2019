import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'custom'
})
export class CustomPipe implements PipeTransform {
   // {{ 0.00 | custom}} => ฿x.xx
  transform(value: String, ...args: any[]): any {
    return '฿' + value.replace(/,/g, '').toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
  }
}
