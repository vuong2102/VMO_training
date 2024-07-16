import { ActiveStatus } from "src/share/model/ActiveStatus";

export interface Allowance {
  allowanceId: string;
  name: string;
  amount: number;
  status: ActiveStatus;
}
