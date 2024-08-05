import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ExcuteResult } from 'src/share/model/ExcuteResult';

@Injectable({
  providedIn: 'root'
})
export class ContractTypeService {
  private apiUrl = "https://localhost:7287/api/contractType";

  constructor(private httpClient: HttpClient,
    private router: Router,
  ) { }

  getAllContractTypeWithFilter(): Observable<ExcuteResult>{
    return this.httpClient.get<ExcuteResult>(`${this.apiUrl}/overview`);
  }
}
