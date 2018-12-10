import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http'
import { Observable } from 'rxjs';
import { User } from './user';

const httpOptions = { headers: new HttpHeaders({'Content-Type': 'application/json'})};

@Injectable()

export class UserService {
  
  private userUrl = 'http://localhost:56258/api/Users/authenticate'
  
  constructor(private http: HttpClient) { }
    
  authenticate(user: User): Observable<User> {
    return this.http.post<User>(this.userUrl, user, httpOptions);
  }
}
