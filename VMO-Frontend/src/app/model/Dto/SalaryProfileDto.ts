import { ActiveStatus } from 'src/share/model/ActiveStatus';
import { Benefit } from '../Benefit';
import { Allowance } from '../Allowance';
import { Employee } from '../Employee';
import { StatusSign } from 'src/share/model/StatusSign';


export interface SalaryProfileDto {
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

  contractId?: string;
  employeeId: string;
  benefits?: Benefit[];
  allowances?: Allowance[];
}

export interface AddSalaryProfileDto {
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
  status: ActiveStatus;

  contractId?: string;
  employeeId: string;
  benefits?: Benefit[];
  allowances?: Allowance[];
}
