import { ActiveStatus } from "src/share/model/ActiveStatus";
import { StatusSign } from "src/share/model/StatusSign";

export interface ContractDto {
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

  employeeId: string;
  employeeApprovedId: string;
  contractTypeId: string;
  salaryProfileId: string;
}
