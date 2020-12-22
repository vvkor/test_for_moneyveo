using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject1.Pages
{
    public class HomePage : DriverHelper
    {
        WebDriverWait wait;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            actions = new Actions(driver);
        }

        IWebElement inputSearch => driver.FindElement(By.Name("q"));
        IWebElement btnSearch => driver.FindElement(By.CssSelector("input[name='btnK']"));

        public void goToGoogle()
        {
            this.driver.Navigate().GoToUrl("https://google.com");
        }
        public void typeTextToSearchField(String Querie)
        {
            actions.insertText(inputSearch, Querie);
        }

        public void pressBtnSearch()
        {
            actions.click(btnSearch);
        }
    }
}
