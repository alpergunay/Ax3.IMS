import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CurrencyLookupComponent } from './currency-lookup.component';

describe('CurrencyLookupComponent', () => {
  let component: CurrencyLookupComponent;
  let fixture: ComponentFixture<CurrencyLookupComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CurrencyLookupComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CurrencyLookupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
