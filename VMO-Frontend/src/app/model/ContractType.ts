import { ActiveStatus } from "src/share/model/ActiveStatus";

export interface ContractType {
  contractTypeId: string;
  name: string;
  contractCode: string;
  term: number;
  status: ActiveStatus;
}
