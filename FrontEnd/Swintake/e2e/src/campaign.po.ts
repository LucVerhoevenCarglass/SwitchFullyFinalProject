import {browser, by} from 'protractor';
import { Campaign } from 'src/app/core/campaigns/campaign';

export class CampaignPage{
    navigateTo(){
        return browser.get('/listcampaigns');
    }
    campaign: Campaign = {
        name: 'User',
        client: 'Client',
        startDate: new Date(),
        classStartDate: new Date()
    };

    AddNewCampaign(campaign: Campaign){
        browser.findElement(by.id('CampaignCreateButton')).click();
        browser.findElement(by.id('inputNameText')).sendKeys(campaign.name);
        browser.findElement(by.id('inputClientText')).sendKeys(campaign.client);
        browser.findElement(by.id('inputStartDate')).sendKeys(campaign.startDate.toDateString());
        browser.findElement(by.id('inputClassStartDate')).sendKeys(campaign.classStartDate.toDateString());
        browser.findElement(by.id('CampaignCreateButton')).click();
    }
}
