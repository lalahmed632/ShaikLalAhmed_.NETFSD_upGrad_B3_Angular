import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `
    <nav class="topnav">
      <span class="brand">📋 Contact Manager</span>
      <a routerLink="/contacts" routerLinkActive="active">Contacts</a>
      <a routerLink="/add-contact" routerLinkActive="active">Add Contact</a>
    </nav>
    <router-outlet></router-outlet>
  `,
  styles: [`
    .topnav { background:#2c3e50; padding:12px 24px; display:flex; align-items:center; gap:20px; }
    .brand { color:white; font-weight:bold; font-size:17px; margin-right:auto; }
    .topnav a { color:#bdc3c7; text-decoration:none; font-size:15px; }
    .topnav a.active, .topnav a:hover { color:white; }
  `]
})
export class AppComponent {}
