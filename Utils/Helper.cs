using case1_hepsiburada.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace case1_hepsiburada.Utils
{
    public class Helper : Driver
    {
        private readonly Actions actions;

        public Helper()
        {
            //actions = new Actions(Get());
        }
        public void GoToUrl(string url)
        {
            Get().Navigate().GoToUrl(url);
        }
        public void ClickElement(IWebElement element)
        {
            element.Click();
        }
        public void ClearElement(IWebElement element)
        {
            element.Clear();
        }
        public void SendkeysElement(IWebElement element, string text)
        {
            element.SendKeys(text);
        }
        public void SwitchToLastWindow()
        {
            // Orijinal sekmedeki tüm açık sekmelerin tanımlamalarını al
            var windowHandles = Get().WindowHandles;

            // Yeni sekmeye geçiş yapın
            Get().SwitchTo().Window(windowHandles.Last());
        }
        public void ScrollToElement(IWebElement element)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
        public string GetText(By locator)
        {
            IWebElement element = Get().FindElement(locator);
            return element.Text;
        }
        public int GetCount(By locator)
        {
            return Get().FindElements(locator).Count;
        }
        public void CloseDriver()
        {
            base.CloseDriver();
        }

        public string CaptureScreenshot()
        {
            var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();

            var fileName = Path.Combine(Path.GetTempPath(), "screenshot.png");
            screenshot.SaveAsFile(fileName, ScreenshotImageFormat.Png); 
            return fileName;
        }
    }
}
