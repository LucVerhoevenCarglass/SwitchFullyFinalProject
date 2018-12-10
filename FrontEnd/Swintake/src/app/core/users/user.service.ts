import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http'
import { Observable, BehaviorSubject } from 'rxjs';
import { User } from './user';
import { Authentication } from './authentication';
import {map} from 'rxjs/operators'

const httpOptions = { headers: new HttpHeaders({'Content-Type': 'application/json'})};

@Injectable()

export class UserService {
  
  private currentUserTokenSubject: BehaviorSubject<Authentication>;
  public currentUserToken: Observable<Authentication>;
  public user: User;
  
  private userUrl = 'http://localhost:56258/api/Users/authenticate'
  
  constructor(private http: HttpClient) {
    this.currentUserTokenSubject = new BehaviorSubject<Authentication>(JSON.parse(sessionStorage.getItem("currentUserToken")));
    this.currentUserToken = this.currentUserTokenSubject.asObservable();
  }
  
  public get currentUserTokenValue(): Authentication{
    return this.currentUserTokenSubject.value;
  }
  
  // authenticate(email: string, password: string) {
  //   return this.http.post(this.userUrl, JSON.stringify({email, password}))
  //   .map(res => res.json())
  //   .map(res => {
  //     localStorage.setItem('auth_token', res.auth_token);
  //     this.logged
  //   }
  //     )
  // }
}
