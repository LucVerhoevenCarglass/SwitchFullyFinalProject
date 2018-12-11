import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Campaign } from './campaign';
import { Observable } from 'rxjs';
import { ApiUrl } from '../CommonUrl/CommonUrl';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class CampaignService {

  constructor(private http: HttpClient) { }
  
  addCampaign(campaign: Campaign): Observable<Campaign> {
    return this.http.post<Campaign>(ApiUrl.urlCampaign, campaign, httpOptions);
  }

  getCampaigns(): Observable<Campaign[]> {
    return this.http.get<Campaign[]>(ApiUrl.urlCampaign);
  }

  getCampaign(id: string): Observable<Campaign> {
    return this.http.get<Campaign>(`${ApiUrl.urlCampaign}id:string?id=${id}`);
   }

}