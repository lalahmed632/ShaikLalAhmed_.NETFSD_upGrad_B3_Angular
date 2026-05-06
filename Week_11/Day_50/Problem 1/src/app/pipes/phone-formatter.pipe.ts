import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'phoneFormatter' })
export class PhoneFormatterPipe implements PipeTransform {
  transform(value: string): string {
    if (!value) return '';
    const cleaned = value.replace(/\D/g, '');
    if (cleaned.length === 10) {
      return `${cleaned.slice(0, 3)}-${cleaned.slice(3, 6)}-${cleaned.slice(6)}`;
    }
    return value;
  }
}
