import { Department } from "./Department ";

export interface Title {
  titleId?: string;
  name: string;
  titleCode: string;
  status: number;
  department: Department;
}
