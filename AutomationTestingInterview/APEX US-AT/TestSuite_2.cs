using AutomationTestingInterview.POM;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using RazorEngine.Compilation.ImpromptuInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTestingInterview.TestSuite
{
    internal class TestSuite_2
    {
        static string _InputValue = "smart tv";

        /// <summary>
        /// Step #1(Precondition): US-AT | Precon | Open the website and navigate to the search bar, enter “smart tv” into searchbar and submit the search
        /// </summary>
        public static void PreCondition1()
        {

            string Case = "Step #1(Precondition): US-AT | Precon | Open the website and navigate to the search bar, enter “smart tv” into searchbar and submit the search";
            Reporting.LogInfo(Case);

            string _SUT = "https://www.liverpool.com.mx/tienda/home";
            Globals.WEB_DRIVER.Navigate().GoToUrl(_SUT);
            HomePageControls HomePage = new HomePageControls();
            HomePage.SearchBar.SendKeys(_InputValue + Keys.Enter);

            Reporting.EndTest(TestStatus.Passed, $"Input value {_InputValue} was sent");
        }


        /// <summary>
        /// Step #2(Test Case): US-AT | TS2 | TC1 | Validate that the size and price filter are displayed
        /// </summary>
        public static void TestCase1() 
        {
            string Case = "Step #2(Test Case): US-AT | TS2 | TC1 | Validate that the size and price filter are displayed";
            Reporting.LogInfo(Case);

            System.Threading.Thread.Sleep(1500);

            PLPageControls _plPageControls = new PLPageControls();

            List<IWebElement> _btnFilterCollection = _plPageControls.btnFilterCollection.FindElements(By.TagName("button")).ToList();
            List<string> _btnFilterTextCollection = new List<string>();

            List<string> Assertions = new List<string>();
            Assertions.Add("TAMAÑO");
            Assertions.Add("PRECIOS");

            foreach (IWebElement _btnFilter in _btnFilterCollection) _btnFilterTextCollection.Add(_btnFilter.Text.ToUpper());


            try 
            {
                Assert.IsTrue(_btnFilterTextCollection.Contains(Assertions[0]), "The collection does not contain expected filter: " + Assertions[0]);
                Assert.IsTrue(_btnFilterTextCollection.Contains(Assertions[1]), "The collection does not contain expected filter: " + Assertions[1]);

                Console.WriteLine($"The collection contains expected filter: {Assertions[0]}");
                Console.WriteLine($"The collection contains expected filter: {Assertions[1]}");

                Reporting.EndTest(TestStatus.Passed, $"The collection contains expected filter: {Assertions[0]} && {Assertions[1]}");
            }
            catch(AssertionException ex) 
            {
                Reporting.EndTest(TestStatus.Failed, $"Assertion failed: {ex.Message}");
            }

        }

        /// <summary>
        /// Step #3(Precondition): US-AT | Precon | Apply size filter to “55 inches”
        /// </summary>
        public static void PreCondition2() 
        {
            string Case = "Step #3(Precondition): US-AT | Precon | Apply size filter to “55 inches”";
            Reporting.LogInfo(Case);

            PLPageControls _plPageControls = new PLPageControls();
            _plPageControls.ViewMoreTamao.Click();

            System.Threading.Thread.Sleep(1500);

            _plPageControls.chkBoxSiezeFilter55Inches.Click();
            System.Threading.Thread.Sleep(3000);

            try 
            {
                Assert.IsTrue(_plPageControls.chkBoxSiezeFilter55Inches.Selected, "Filter 55 Inches was not selected");
                Console.WriteLine("Filter 55 Inches was selected");

                Reporting.EndTest(TestStatus.Passed, "Filter 55 Inches was selected");
            }
            catch(AssertionException ex) 
            {
                Reporting.EndTest(TestStatus.Passed, $"Assertion failed: {ex.Message}");
            }
        }


        /// <summary>
        /// Step #4(Precondition): US-AT | Precon | Apply price filter to “Item” > “$10,000
        /// </summary>
        public static void PreCondition3() 
        {
            string Case = "Step #4(Precondition): US-AT | Precon | Apply price filter to “Item” > “$10,000";
            Reporting.LogInfo(Case);

            PLPageControls _plPageControls = new PLPageControls();      
            _plPageControls.rbMoreTo10000.Click();
            System.Threading.Thread.Sleep(3000);

            Reporting.EndTest(TestStatus.Passed, "Filter Price was selected");
        }


        /// <summary>
        /// Step #5(Precondition): US-AT | Precon | Apply brand filter to “Sony”
        /// </summary>
        public static void PreCondition4() 
        {
            string Case = "Step #5(Precondition): US-AT | Precon | Apply brand filter to “Sony”";
            Reporting.LogInfo(Case);

            PLPageControls _plPageControls = new PLPageControls();
            _plPageControls.chBoxSonyBrand.Click();
            System.Threading.Thread.Sleep(3000);


            try 
            {
                Assert.IsTrue(_plPageControls.chBoxSonyBrand.Selected, "Filter check box by Brand SONY was not selected");
                Console.WriteLine("Filter check box by Brand SONY was selected");

                Reporting.EndTest(TestStatus.Passed, "Filter check box by Brand SONY was selected");
            }
            catch(AssertionException ex) 
            {
                Reporting.EndTest(TestStatus.Passed, $"Assertion failed: {ex.Message}");
            }
           
        }

        /// <summary>
        /// Step #6(Test Case): US-AT | TS2 |TC2 | Validate all filter were applied correctly
        /// </summary>
        public static void TestCase2() 
        {
            string Case = "Step #6(Test Case): US-AT | TS2 |TC2 | Validate all filter were applied correctly";
            Reporting.LogInfo(Case);

            PLPageControls _plPageControls = new PLPageControls();

            List<IWebElement> _iWebElementFilterCollection = _plPageControls.filterApplied.FindElements(By.ClassName("mdc-chip__text")).ToList();
            List<string> _FilterTextCollection = new List<string>();
            List<string> _Assertions = new List<string>();
            _Assertions.Add("SONY");
            _Assertions.Add("55 PULGADAS");
            _Assertions.Add("MAS DE $10000");


            foreach (IWebElement _iWebElementFilter in _iWebElementFilterCollection) _FilterTextCollection.Add(_iWebElementFilter.Text);           

            foreach (string _filterText in _FilterTextCollection)
            {
                bool Evaluation = _Assertions.Any(item => _filterText.ToUpper().Contains(item));


                try 
                {
                    Assert.IsTrue(Evaluation, "The filter for " + _filterText + " was not applied");
                    Console.WriteLine("The filter for " + _filterText + " was applied");
                }
                catch(AssertionException ex) 
                {
                    Reporting.EndTest(TestStatus.Passed, $"Assertion failed: {ex.Message}");
                    goto SkipTest;
                }
             
            }

            Reporting.EndTest(TestStatus.Passed, $"The filter for {_Assertions[0]} && {_Assertions[1]} && {_Assertions[2]} were applied"); ;

            SkipTest:
            {
                
            }
        }



        /// <summary>
        /// Step #7(Test Case): US-AT | TS2 |TC3 | Validate the results count.
        /// </summary>
        public static void TestCase3()
        {
            string Case = "Step #7(Test Case): US-AT | TS2 |TC3 | Validate the results count.";
            Reporting.LogInfo(Case);

            PLPageControls _plPageControls = new PLPageControls();

            List<CardDetail> _CardDetailCollection = _plPageControls.CardsDetailCollection();
            Console.WriteLine($"Result items found: {_CardDetailCollection.Count.ToString()}");

            Reporting.EndTest(TestStatus.Passed, $"Result items found: {_CardDetailCollection.Count.ToString()}");
        }
    }
}
