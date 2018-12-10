import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/core/users/user.service';
import { User } from 'src/app/core/users/user';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent implements OnInit {

  public user: User;
  constructor(private userService: UserService) { }

  ngOnInit() {
    this.getCurrentUser();
  }

  getCurrentUser(): void{
    this.user = this.userService.user;
  }

  // logOut() {
  //   this.userService.signOut();
  // }

}
