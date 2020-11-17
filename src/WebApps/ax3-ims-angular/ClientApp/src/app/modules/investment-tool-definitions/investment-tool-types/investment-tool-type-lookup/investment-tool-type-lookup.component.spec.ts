import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InvestmentToolTypeLookupComponent } from './investment-tool-type-lookup.component';

describe('InvestmentToolTypeLookupComponent', () => {
  let component: InvestmentToolTypeLookupComponent;
  let fixture: ComponentFixture<InvestmentToolTypeLookupComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InvestmentToolTypeLookupComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InvestmentToolTypeLookupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
