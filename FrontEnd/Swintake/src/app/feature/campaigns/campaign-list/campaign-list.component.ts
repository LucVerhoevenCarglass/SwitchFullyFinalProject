import { Component, OnInit } from '@angular/core';
import { Campaign } from '../../../core/campaigns/campaign';
import { CampaignService } from '../../../core/campaigns/campaign.service';

@Component({
  selector: 'app-campaign-list',
  templateUrl: './campaign-list.component.html',
  styleUrls: ['./campaign-list.component.css']
})
export class CampaignListComponent implements OnInit {

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
