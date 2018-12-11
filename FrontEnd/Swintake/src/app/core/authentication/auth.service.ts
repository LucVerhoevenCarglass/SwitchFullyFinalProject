import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http'
import { User } from '../users/user';
import {map, tap} from 'rxjs/operators'
import { shareReplay } from 'rxjs/operators';
import * as moment from "moment";
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json'})
};

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private userUrl = 'http://localhost:56258/api/Users/authenticate';
  userName: string;

  constructor(private http: HttpClient) { }

  login(user: User): Observable<User>
  {
    return this.http.post<User>(this.userUrl, user, httpOptions)
      .pipe(
        tap(res => this.setSession),
        tap(res => console.log(res)));
  }

  setSession(authResult) {
    const expiresAt = moment().add(authResult.expiresIn, 'second');

    localStorage.setItem('id_token', authResult.idToken);
    localStorage.setItem('expires_at', JSON.stringify(expiresAt.valueOf()));
  }
}
