import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, forkJoin } from 'rxjs';
import { map } from 'rxjs/operators';
import { Question } from '../models/question.model';
import { Option } from '../models/option.model';
 
@Injectable({
  providedIn: 'root'
})
export class JointService {
  private baseUrl = 'https://localhost:7107/api';
 
  constructor(private http: HttpClient) { }
 
  getQuestionWithOptions(questionId: number): Observable<Option[]> {
    return this.http.get<Option[]>(`${this.baseUrl}/Question/${questionId}/Option`);
  }
 
  getExamQuestions(examId: number): Observable<Question[]> {
    const headers = new HttpHeaders({
      'Access-Control-Allow-Headers': 'Content-Type',
       'Access-Control-Allow-Origin': '*',
       'Content-Type': 'application/json',
       'Access-Control-Allow-Methods':' GET, POST, PATCH, PUT, DELETE, OPTIONS'
 
  });
    return this.http.get<Question[]>(`${this.baseUrl}/Exam/${examId}/Questions`, { headers });
  }
}
 