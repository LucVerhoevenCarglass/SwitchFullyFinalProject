import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { User } from '../users/user';
import { map, tap, catchError } from 'rxjs/operators'
import { shareReplay } from 'rxjs/operators';
import { Observable, of, BehaviorSubject } from 'rxjs';
import { error } from 'util';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()

export class AuthService {

  private tokenInfoSubject: BehaviorSubject<any>;
  public tokenInfo: Observable<any>;
  private userUrl = 'http://localhost:56258/api/Users/';

  constructor(private http: HttpClient) {
    this.tokenInfoSubject = new BehaviorSubject<any>(JSON.parse(sessionStorage.getItem('tokenInfo')));
    this.tokenInfo = this.tokenInfoSubject.asObservable();
  }

  login(email: string, password: string) {
    return this.http.post<any>(`${this.userUrl}authenticate`, { email, password })
      .pipe(map(user => {
        if (user) {
          localStorage.setItem('tokenInfo', user);
          this.tokenInfoSubject.next(user);
        }
        return user;
      }));
  }
  
  getCurrentUser() {
    return this.http.get(`${this.userUrl}current`);
  }

  logout() {
    sessionStorage.removeItem('tokenInfo');
  }
}
