import { ActiveStatus } from "src/share/model/ActiveStatus";
import { StatusSign } from "src/share/model/StatusSign";
import { Employee } from "./Employee";
import { SalaryProfile } from "./SalaryProfile";
import { ContractType } from "./ContractType";

export interface Contract {
  contractId: string;
  contractCode: string;
  startDate: Date;
  endDate?: Date;
  statusSign: StatusSign;
  createDate: Date;
  creatorId?: string;
  updateDate?: Date;
  updaterId?: string;
  status: ActiveStatus;

  employee: Employee;
  employeeApproved: Employee;
  contractType: ContractType;
  salaryProfile?: SalaryProfile;
}
