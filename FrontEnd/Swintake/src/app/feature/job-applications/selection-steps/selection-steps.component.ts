import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { JobApplication } from 'src/app/core/jobapplications/classes/jobApplication';
import { JobApplicationService } from 'src/app/core/jobapplications/services/jobapplication.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { SelectionStep } from 'src/app/core/jobapplications/classes/selectionStep';

@Component({
  selector: 'app-selection-steps',
  templateUrl: './selection-steps.component.html',
  styleUrls: ['./selection-steps.component.css']
})
export class SelectionStepsComponent implements OnInit {
  @Input() jobapplication: JobApplication ;
  //jobapplication: JobApplication = new JobApplication();
  selectionStep: SelectionStep = new SelectionStep();
  submitted = false;
  SelectionStepForm: FormGroup;
  constructor(private route: ActivatedRoute,
              private formbuilder: FormBuilder,
              private _router: Router,
              private jobApplicationService: JobApplicationService  ) { }

ngOnInit() {
  //this.getApplicationById();
  if (this.jobapplication && this.jobapplication.currentSelectionStep) 
  {
       this.selectionStep = this.jobapplication.currentSelectionStep;
  };
  this.SelectionStepForm = this.formbuilder.group({
    comment: ['']
  });
}

//   getApplicationById(): any{
//     const id = this.route.snapshot.paramMap.get('id');
//     this.jobApplicationService.getJobApplicationById(id)
//        .subscribe(jobapp => {this.jobapplication=jobapp;});
//        if (this.jobapplication && this.jobapplication.currentSelectionStep) {
//            this.selectionStep = this.jobapplication.currentSelectionStep;
//        }
// }

get i()
{
  return this.SelectionStepForm.controls;
}

isValid(): boolean{
  this.submitted = true;
  if(this.SelectionStepForm.invalid)
  {
    return false;
  }
  return true;
}

cancel(){
  //this._router.navigateByUrl('/candidates');
}

}
