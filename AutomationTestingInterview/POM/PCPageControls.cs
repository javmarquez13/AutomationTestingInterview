using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTestingInterview.POM
{
    public class PCPageControls
    {
        public PCPageControls() 
        {
            PageFactory.InitElements(Globals.WEB_DRIVER, this);
        }


        [FindsBy(How = How.ClassName, Using = "btn-catpromo03")]
        public IWebElement btnCatPromo { get; set; }


        [FindsBy(How = How.XPath, Using ="//*/main[1]/div[2]/div[1]")]
        public IWebElement iWebElementContainer { get; set;}
    }
}
