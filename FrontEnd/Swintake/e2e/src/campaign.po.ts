import {browser, by, protractor, element} from 'protractor';
import { Campaign } from 'src/app/core/campaigns/classes/campaign';


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

 

    navigateCreateCampaign(){
    
        browser.findElement(by.id('CreateButtonCampaign')).click();
    }

    AddNewCampaign(campaign: Campaign){
        browser.findElement(by.id('inputNameText')).sendKeys(campaign.name);
        browser.findElement(by.id('inputClientText')).sendKeys(campaign.client);
        browser.findElement(by.id('inputStartDate')).sendKeys(campaign.startDate.getDate()+'-'+(campaign.startDate.getMonth()+1)+'-'+campaign.startDate.getFullYear());
        browser.findElement(by.id('inputClassStartDate')).sendKeys(campaign.classStartDate.getDate()+'-'+(campaign.classStartDate.getMonth()+1)+'-'+(campaign.classStartDate.getFullYear()+1));
        browser.findElement(by.id('CampaignCreateButton')).click();
        return this;
    }

    expectifCampaignHasbeenAddedToList(campaingName: string)
    {
        expect(browser.wait(protractor.ExpectedConditions.textToBePresentInElement(element(by.id('listcampaings')),campaingName),5000)).toBeTruthy();
        return this;
    }
}
