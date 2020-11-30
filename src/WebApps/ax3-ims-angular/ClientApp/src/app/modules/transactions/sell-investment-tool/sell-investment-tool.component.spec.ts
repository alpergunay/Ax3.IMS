import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SellInvestmentToolComponent } from './sell-investment-tool.component';

describe('SellInvestmentToolComponent', () => {
  let component: SellInvestmentToolComponent;
  let fixture: ComponentFixture<SellInvestmentToolComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SellInvestmentToolComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SellInvestmentToolComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
