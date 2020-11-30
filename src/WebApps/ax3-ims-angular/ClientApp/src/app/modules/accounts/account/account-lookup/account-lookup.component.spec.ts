import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AccountLookupComponent } from './account-lookup.component';

describe('AccountLookupComponent', () => {
  let component: AccountLookupComponent;
  let fixture: ComponentFixture<AccountLookupComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AccountLookupComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AccountLookupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
