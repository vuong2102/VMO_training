import { TitleDto } from "./TitleDto";
import { DepartmentDto } from "./DepartmentDto";

export interface EmployeeDto {
  id: string;
  name: string;
  sex: string;
  dateOfBirth: Date;
  email: string;
  phoneNumber: string;
  status: string;
  department: DepartmentDto;
  title: TitleDto;
}
