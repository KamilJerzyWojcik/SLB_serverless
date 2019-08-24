import { TestBed } from '@angular/core/testing';

import { AppServerlessService } from './app-serverless.service';

describe('AppServerlessService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AppServerlessService = TestBed.get(AppServerlessService);
    expect(service).toBeTruthy();
  });
});
