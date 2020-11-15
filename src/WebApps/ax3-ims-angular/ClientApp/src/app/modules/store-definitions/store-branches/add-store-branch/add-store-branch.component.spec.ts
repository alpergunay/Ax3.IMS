import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddStoreBranchComponent } from './add-store-branch.component';

describe('AddStoreBranchComponent', () => {
  let component: AddStoreBranchComponent;
  let fixture: ComponentFixture<AddStoreBranchComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddStoreBranchComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddStoreBranchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
