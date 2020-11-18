import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StoreBranchLookupComponent } from './store-branch-lookup.component';

describe('StoreBranchLookupComponent', () => {
  let component: StoreBranchLookupComponent;
  let fixture: ComponentFixture<StoreBranchLookupComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StoreBranchLookupComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StoreBranchLookupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
