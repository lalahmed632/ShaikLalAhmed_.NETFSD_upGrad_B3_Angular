import { Component, OnInit } from '@angular/core';
import { Contact } from '../../models/contact.model';
import { ContactService } from '../../services/contact.service';

@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.css']
})
export class ContactListComponent implements OnInit {
  contacts: Contact[] = [];
  loading = false;
  errorMessage = '';
  successMessage = '';

  constructor(private contactService: ContactService) {}

  ngOnInit(): void {
    this.loadContacts();
  }

  loadContacts(): void {
    this.loading = true;
    this.errorMessage = '';
    this.contactService.getContacts().subscribe({
      next: (data) => { this.contacts = data; this.loading = false; },
      error: (err) => { this.errorMessage = err.message; this.loading = false; }
    });
  }

  deleteContact(id: number): void {
    if (!confirm('Are you sure you want to delete this contact?')) return;
    this.contactService.deleteContact(id).subscribe({
      next: () => {
        this.contacts = this.contacts.filter(c => c.id !== id);
        this.successMessage = 'Contact deleted successfully.';
        setTimeout(() => this.successMessage = '', 3000);
      },
      error: (err) => { this.errorMessage = err.message; }
    });
  }
}
