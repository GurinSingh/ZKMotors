import { TestBed } from '@angular/core/testing';

import { UserManagerService } from './userManager.service';

describe('AuthenticateService', () => {
  let service: UserManagerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UserManagerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
