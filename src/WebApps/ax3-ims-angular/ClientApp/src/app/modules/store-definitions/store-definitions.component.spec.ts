import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StoreDefinitionsComponent } from './store-definitions.component';

describe('StoreDefinitionsComponent', () => {
  let component: StoreDefinitionsComponent;
  let fixture: ComponentFixture<StoreDefinitionsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StoreDefinitionsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StoreDefinitionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
