import { ActiveStatus } from "src/share/model/ActiveStatus";

export interface Benefit {
  benefitId: string;
  type: string;
  expense: number;
  status: ActiveStatus;
}
