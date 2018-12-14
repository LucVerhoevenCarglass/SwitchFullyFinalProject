import { LoginPage } from './login.po';
import { CampaignPage } from './campaign.po';

fdescribe('workspace-project App', () => {
  let loginPage: LoginPage = new LoginPage();
  let campaignPage: CampaignPage = new CampaignPage();

 // beforeAll(() => loginPage.navigateTo());

  it('should authenticate the user', () => {
    loginPage.navigateTo();
    loginPage.login(loginPage.user)
    .expectIfUserIsLoggedIn('Niels');
  });

    it('should add new created campaing into list', () => {
     campaignPage.navigateTo();
     campaignPage.navigateCreateCampaign();

     campaignPage.AddNewCampaign(campaignPage.campaign)
                 .expectifCampaignHasbeenAddedToList(campaignPage.campaign.name);
    });
});
