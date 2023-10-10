using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutomationTestingInterview.POM
{
    class HomePageControls
    {
        public  HomePageControls() 
        {
            PageFactory.InitElements(Globals.WEB_DRIVER, this);
        }


        [FindsBy(How = How.Id, Using = "mainSearchbar")]
        public IWebElement SearchBar { get; set; }


        [FindsBy(How = How.ClassName, Using = "m-header__searchLinkResult")]
        public IWebElement ddlSearchBarResults { get; set; }


        [FindsBy(How = How.CssSelector, Using = "ul.row.p-2")]
        public IWebElement rowContainer { get; set; }


        [FindsBy(How = How.XPath, Using = "//*/li[1]/span[1]")]
        public IWebElement mainMenuCategories { get; set; }


        [FindsBy(How = How.XPath, Using = "//*/div[6]/li[1]/div[1]/a[1]/div[1]/div[1]/span[1]")]
        public IWebElement BellezaCategory { get; set; }


        [FindsBy(How = How.XPath, Using = "")]
        public IWebElement subMenuMenFragance { get; set; }
    }

}
