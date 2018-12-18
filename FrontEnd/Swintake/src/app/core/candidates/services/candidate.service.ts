import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiUrl } from '../../CommonUrl/CommonUrl';
import { Candidate } from '../classes/candidate';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()

export class CandidateService {
  
  constructor(private http: HttpClient) { }

  addCandidate(candidate: Candidate): Observable<Candidate> {
    delete candidate.id;
    return this.http.post<Candidate>(ApiUrl.urlCandidates, candidate, httpOptions);
  }

  getCandidateById(id: string): Observable<Candidate> {
    return this.http.get<Candidate>(`${ApiUrl.urlCandidates}${id}`);
  }
  
  getCandidates(): Observable<Candidate[]> {
    return this.http.get<Candidate[]>(ApiUrl.urlCandidates);
  }
}
