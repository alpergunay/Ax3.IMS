import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddInvestmentToolComponent } from './add-investment-tool.component';

describe('AddInvestmentToolComponent', () => {
  let component: AddInvestmentToolComponent;
  let fixture: ComponentFixture<AddInvestmentToolComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddInvestmentToolComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddInvestmentToolComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
