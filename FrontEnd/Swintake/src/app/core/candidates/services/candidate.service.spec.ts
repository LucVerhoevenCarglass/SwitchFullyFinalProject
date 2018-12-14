import { CandidateService } from './candidate.service';
import { HttpClient } from '@angular/common/http';
import { Candidate } from '../classes/candidate';
import { of } from 'rxjs'
import { ApiUrl } from '../../CommonUrl/CommonUrl';

fdescribe('CandidateService', () => {
  let httpClient: HttpClient;
  let candidateService: CandidateService;

  beforeEach(() => {
    httpClient = ({ get: null, post: null } as unknown) as HttpClient;
    candidateService = new CandidateService(httpClient);
  });

  it('should return new candidate', () => {

    let candidate: Candidate = {
      firstName: 'Peter',
      lastName: 'Parker',
      email: 'totallynotspiderman@gmail.com',
      phoneNumber: '0470000000',
      gitHubUserName: 'noYOUarespiderman',
      linkedIn: 'pp',
      comment: 'great candidate'
    };
    spyOn(httpClient, 'post').and.callFake((url: string) => {
      expect(url).toBe(ApiUrl.urlCandidates);
      return of(candidate);
    });

    candidateService.addCandidate(candidate)
      .subscribe((result: Candidate) =>
        expect(result).toEqual(candidate));
  });
});