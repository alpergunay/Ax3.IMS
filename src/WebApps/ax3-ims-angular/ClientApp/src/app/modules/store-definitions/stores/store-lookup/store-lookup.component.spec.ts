import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StoreLookupComponent } from './store-lookup.component';

describe('StoreLookupComponent', () => {
  let component: StoreLookupComponent;
  let fixture: ComponentFixture<StoreLookupComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StoreLookupComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StoreLookupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
