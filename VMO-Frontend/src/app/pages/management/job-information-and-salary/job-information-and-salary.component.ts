import { Benefit } from './../../../model/Benefit';
import {
  Component,
  ElementRef,
  HostListener,
  OnInit,
  Renderer2,
} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AppComponent } from 'src/app/app.component';
import { DepartmentService } from 'src/app/services/category/department/department.service';
import { JobInformationAndSalaryService } from '../../../services/management/Job-Information-and-Salary/job-information-and-salary.service';
import { ResultCode } from 'src/share/model/ResultCode';
import { SalaryProfile } from 'src/app/model/SalaryProfile';
import {
  AddSalaryProfileDto,
  SalaryProfileDto,
} from 'src/app/model/Dto/SalaryProfileDto';
import {
  mapToAddSalaryProfileDto,
  mapToSalaryProfile,
  mapToSalaryProfileDto,
} from 'src/app/model/Mapper/SalaryProfileMapper';
import { Employee } from '../../../model/Employee';
import { EmployeeProfileService } from 'src/app/services/management/employee-profile/employee-profile.service';
import { ActiveStatus } from '../../../../share/model/ActiveStatus';
import { Department } from 'src/app/model/Department ';
import { TitleService } from 'src/app/services/category/title/title.service';
import { Title } from 'src/app/model/Title';
import { VndCurrencyPipe } from 'src/helper/VndCurrencyPipe';
import { createNewSalaryProfile } from 'src/share/Initital/Initial';
import { BenefitService } from 'src/app/services/category/benefit/benefit.service';
import { AllowanceService } from 'src/app/services/category/allowance/allowance.service';
import { Allowance } from 'src/app/model/Allowance';
import { NzAlertType } from 'src/share/model/NzAlertType';
import { ContractService } from 'src/app/services/management/contract-profile/contract.service';

@Component({
  selector: 'app-job-information-and-salary',
  templateUrl: './job-information-and-salary.component.html',
  styleUrls: ['./job-information-and-salary.component.css'],
  providers: [VndCurrencyPipe],
})
export class JobInformationAndSalaryComponent implements OnInit {
  listOfOption: any;
  salaryProfile: any;
  test: any;
  isNewTitleFormVisible = false;
  isFormEmployeeVisible = false;
  isFormSaveSalaryProfileVisible = false;
  isFormSalaryVisible = false;
  isFormAllowanceVisible = false;
  isFormBenefitVisible = false;

  current = 0;
  activeStatus = ActiveStatus;
  selectedStatus: any;
  selectedTitle: any;
  listTitle: any;
  listAllowanceDetail: any;
  listBenefitDetail: any;
  departmentCode: string = '';
  titleCode: string = '';
  selectedDepartment: any;
  addSalaryProfileForm: FormGroup;
  addEmployeeForm: FormGroup;

  listBenefit: Benefit[] = [];
  listAllowance: Allowance[] = [];
  listOfSelectedAllowance: Allowance[] = [];
  listOfSelectedBenefit: Benefit[] = [];
  listOfData: SalaryProfile[] = [];
  listDepartment: Department[] = [];
  listSalaryProfile: SalaryProfile[] = [];
  listSalaryProfileGet: SalaryProfile[] = [];
  listEmployee: Employee[] = [];

  AddSalaryProfile: SalaryProfile = {} as SalaryProfile;
  AddSalaryProfileDto: AddSalaryProfileDto = {} as AddSalaryProfileDto;
  selectedEmployee: Employee = {} as Employee;
  employee: Employee = {} as Employee;

  activeStatuses = [ActiveStatus.Active, ActiveStatus.NoActive];

  constructor(
    private router: Router,
    private departmentService: DepartmentService,
    private titleService: TitleService,
    private benefitService: BenefitService,
    private allowanceService: AllowanceService,
    private employeeProfileService: EmployeeProfileService,
    private appComponent: AppComponent,
    private SalaryProfileService: JobInformationAndSalaryService,
    private contractService: ContractService,
    private fb: FormBuilder,
    private vndCurrencyPipe: VndCurrencyPipe,
    private eRef: ElementRef,
    private renderer: Renderer2
  ) {
    this.addSalaryProfileForm = this.fb.group({
      status: [null, Validators.required],
      basicSalary: ['', Validators.required],
      grossSalaryTotal: [''],
      deduction: ['', Validators.required],
      salaryLevel: ['', Validators.required],
      netSalary: ['', Validators.required],
      salaryRank: ['', Validators.required],
      bonus: ['', Validators.required],
      createDate: [new Date(), Validators.required],
      benefits: [],
      allowances: [],
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

  formatterVND(value: number): string {
    return `${value}`.replace(/\B(?=(\d{3})+(?!\d))/g, '.');
  }
  formatterNegativeVND(value: number): string {
    return `-${value}`.replace(/\B(?=(\d{3})+(?!\d))/g, '.');
  }
  onValueChange1(value: number) {
    this.AddSalaryProfile.basicSalary = value;
  }

  pre(): void {
    this.current -= 1;
    this.changeContent();
  }

  next(): void {
    this.current += 1;
    this.changeContent();
  }

  done(): void {
    this.SalaryProfileService.addNewSalaryProfile(
      this.AddSalaryProfileDto
    ).subscribe((res: any) => {
      if (res.code == ResultCode.SuccessResult) {
        this.getAllSalaryProfile();
        this.hideNewTitleForm();
        this.appComponent.showSuccessAlert(
          'Thêm dữ liệu thành công',
          true,
          NzAlertType.Success,
          'Success'
        );
      } else {
        this.appComponent.showSuccessAlert(
          'Thêm dữ liệu không thành công',
          true,
          NzAlertType.Warning,
          'Warning'
        );
      }
    });
    console.log(this.AddSalaryProfileDto);
  }
  setEmployee(employee: Employee) {
    this.AddSalaryProfile.employee = employee;
  }

  changeContent(): void {
    switch (this.current) {
      case 0: {
        this.isFormEmployeeVisible = true;
        this.isFormSalaryVisible = false;
        this.isFormSaveSalaryProfileVisible = false;
        break;
      }
      case 1: {
        this.isFormSalaryVisible = true;
        this.isFormEmployeeVisible = false;
        this.isFormSaveSalaryProfileVisible = false;
        break;
      }
      case 2: {
        this.isFormSaveSalaryProfileVisible = true;
        this.isFormSalaryVisible = true;
        this.setFormValues();
        console.log('final 2: ', this.AddSalaryProfileDto);
        break;
      }
      default: {
      }
    }
  }

  grossSalaryTotal = 0;
  setFormValues() {
    this.AddSalaryProfile = this.addSalaryProfileForm.value;
    this.grossSalaryTotal =
      this.AddSalaryProfile.basicSalary +
      this.AddSalaryProfile.netSalary +
      this.AddSalaryProfile.bonus -
      this.AddSalaryProfile.deduction;
    this.AddSalaryProfile.grossSalary = this.grossSalaryTotal;
    this.setEmployee(this.selectedEmployee);
    this.AddSalaryProfile.benefits = this.listOfSelectedBenefit;
    this.AddSalaryProfile.allowances = this.listOfSelectedAllowance;
    this.AddSalaryProfileDto = mapToAddSalaryProfileDto(this.AddSalaryProfile);
  }

  ngOnInit(): void {
    this.getAllSalaryProfile();
  }

  onAllowanceChange(selectedItems: Allowance[]): void {
    this.listOfSelectedAllowance = selectedItems;
    this.AddSalaryProfile.allowances = this.listOfSelectedAllowance;
  }

  onBenefitChange(selectedBenefits: Benefit[]): void {
    this.listOfSelectedBenefit = selectedBenefits;
    this.AddSalaryProfile.benefits = this.listOfSelectedBenefit;
  }

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
        } else {
          this.listEmployee = [];
        }
      });
  }
  listSalaryProfileDto: SalaryProfileDto[] = [];
  employeeMap: Employee = {} as Employee;

  async getAllSalaryProfile() {
    this.listSalaryProfile = [];
    this.listSalaryProfileGet = [];
    try {
      const res: any = await this.SalaryProfileService.getAllSalaryProfileWithFilter().toPromise();
      if (res.code == ResultCode.SuccessResult) {
        this.listSalaryProfileDto = res.result.data;
      } else {
        this.listSalaryProfileDto = [];
      }
    } catch (error) {
      console.error('Error fetching contracts:', error);
    }

    this.listSalaryProfileDto.forEach(async (element: any) => {
      const resEmployee: any = await this.employeeProfileService
        .getEmployeeById(element.employeeId)
        .toPromise();
      if (resEmployee.code == ResultCode.SuccessResult) {
        element.Employee = resEmployee.result.data;
        this.employeeMap = resEmployee.result;
        this.salaryProfile = mapToSalaryProfile(
          element,
          undefined,
          this.employeeMap
        );
      }
      this.listSalaryProfileGet.push(this.salaryProfile);
    });
    this.listSalaryProfile = this.listSalaryProfileGet;
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

  deleteSalaryProfile(salaryProfile: SalaryProfile) {
    this.SalaryProfileService.deleteSalaryProfile(salaryProfile).subscribe(
      (res: any) => {
        if (res.code == ResultCode.SuccessResult) {
          this.appComponent.showSuccessAlert(
            'Xóa dữ liệu thành công',
            true,
            NzAlertType.Success,
            'Success'
          );
          this.getAllSalaryProfile();
        } else {
          this.appComponent.showSuccessAlert(
            'Xóa dữ liệu không thành công',
            true,
            NzAlertType.Warning,
            'Warning'
          );
        }
      }
    );
  }
  warningDetail() {
    this.appComponent.showSuccessAlert(
      'Bạn không có quyền thực hiện',
      true,
      NzAlertType.Warning,
      'Warning'
    );
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
    this.isFormSaveSalaryProfileVisible = false;

    this.listOfSelectedAllowance = [];
    this.listOfSelectedBenefit = [];

    this.getListDepartment();
    this.AddSalaryProfile = createNewSalaryProfile(this.selectedEmployee);

    this.benefitService.getAllBenefitWithFilter().subscribe((res: any) => {
      this.listBenefit = res.result.data;
    });

    this.allowanceService.getAllAllowanceWithFilter().subscribe((res: any) => {
      this.listAllowance = res.result.data;
    });
    this.listOfData.push(this.AddSalaryProfile);
  }

  openDetailAllowance(salaryProfile: SalaryProfile) {
    this.listAllowanceDetail = salaryProfile.allowances;
    this.isFormAllowanceVisible = true;
    this.isFormBenefitVisible = false;
  }
  openDetailBenefit(salaryProfile: SalaryProfile) {
    this.listBenefitDetail = salaryProfile.benefits;
    this.isFormBenefitVisible = true;
    this.isFormAllowanceVisible = false;
  }
  closeDetail() {
    this.isFormAllowanceVisible = false;
    this.isFormBenefitVisible = false;
  }

  deleteAllowance(allowance: Allowance) {
    throw new Error('Method not implemented.');
  }
  hideAlloBeneForm() {
    this.isFormAllowanceVisible = false;
    this.isFormBenefitVisible = false;
  }
}
