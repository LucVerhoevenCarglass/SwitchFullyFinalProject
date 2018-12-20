import { Component, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { JobApplication } from 'src/app/core/jobapplications/classes/jobApplication';
import { JobApplicationService } from 'src/app/core/jobapplications/services/jobapplication.service';
import { tap } from 'rxjs/operators';

@Component({
  selector: 'app-jobapplication-detail',
  templateUrl: './jobapplication-detail.component.html',
  styleUrls: ['./jobapplication-detail.component.css']
})
export class JobapplicationDetailComponent implements OnInit {

  jobapplicationId: string;
  jobapplication: JobApplication;
  isJobApplicationRetrieved: boolean;

  constructor(private route: ActivatedRoute,
              private jobApplicationService: JobApplicationService
    ) { }

  ngOnInit() {
    this.isJobApplicationRetrieved = false;
        this.getApplicationById();
  }

  getApplicationById(){
    this.jobapplicationId = this.route.snapshot.paramMap.get('id');
    this.jobApplicationService.getJobApplicationById(this.jobapplicationId)
          .subscribe(jobapp => {
            this.jobapplication = jobapp;
            this.isJobApplicationRetrieved = true;
          });
  }

  jobapplicationChange(jobApplication: JobApplication){
    this.jobapplication=jobApplication;
  }
  
  rejectJobApplication()
  {
    if (confirm('Are you sure you want to reject this jobapplication?')) {
      this.jobApplicationService.rejectJobApplication(this.jobapplicationId);
      this.getApplicationById();
      console.log("service.rejectjobapplication done");
    } 
    else {
      alert('The jobapplication was not rejected');
    }
  }

}
