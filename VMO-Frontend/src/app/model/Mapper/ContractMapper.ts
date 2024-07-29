import { ContractType } from '../ContractType';
import { ContractDto } from '../Dto/ContractDto';
import { Employee } from '../Employee';
import { SalaryProfile } from '../SalaryProfile';
import { Contract } from 'src/app/model/Contract';

export function mapToContract(dto: ContractDto, salaryProfile: SalaryProfile, employee: Employee, contractType: ContractType): Contract {
  return {
    contractId: dto.contractId,
    contractCode: dto.contractCode,
    startDate: dto.startDate,
    endDate: dto.endDate,
    statusSign: dto.statusSign,
    createDate: dto.createDate,
    creatorId: dto.creatorId,
    updateDate: dto.updateDate,
    updaterId: dto.updaterId,
    status: dto.status,

    employee: employee,
    employeeApproved: employee,
    contractType: contractType,
    salaryProfile: salaryProfile,
  };
}

export function mapToContractDto(contract: Contract, salaryProfile: SalaryProfile, employee: Employee, contractType: ContractType): ContractDto {
  return {
    contractId: contract.contractId,
    contractCode: contract.contractCode,
    startDate: contract.startDate,
    endDate: contract.endDate,
    statusSign: contract.statusSign,
    createDate: contract.createDate,
    creatorId: contract.creatorId,
    updateDate: contract.updateDate,
    updaterId: contract.updaterId,
    status: contract.status,

    employeeId: employee.employeeId,
    employeeApprovedId: employee.employeeId,
    contractTypeId: contractType.contractTypeId,
    salaryProfileId: salaryProfile.salaryProfileId,
  };
}
