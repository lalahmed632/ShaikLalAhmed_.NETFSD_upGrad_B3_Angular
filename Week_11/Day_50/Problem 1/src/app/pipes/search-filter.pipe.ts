import { Pipe, PipeTransform } from '@angular/core';
import { Contact } from '../models/contact.model';

@Pipe({ name: 'searchFilter', pure: false })
export class SearchFilterPipe implements PipeTransform {
  transform(contacts: Contact[], searchTerm: string): Contact[] {
    if (!contacts || !searchTerm) return contacts;
    const term = searchTerm.toLowerCase();
    return contacts.filter(
      c =>
        c.name.toLowerCase().includes(term) ||
        c.email.toLowerCase().includes(term)
    );
  }
}
