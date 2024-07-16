import { Contract } from "../Contract";
import { EmployeeDto } from "../Dto/EmployeeDto";
import { SalaryProfileDto } from "../Dto/SalaryProfileDto";
import { Employee } from "../Employee";
import { SalaryProfile } from "../SalaryProfile";


export function mapToSalaryProfile(dto: SalaryProfileDto, contract?: Contract, employee?: Employee): SalaryProfile {
  return {
    salaryProfileId: dto.salaryProfileId,
    basicSalary: dto.basicSalary,
    bonus: dto.bonus,
    deduction: dto.deduction,
    netSalary: dto.netSalary,
    salaryRank: dto.salaryRank,
    salaryLevel: dto.salaryLevel,
    createDate: new Date(dto.createDate),
    creatorId: dto.creatorId,
    updateDate: new Date(dto.updateDate),
    updaterId: dto.updaterId,
    status: dto.status,
    contract: contract,
    employee: employee!,
    benefits: dto.benefits,
    allowances: dto.allowances
  };
}

export function mapToSalaryProfileDto(profile: SalaryProfile): SalaryProfileDto {
  return {
    salaryProfileId: profile.salaryProfileId,
    basicSalary: profile.basicSalary,
    bonus: profile.bonus,
    deduction: profile.deduction,
    netSalary: profile.netSalary,
    salaryRank: profile.salaryRank,
    salaryLevel: profile.salaryLevel,
    createDate: profile.createDate,
    creatorId: profile.creatorId,
    updateDate: profile.updateDate,
    updaterId: profile.updaterId,
    status: profile.status,
    contractId: profile.contract ? profile.contract.id : undefined,
    employeeId: profile.employee.employeeId,
    benefits: profile.benefits,
    allowances: profile.allowances
  };
}
