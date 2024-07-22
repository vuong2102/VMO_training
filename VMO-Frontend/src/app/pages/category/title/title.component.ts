import {
  Component,
  OnInit,
  Input,
  NgModule,
  EventEmitter,
  Output,
} from '@angular/core';
import { Router } from '@angular/router';
import { AppComponent } from 'src/app/app.component';
import { Title } from 'src/app/model/Title';
import { TitleService } from 'src/app/services/category/title/title.service';
import { ExcuteResult } from 'src/share/model/ExcuteResult';
import { NzAlertType } from 'src/share/model/NzAlertType';
import { ResultCode } from 'src/share/model/ResultCode';
import { DepartmentService } from '../../../services/category/department/department.service';
import { ActiveStatus } from 'src/share/model/ActiveStatus';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { StatusModel } from 'src/share/model/StatusModel';
import { Department } from 'src/app/model/Department ';

@Component({
  selector: 'app-title',
  templateUrl: './title.component.html',
  styleUrls: ['./title.component.css'],
})
export class TitleComponent implements OnInit {
  titleForm: FormGroup;
  listTitle: Title[] = [];
  listDepartment: Department[] = [];
  isSuccessAlertVisible: boolean = false;
  isNewTitleFormVisible = false;
  object: any;
  selectedDepartment: any;
  activeStatus: ActiveStatus | undefined;
  selectedStatus: any;
  titleCodeMax: string = '';
  statusModel: StatusModel | undefined;
  statusCode: any;

  ngOnInit(): void {
    this.getAllTitle();
  }

  constructor(
    private router: Router,
    private titleService: TitleService,
    private departmentService: DepartmentService,
    private appComponent: AppComponent,
    private fb: FormBuilder
  ) {
    this.titleForm = this.fb.group({
      userName: ['', Validators.required],
      titleCodeMax: [{ value: this.titleCodeMax, disabled: true }],
      department: [null, Validators.required],
      status: [null, Validators.required],
    });
  }

  getAllTitle() {
    this.titleService.getAllTitleWithFilter().subscribe((res: any) => {
      if (res.code == ResultCode.SuccessResult) {
        this.listTitle = res.result.data;
      } else {
        this.listTitle = [];
      }
    });
  }

  getAllDepartment() {
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

  getTitleCodeMax() {
    this.titleService.getTitleCodeMax().subscribe((res: any) => {
      if (res.code == ResultCode.SuccessResult) {
        this.titleCodeMax = res.result;
      } else {
        this.titleCodeMax;
      }
    });
  }

  departmentCode: any;
  selectDepartment(department: Department) {
    this.selectedDepartment = department;
    this.departmentCode = department.departmentCode;
  }

  selectStatus(status: number) {
    this.statusCode = status;
    if (status) this.selectedStatus = ActiveStatus.Active;
    if (!status) this.selectedStatus = ActiveStatus.NoActive;
  }

  addTitle() {
    const title: any = {
      name: this.titleForm.value.userName,
      titleCode: this.titleCodeMax,
      status: this.statusCode,
      departmentId: this.selectedDepartment.departmentId,
    };
    this.titleService.addNewTitle(title).subscribe((res: any) => {
      if (res.code == ResultCode.SuccessResult) {
        this.appComponent.showSuccessAlert(
          'Thêm dữ liệu thành công',
          true,
          NzAlertType.Success
        );
        this.getAllTitle();
      } else {
        this.appComponent.showSuccessAlert(
          'Thêm dữ liệu không thành công',
          true,
          NzAlertType.Warning
        );
      }
    });
    this.refreshForm();
  }


  deleteTitle(title: Title) {
    this.titleService.deleteFood(title).subscribe((res: any) => {
      if (res.code == ResultCode.SuccessResult) {
        this.appComponent.showSuccessAlert(
          'Xóa dữ liệu thành công',
          true,
          NzAlertType.Success
        );
      } else {
        this.appComponent.showSuccessAlert(
          'Xóa dữ liệu không thành công',
          true,
          NzAlertType.Warning
        );
      }
    });
  }

  formTitle() {
    this.getAllDepartment();
    this.getTitleCodeMax();
    this.isNewTitleFormVisible = true;
    this.refreshForm();
  }

  refreshForm() {
    this.titleForm = new FormGroup({
      userName: new FormControl(''),
    });
    this.selectedDepartment = null;
    this.departmentCode = null;
    this.selectedStatus = null;
  }

  editTitle(_t32: Title) {
    throw new Error('Method not implemented.');
  }

  toggleNewTitleForm() {
    this.isNewTitleFormVisible = !this.isNewTitleFormVisible;
  }

  hideNewTitleForm() {
    this.isNewTitleFormVisible = false;
  }

  submitNewTitle() {
    this.hideNewTitleForm();
    this.addTitle();
  }
}
