import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ContactListComponent } from '../components/contact-list/contact-list.component';

describe('ContactListComponent', () => {
  let component: ContactListComponent;
  let fixture: ComponentFixture<ContactListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ContactListComponent]
    });
    fixture = TestBed.createComponent(ContactListComponent);
    component = fixture.componentInstance;
  });

  it('should create component', () => {
    expect(component).toBeTruthy();
  });
});
