import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InvestmentToolDefinitionsComponent } from './investment-tool-definitions.component';

describe('InvestmentToolDefinitionsComponent', () => {
  let component: InvestmentToolDefinitionsComponent;
  let fixture: ComponentFixture<InvestmentToolDefinitionsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InvestmentToolDefinitionsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InvestmentToolDefinitionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
