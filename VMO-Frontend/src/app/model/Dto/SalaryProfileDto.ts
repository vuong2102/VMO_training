import { ActiveStatus } from 'src/share/model/ActiveStatus';
import { Benefit } from '../Benefit';
import { Allowance } from '../Allowance';
import { Employee } from '../Employee';


export interface SalaryProfileDto {
  salaryProfileId: string;
  basicSalary: number;
  bonus: number;
  deduction: number;
  netSalary: number;
  salaryRank: string;
  salaryLevel: string;
  createDate: Date;
  creatorId: string;
  updateDate: Date;
  updaterId: string;
  status: ActiveStatus;

  contractId?: string;
  employeeId: string;
  benefits?: Benefit[];
  allowances?: Allowance[];
}
