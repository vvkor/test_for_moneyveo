using NUnit.Framework;
using NUnitTestProject1.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using SeleniumExtras.WaitHelpers;

namespace NUnitTestProject1
{
    public class Tests : DriverHelper
    {

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            homePage = new Pages.HomePage(driver);
            resultsPage = new Pages.ResultsPage(driver);
            actions = new Actions(driver);
        }

        [Test]
        public void Test1()
        {
            homePage.goToGoogle();
            homePage.typeTextToSearchField("Selenium IDE export to C#");
            homePage.pressBtnSearch();
            resultsPage.searchTextOnResults();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}