import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Option } from '../models/option.model';
 
@Injectable({
  providedIn: 'root'
})
export class OptionService {
  private baseUrl = 'https://localhost:7107/api';
 
  constructor(private http: HttpClient) { }
 
  getOptionQuestionId(questionId: number): Observable<Option[]> {
    return this.http.get<Option[]>(`${this.baseUrl}/Option/Question/${questionId}`);
  }
 
  getOption(questionId: number): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/Option/${questionId}`);
  }
}
 