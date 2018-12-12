import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { map } from 'rxjs/operators'
import { Observable, of, BehaviorSubject } from 'rxjs';
import { UserAuth } from './userAuth';
import { LoggedInUser } from './loggedInUser';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()

export class AuthService {

  private tokenInfoSubject: BehaviorSubject<UserAuth>;
  public tokenInfo: Observable<UserAuth>;

  private userUrl = 'http://localhost:56258/api/Users/';
  
  constructor(private http: HttpClient) {
    this.tokenInfoSubject = new BehaviorSubject<UserAuth>(JSON.parse(sessionStorage.getItem('tokenInfo')));
    this.tokenInfo = this.tokenInfoSubject.asObservable();
  }

  get currentUserTokenValue(): UserAuth{
    return this.tokenInfoSubject.value;
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

  getCurrentUser(): Observable<LoggedInUser> {
    return this.http.get<LoggedInUser>(`${this.userUrl}current`);
  }

  logout() {
    sessionStorage.removeItem('tokenInfo');
    this.tokenInfoSubject.next(null);
  }
}
