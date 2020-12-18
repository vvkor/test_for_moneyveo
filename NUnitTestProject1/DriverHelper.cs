using NUnitTestProject1.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject1
{
    
    public class DriverHelper
    {
        protected HomePage homePage;
        protected ResultsPage resultsPage;
        protected Actions actions;


        public IWebDriver driver { get; set; }


        public DriverHelper()
        {
        }
    }
}
