using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Timers;
using case1_hepsiburada.Utils;
using case1_hepsiburada.Pages;
using case1_hepsiburada.Actuals;
using NUnit.Allure.Attributes;
using Allure.Net.Commons;
using NUnit.Allure.Core;
using NUnit.Framework.Interfaces;

namespace case1_hepsiburada.Tests
{
    [TestFixture(Author = "KaanAKCAN", Description = "HBTests")]
    [AllureNUnit]
    [AllureLink("https://github.com/unickq/allure-nunit")]
    public class ProductTest
    {
        private ProductPage _do;
        private GeneralMethods _GM;
        private ProductActuals _actuals;
        public ProductTest()
        {
            _do = new ProductPage();
            _actuals = new ProductActuals();
            _GM = new GeneralMethods();
        }

        #region Test Data
        public static string desiredProductName = "iPhone 11 128 GB";
        public static string reviewText = "Bu değerlendirme faydalı mı?";
        #endregion

        [OneTimeSetUp]
        public void OTSUP(){}

        [SetUp]
        public void Setup(){_do = new ProductPage();}

        [Test]
        [AllureTag("NUnit", "Debug")]
        [AllureIssue("GitHub#1", "https://github.com/unickq/allure-nunit")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Core")]
        [AllureId(123)]
        public void HepsiBuradaWebSiteTest()
        {
            _GM.GoToUrl("https://www.hepsiburada.com"); // Hepsiburada.com'u ziyaret et
            _do.clickAcceptCookiesButtonComment(); // Çerezleri kabul etmek için kabul düğmesini tıkla 
            _do.typeSearchBox("iphone");//// Arama kutusunu bul ve arama kelimesini gir
            _do.clickSearchBtn();
            _do.selectProduct(desiredProductName);// İstenilen ürünü seç
            _GM.SwitchToLastWindow();// Yeni sekmeye geçiş yap
            _do.downScrollElementId(); // Kaydırma işlemi
            _do.clickTabElement(); // "Yorumlar" sekmesine geçiş yap
            _do.downScrollElementXpath(); // Kaydırma işlemi
            if (_actuals.HasReview(reviewText))// Yorumlar varsa işlem yap
            {
                _do.clickLikebtn();
                Assert.AreEqual("Teşekkür Ederiz.", _actuals.thankYouMessage);
            }
            else
            {
                Console.WriteLine("Yorumlar tabında hiç yorum yok.");
            }
        }
        [TearDown]
        public void Teardown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                AllureLifecycle.Instance.AddAttachment("Screenshot", "image/png", File.ReadAllBytes(_GM.CaptureScreenshot()));
            }
        }
        [OneTimeTearDown]
        public void ottd()
        {
            _GM.CloseDriver();// Tarayıcıyı kapat
        }
    }
}