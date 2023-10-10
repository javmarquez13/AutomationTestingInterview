using AutomationTestingInterview.POM;
using AventStack.ExtentReports.Gherkin.Model;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AutomationTestingInterview.TestSuite
{

    /// <summary>
    /// Fundamentos SCRUM
    /// ITQBS cretification
    /// Que hace un tester en Scrum?
    /// </summary>
    class TestSuite_1
    {
        static string _ExpectedResult = "PLAYSTATION 5";
        static string _InputValue = "playstation";

        /// <summary>
        /// Step #1(Precondition): US-AT | Precon | Open the website and navigate to the search bar, enter “playstation” into searchbar and submit the search
        /// </summary>
        public static void PreCondition1()
        {
            string Case = "Step #1(Precondition): US-AT | Precon | Open the website and navigate to the search bar, enter “playstation” into searchbar and submit the search";
            Reporting.LogInfo(Case);

            string _SUT = "https://www.liverpool.com.mx/tienda/home";
            Globals.WEB_DRIVER.Navigate().GoToUrl(_SUT);
            HomePageControls HomePage = new HomePageControls();
            HomePage.SearchBar.SendKeys(_InputValue);

         
            Reporting.EndTest(TestStatus.Passed, $"Input value {_InputValue} was sent");
        }


        static List<IWebElement> _iWebElementsFound = new List<IWebElement>();
        /// <summary>
        /// Step #2(Test Case): US-AT | TS1 | TC1 | Validate results displayed includes games for playstation 5 and playstation consoles.
        /// </summary>
        /// 
        public static void TestCase1() 
        {
            string Case = "Step #2(Test Case): US-AT | TS1 | TC1 | Validate results displayed includes games for playstation 5 and playstation consoles";
            Reporting.LogInfo(Case);

            HomePageControls _homePageControls = new HomePageControls();   
            
            System.Threading.Thread.Sleep(1500);

            _iWebElementsFound = _homePageControls.ddlSearchBarResults.FindElements(By.TagName("a")).ToList();
            _iWebElementsFound.AddRange(_homePageControls.rowContainer.FindElements(By.TagName("figure")).ToList());

            List<string> Assertions = new List<string>();
            Assertions.Add("PLAYSTATION 5");
            Assertions.Add("PLAY STATION");
            Assertions.Add("PLAYSTATION");
            Assertions.Add("PS5");

            foreach (IWebElement _iWebElement in _iWebElementsFound)
            {
                string _Text = _iWebElement.Text;
                bool Evaluation = Assertions.Any(item => _Text.ToUpper().Contains(item));

                try 
                {
                    Assert.IsTrue(Evaluation, "Item not releted to PlayStation console | Item Name: " + _Text);
                }
                catch(AssertionException ex) 
                {
                    Reporting.EndTest(TestStatus.Failed, $"Assertion failed: {ex.Message}");
                    goto SkipTest;
                }         
            }


            Reporting.EndTest(TestStatus.Passed, "All items result releted to PlayStation console");

        SkipTest: { }
        }


        /// <summary>
        /// Step #3(Precondition): US-AT | Precon | Select the “playstation 5” in the results listed.
        /// </summary>
        public static void PreCondition2()
        {
            string Case = $"Step #3(Precondition): US-AT | Precon | Select the {_ExpectedResult} in the results listed";
            Reporting.LogInfo(Case);


            bool _itemClicked = false;
            foreach (IWebElement _iWebElement in _iWebElementsFound)
            {
                string _Text = _iWebElement.Text;

                if (_Text.ToUpper().Contains(_ExpectedResult)) 
                {
                    _iWebElement.Click();
                    _itemClicked = true;
                    break;
                }
            }


            try
            {
                Assert.IsTrue(_itemClicked, $"The result {_ExpectedResult} was not found in collection");
                Console.WriteLine($"The result {_ExpectedResult} was found in collection");
            }
            catch (AssertionException ex)
            {
                Reporting.EndTest(TestStatus.Failed, $"Assertion failed: {ex.Message}");
                goto SkipTest;
            }



            Reporting.EndTest(TestStatus.Passed, $"The result {_ExpectedResult} was found in collection");

        SkipTest: { }
        }


        /// <summary>
        /// Step #4(Test Case): US-AT | TS1 | TC2 | Validate the title and price of the item in the page displayed.
        /// </summary>
        public static void TestCase2()
        {
            string Case = "Step #4(Test Case): US-AT | TS1 | TC2 | Validate the title and price of the item in the page displayed";
            Reporting.LogInfo(Case);

            PLPageControls _plPageControls = new PLPageControls();

            System.Threading.Thread.Sleep(1500);


            string _Assertion = _ExpectedResult;

            string _text = _plPageControls.TitleResults.Text;

            try 
            {
                Assert.IsTrue(_text.ToUpper().Contains(_Assertion), "Title does not contains the expected search: " + _Assertion);
            }
            catch (AssertionException ex) 
            { 
                Reporting.EndTest(TestStatus.Failed, $"Assertion failed: {ex.Message}");
            }

            List<CardDetail> _CardDetailCollection = _plPageControls.CardsDetailCollection();

            string _title = _CardDetailCollection[0].CardTitle;
            string _Price = _CardDetailCollection[0].CardPrice;
            string _discount = _CardDetailCollection[0].CardDiscount;

            Console.WriteLine($"Title: {_text} \n" +
                              $"Price: {_Price} \n" +
                              $"Discount: {_discount} \n");


            if (string.IsNullOrEmpty(_Price) && string.IsNullOrEmpty(_discount)) 
                Reporting.EndTest(TestStatus.Passed, $"The price was fount into collection  {_Price}");

            if (!string.IsNullOrEmpty(_discount)) 
                Reporting.EndTest(TestStatus.Passed, $"The price was found into collection {_discount}");       
        }
    }
}
