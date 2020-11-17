import { TestBed } from '@angular/core/testing';

import { InvestmentToolsService } from './investment-tools.service';

describe('InvestmentToolsService', () => {
  let service: InvestmentToolsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(InvestmentToolsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
