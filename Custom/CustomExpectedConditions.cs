using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject_SpecFlow.Custom
{
    public class CustomExpectedConditions
    {

        public static Func<IWebDriver, IWebElement> ElementExistsIsVisibleIsEnabledNoAttribute(By locator)
        {
            return (driver) =>
            {
                IWebElement element = driver.FindElement(locator);
                if (element.Displayed && element.Enabled)
                {
                    return element;
                }

                return null;
            };
        }
    }
}
