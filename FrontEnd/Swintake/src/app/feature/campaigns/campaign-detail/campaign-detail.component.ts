import { Component, OnInit } from '@angular/core';
import { CampaignService } from '../../../core/campaigns/campaign.service';
import { Campaign } from '../../../core/campaigns/campaign';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-campaign-detail',
  templateUrl: './campaign-detail.component.html',
  styleUrls: ['./campaign-detail.component.css']
})
export class CampaignDetailComponent implements OnInit {
  campaign: Campaign;
  constructor(private campaignService: CampaignService,  private route: ActivatedRoute) { }


  ngOnInit() {
    this.getCampaign()
  }

  getCampaign(): void{
    const id = this.route.snapshot.paramMap.get('id');
    this.campaignService.getCampaign(id)
    .subscribe(campaign => this.campaign = campaign);
  }

}
