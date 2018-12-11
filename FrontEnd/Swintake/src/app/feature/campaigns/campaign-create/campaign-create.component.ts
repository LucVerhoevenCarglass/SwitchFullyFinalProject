import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { CampaignService } from '../../../core/campaigns/campaign.service'
import { Campaign } from 'src/app/core/campaigns/campaign';

@Component({
  selector: 'app-campaign-create',
  templateUrl: './campaign-create.component.html',
  styleUrls: ['./campaign-create.component.css']
})
export class CampaignCreateComponent implements OnInit {

  /*createNewCampaignForm = new FormGroup({
    campaignName : new FormControl(''),
    campaignClient : new FormControl(''),
    campaignStartDate : new FormControl(''),
    campaignClassStartDate : new FormControl(''),
    campaignComment : new FormControl('')
  });
  */
  createNewCampaignForm = this.formbuilder.group({
    Name: ['', Validators.required],
    Client: ['', Validators.required],
    StartDate: ['', Validators.required],
    ClassStartDate: ['', Validators.required],
    Comment: [''],
    });

    campaign: Campaign = new Campaign();
    submitted = false;



  constructor(
    private campaignService: CampaignService,
    private formbuilder: FormBuilder) { }

  ngOnInit() {
  }

  create() {
    this.campaignService.addCampaign(this.createNewCampaignForm.value)
        .subscribe();
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
      return false;;
    }
   return true;
  }

}