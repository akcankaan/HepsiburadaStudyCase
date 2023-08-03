using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using case1_hepsiburada.Elements;
using case1_hepsiburada.Utils;
using Newtonsoft.Json.Bson;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace case1_hepsiburada.Pages
{
    public class ProductPage : ProductElements
    {
        private Helper helper;
        public ProductPage()
        {
            this.helper = new Helper();
        }
        [AllureStep("Çerezleri kabul et.")]
        public void clickAcceptCookiesButtonComment() => helper.ClickElement(acceptCookiesButton);
        [AllureStep("Yorumlar tabına tıkla.")]
        public void clickTabElement() => helper.ClickElement(tabElement);
        [AllureStep("Arama butonuna tıkla.")]
        public void clickSearchBtn() => helper.ClickElement(searchBtn);
        [AllureStep("Like butonuna tıkla.")]
        public void clickLikebtn() => helper.ClickElement(likeBtn);
        [AllureStep("Aşağı kaydır")]
        public void downScrollElementId() => helper.ScrollToElement(scrollElementId);
        [AllureStep("Aşağı kaydır")]
        public void downScrollElementXpath() => helper.ScrollToElement(scrollElementXpath);
        public void typeSearchBox(string searchKeyword)
        {
            helper.ClickElement(base.searchBox);
            helper.ClearElement(base.searchInput);
            helper.SendkeysElement(base.searchInput, searchKeyword);
        }
        [AllureStep("Seçilen ürüne tıkla.")]
        public void selectProduct(string productName)
        {
            // İstenilen ürünü tıklayın
            helper.ClickElement(base.selectProduct(productName));
        }
    }
}
