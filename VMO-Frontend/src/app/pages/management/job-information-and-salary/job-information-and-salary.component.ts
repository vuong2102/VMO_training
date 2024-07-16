import { Component, OnInit, NgModule } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AppComponent } from 'src/app/app.component';
import { DepartmentService } from 'src/app/services/category/department/department.service';
import { JobInformationAndSalaryService } from '../../../services/management/Job-Information-and-Salary/job-information-and-salary.service';
import { ResultCode } from 'src/share/model/ResultCode';
import { SalaryProfile } from 'src/app/model/SalaryProfile';
import { SalaryProfileDto } from 'src/app/model/Dto/SalaryProfileDto';
import { mapToSalaryProfile } from 'src/app/model/Mapper/SalaryProfileMapper';
import { Employee } from '../../../model/Employee';
import { ExcuteResult } from 'src/share/model/ExcuteResult';
import { EmployeeProfileService } from 'src/app/services/management/employee-profile/employee-profile.service';
import { ActiveStatus } from '../../../../share/model/ActiveStatus';
import { Department } from 'src/app/model/Department ';
import { TitleService } from 'src/app/services/category/title/title.service';
import { Title } from 'src/app/model/Title';
interface DataItem {
  name: string;
  age: number;
  street: string;
  building: string;
  number: number;
  companyAddress: string;
  companyName: string;
  gender: string;
}
@Component({
  selector: 'app-job-information-and-salary',
  templateUrl: './job-information-and-salary.component.html',
  styleUrls: ['./job-information-and-salary.component.css'],
})
export class JobInformationAndSalaryComponent implements OnInit {
  listOfOption: any;
  listSalaryProfile: SalaryProfile[] = [];
  listEmployee: Employee[] = [];
  employee: Employee = {} as Employee;
  salaryProfile: any;
  test: any;
  isNewTitleFormVisible = false;
  isFormEmployeeVisible = false;
  isFormSalaryVisible = false;
  current = 0;
  activeStatus = ActiveStatus;
  index = 'First-content';
  selectedStatus: any;
  selectedTitle: any;
  selectedEmployee: any;

  listDepartment: Department[] = [];
  listOfSelectedValue = ['a10', 'c12'];
  listTitle: any;
  departmentCode: string = '';
  titleCode: string = '';

  pre(): void {
    this.current -= 1;
    this.changeContent();
  }

  next(): void {
    this.current += 1;
    this.changeContent();
  }

  done(): void {
    console.log('done');
  }
  changeContent(): void {
    switch (this.current) {
      case 0: {
        this.isFormEmployeeVisible = true;
        this.isFormSalaryVisible = false;
        break;
      }
      case 1: {
        this.isFormSalaryVisible = true;
        this.isFormEmployeeVisible = false;
        this.index = 'Second-content';
        break;
      }
      case 2: {
        this.index = 'third-content';
        break;
      }
      default: {
        this.index = 'error';
      }
    }
  }
  ngOnInit(): void {
    this.getAllSalaryProfile();
  }
  constructor(
    private router: Router,
    private departmentService: DepartmentService,
    private titleService: TitleService,
    private employeeProfileService: EmployeeProfileService,
    private appComponent: AppComponent,
    private SalaryProfileService: JobInformationAndSalaryService,
    private fb: FormBuilder
  ) {
    this.addSalaryProfileForm = this.fb.group({
      userName: ['', Validators.required],
      titleCodeMax: [{ value: this.titleCodeMax, disabled: true }],
      department: [null, Validators.required],
      status: [null, Validators.required],
    });

    this.addEmployeeForm = this.fb.group({
      userName: ['', Validators.required],
      title: ['', Validators.required],
      employee: ['', Validators.required],
      titleCode: ['', Validators.required],
      department: [null, Validators.required],
      status: [null, Validators.required],
    });
  }

  selectStatus(arg0: number) {
    throw new Error('Method not implemented.');
  }
  titleCodeMax: any;
  submitNewTitle() {
    throw new Error('Method not implemented.');
  }
  selectedDepartment: any;
  addSalaryProfileForm: FormGroup;
  addEmployeeForm: FormGroup;

  selectDepartment(department: Department) {
    this.selectedDepartment = department;
    this.departmentCode = department.departmentCode;
    this.titleService
      .getAllTitleByDepartmentId(department.departmentId)
      .subscribe((res: any) => {
        if (res.code == ResultCode.SuccessResult) {
          this.listTitle = res.result.data;
        }
      });
  }
  selectTitle(title: Title) {
    this.selectedTitle = title;
    this.titleCode = title.titleCode;
    this.getEmployeeByDepartmentTitleId(
      this.selectedDepartment.departmentId,
      this.selectedTitle.titleId
    );
  }

  employeeCode: any;
  selectEmployee(employee: Employee) {
    this.selectedEmployee = employee;
    this.employeeCode = employee.code;
  }
  getEmployeeByDepartmentTitleId(departmentId: string, titleId: string) {
    this.employeeProfileService
      .getAllEmployeeByDepartmentTitleId(departmentId, titleId)
      .subscribe((res: any) => {
        if (res.code == ResultCode.SuccessResult) {
          this.listEmployee = res.result.data;
        }
        else{
          this.listEmployee = [];
        }
      });
  }

  getAllSalaryProfile() {
    this.SalaryProfileService.getAllSalaryProfileWithFilter().subscribe(
      (res: any) => {
        if (res.code == ResultCode.SuccessResult) {
          res.result.data.forEach((element: SalaryProfileDto) => {
            this.employeeProfileService
              .getEmployeeById(element.employeeId)
              .subscribe((res2: any) => {
                if (res2.code == ResultCode.SuccessResult) {
                  this.test = res2.result;
                  this.salaryProfile = mapToSalaryProfile(
                    element,
                    undefined,
                    this.test
                  );
                  this.listSalaryProfile.push(this.salaryProfile);
                }
              });
          });
        } else {
          this.listSalaryProfile = [];
        }
      }
    );
  }

  getListDepartment() {
    this.departmentService
      .getAllDepartmentWithFilter()
      .subscribe((res: any) => {
        if (res.code == ResultCode.SuccessResult) {
          this.listDepartment = res.result.data;
        } else {
          this.listDepartment = [];
        }
      });
  }

  deleteTitle(salaryProfile: SalaryProfile) {
    throw new Error('Method not implemented.');
  }
  formTitle() {
    throw new Error('Method not implemented.');
  }
  formContract() {
    throw new Error('Method not implemented.');
  }
  hideNewTitleForm() {
    this.isNewTitleFormVisible = false;
  }
  openForm() {
    this.isNewTitleFormVisible = true;
    this.isFormEmployeeVisible = true;
    this.isFormSalaryVisible = false;
    this.getListDepartment();
  }

  listOfData: DataItem[] = [];
  sortAgeFn = (a: DataItem, b: DataItem): number => a.age - b.age;
  nameFilterFn = (list: string[], item: DataItem): boolean =>
    list.some((name) => item.name.indexOf(name) !== -1);
  filterName = [
    { text: 'Joe', value: 'Joe' },
    { text: 'John', value: 'John' },
  ];
}
