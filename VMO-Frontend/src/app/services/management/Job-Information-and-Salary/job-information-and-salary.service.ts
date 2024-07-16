import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { SalaryProfile } from 'src/app/model/SalaryProfile';
import { ExcuteResult } from 'src/share/model/ExcuteResult';

@Injectable({
  providedIn: 'root'
})
export class JobInformationAndSalaryService {
  private apiUrl = "https://localhost:7287/api/SalaryProfile";

  constructor(private httpClient:HttpClient,
    private router: Router,
  ) { }

  getAllSalaryProfileWithFilter(): Observable<ExcuteResult>{
    return this.httpClient.get<ExcuteResult>(`${this.apiUrl}/all`);
  }

  addNewSalaryProfile(salaryProfile: SalaryProfile): Observable<ExcuteResult> {
    return this.httpClient.post<ExcuteResult>(`${this.apiUrl}/add`, salaryProfile);
  }

  deleteFood(salaryProfile: SalaryProfile): Observable<ExcuteResult>{
    return this.httpClient.delete<ExcuteResult>(`${this.apiUrl}/delete?id=${salaryProfile.salaryProfileId}`);
  }


}
