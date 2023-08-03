using case1_hepsiburada.Utils;
using OpenQA.Selenium;

namespace case1_hepsiburada.Elements
{
    public class ProductElements : Driver
    {
        public IWebElement acceptCookiesButton => Get().FindElement(By.Id("onetrust-accept-btn-handler"));
        public IWebElement tabElement => Get().FindElement(By.CssSelector("td[id='reviewsTabTrigger'] a#productReviewsTab"));
        public IWebElement scrollElementId => Get().FindElement(By.Id("tabProductDesc"));
        public IWebElement scrollElementXpath => Get().FindElement(By.XPath("//div[contains(@class, 'paginationContentHolder')]"));
        public IWebElement searchBox => Get().FindElement(By.XPath("(//div[contains(@class,'searchBoxOld-')])[1]"));
        public IWebElement searchInput => Get().FindElement(By.XPath("//input[@placeholder='Ürün, kategori veya marka ara']"));
        public IWebElement searchBtn => Get().FindElement(By.XPath("//div[contains(@class,'searchBoxOld-') and text()='ARA']"));
        public IWebElement selectProduct(string productName) => Get().FindElement(By.XPath($"//h3[text()='{productName}']"));
        public bool HasReview(string reviewText) => Get().FindElements(By.XPath($"//span[contains(text(), '{reviewText}')]")).Count > 0;
        public IWebElement likeBtn => Get().FindElement(By.XPath("(//div[contains(@class, 'hermes-ReviewCard-module-')]//div[contains(@class, 'thumbsUp')])[1]"));

    }
}
