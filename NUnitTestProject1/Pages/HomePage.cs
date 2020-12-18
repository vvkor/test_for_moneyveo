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
        }

        IWebElement inputSearch => driver.FindElement(By.Name("q"));
        IWebElement btnSearch => driver.FindElement(By.CssSelector("input[name='btnK']"));

        public void goToGoogle()
        {
            this.driver.Navigate().GoToUrl("https://google.com");
        }
        public void typeTextToSearchField(String Querie)
        {
            // По-хорошему было бы не плохо юзать ожидания, вынесенные в экшенсы, но я словил NullReferenceException. Видимо, где-то что-то не инициализировал, судя по всему wait в Actions.
            //actions.insertText(inputSearch, Querie);

            //Менее красивый вариант - писать явные ожидания тут.
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(inputSearch)).SendKeys(Querie);
        }

        public void pressBtnSearch()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(btnSearch)).Click();
        }
    }
}
