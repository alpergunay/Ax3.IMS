import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InvestmentToolLookupComponent } from './investment-tool-lookup.component';

describe('InvestmentToolLookupComponent', () => {
  let component: InvestmentToolLookupComponent;
  let fixture: ComponentFixture<InvestmentToolLookupComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InvestmentToolLookupComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InvestmentToolLookupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
