import { Component, OnInit } from '@angular/core';
import {FormGroup, FormBuilder, Validators, FormControl} from '@angular/forms'
import { UserService } from 'src/app/core/users/user.service';
import { Authentication } from 'src/app/core/users/authentication';
import { AuthService } from 'src/app/core/authentication/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  userForm = this.formbuilder.group(
    {
      email: ['', Validators.required],
      password: ['', Validators.required]
    }
  );
  constructor(private formbuilder: FormBuilder, private authService: AuthService) { }

  ngOnInit() {
  }

  authenticate() : void{
    this.authService.login(this.userForm.value).
    subscribe(i => window.location.href = `/jobapplications/`);
  }
}
