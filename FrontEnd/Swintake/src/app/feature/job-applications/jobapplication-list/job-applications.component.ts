import { Component, OnInit } from '@angular/core';
import { JobApplication } from 'src/app/core/jobapplications/classes/jobApplication';
import { JobApplicationService } from 'src/app/core/jobapplications/services/jobapplication.service';
import { CandidateService } from 'src/app/core/candidates/services/candidate.service';
import { CampaignService } from 'src/app/core/campaigns/services/campaign.service';
import { pipe } from '@angular/core/src/render3';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-job-applications',
  templateUrl: './job-applications.component.html',
  styleUrls: ['./job-applications.component.css']
})
export class JobApplicationsComponent implements OnInit {

  jobApplications: JobApplication[] = [];
  constructor(private jobApplicationService: JobApplicationService) { }

  ngOnInit() {
    this.getAllJobApplications();
  }

  getAllJobApplications(): void {
    this.jobApplicationService.getJobApplications()
      .subscribe(jobApplications => this.jobApplications = jobApplications);
  }
}
