import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactListComponent } from '../problem1-api/components/contact-list/contact-list.component';
import { ContactDetailComponent } from '../problem1-api/components/contact-detail/contact-detail.component';
import { AddContactComponent } from '../problem1-api/components/add-contact/add-contact.component';
import { EditContactComponent } from '../problem1-api/components/edit-contact/edit-contact.component';
import { AuthGuard } from '../problem3-guard/auth.guard';

const routes: Routes = [
  { path: '', redirectTo: 'contacts', pathMatch: 'full' },
  { path: 'contacts', component: ContactListComponent },
  { path: 'add-contact', component: AddContactComponent, canActivate: [AuthGuard] },
  { path: 'contact/:id', component: ContactDetailComponent, canActivate: [AuthGuard] },
  { path: 'edit-contact/:id', component: EditContactComponent, canActivate: [AuthGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
