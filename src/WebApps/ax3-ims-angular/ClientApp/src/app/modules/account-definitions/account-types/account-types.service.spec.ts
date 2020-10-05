import { TestBed } from '@angular/core/testing';

import { AccountTypesService } from './account-types.service';

describe('AccountTypesService', () => {
  let service: AccountTypesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AccountTypesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
