using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V85.IndexedDB;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTestingInterview
{
    class PLPageControls
    {
        public PLPageControls()
        {
            PageFactory.InitElements(Globals.WEB_DRIVER, this);
        }


        [FindsBy(How = How.CssSelector, Using = "h1.a-headline__typeahed.searcherTitle-result")]
        public IWebElement TitleResults { get; set; }

        [FindsBy(How = How.ClassName, Using = "m-product__listingPlp")]
        public IWebElement ListProduct { get; set; }

        [FindsBy(How = How.Id, Using = "Tamao")]
        public IWebElement ViewMoreTamao { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='variants.normalizedSize-55 pulgadas']")]
        public IWebElement chkBoxSiezeFilter55Inches { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.o-aside.d-aside--margin")]
        public IWebElement btnFilterCollection { get; set; }

        [FindsBy(How = How.Id, Using = "variants.prices.sortPrice-10000-700000")]
        public IWebElement rbMoreTo10000 { get; set; }

        [FindsBy(How = How.Id, Using = "min-price-filter")]
        public IWebElement txtBoxMinPrice { get; set; }

        [FindsBy(How = How.Id, Using = "max-price-filter")]
        public IWebElement txtBoxMaxPrice { get; set; }

        [FindsBy(How = How.ClassName, Using = "next-button__filter")]
        public IWebElement btnNextButtonFilter { get; set; }

        [FindsBy(How = How.Id, Using = "Marcas")]
        public IWebElement ViewMoreBrands { get; set; }

        [FindsBy(How = How.ClassName, Using = "filter-brands")]
        public IWebElement filterBrands { get; set; }

        [FindsBy(How = How.Id, Using = "brand-SONY")]
        public IWebElement chBoxSonyBrand { get;set; }


        [FindsBy(How = How.CssSelector, Using = "div.m-plp__filterApplied.mt-4")]
        public IWebElement filterApplied { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.o-aside.d-aside--margin")]
        public IWebElement filterAppliedByCategories { get; set; }

        [FindsBy(How = How.Id, Using = "brand-DIOR")]
        public IWebElement chBoxBrandDior { get; set; }

       
        public List<CardDetail> CardsDetailCollection()
        {
            List<IWebElement> _iWebElementsFound = new List<IWebElement>();
            List<IWebElement> _Articules = new List<IWebElement>();

            _iWebElementsFound = ListProduct.FindElements(By.TagName("figure")).ToList();


            List<CardDetail> _CardDetailCollection = new List<CardDetail>();

            foreach (IWebElement _iWebElement in _iWebElementsFound)
            {
                IWebElement _figElement = _iWebElement.FindElement(By.TagName("figcaption"));

                Globals.WEB_DRIVER.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

                List<string> _CardDetail = _figElement.Text.Replace("\r", "").Split(new string[] { "\n" }, StringSplitOptions.None).ToList();

                if (_CardDetail.Count == 2) _CardDetail.Add("$0");

                _CardDetailCollection.Add(new CardDetail
                {
                    CardTitle = _CardDetail[0],
                    CardPrice = _CardDetail[1],
                    CardDiscount = _CardDetail[2]
                });
            }


            return _CardDetailCollection;
        }
    }
}
