import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { CampaignService } from '../../../core/campaigns/services/campaign.service'
import { Campaign } from 'src/app/core/campaigns/classes/campaign';
import { Router } from '@angular/router';
import { ApiUrl } from 'src/app/core/CommonUrl/CommonUrl';

// TODO: Remove console.log() statements

@Component({
  selector: 'app-campaign-create',
  templateUrl: './campaign-create.component.html',
  styleUrls: ['./campaign-create.component.css']
})
export class CampaignCreateComponent implements OnInit {

    campaign: Campaign = new Campaign();
    submitted = false;
    createNewCampaignForm:FormGroup;
    errorMessageForClassStartDate: string;

  constructor(
    private campaignService: CampaignService,
    private formbuilder: FormBuilder,
    private _router: Router) { }

    ngOnInit() {
      this.campaign.name="new Campaign";
      this.createNewCampaignForm = this.formbuilder.group({
        name: ['', Validators.required],
        client: ['', Validators.required],
        startDate: ['', Validators.required],
        classStartDate: ['', Validators.required],
        comment: ['']
      });
      
  }

  create() {
          this.campaignService.addCampaign(this.createNewCampaignForm.value)
              .subscribe(data => {
                this._router.navigateByUrl('/campaigns');
              }, error => {console.log(error)});
  }

  cancel(){
    this._router.navigateByUrl('/campaigns');  }

  // TODO: a method with the name i, nice... (joke, not nice!). Refactor :)
  get i(){
    return this.createNewCampaignForm.controls;
  }

  isValid(): boolean{
    this.submitted=true;
    this.errorMessageForClassStartDate = this.compareTwoDates();
    if(this.createNewCampaignForm.invalid || this.errorMessageForClassStartDate != null)
    {
      return false;
    }
   return true;
  }

  compareTwoDates(){
    let dateStartClassCampaign = new Date(this.i.classStartDate.value).toISOString().slice(0,10);
    let dateStartCampaign = new Date(this.i.startDate.value).toISOString().slice(0,10);
console.log(dateStartCampaign);
console.log(dateStartClassCampaign);
    if(dateStartClassCampaign <  dateStartCampaign){
      return `The class startDate can't start before the campaing start date`;
    }
    return null;
  }

}