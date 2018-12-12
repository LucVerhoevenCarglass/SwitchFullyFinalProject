import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms'
import { UserService } from 'src/app/core/users/user.service';
import { Authentication } from 'src/app/core/users/authentication';
import { AuthService } from 'src/app/core/authentication/auth.service';
import { Router, ActivatedRoute } from '@angular/router'
import { first } from 'rxjs/operators'

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
  invalidLogin: boolean;

  constructor(private formbuilder: FormBuilder, private authService: AuthService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
  }

  login(): void {
    const val = this.userForm.value;
    if (val.email && val.password) {
      this.authService.login(val.email, val.password)
        .pipe(first())
        .subscribe(
          i => window.location.href = '/jobapplications',
          error => {
            console.log(error);
          });
    }
  }
  getCurrentUser() {
    this.authService.getCurrentUser();
  }
}
