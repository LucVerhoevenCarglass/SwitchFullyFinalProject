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
    campaign: Campaign = new Campaign();
    submitted = false;
    createNewCampaignForm:FormGroup;
    //email = new FormControl('', [Validators.required, Validators.email]);
    name = new FormControl('', [Validators.required ]);
    client = new FormControl('', [Validators.required ]);
    startDate = new FormControl('', [Validators.required ]);
    classStartDate = new FormControl('', [Validators.required ]);
    comment = new FormControl('');



  constructor(
    private campaignService: CampaignService,
    private formbuilder: FormBuilder) { }

    ngOnInit() {
      this.campaign.Name="new Campaign";
      this.createNewCampaignForm = this.formbuilder.group({
        name: this.name,
        client: this.client,
        startDate: this.startDate,
        classStartDate: this.classStartDate,
        comment: this.comment,
      });
  }

  getErrorMessage() {
    return this.name.hasError('required') ? 'Is Required' : 
           this.client.hasError('required') ? 'Is Required' : 
           this.startDate.hasError('required') ? 'Is Required' : 
           this.classStartDate.hasError('required') ? 'Is Required' : '';
  }

  create() {
   // if (this.isValid())
   // {
      this.campaignService.addCampaign(this.createNewCampaignForm.value)
      .subscribe();
  //  }

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