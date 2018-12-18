import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { first } from 'rxjs/operators';
import { AuthService } from 'src/app/core/authentication/services/auth.service';
import { LoggedInUser } from '../core/authentication/classes/loggedInUser';
import { UserAuth } from '../core/authentication/classes/userAuth';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],

})

export class HeaderComponent {
  currentUser: LoggedInUser = new LoggedInUser();
  currentUserToken: UserAuth;

  constructor(private authService: AuthService, private router: Router, private modalService: NgbModal) {
    this.authService.tokenInfo.subscribe(t => { this.currentUserToken = t });
  }

  ngOnInit() {
  }

  logOut() {
    this.authService.logout();
    this.currentUser = new LoggedInUser();
    this.router.navigate(['/login']);
  }

  currentUserName(): string {
    if (this.currentUserToken && !this.currentUser.firstName) {
      this.authService.getCurrentUser().pipe(first()).subscribe(
        user => {
          this.currentUser = user;
        });
    }
    return `${this.currentUser.firstName}`;
  }
}

