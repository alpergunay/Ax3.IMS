import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StoreTypeLookupComponent } from './store-type-lookup.component';

describe('StoreTypeLookupComponent', () => {
  let component: StoreTypeLookupComponent;
  let fixture: ComponentFixture<StoreTypeLookupComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StoreTypeLookupComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StoreTypeLookupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
