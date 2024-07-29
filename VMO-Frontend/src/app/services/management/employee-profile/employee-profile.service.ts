import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ExcuteResult } from 'src/share/model/ExcuteResult';

@Injectable({
  providedIn: 'root'
})
export class EmployeeProfileService {

  public apiUrl = "https://localhost:7287/api/employee";

  constructor(private httpClient:HttpClient,
    private router: Router,
  ) { }

  getEmployeeById(id: string): Observable<any>{
    return this.httpClient.get(`${this.apiUrl}/detail/` +id);
  }

  getAllEmployeeByDepartmentTitleId(departmentId: string, titleId: string) {
    return this.httpClient.get(`${this.apiUrl}/all-filter?departmentId=${departmentId}&titleId=${titleId}`);;
  }

  getAllEmployeeByEmployeeCode(employeeCode: string) {
    return this.httpClient.get(`${this.apiUrl}?employeeCode=${employeeCode}`);;
  }

  async getAllTitleWithFilter(): Promise<Observable<ExcuteResult>>{
    return await this.httpClient.get<ExcuteResult>(`${this.apiUrl}/all`);
  }
}
