import { Component, OnInit, HostListener, Inject } from '@angular/core';
import { AuthService } from 'src/app/core/authentication/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],

})

export class HeaderComponent {
  userName: string;
  constructor(private authService: AuthService) { }

  ngOnInit() {
    this.getCurrentUserName();
  }

  logOut() {
    this.authService.logout();
    window.location.href = '/login';
  }

  getCurrentUserName() {
    this.authService.getCurrentUser().subscribe(options => {
      this.userName = options['firstName'];
    });
  }

}
