import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Title } from 'src/app/model/Title';
import { ExcuteResult } from 'src/share/model/ExcuteResult';

@Injectable({
  providedIn: 'root'
})
export class TitleService {

  private apiUrl = "https://localhost:7287/api/title";

  constructor(private httpClient:HttpClient,
    private router: Router,
  ) { }

  getAllTitleWithFilter(): Observable<ExcuteResult>{
    return this.httpClient.get<ExcuteResult>(`${this.apiUrl}/all`);
  }

  getAllTitleByDepartmentId(id: string): Observable<ExcuteResult>{
    return this.httpClient.get<ExcuteResult>(`${this.apiUrl}/departmentId?id=${id}`)
  }

  getTitleCodeMax(): Observable<string>{
    return this.httpClient.get<string>(`${this.apiUrl}/titlecode-max`);
  }

  addNewTitle(title: Title): Observable<ExcuteResult> {
    return this.httpClient.post<ExcuteResult>(`${this.apiUrl}/add`, title);
  }

  updateFood(title: Title): Observable<ExcuteResult> {
    return this.httpClient.put<ExcuteResult>(`${this.apiUrl}/update/${title.titleId}`, title);
  }

  deleteFood(title: Title): Observable<ExcuteResult>{
    return this.httpClient.delete<ExcuteResult>(`${this.apiUrl}/delete?id=${title.titleId}`);
  }
}
