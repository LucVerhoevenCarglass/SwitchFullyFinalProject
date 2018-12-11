import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms'
import { CampaignService } from '../../../core/campaigns/campaign.service'

@Component({
  selector: 'app-campaign-create',
  templateUrl: './campaign-create.component.html',
  styleUrls: ['./campaign-create.component.css']
})
export class CampaignCreateComponent implements OnInit {

  createNewCampaignForm = new FormGroup({
    campaignName : new FormControl(''),
    campaignClient : new FormControl(''),
    campaignStartDate : new FormControl(''),
    campaignClassStartDate : new FormControl(''),
    campaignComment : new FormControl('')
  });

  constructor(private campaignService: CampaignService) { }

  ngOnInit() {
  }

  create() {
    console.log("starting create a campaign");
    this.campaignService.addCampaign(this.createNewCampaignForm.value)
    console.log("created a campaign");
  }

}