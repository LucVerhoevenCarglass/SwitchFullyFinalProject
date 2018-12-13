import { LoginPage } from './login.po';

fdescribe('workspace-project App', () => {
  let loginPage: LoginPage = new LoginPage();

 // beforeAll(() => loginPage.navigateTo());

  it('should authenticate the user', () => {
    loginPage.navigateTo();
    loginPage.login(loginPage.user)
    .expectIfUserIsLoggedIn('Niels');
  });
});
