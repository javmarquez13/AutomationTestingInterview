using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTestingInterview
{
    public static class SelFunctionsGet
    {
        /// <summary>
        /// Get Text Value from Element
        /// </summary>
        /// <param name="_element"></param>
        /// <returns></returns>
        public static string GetText(IWebElement _element)
        {
            return _element.GetAttribute("value");
        }


        /// <summary>
        /// Get Text Value from DropDownList
        /// </summary>
        /// <param name="_element"></param>
        /// <returns></returns>
        public static string GetTextFromDDL(IWebElement _element)
        {
            return new SelectElement(_element).AllSelectedOptions.SingleOrDefault().Text;
        }


    }
}
