using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace case1_hepsiburada.Utils
{
    public class Driver
    {
        private readonly TimeSpan pageLoadTimeout = TimeSpan.FromSeconds(30);
        private readonly TimeSpan implicitWaitTimeout = TimeSpan.FromSeconds(30);

        public static IWebDriver _driver;
        public IWebDriver Get()
        {
            if (_driver == null)
            {
                _driver = new ChromeDriver();
            }

            _driver.Manage().Timeouts().PageLoad = pageLoadTimeout;
            _driver.Manage().Timeouts().ImplicitWait = implicitWaitTimeout;
            _driver.Manage().Window.Maximize();
            return _driver;
        }

        public void CloseDriver()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver = null;
            }
        }
    }
}
