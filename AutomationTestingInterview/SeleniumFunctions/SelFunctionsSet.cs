using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTestingInterview
{
    public static class SelFunctionsSet
    {
        /// <summary>
        /// Send Text to WebElement
        /// </summary>
        /// <param name="_webElement">IWebElement</param>
        /// <param name="_value">Value to send</param>
        public static void EnterText(this IWebElement _webElement, string _value)
        {
            _webElement.SendKeys(_value);
        }


        /// <summary>
        /// Function to send a click to iWebElement
        /// </summary>
        /// <param name="_webElement">iWebElement</param>
        public static void Clicks(this IWebElement _webElement)
        {
            _webElement.Click();
        }


        /// <summary>
        /// Select option in DropDownList from Selenium WebDriver
        /// </summary>
        /// <param name="_element">IWebElement</param>
        /// <param name="_value">Value to Select</param>
        public static void SelectDropDown(this IWebElement _element, string _value)
        {
            new SelectElement(_element).SelectByText(_value);
        }
    }
}
