import { TestBed } from '@angular/core/testing';

import { VehicleStatusService } from './vehicle-status.service';

describe('VehicleStatusService', () => {
  let service: VehicleStatusService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VehicleStatusService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
