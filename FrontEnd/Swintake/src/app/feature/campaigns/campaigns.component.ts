import { Component, OnInit } from '@angular/core';
import { Campaign } from '../../core/campaigns/campaign';
import { CampaignService } from '../../core/campaigns/campaign.service';

@Component({
  selector: 'app-campaigns',
  templateUrl: './campaigns.component.html',
  styleUrls: ['./campaigns.component.css']
})
export class CampaignsComponent implements OnInit {

  campaigns: Campaign[];

  constructor(private campaignService: CampaignService) { }

  ngOnInit() {
    this.getAllCampaigns();
  }

  getAllCampaigns(){
    this.campaignService.getCampaigns()
    .subscribe(campaigns => this.campaigns = campaigns);
  }

}
