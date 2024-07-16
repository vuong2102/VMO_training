import { TestBed } from '@angular/core/testing';
import { JobInformationAndSalaryService } from './job-information-and-salary.service';

describe('JobInformationAndSalaryService', () => {
  let service: JobInformationAndSalaryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(JobInformationAndSalaryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
