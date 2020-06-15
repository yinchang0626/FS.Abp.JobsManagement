import { async, TestBed } from '@angular/core/testing';
import { JobsManagementModule } from './jobs-management.module';

describe('JobsManagementModule', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [JobsManagementModule]
    }).compileComponents();
  }));

  it('should create', () => {
    expect(JobsManagementModule).toBeDefined();
  });
});
