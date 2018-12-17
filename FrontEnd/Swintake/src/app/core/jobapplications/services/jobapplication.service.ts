import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { ApiUrl } from '../../CommonUrl/CommonUrl';
import { JobApplication } from '../classes/jobApplication';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()

export class JobApplicationService {
  
  constructor(private http: HttpClient) { }
  
  createJobApplication(campaignId: string, candidateId: string): Observable<JobApplication> {
      return this.http.post<JobApplication>(ApiUrl.urlJobApplications, {candidateId, campaignId}, httpOptions);
    }
}
