import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'custom'
})
export class CustomPipe implements PipeTransform {
   // {{ yai | custom}} => lek
  transform(value: String, ...args: any[]): any {
    return 'lek'
  }

}
