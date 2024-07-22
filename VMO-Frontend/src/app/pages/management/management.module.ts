import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ManagementRoutingModule } from './management-routing.module';
import { ManagementComponent } from './management.component';
import { ContractComponent } from './contract/contract.component';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';
import { NzToolTipModule } from 'ng-zorro-antd/tooltip';
import { IconsProviderModule } from 'src/app/icons-provider.module';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzInputGroupComponent, NzInputModule } from 'ng-zorro-antd/input';
import { NzAlertModule } from 'ng-zorro-antd/alert';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { JobInformationAndSalaryComponent } from './job-information-and-salary/job-information-and-salary.component';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { NzStepsModule } from 'ng-zorro-antd/steps';
import { BrowserModule } from '@angular/platform-browser';
import { VndCurrencyPipe } from 'src/helper/VndCurrencyPipe';
import { NzInputNumberModule } from 'ng-zorro-antd/input-number';
import { NzSpaceModule } from 'ng-zorro-antd/space';
import { NzPaginationModule } from 'ng-zorro-antd/pagination';
import { NzAvatarModule } from 'ng-zorro-antd/avatar';
import { NzListModule } from 'ng-zorro-antd/list';

@NgModule({
  declarations: [
    ManagementComponent,
    ContractComponent,
    JobInformationAndSalaryComponent,
    VndCurrencyPipe,
  ],
  imports: [
    CommonModule,
    ManagementRoutingModule,
    NzLayoutModule,
    NzMenuModule,
    NzTableModule,
    NzDropDownModule,
    NzToolTipModule,
    NzButtonModule,
    NzInputModule,
    NzAlertModule,
    NzFormModule,
    ReactiveFormsModule,
    NzSelectModule,
    NzInputModule,
    NzInputNumberModule,
    NzSpaceModule,
    NzPaginationModule,
    IconsProviderModule,
    NzGridModule,
    NzStepsModule,
    NzAvatarModule,
    NzListModule,
    BrowserModule,
    FormsModule,

  ]
})
export class ManagementModule { }
