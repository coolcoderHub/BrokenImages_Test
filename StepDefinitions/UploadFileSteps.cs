using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace UnitTestProject_SpecFlow.StepDefinitions
{
    [Binding]
    public class UploadFileSteps
    {
        IWebDriver driver;
        ChromeOptions capability;

    [Given(@"Open given upload link")]
        public void GivenOpenGivenUploadLink()
        {
            //capability = new ChromeOptions();

            ////capability.AddAdditionalChromeOption("browserName", "Chrome");
            //capability.AddAdditionalChromeOption("version", "latest");
            //capability.AddAdditionalChromeOption("platform", "WIN10");
            //capability.AddAdditionalChromeOption("client_key", "key");
            //capability.AddAdditionalChromeOption("client_secret", "secret");
            //capability.AddAdditionalChromeOption("name", "Test File Upload");
            //capability.AddAdditionalChromeOption("uploadFilepath", "C:\\test\\logo.png");

            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/upload");

            //driver = new RemoteWebDriver(new Uri("https://hub.testingbot.com/wd/hub"), capability);
            //driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/upload");
        }
        
        [When(@"Select your file for upload")]
        public void WhenSelectYourFileForUpload()
        {
            var allowsDetection = driver as IAllowsFileDetection;
            allowsDetection.FileDetector = new LocalFileDetector();

            IWebElement upload = driver.FindElement(By.Id("file-upload"));
            upload.SendKeys("C:\\test\\logo.png");
        }
        
        [Then(@"Upload file to page")]
        public void ThenUploadFileToPage()
        {
            driver.FindElement(By.Id("file-submit")).Click();

            bool uploaded = true; // ?????
            Assert.AreEqual(true, uploaded);

            driver.Quit();
        }
    }
}
