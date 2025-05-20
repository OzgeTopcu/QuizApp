import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/user.model';
 
@Injectable({
  providedIn: 'root'
})
export class UserService {
  private baseUrl = "https://localhost:7107/api";
 
  constructor(private http: HttpClient) {}
 
  getUserById(userId: number): Observable<User> {
    return this.http.get<User>(`${this.baseUrl}/User/${userId}`);
  }
 
  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(`${this.baseUrl}/User`);
  }
}