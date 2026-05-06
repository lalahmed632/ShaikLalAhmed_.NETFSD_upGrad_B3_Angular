import { Injectable } from '@angular/core';
import { Contact } from '../models/contact.model';

@Injectable({ providedIn: 'root' })
export class ContactService {
  private contacts: Contact[] = [
    { id: 1, name: 'Alice Johnson', email: 'alice@example.com', phone: '9876543210' },
    { id: 2, name: 'Bob Smith', email: 'bob@example.com', phone: '8765432109' },
    { id: 3, name: 'Carol White', email: 'carol@example.com', phone: '7654321098' },
    { id: 4, name: 'David Brown', email: 'david@example.com', phone: '6543210987' },
    { id: 5, name: 'Eve Davis', email: 'eve@example.com', phone: '5432109876' },
  ];

  getContacts(): Contact[] {
    return this.contacts;
  }

  getContactById(id: number): Contact | undefined {
    return this.contacts.find(c => c.id === id);
  }

  addContact(contact: Contact): void {
    contact.id = this.contacts.length + 1;
    this.contacts.push(contact);
  }
}
