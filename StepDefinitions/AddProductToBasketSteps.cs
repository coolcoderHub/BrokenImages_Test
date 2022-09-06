using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium.Interactions;
using System.Linq;
using OpenQA.Selenium.Support.UI;
using UnitTestProject_SpecFlow.Custom;

namespace UnitTestProject_SpecFlow.StepDefinitions
{
    [Binding]
    public class AddProductToBasketSteps
    {
        IWebDriver driver;
        IList<IWebElement> productList;
        IWebElement product;
        Actions action;

        [Given(@"open web page")]
        public void GivenOpenWebPage()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            driver.Manage().Window.Maximize();
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, 800)");
        }
        
        [When(@"find first product in page")]
        public void WhenFindFirstProductInPage()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Actions action = new Actions(driver);
            product = wait.Until(CustomExpectedConditions.ElementExistsIsVisibleIsEnabledNoAttribute(By.XPath(("//*[@id=\"layer_cart\"]/div[1]/div[2]/div[4]/a/span"))));
            //var btn = wait.Until(CustomExpectedConditions.ElementExistsIsVisibleIsEnabledNoAttribute(By.CssSelector("#homefeatured > .ajax_block_product:nth-child(1) .button:nth-child(1) > span")));
            action.MoveToElement(driver.FindElement(By.CssSelector("#homefeatured > .ajax_block_product:nth-child(1) .button:nth-child(1) > span"))).Build().Perform();
            Thread.Sleep(500);

        }

        [Then(@"add product to basket")]
        public void ThenAddProductToBasket()
        {
            driver.Quit();
        }
    }
}
