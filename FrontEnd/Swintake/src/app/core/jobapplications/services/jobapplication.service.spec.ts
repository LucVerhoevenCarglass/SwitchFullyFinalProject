import { TestBed } from '@angular/core/testing';

import { JobApplicationService } from './jobapplication.service';
import { HttpClient } from '@angular/common/http';
import { JobApplication } from '../classes/jobApplication';
import { ApiUrl } from '../../CommonUrl/CommonUrl';
import { of } from 'rxjs';

fdescribe('JobApplicationService', () => {
  let httpClient: HttpClient;
  let jobApplicationService: JobApplicationService;

  beforeEach(() => {
    httpClient = ({ get: null, post: null } as unknown) as HttpClient;
    jobApplicationService = new JobApplicationService(httpClient);
  });

  it('should return new JobApplication', () => {

    let jobApplication: JobApplication = {
      candidateId: 'candidateId',
      campaignId: 'campaignId'
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
