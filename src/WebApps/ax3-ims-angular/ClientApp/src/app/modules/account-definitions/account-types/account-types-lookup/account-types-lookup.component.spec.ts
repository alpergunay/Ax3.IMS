import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AccountTypesLookupComponent } from './account-types-lookup.component';

describe('AccountTypesLookupComponent', () => {
  let component: AccountTypesLookupComponent;
  let fixture: ComponentFixture<AccountTypesLookupComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AccountTypesLookupComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AccountTypesLookupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
