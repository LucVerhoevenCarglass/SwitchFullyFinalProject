import {browser, by} from 'protractor';
import { User } from 'src/app/core/authentication/classes/user';

export class LoginPage{
    navigateTo(){
        return browser.get('/');
    }

    user: User = {
        Email: 'niels@switchfully.com',
        Password: 'ILoveReinout'
    };

    login(user: User){
        browser.findElement(by.id('emailInput')).sendKeys(user.Email);
        browser.findElement(by.id('passwordInput')).sendKeys(user.Password);
        browser.findElement(by.id('loginButton')).click();
        return this;
    }

    expectIfUserIsLoggedIn(firstName: string)
    {
        expect(browser.findElement(by.id('loggedInUser')).getText()).toContain(firstName);
        return this;
    }
}