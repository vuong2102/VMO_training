import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppComponent } from 'src/app/app.component';
import { ExcuteResult } from 'src/share/model/ExcuteResult';

@Injectable({
  providedIn: 'root'
})
export class ContractService {
  private apiUrl = "https://localhost:7287/api/contract";
  private apiUrlContractType = "https://localhost:7287/api/contractType";


  constructor(
    private httpClient: HttpClient,
  ) { }

  getAllContractWithFilter(): Observable<ExcuteResult>{
    return this.httpClient.get<ExcuteResult>(`${this.apiUrl}/all`);
  }

  getContractTypeById(id: string): Observable<any>{
    return this.httpClient.get<any>(`${this.apiUrlContractType}/detail?id=${id}`)
  }
  deleteContract(id: string): Observable<ExcuteResult>{
    return this.httpClient.delete<ExcuteResult>(`${this.apiUrl}/delete?id=${id}`)
  }

  getContractCodeMax(): Observable<ExcuteResult>{
    return this.httpClient.get<ExcuteResult>(`${this.apiUrl}/contractCode-max`);
  }

  getContractType(id: string): Observable<ExcuteResult>{
    return this.httpClient.get<ExcuteResult>(`${this.apiUrl}/contractCode-max`);
  }
}
