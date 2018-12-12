import { Component, OnInit, HostListener, Inject } from '@angular/core';
import { AuthService } from 'src/app/core/authentication/auth.service';
import { Observable } from 'rxjs';
import { map, first } from 'rxjs/operators';
import { UserAuth } from '../core/authentication/userAuth';
import { User } from '../core/users/user';
import { Router } from '@angular/router';
import { LoggedInUser } from '../core/authentication/loggedInUser';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],

})

export class HeaderComponent {
  currentUser: LoggedInUser = new LoggedInUser();
  currentUserToken: UserAuth;

  constructor(private authService: AuthService, private router: Router) {
    this.authService.tokenInfo.subscribe(t => {this.currentUserToken = t});
    console.log(this.currentUserToken);
  }

  ngOnInit() {
  }

  logOut() {
    this.authService.logout();
    this.currentUser = new LoggedInUser();
    this.router.navigate(['/login']);
  }

  CurrentUserName(): string {
    if(this.currentUserToken && !this.currentUser.firstName)
    {
      this.authService.getCurrentUser().pipe(first()).subscribe(
        user => {
          this.currentUser = user;
        });
    }
    return `${this.currentUser.firstName}`;
  }
}

