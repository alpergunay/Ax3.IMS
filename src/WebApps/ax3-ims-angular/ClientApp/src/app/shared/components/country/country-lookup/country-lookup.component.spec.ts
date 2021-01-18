import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CountryLookupComponent } from './country-lookup.component';

describe('CountryLookupComponent', () => {
  let component: CountryLookupComponent;
  let fixture: ComponentFixture<CountryLookupComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CountryLookupComponent ]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CountryLookupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
