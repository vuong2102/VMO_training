import { Department } from "./Department ";
import { Title } from "./Title";

export interface Employee {
  employeeId: string;
  name: string;
  code: string
  sex: string;
  dateOfBirth: Date;
  email: string;
  phoneNumber: string;
  status: string;
  title: Title;
  department: Department;
}
