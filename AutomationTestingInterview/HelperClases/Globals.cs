using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTestingInterview
{
    class Globals
    {
        private static IWebDriver _driver;
        public static IWebDriver WEB_DRIVER
        {
            get
            {
                return _driver;
            }

            set
            {
                _driver = value;
            }
        }
    }
}
