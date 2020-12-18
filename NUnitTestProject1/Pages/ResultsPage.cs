using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace NUnitTestProject1.Pages
{
    public class ResultsPage : DriverHelper
    {
        WebDriverWait wait;
        public ResultsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //[FindsBy(How = How.CssSelector, Using = ".//*[@id='rso']/div[4]/div/div/a/h3/span")]
        //IWebElement searchResult;
        IWebElement searchResult => driver.FindElement(By.XPath(".//*[@id='rso']/div[4]/div/div/a/h3/span"));


        public void searchTextOnResults()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            //Arrange
            String expectedText = "Selenium IDE";
            //Act
            String actualText;
            if (driver.FindElements(By.XPath(".//*[@id='rso']/div[4]/div/div/a/h3/span")).Count > 0)
            {
                actualText = wait.Until(ExpectedConditions.ElementToBeClickable(searchResult)).Text;
            }
            else if(driver.FindElements(By.XPath(".//*[@id='rso']/div[2]/div[3]/div/div/a/h3/div/span")).Count > 0)
            {
                actualText = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//*[@id='rso']/div[2]/div[3]/div/div/a/h3/div/span"))).Text;
            }
            else if (driver.FindElements(By.XPath(".//*[@id='rso']/div[2]/div[3]/div/div/a/h3/span")).Count > 0)
            {
                actualText = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//*[@id='rso']/div[2]/div[3]/div/div/a/h3/span"))).Text;
            }
            else
            {
                actualText = wait.Until(ExpectedConditions.ElementToBeClickable(searchResult)).Text;
            }

            //Assert
            Assert.IsTrue(actualText.Contains(expectedText));
        }
    }
}
