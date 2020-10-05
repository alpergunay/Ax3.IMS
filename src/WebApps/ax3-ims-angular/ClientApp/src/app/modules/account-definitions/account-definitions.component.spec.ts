import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AccountDefinitionsComponent } from './account-definitions.component';

describe('AccountDefinitionsComponent', () => {
  let component: AccountDefinitionsComponent;
  let fixture: ComponentFixture<AccountDefinitionsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AccountDefinitionsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AccountDefinitionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
