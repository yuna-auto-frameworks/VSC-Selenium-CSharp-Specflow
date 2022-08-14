using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_SHARP_SPECFLOW.Commons
{
    public class AbstractPage
    {
        public IWebElement element;
        public int timeWait = 30;

        public void clickToElement(IWebDriver driver, string locator)
        {
            element = driver.FindElement(By.XPath(locator));
            element.Click();
        }

        public void sendKeyToElement(IWebDriver driver, string locator, string value)
        {
            element = driver.FindElement(By.XPath(locator));
            element.Clear();
            element.SendKeys(value);
        }

        public void waitForControl(IWebDriver driver, string locator)
        {
            try
            {
                By by = By.XPath(locator);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
                wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void waitForDynamicControl(IWebDriver driver, string locator, string value)
        {
            try
            {
                By by = null;
                string control = string.Format(locator, value);
                by = By.XPath(control);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
                wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public bool isControlDisplayed(IWebDriver driver, string locator)
        {
            try
            {
                element = driver.FindElement(By.XPath(locator));
                return element.Displayed;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool isDynamicControlDisplayed(IWebDriver driver, string locator, string value)
        {
            try
            {
                string control = string.Format(locator, value);
                element = driver.FindElement(By.XPath(locator));
                return element.Displayed;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public void selectItemCombobox(IWebDriver driver, string locator, string item)
        {
            element = driver.FindElement(By.XPath(locator));
            SelectElement select = new SelectElement(element);
            select.SelectByText(item);
        }

        public String getText(IWebDriver driver, string controlName)
        {
            try
            {
                waitForControl(driver, controlName);
                element = driver.FindElement(By.XPath(controlName));
                return element.Text;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }




    }
}
