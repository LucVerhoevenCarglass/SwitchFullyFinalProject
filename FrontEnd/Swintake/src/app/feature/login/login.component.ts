import { Component, OnInit } from '@angular/core';
import {FormGroup, FormBuilder, Validators, FormControl} from '@angular/forms'
import { UserService } from 'src/app/core/users/user.service';

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
  constructor(private formbuilder: FormBuilder, private userService: UserService) { }

  ngOnInit() {
  }

  authenticate() : void{
    this.userService.authenticate(this.userForm.value)
    .subscribe(user => window.location.href = `/jobapplications/`);
  }
}
