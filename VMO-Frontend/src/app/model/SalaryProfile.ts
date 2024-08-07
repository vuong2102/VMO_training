import { StatusSign } from 'src/share/model/StatusSign';
import { ActiveStatus } from 'src/share/model/ActiveStatus';
import { Benefit } from './Benefit';
import { Allowance } from './Allowance';
import { Employee } from './Employee';
import { Contract } from './Contract';

export interface SalaryProfile {
  salaryProfileId: string;
  salaryProfileCode: string;
  basicSalary: number;
  bonus: number;
  deduction: number;
  netSalary: number;
  grossSalary: number;
  salaryRank: string;
  salaryLevel: string;
  createDate: Date;
  creatorId?: string;
  updateDate?: Date;
  updaterId?: string;
  signDate: Date;
  statusSign: StatusSign;
  status: ActiveStatus;

  contract?: Contract;
  employee: Employee;
  benefits?: Benefit[];
  allowances?: Allowance[];
}
