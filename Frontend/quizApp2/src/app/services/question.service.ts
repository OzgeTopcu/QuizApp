import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Outcome } from '../models/outcome.model';
 
@Injectable({
  providedIn: 'root'
})
export class OutcomeService {
  private baseUrl = 'https://localhost:7107/api';
 
  constructor(private http: HttpClient) {}
 
  getOutcomeByUserId(userId: number): Observable<Outcome[]> {
    return this.http.get<Outcome[]>(`${this.baseUrl}/User/${userId}/{OutCome}`);
  }
 
  getOutcomeByExamId(examId: number): Observable<Outcome> {
    return this.http.get<Outcome>(`${this.baseUrl}/Exam/${examId}/{OutCome}`);
  }
}