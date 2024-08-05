import { ActiveStatus } from "src/share/model/ActiveStatus";
import { Contract } from './Contract';

export interface ContractType {
  contractTypeId: string;
  name: string;
  contractCode: string;
  term: number;
  status: ActiveStatus;
}

export interface ContractTypeOverview {
  contractTypeId: string;
  contractTypeName: string;
  number: number;
}
