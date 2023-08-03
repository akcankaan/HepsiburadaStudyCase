using case1_hepsiburada.Utils;
using OpenQA.Selenium;

namespace case1_hepsiburada.Actuals
{
    public class ProductActuals : Helper
    { 
        public bool HasReview(string reiewText) => GetCount(By.XPath("//span[contains(text(), '" + reiewText + "')]")) > 0;
        public string thankYouMessage => GetText(By.XPath("(//div[@itemprop='review'])[1]//span[contains(text(),'Teşekkür Ederiz.')]"));
    }
}
