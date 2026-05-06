import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ContactService } from '../../services/contact.service';
import { Contact } from '../../models/contact.model';

@Component({
  selector: 'app-add-contact',
  templateUrl: './add-contact.component.html',
  styleUrls: ['./add-contact.component.css']
})
export class AddContactComponent {
  // --- Reactive Form ---
  contactForm: FormGroup;
  successMessage: string = '';

  constructor(
    private fb: FormBuilder,
    private contactService: ContactService,
    private router: Router
  ) {
    this.contactForm = this.fb.group({
      name:  ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      phone: ['', [Validators.required, Validators.minLength(10)]]
    });
  }

  get f() { return this.contactForm.controls; }

  onSubmit(): void {
    if (this.contactForm.invalid) return;
    const newContact: Contact = {
      id: 0,
      name: this.contactForm.value.name,
      email: this.contactForm.value.email,
      phone: this.contactForm.value.phone
    };
    this.contactService.addContact(newContact);
    this.successMessage = `Contact "${newContact.name}" added successfully!`;
    this.contactForm.reset();
    setTimeout(() => this.router.navigate(['/contacts']), 1500);
  }
}
