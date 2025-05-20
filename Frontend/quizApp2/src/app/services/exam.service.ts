import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Exam } from '../models/exam.model';
import { Question } from '../models/question.model';
 
@Injectable({
  providedIn: 'root',
 
})
export class ExamService {
  private baseUrl = 'https://localhost:7107/api';
 
  constructor(private http: HttpClient) {}
 
  getExam(): Observable<Exam[]> {
    return this.http.get<Exam[]>(`${this.baseUrl}/Exam`);
  }
 
  getQuestionsByExamId(examId:number): Observable<Question[]> {
    return this.http.get<Question[]>(`${this.baseUrl}/Exam/Questions/${examId}`);
 
  }
}