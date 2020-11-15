import { TestBed } from '@angular/core/testing';

import { StoreBranchService } from './store-branch.service';

describe('StoreBranchService', () => {
  let service: StoreBranchService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StoreBranchService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
