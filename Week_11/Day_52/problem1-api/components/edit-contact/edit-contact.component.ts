import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ContactService } from '../../services/contact.service';

@Component({
  selector: 'app-edit-contact',
  templateUrl: './edit-contact.component.html',
  styleUrls: ['./edit-contact.component.css']
})
export class EditContactComponent implements OnInit {
  contactForm: FormGroup;
  contactId!: number;
  loading = false;
  errorMessage = '';

  constructor(private fb: FormBuilder, private contactService: ContactService,
              private route: ActivatedRoute, private router: Router) {
    this.contactForm = this.fb.group({
      name:  ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phone: ['', [Validators.required, Validators.minLength(10)]]
    });
  }

  ngOnInit(): void {
    this.contactId = Number(this.route.snapshot.paramMap.get('id'));
    this.contactService.getContactById(this.contactId).subscribe({
      next: (data) => this.contactForm.patchValue(data),
      error: (err) => this.errorMessage = err.message
    });
  }

  get f() { return this.contactForm.controls; }

  onSubmit(): void {
    if (this.contactForm.invalid) return;
    this.loading = true;
    this.contactService.updateContact({ id: this.contactId, ...this.contactForm.value }).subscribe({
      next: () => { this.loading = false; this.router.navigate(['/contacts']); },
      error: (err) => { this.errorMessage = err.message; this.loading = false; }
    });
  }
}
