import { Component, OnInit } from '@angular/core';
import { CampaignService } from 'src/app/core/campaigns/services/campaign.service';
import { Campaign } from 'src/app/core/campaigns/classes/campaign';
import { Candidate } from 'src/app/core/candidates/classes/candidate';
import { ApiUrl } from 'src/app/core/CommonUrl/CommonUrl';
import { ActivatedRoute } from '@angular/router';
import { JobapplicationService } from 'src/app/core/jobapplications/jobapplication.service';

@Component({
  selector: 'app-campaign-dropdown',
  templateUrl: './campaign-dropdown.component.html',
  styleUrls: ['./campaign-dropdown.component.css']
})
export class CampaignDropdownComponent implements OnInit {

  campaings: Campaign[];
  selectedCampaign: number;
  candidateId: number;

  constructor(private campaignService: CampaignService, private route: ActivatedRoute, private jobApplicationService: JobapplicationService) 
  { 
    this.campaignService.getCampaigns().subscribe(data => this.campaings = data,
      error => console.log(error));
      this.route.params.subscribe(params => { 
        this.candidateId = params['id'];
      });

  }

  ngOnInit() {
  }

  onSubmit(campaignId: number){
    this.jobApplicationService.createJobApplication(campaignId, this.candidateId);
    
}
