import { LoginPage } from './login.po';
import { CampaignPage } from './campaign.po';
import { CandidatePage } from './candidate.po';

fdescribe('workspace-project App', () => {
  let loginPage: LoginPage = new LoginPage();
  let campaignPage: CampaignPage = new CampaignPage();
  let candidatePage: CandidatePage = new CandidatePage();

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

    it('should add new created candidate into list', () => {
      candidatePage.navigateTo();
      candidatePage.navigateCreateCandidate();
 
      candidatePage.addNewCandidate(candidatePage.candidate)
                  .expectifCandidateHasbeenAddedToList(candidatePage.candidate.firstName);
     });
 
});
