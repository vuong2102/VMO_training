import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TitleComponent } from '../category/title/title.component';
import { ContractComponent } from './contract/contract.component';
import { JobInformationAndSalaryComponent } from './job-information-and-salary/job-information-and-salary.component';

const routes: Routes = [
  { path: 'hop-dong-lao-dong', component: ContractComponent },
  { path: 'thong-tin-cong-tac-luong', component: JobInformationAndSalaryComponent },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ManagementRoutingModule { }
