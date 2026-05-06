import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';
import { ContactService } from '../../services/contact.service';

@Component({
  selector: 'app-contact-list',
  template: `
    <input [formControl]="searchControl" placeholder="Search contacts" />
    <ul>
      <li *ngFor="let contact of contacts$ | async">
        {{contact.name}} - {{contact.email}}
      </li>
    </ul>
  `
})
export class ContactListComponent implements OnInit {
  contacts$ = this.contactService.getContacts();
  searchControl = new FormControl('');

  constructor(private contactService: ContactService) {}

  ngOnInit() {
    this.searchControl.valueChanges.pipe(
      debounceTime(300),
      distinctUntilChanged(),
      switchMap(() => this.contactService.getContacts())
    ).subscribe(data => this.contacts$ = data);
  }
}
