import { SalaryProfile } from './../../../model/SalaryProfile';
import { Component, OnInit } from '@angular/core';
import { Contract } from 'src/app/model/Contract';
import { ContractType } from 'src/app/model/ContractType';
import { ContractDto } from 'src/app/model/Dto/ContractDto';
import { Employee } from 'src/app/model/Employee';
import { mapToContract } from 'src/app/model/Mapper/ContractMapper';
import { EmployeeProfileService } from 'src/app/services/management/employee-profile/employee-profile.service';
import { ResultCode } from 'src/share/model/ResultCode';
import { JobInformationAndSalaryService } from '../../../services/management/Job-Information-and-Salary/job-information-and-salary.service';
import { ContractService } from 'src/app/services/management/contract-profile/contract.service';
import { StatusSign } from 'src/share/model/StatusSign';
import { AppComponent } from 'src/app/app.component';
import { NzAlertType } from 'src/share/model/NzAlertType';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Department } from 'src/app/model/Department ';
import { Title } from 'src/app/model/Title';
import { async } from 'rxjs';
import { SalaryProfileDto } from 'src/app/model/Dto/SalaryProfileDto';
import { ActiveStatus } from 'src/share/model/ActiveStatus';

@Component({
  selector: 'app-contract',
  templateUrl: './contract.component.html',
  styleUrls: ['./contract.component.css'],
})
export class ContractComponent implements OnInit {

  list: any;
  employeeMap: Employee = {} as Employee;
  contractTypeMap: ContractType = {} as ContractType;
  salaryProfileMap: SalaryProfile = {} as SalaryProfile;
  contractMap: Contract = {} as Contract;

  listContractDto: ContractDto[] = [];
  listContract: Contract[] = [];
  statusSignes = [StatusSign.NoSign, StatusSign.Signed, StatusSign.WaitingSign]
  activeStatus = [ActiveStatus.Active, ActiveStatus.NoActive]

  isAddFormVisible = true;
  infoEmployeeForm: FormGroup;

  // Add Form
  employeeGetByCode: Employee = {} as Employee;
  departmentGetByEmployeeCode: Department = {} as Department;
  tilteGetByEmployeeCode: Title = {} as Title;
  salaryProfileGetByEmployeeCode: SalaryProfileDto = {} as SalaryProfileDto;
  contractAdd: ContractDto = {} as ContractDto;
  contractType: ContractType = {} as ContractType;


  constructor(
    private contractService: ContractService,
    private employeeService: EmployeeProfileService,
    private salaryProfileService: JobInformationAndSalaryService,
    private appComponent: AppComponent,
    private fb: FormBuilder,

  ) {
    this.infoEmployeeForm = this.fb.group({
      employeeName: ['', Validators.required],
      employeeCode: ['', Validators.required],
      department: ['', Validators.required],
      departmentCode: ['', Validators.required],
      title: ['', Validators.required],
      titleCode: ['', Validators.required],
    });
  }

  ngOnInit(): void {
    this.getAllContract();
  }

  async getAllContract() {
    try {
      const res: any = await this.contractService.getAllContractWithFilter().toPromise();
      if(res.code == ResultCode.SuccessResult){
        this.listContractDto = res.result.data;
      }
    } catch (error) {
      console.error('Error fetching contracts:', error);
    }
    this.getAllInfoContract();
  }

  getAllInfoContract() {
    this.list = [];
    this.listContractDto.forEach(async (element) => {
      const res: any = await this.employeeService.getEmployeeById(element.employeeId).toPromise();
      const resContractType = await this.contractService.getContractTypeById(element.contractTypeId).toPromise();
      this.employeeMap = res.result;
      this.contractTypeMap = resContractType.result;
      this.contractMap = mapToContract(
        element,
        this.salaryProfileMap,
        this.employeeMap,
        this.contractTypeMap
      );
      this.list.push(this.contractMap);
    });
    this.listContract = this.list;
    console.log(this.listContract);
  }

  deleteContract(contract: Contract) {
    this.contractService.deleteContract(contract.contractId).subscribe((res: any) => {
      if(res.code == ResultCode.SuccessResult) {
        this.appComponent.showSuccessAlert(
          'Xóa dữ liệu thành công',
          true,
          NzAlertType.Success,
          'Success'
        )
        this.getAllContract();
      }
      else {
        this.appComponent.showSuccessAlert(
          'Xóa dữ liệu không thành công',
          true,
          NzAlertType.Error,
          'Error'
        )
      }
    })
  }
  salaryProfileIdGet = '';
  async getEmployeeByEmployeeCode(employeeCode: string){
    try {
      this.employeeGetByCode = {} as Employee;
      const res: any = await this.employeeService.getAllEmployeeByEmployeeCode(employeeCode).toPromise();
      if (res.code == ResultCode.SuccessResult) {
        if(res.result.data.length > 0){
          this.employeeGetByCode = res.result.data[0];
          this.departmentGetByEmployeeCode = this.employeeGetByCode.department;
          this.tilteGetByEmployeeCode = this.employeeGetByCode.title;
          this.getSalaryProfileByEmployeeId(this.employeeGetByCode.employeeId);
        }
        else {
          this.salaryProfileGetByEmployeeCode = {} as SalaryProfileDto;
          this.appComponent.showSuccessAlert(
            'Nhân viên chưa thiết lập hồ sơ lương',
            true,
            NzAlertType.Error,
            'Error'
          )
        }
      }
    } catch (error) {
      console.error('Error fetching contracts:', error);
    }
  }

  async getSalaryProfileByEmployeeId(employeeId: string){
    const res2: any = await this.salaryProfileService.getSalaryProfileByEmployeeCode(employeeId).toPromise();
      if (res2.code == ResultCode.SuccessResult) {
        this.salaryProfileGetByEmployeeCode = res2.result;
        console.log(res2.result);
      } else {
        this.salaryProfileGetByEmployeeCode = {} as SalaryProfileDto;
        this.appComponent.showSuccessAlert(
          'Chưa thiết lập hồ sơ lương',
          true,
          NzAlertType.Error,
          'Error'
        )
      }
  }

  async getContractType(id: string){
    const res: any = await this.contractService.getContractTypeById(id).toPromise();
    if (res.code == ResultCode.SuccessResult) {
      this.contractType = res.result;
    }
  }

  searchValue: string = '';
  async searchAddForm(searchValue: string) {
    this.getEmployeeByEmployeeCode(searchValue);
  }

  async getSalaryProfileByEmployeeCode(code: string){
    try {
      const res: any = await this.salaryProfileService.getSalaryProfileByEmployeeCode(code).toPromise();
      if (res.code == ResultCode.SuccessResult) {
        console.log(res.result);
        this.salaryProfileGetByEmployeeCode = res.result;
        console.log("Hồ sơ lương", this.salaryProfileGetByEmployeeCode);
      } else {
        this.salaryProfileGetByEmployeeCode = {} as SalaryProfileDto;
        this.appComponent.showSuccessAlert(
          'Chưa thiết lập hồ sơ lương',
          true,
          NzAlertType.Error,
          'Error'
        )
      }
    } catch (error) {
      console.error('Error fetching contracts:', error);
    }
  }

  openForm() {
    this.isAddFormVisible = true;
    this.contractAddVisible = false;
  }

  refreshValue(){
    this.searchValue = '';
    this.employeeGetByCode = {} as Employee;
    this.departmentGetByEmployeeCode = {} as Department;
    this.tilteGetByEmployeeCode = {} as Title;
  }

  hideForm() {
    this.isAddFormVisible = false;
  }

  formContract() {
    throw new Error('Method not implemented.');
  }

  index = 0;
  onIndexChange(event: number): void {
    this.index = event;
  }

  contractAddVisible = false;
  createContract() {
    this.contractAddVisible = true;
    this.contractService.getContractCodeMax().subscribe((res: any) => {
      if(res.code == ResultCode.SuccessResult){
        this.contractAdd.contractCode = res.result;
      }
    })
  }
  dataDate = null;
  onChangeSignDate(result: Date): void {
    this.salaryProfileGetByEmployeeCode.signDate = result;
  }
}
