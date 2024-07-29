import { Contract } from "../Contract";
import { EmployeeDto } from "../Dto/EmployeeDto";
import { AddSalaryProfileDto, SalaryProfileDto } from "../Dto/SalaryProfileDto";
import { Employee } from "../Employee";
import { SalaryProfile } from "../SalaryProfile";


export function mapToSalaryProfile(dto: SalaryProfileDto, contract?: Contract, employee?: Employee): SalaryProfile {
  return {
    salaryProfileId: dto.salaryProfileId,
    salaryProfileCode: dto.salaryProfileCode,
    basicSalary: dto.basicSalary,
    bonus: dto.bonus,
    deduction: dto.deduction,
    netSalary: dto.netSalary,
    grossSalary: dto.grossSalary,
    salaryRank: dto.salaryRank,
    salaryLevel: dto.salaryLevel,
    createDate: new Date(dto.createDate),
    creatorId: dto.creatorId,
    updateDate: dto.updateDate,
    updaterId: dto.updaterId,
    signDate: dto.signDate,
    statusSign: dto.statusSign,
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
    salaryProfileCode: profile.salaryProfileCode,
    basicSalary: profile.basicSalary,
    bonus: profile.bonus,
    deduction: profile.deduction,
    netSalary: profile.netSalary,
    grossSalary: profile.grossSalary,
    salaryRank: profile.salaryRank,
    salaryLevel: profile.salaryLevel,
    createDate: profile.createDate,
    creatorId: profile.creatorId,
    updateDate: profile.updateDate,
    updaterId: profile.updaterId,
    signDate: profile.signDate,
    statusSign: profile.statusSign,
    status: profile.status,
    contractId: profile.contract ? profile.contract.contractId : undefined,
    employeeId: profile.employee.employeeId,
    benefits: profile.benefits,
    allowances: profile.allowances
  };
}

export function mapToAddSalaryProfileDto(profile: SalaryProfile): AddSalaryProfileDto {
  return {
    basicSalary: profile.basicSalary,
    bonus: profile.bonus,
    deduction: profile.deduction,
    netSalary: profile.netSalary,
    grossSalary: profile.grossSalary,
    salaryRank: profile.salaryRank,
    salaryLevel: profile.salaryLevel,
    createDate: profile.createDate,
    creatorId: profile.creatorId,
    updateDate: profile.updateDate,
    updaterId: profile.updaterId,
    status: profile.status,
    contractId: profile.contract ? profile.contract.contractId : undefined,
    employeeId: profile.employee.employeeId,
    benefits: profile.benefits,
    allowances: profile.allowances
  };
}
