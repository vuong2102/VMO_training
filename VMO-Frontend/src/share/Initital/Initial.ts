import { Employee } from './../../app/model/Employee';
import { SalaryProfile } from 'src/app/model/SalaryProfile';
import { ActiveStatus } from '../model/ActiveStatus';

export function createNewSalaryProfile(employee: Employee): SalaryProfile {
  return {
    salaryProfileId: '',
    basicSalary: 0,
    bonus: 0,
    deduction: 0,
    netSalary: 0,
    grossSalary: 0,
    salaryRank: '',
    salaryLevel: '',
    createDate: new Date(),
    creatorId: undefined,
    updateDate: undefined,
    updaterId: undefined,
    status: ActiveStatus.All,
    contract: undefined,
    employee: employee,
    benefits: [],
    allowances: [],
  };
}
