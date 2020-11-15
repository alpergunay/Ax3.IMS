import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StoreBranchesComponent } from './store-branches.component';

describe('StoreBranchesComponent', () => {
  let component: StoreBranchesComponent;
  let fixture: ComponentFixture<StoreBranchesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StoreBranchesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StoreBranchesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
