import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { JobApplication } from 'src/app/core/jobapplications/classes/jobApplication';
import { SelectionStep } from 'src/app/core/jobapplications/classes/selectionStep';
import { JobApplicationService } from 'src/app/core/jobapplications/services/jobapplication.service';


@Component({
  selector: 'app-selection-steps',
  templateUrl: './selection-steps.component.html',
  styleUrls: ['./selection-steps.component.css']
})

export class SelectionStepsComponent implements OnInit {
  @Input() jobapplication: JobApplication ;
  @Output() jobapplicationChange = new EventEmitter<JobApplication>();

  selectionStep: SelectionStep;
  selectionSteps: SelectionStep [];
  submitted = false;
  SelectionStepForm: FormGroup;
  constructor(private route: ActivatedRoute,
              private formbuilder: FormBuilder,
              private _router: Router,
              private jobApplicationService: JobApplicationService  ) { }

ngOnInit() {
  if (this.jobapplication && this.jobapplication.currentSelectionStep) 
  {
       this.selectionStep = this.jobapplication.currentSelectionStep;
       this.selectionSteps = this.orderSelectionStep();
  };
  this.SelectionStepForm = this.formbuilder.group({
    comment: ['']
  });
}

orderSelectionStep(): SelectionStep[] 
{
  
const orderSelectionStep = ["Register CV Screening",
"Register Phone Screening",
"Register TestResults",
"Register First interview",
"Register Group interview",
"Register Final decision",
"Audit Selection process" ];

  let orderSelectionSteps: SelectionStep [] = new Array <SelectionStep>(this.jobapplication.selectionSteps.length);

  for (let index = 0; index < this.jobapplication.selectionSteps.length; index++) {
    
    let i = orderSelectionStep.findIndex(desc => desc === this.jobapplication.selectionSteps[index].description);
    
    orderSelectionSteps[i] = this.jobapplication.selectionSteps[index];    
  }
  return orderSelectionSteps;
}

save() {
 this.jobApplicationService.saveNextSelectionStep(this.jobapplication.id, this.SelectionStepForm.value.comment)
     .subscribe(data => {this.jobapplication = data;
                         this.orderSelectionStep();
                         this.jobapplicationChange.emit(data)}
     );
}

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
