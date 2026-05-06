import { Component } from '@angular/core';
import { Contact } from '../../models/contact.model';

@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.css']
})
export class ContactListComponent {
  searchTerm: string = '';
  showAll: boolean = false;

  contacts: Contact[] = [
    { contactId: 1, name: 'alice johnson', email: 'alice@example.com', phone: '9876543210', isActive: true },
    { contactId: 2, name: 'bob smith', email: 'bob@example.com', phone: '8765432109', isActive: false },
    { contactId: 3, name: 'carol white', email: 'carol@example.com', phone: '7654321098', isActive: true },
    { contactId: 4, name: 'david brown', email: 'david@example.com', phone: '6543210987', isActive: true },
    { contactId: 5, name: 'eve davis', email: 'eve@example.com', phone: '5432109876', isActive: false },
    { contactId: 6, name: 'frank miller', email: 'frank@example.com', phone: '4321098765', isActive: true },
    { contactId: 7, name: 'grace wilson', email: 'grace@example.com', phone: '3210987654', isActive: false },
    { contactId: 8, name: 'henry moore', email: 'henry@example.com', phone: '2109876543', isActive: true },
    { contactId: 9, name: 'isla taylor', email: 'isla@example.com', phone: '1098765432', isActive: true },
    { contactId: 10, name: 'jack anderson', email: 'jack@example.com', phone: '0987654321', isActive: false },
  ];

  get displayCount(): number {
    return this.showAll ? this.contacts.length : 5;
  }

  toggleStatus(contact: Contact): void {
    contact.isActive = !contact.isActive;
  }

  toggleShowMore(): void {
    this.showAll = !this.showAll;
  }
}
