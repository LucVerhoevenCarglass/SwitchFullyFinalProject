import { Component, OnInit, HostListener, Inject } from '@angular/core';
import { AuthService } from 'src/app/core/authentication/services/auth.service';
import { Observable } from 'rxjs';
import { map, first } from 'rxjs/operators';
import { UserAuth } from '../core/authentication/classes/userAuth';
import { Router } from '@angular/router';
import { LoggedInUser } from '../core/authentication/classes/loggedInUser';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';


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
    console.log(this.currentUserToken);
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

