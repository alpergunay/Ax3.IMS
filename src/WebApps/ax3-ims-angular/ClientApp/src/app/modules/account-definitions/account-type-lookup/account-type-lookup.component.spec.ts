import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AccountTypeLookupComponent } from './account-type-lookup.component';

describe('AccountTypeLookupComponent', () => {
  let component: AccountTypeLookupComponent;
  let fixture: ComponentFixture<AccountTypeLookupComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AccountTypeLookupComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AccountTypeLookupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
