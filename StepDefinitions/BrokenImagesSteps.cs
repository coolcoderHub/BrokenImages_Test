using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.Threading;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using System.Net;
using System.IO;

namespace UnitTestProject_SpecFlow.StepDefinitions
{
    [Binding]
    public class BrokenImagesSteps
    {
        IList<IWebElement> imagelist;
        int brokenImagesCount;

        IWebDriver driver; 

        [Given(@"open http call")]
        public void GivenOpenHttpCall()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/broken_images");
            //linklist = driver.FindElements(By.TagName("a"));

            //in the same linklist list add another attribute img is added to the list//
            imagelist = driver.FindElements(By.TagName("img"));
            //list is created to store the a tag that has only href//
        }
        
        [When(@"count broken images in page")]
        public void WhenCountBrokenImagesInPage()
        {
                brokenImagesCount = 0;
                for (int q = 0; q < imagelist.Count; q++)
                {
                    Console.WriteLine(imagelist[q]);

                    String linkURL = imagelist[q].GetAttribute("src");
                    Console.WriteLine("linkURL = " + linkURL);

                    Uri url = new Uri(linkURL);

                    try
                    {
                        var request = (HttpWebRequest)WebRequest.Create(url);
                        request.Method = "GET";

                        using (var response = (HttpWebResponse)request.GetResponse())
                        {
                            using (var stream = response.GetResponseStream())
                            {
                                using (var sr = new StreamReader(stream))
                                {
                                    var statusCod = response.StatusCode;
                                    int statusCode = (int)statusCod;

                                    Console.WriteLine(linkURL + " and its Status codes is:" + statusCode.ToString());
                                    if (statusCode == 404 || statusCode == 500)
                                    {
                                        if (statusCode != 200)
                                        {
                                            brokenImagesCount = brokenImagesCount + 1;
                                            Console.WriteLine(linkURL + " and its Status codes is:" + statusCode.ToString());
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        // handle err
                    }

                //Console.WriteLine("The total number of broken images are:" + brokenImagesCount);

            }

        }

        [Then(@"write broken images count")]
        public void ThenWriteBrokenImagesCount()
        {
            Console.WriteLine("The total number of broken images are:" + brokenImagesCount);
            Assert.AreEqual(brokenImagesCount, 0);
            driver.Quit();
        }
    }
}
