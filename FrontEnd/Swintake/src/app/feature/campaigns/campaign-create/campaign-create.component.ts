import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { CampaignService } from '../../../core/campaigns/services/campaign.service'
import { Campaign } from 'src/app/core/campaigns/classes/campaign';
import { DateValidator } from './dateValidator';
import { Router } from '@angular/router';
import { ApiUrl } from 'src/app/core/CommonUrl/CommonUrl';


@Component({
  selector: 'app-campaign-create',
  templateUrl: './campaign-create.component.html',
  styleUrls: ['./campaign-create.component.css']
})
export class CampaignCreateComponent implements OnInit {

    campaign: Campaign = new Campaign();
    submitted = false;
    createNewCampaignForm:FormGroup;
    name = new FormControl('', [Validators.required ]);
    client = new FormControl('', [Validators.required ]);
    startDate = new FormControl('', [Validators.required, DateValidator.dateBeforeToday ]);
    classStartDate = new FormControl('', [Validators.required, DateValidator.dateBeforeToday ]);
    comment = new FormControl('');
    today: Date;

  constructor(
    private campaignService: CampaignService,
    private formbuilder: FormBuilder,
    private _router: Router) { }

    ngOnInit() {
      this.campaign.name="new Campaign";
      this.createNewCampaignForm = this.formbuilder.group({
        name: this.name,
        client: this.client,
        startDate: this.startDate,
        classStartDate: this.classStartDate,
        comment: this.comment,
      });
      this.today = new Date();
  }

  getErrorMessage() {
    return this.name.hasError('required') ? 'Is Required' : 
           this.client.hasError('required') ? 'Is Required' : 
           this.startDate.hasError('required') ? 'Is Required' : 
           this.classStartDate.hasError('required') ? 'Is Required' : '';
  }

  create() {
          this.campaignService.addCampaign(this.createNewCampaignForm.value)
              .subscribe()
          this._router.navigateByUrl('/listcampaigns');
  }

  cancel(){
    this.createNewCampaignForm;
  }

  get i()
  {
    return this.createNewCampaignForm.controls;
  }

  isValid(): boolean{
    this.submitted=true;
    if(this.createNewCampaignForm.invalid)
    {
      return false;
    }
   return true;
  }

}