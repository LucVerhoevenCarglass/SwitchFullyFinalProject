import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms'
import { AuthService } from 'src/app/core/authentication/auth.service';
import { Router, ActivatedRoute } from '@angular/router'
import { first } from 'rxjs/operators'
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'ngbd-modal-content',
  template: `
    <div class="modal-header">
      <h4 class="modal-title">Oops!</h4>
      <button type="button" class="close" aria-label="Close" (click)="activeModal.dismiss('Cross click')">
        <span aria-hidden="true">&times;</span>
      </button>
    </div>
    <div class="modal-body">
      <p>E-mail or Password invalid</p>
    </div>
    <div class="modal-footer">
      <button type="button" class="btn btn-outline-dark" (click)="activeModal.close('Close click')">Close</button>
    </div>
  `
})
export class NgbdModalContent {

  constructor(public activeModal: NgbActiveModal) {}
}

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {

  isSubmitted = false;
  userForm: FormGroup;
  invalidLogin: boolean;
  returnUrl: string;
  
  constructor(private formbuilder: FormBuilder, 
    private authService: AuthService, 
    private route: ActivatedRoute, 
    private router: Router,
    private modalService: NgbModal) { }
  
  ngOnInit() {
    this.userForm = this.formbuilder.group(
      {
        email: ['', [Validators.required, Validators.email]],
        password: ['', Validators.required]
      }
    );

    this.authService.logout();
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  get f(){
    return this.userForm.controls;
  }

  isValid(): boolean{
    this.isSubmitted = true;
    if(this.userForm.invalid)
    {
      return false;
    }
    return true;
  }
  
  login(): void {
    const val = this.userForm.value;
    if (val.email && val.password) {
      this.authService.login(val.email, val.password)
        .pipe(first())
        .subscribe(data => {
          this.router.navigate(['/jobapplications']);},
          error => {
            this.open();
          });
    }
  }

  open() {
    this.modalService.open(NgbdModalContent);
    this.userForm.reset();
    this.isSubmitted = false;
  }
}
