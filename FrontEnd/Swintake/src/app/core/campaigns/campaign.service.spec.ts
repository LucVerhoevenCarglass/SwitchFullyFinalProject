import { TestBed } from '@angular/core/testing';

import { CampaignService } from './campaign.service';
import { HttpClient } from '@angular/common/http';
import { Campaign } from '../campaigns/campaign';
import { of } from 'rxjs'
import { ApiUrl } from '../CommonUrl/CommonUrl';

fdescribe('CampaignService', () => {
  let httpClient: HttpClient;
  let campaignservice: CampaignService;

  beforeEach(() => 
  {
      httpClient = ({ get: null, post: null } as unknown) as HttpClient;
      campaignservice = new CampaignService(httpClient);
  });

  it('should return new campaign', () => {

    let campaign: Campaign = {
      name: 'User',
      client: 'Client',
      startDate: new Date(),
      classStartDate: new Date()
    };
    spyOn(httpClient, 'post').and.callFake((url: string) => {
      expect(url).toBe(ApiUrl.urlCampaign);
      return of(campaign);
    });

    campaignservice.addCampaign(campaign)
                  .subscribe((result: Campaign) =>
                  expect(result).toEqual(campaign));
  });

  it('should return list of campaigns', () => 
  {
    spyOn(httpClient, 'get').and.callFake((url: string) => {
      expect(url).toBe(ApiUrl.urlCampaign);
      return of(createFakeCampaigns());
    });

    campaignservice.getCampaigns()
    .subscribe((result: Campaign[]) =>
    expect(result.length).toEqual(2));
  });

});


  function createFakeCampaigns(): Campaign[] 
  {
    return [
      {
          id: '1',
          name: 'User',
          client: 'Client',
          startDate: new Date(),
          classStartDate: new Date()
      },
      {
        id: '2',
        name: 'User2',
        client: 'Client',
        startDate: new Date(),
        classStartDate: new Date()
      }
    ]
  }