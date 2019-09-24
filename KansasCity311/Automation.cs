using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KansasCity311
{
    public class Automation
    {
        IWebDriver driver { get; set; }
        OpenQA.Selenium.Support.UI.WebDriverWait wait { get; set; }

        public string Run(Form311 form311)
        {
            //ChromeDriver
            try
            {
                var chromeDriverService = ChromeDriverService.CreateDefaultService();
                chromeDriverService.HideCommandPromptWindow = true;
                var options = new ChromeOptions();
                //options.AddArguments("--no-sandbox", "--disable-web-security", "--disable-gpu", "--incognito", "--proxy-bypass-list=*", "--proxy-server='direct://'", "--log-level=3", "--hide-scrollbars");
                //options.AddArguments("--headless", "--no-sandbox", "--disable-web-security", "--disable-gpu", "--incognito", "--proxy-bypass-list=*", "--proxy-server='direct://'", "--log-level=3", "--hide-scrollbars");
                driver = new ChromeDriver(chromeDriverService, options);
            }
            catch (Exception ex)
            {
                driver.Quit();
                return "Error creating ChromeDriver, automation never started\n\rException:\r\n" + ex.ToString();
            }

            try
            {
                //Navigate to URL
                driver.Navigate().GoToUrl("https://www.kcmo.gov/city-hall/311/report-to-311-form");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromMinutes(2));

                //Switch to iFrame
                var frame = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//iframe[@src='https://survey.kcmo.org/fs.aspx?surveyid=243f81ae1b94148896facbc9ff349ad']")));
                driver.SwitchTo().Frame(frame);

                //First Name
                ClickAndSendKeysByXpath("//input[@title='First Name:']", form311.ContactInformation.FirstName);

                //Last Name
                ClickAndSendKeysByXpath("//input[@title='Last Name:']", form311.ContactInformation.LastName);

                //Email Address
                ClickAndSendKeysByXpath("//span[text()='Email Address:']/../following-sibling::td//input", form311.ContactInformation.EmailAddress);

                //Confirm Email Address
                ClickAndSendKeysByXpath("//input[@title='Confirm Email Address:']", form311.ContactInformation.EmailAddress);

                //Phone Number
                ClickAndSendKeysByXpath("//input[@title='Contact Phone Number:']", form311.ContactInformation.PhoneNumber);

                //Would You Like Your Contact Information Added to this Case?
                if (form311.ContactInformation.IncludeContactInfo)
                {
                    ClickByXpath("//span[@title='Yes']/input");
                }
                else
                {
                    ClickByXpath("//span[@title='No']/input");
                }

                //I Want To Report
                SendKeysByXpath("//select[contains(@name,'AnswerItemDropDownList')]", form311.WhatToReport);

                //Incident Address or Intersection
                ClickAndSendKeysByXpath("//input[@title='Incident Address or Intersection:']", form311.IncedentAddress);

                //Description/Concern
                ClickAndSendKeysByXpath("//textarea[@class='inputTextItem']", form311.Description);

                //Submit
                ClickByXpath("//input[@class='buttonstyle']");

                //Check for Success Message
                var successMessage = driver.FindElement(By.XPath("//div[text()='Thank you for contacting 311!']"));
                if (successMessage.Displayed)
                {
                    driver.Quit();
                    return "Automation Successful! Thank you for contacting 311!";
                }
                driver.Quit();
            }
            catch (Exception ex)
            {
                driver.Quit();
                return "Error during automation\n\rException:\r\n" + ex.ToString();
            }

            return "Automation did not encounter an error, but 'Thank you for contacting 311!' message was not detected";
        }

        private void ClickAndSendKeysByXpath(string xpath, string sendKeys)
        {
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromMinutes(2));
            try
            {
                var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
                element.Click();
                element.SendKeys(sendKeys);
            }
            catch
            {
                Thread.Sleep(5000);
                var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
                element.Click();
                element.SendKeys(sendKeys);
            }
        }

        private void ClickByXpath(string xpath)
        {
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromMinutes(2));
            try
            {
                var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
                element.Click();
            }
            catch
            {
                Thread.Sleep(5000);
                var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
                element.Click();
            }
        }

        private void SendKeysByXpath(string xpath, string sendKeys)
        {
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromMinutes(2));
            try
            {
                var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
                element.SendKeys(sendKeys);
            }
            catch
            {
                Thread.Sleep(5000);
                var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
                element.SendKeys(sendKeys);
            }
        }
    }
}
