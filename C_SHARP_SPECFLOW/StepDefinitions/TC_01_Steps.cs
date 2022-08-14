using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Firefox;
using C_SHARP_SPECFLOW.Interfaces;

namespace C_SHARP_SPECFLOW.StepDefinitions
{
    [Binding]
    public class TC_01_Steps
    {
        private IWebDriver driver;

        [Given(@"I am on LiveGuru site")]
        public void GivenIAmOnLiveGuruSite()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl(MyAccountUI.MY_ACCOUNT_URL);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
        }
        
        [Given(@"I input username (.*) and password (.*)")]
        public void GivenIInputUsernameAndPassword(string userName, string password)
        {
            driver.FindElement(By.XPath(MyAccountUI.USERNAME_TXT)).SendKeys(userName);
            driver.FindElement(By.XPath(MyAccountUI.PASSWORD_TXT)).SendKeys(password);
        }

        [When(@"I click Login button")]
        public void WhenIClickLoginButton()
        {
            driver.FindElement(By.XPath(MyAccountUI.LOGIN_BTN)).Click();
        }
        
        [Then(@"The error message should be display")]
        public Boolean ThenTheErrorMessageShouldBeDisplay()
        {
            IWebElement errorMessage = driver.FindElement(By.XPath(MyAccountUI.INVALID_ERROR_MSG));
            return errorMessage.Displayed;
        }

        [Then(@"I quit browser")]
        public void ThenIQuitBrowser()
        {
            driver.Quit();
        }

        [Then(@"I verify the failure message (.*)")]
        public Boolean ThenIVerifyTheFailureMessage(string error)
        {
            string control = string.Format(MyAccountUI.DYNAMIC_INVALID_ERROR_MSG, error);
            IWebElement errorMessage = driver.FindElement(By.XPath(control));
            return errorMessage.Displayed;
        }

        [Given(@"I input username and password")]
        public void GivenIInputUsernameAndPassword(Table table)
        {
            driver.FindElement(By.XPath(MyAccountUI.USERNAME_TXT)).SendKeys(table.Rows[1]["email"]);
            driver.FindElement(By.XPath(MyAccountUI.PASSWORD_TXT)).SendKeys(table.Rows[1]["pass"]);
        }

        [Then(@"I verify the failure message")]
        public Boolean ThenIVerifyTheFailureMessage(Table table)
        {
            string control = string.Format(MyAccountUI.DYNAMIC_INVALID_ERROR_MSG, table.Rows[0]["error"]);
            IWebElement errorMessage = driver.FindElement(By.XPath(control));
            return errorMessage.Displayed;
        }

        [Then(@"The error message (.*) should be shown on form")]
        public bool ThenTheErrorMessageShouldBeShownOnForm(string errorMsg)
        {
            string control = string.Format(MyAccountUI.DYNAMIC_INVALID_ERROR_MSG, errorMsg);
            IWebElement element = driver.FindElement(By.XPath(control));
            return element.Displayed;
        }



    }
}
