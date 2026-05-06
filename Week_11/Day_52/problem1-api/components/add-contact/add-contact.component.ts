import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ContactService } from '../../services/contact.service';

@Component({
  selector: 'app-add-contact',
  templateUrl: './add-contact.component.html',
  styleUrls: ['./add-contact.component.css']
})
export class AddContactComponent {
  contactForm: FormGroup;
  loading = false;
  errorMessage = '';

  constructor(private fb: FormBuilder, private contactService: ContactService, private router: Router) {
    this.contactForm = this.fb.group({
      name:  ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phone: ['', [Validators.required, Validators.minLength(10)]]
    });
  }

  get f() { return this.contactForm.controls; }

  onSubmit(): void {
    if (this.contactForm.invalid) return;
    this.loading = true;
    this.contactService.addContact({ id: 0, ...this.contactForm.value }).subscribe({
      next: () => { this.loading = false; this.router.navigate(['/contacts']); },
      error: (err) => { this.errorMessage = err.message; this.loading = false; }
    });
  }
}
