import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BuyInvestmentToolComponent } from './buy-investment-tool.component';

describe('BuyInvestmentToolComponent', () => {
  let component: BuyInvestmentToolComponent;
  let fixture: ComponentFixture<BuyInvestmentToolComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BuyInvestmentToolComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BuyInvestmentToolComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
