using C_SHARP_SPECFLOW.Commons;
using C_SHARP_SPECFLOW.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System;
using TechTalk.SpecFlow;

namespace C_SHARP_SPECFLOW.StepDefinitions
{
    [Binding]
    public class TC_04_Steps: AbstractPage
    {
        IWebDriver driver;

        [Given(@"I am on ZingPoll website")]
        public void GivenIAmOnZingPollWebsite()
        {
            driver = new ChromeDriver(@"G:\PROJECT TRAINING\BDD_SPECFLOW_05\C_SHARP_SPECFLOW\C_SHARP_SPECFLOW\Drivers");
            driver.Navigate().GoToUrl(ZingPollUI.HOMEPAGE_URL);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
        }
        
        [Given(@"I click the SignIn button")]
        public void GivenIClickTheSignInButton()
        {
            waitForControl(driver, ZingPollUI.SIGN_IN_TITLE);
            clickToElement(driver, ZingPollUI.SIGN_IN_TITLE);
        }

        [When(@"I enter email (.*) and password (.*)")]
        public void WhenIEnterEmailAndPassword(string userName, string password)
        {
            waitForControl(driver, ZingPollUI.EMAIL_TEXTBOX);
            sendKeyToElement(driver, ZingPollUI.EMAIL_TEXTBOX, userName);
            sendKeyToElement(driver, ZingPollUI.PASSWORD_TEXTBOX, password);
        }


        [When(@"I click Submit button")]
        public void WhenIClickSubmitButton()
        {
            clickToElement(driver, ZingPollUI.LOGIN_BUTTON);
        }
        
        [Then(@"The SignIn form should be shown")]
        public void ThenTheSignInFormShouldBeShown()
        {
            waitForControl(driver, ZingPollUI.SIGN_IN_POPUP);
            isControlDisplayed(driver, ZingPollUI.SIGN_IN_POPUP);
        }
        
        [Then(@"I verify the error failure message (.*)")]
        public void ThenIVerifyTheErrorFailureMessage(string errorMsg)
        {
            waitForDynamicControl(driver, ZingPollUI.ERROR_NOT_REGISTERED_MESSAGE, errorMsg);
            isDynamicControlDisplayed(driver, ZingPollUI.ERROR_NOT_REGISTERED_MESSAGE, errorMsg);
        }
        
        [Then(@"I quit the browser")]
        public void ThenIQuitTheBrowser()
        {
            driver.Quit();
        }
    }
}
