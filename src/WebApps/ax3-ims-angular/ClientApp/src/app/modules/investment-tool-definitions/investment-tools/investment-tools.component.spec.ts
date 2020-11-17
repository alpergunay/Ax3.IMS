import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InvestmentToolsComponent } from './investment-tools.component';

describe('InvestmentToolsComponent', () => {
  let component: InvestmentToolsComponent;
  let fixture: ComponentFixture<InvestmentToolsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InvestmentToolsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InvestmentToolsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
