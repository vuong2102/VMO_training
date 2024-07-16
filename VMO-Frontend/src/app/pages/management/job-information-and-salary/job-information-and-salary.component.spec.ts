import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JobInformationAndSalaryComponent } from './job-information-and-salary.component';

describe('JobInformationAndSalaryComponent', () => {
  let component: JobInformationAndSalaryComponent;
  let fixture: ComponentFixture<JobInformationAndSalaryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ JobInformationAndSalaryComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(JobInformationAndSalaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
