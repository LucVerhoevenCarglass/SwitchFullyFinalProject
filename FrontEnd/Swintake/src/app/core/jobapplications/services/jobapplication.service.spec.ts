import { HttpClient } from '@angular/common/http';
import { of } from 'rxjs';
import { ApiUrl } from '../../CommonUrl/CommonUrl';
import { JobApplication } from '../classes/jobApplication';
import { JobApplicationService } from './jobapplication.service';
import { Candidate } from '../../candidates/classes/candidate';
import { Campaign } from '../../campaigns/classes/campaign';

fdescribe('JobApplicationService', () => {
  let httpClient: HttpClient;
  let jobApplicationService: JobApplicationService;

  beforeEach(() => {
    httpClient = ({ get: null, post: null } as unknown) as HttpClient;
    jobApplicationService = new JobApplicationService(httpClient);
  });

  it('should return new JobApplication', () => {

    let candidate: Candidate = {
      firstName: 'Peter',
      lastName: 'Parker',
      email: 'totallynotspiderman@gmail.com',
      phoneNumber: '0470000000',
      gitHubUserName: 'noYOUarespiderman',
      linkedIn: 'pp',
      comment: 'great candidate'
    };

    let campaign: Campaign = {
      name: 'User',
      client: 'Client',
      startDate: new Date(),
      classStartDate: new Date()
    };


    let jobApplication: JobApplication = {
      candidateId: candidate.id,
      campaignId: campaign.id,
      candidate: candidate,
      campaign: campaign
    };

  spyOn(httpClient, 'post').and.callFake((url: string) => {
    expect(url).toBe(ApiUrl.urlJobApplications);
    return of(jobApplication);
  });

  jobApplicationService.createJobApplication(jobApplication.candidateId, jobApplication.campaignId)
    .subscribe((result: JobApplication) =>
      expect(result).toEqual(jobApplication));
});
});
