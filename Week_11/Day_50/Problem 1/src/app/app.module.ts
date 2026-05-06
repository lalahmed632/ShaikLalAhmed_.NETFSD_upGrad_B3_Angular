import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { ContactListComponent } from './components/contact-list/contact-list.component';
import { PhoneFormatterPipe } from './pipes/phone-formatter.pipe';
import { StatusPipe } from './pipes/status.pipe';
import { SearchFilterPipe } from './pipes/search-filter.pipe';

@NgModule({
  declarations: [
    AppComponent,
    ContactListComponent,
    PhoneFormatterPipe,
    StatusPipe,
    SearchFilterPipe
  ],
  imports: [BrowserModule, FormsModule],
  bootstrap: [AppComponent]
})
export class AppModule {}
