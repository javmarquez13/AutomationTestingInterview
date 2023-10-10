using AutomationTestingInterview.POM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V115.Debugger;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace AutomationTestingInterview.TestSuite
{
    class TestSuite_3
    {
        /// <summary>
        /// Step #1(Precondition): US-AT | Precon | Open the website and navigate to home and locate Categorias menu
        /// </summary>
        public static void PreCondition1()
        {

            string Case = "Step #1(Precondition): US-AT | Precon | Open the website and navigate to home and locate Categorias menu";
            Reporting.LogInfo(Case);


            string _SUT = "https://www.liverpool.com.mx/tienda/home";
            Globals.WEB_DRIVER.Navigate().GoToUrl(_SUT);

            HomePageControls HomePage = new HomePageControls();
            HomePage.mainMenuCategories.Click();


            System.Threading.Thread.Sleep(1000);
            Reporting.EndTest(TestStatus.Passed, "Main menu categorias was found");
        }

        /// <summary>
        /// Step #2(Precondition): US-AT | Precon | Navigate hover over “Belleza” Category
        /// </summary>
        public static void PreCondition2()
        {
            string Case = "Step #2(Precondition): US-AT | Precon | Navigate hover over “Belleza” Category";
            Reporting.LogInfo(Case);


            HomePageControls HomePage = new HomePageControls();
            HomePage.BellezaCategory.Click();


            System.Threading.Thread.Sleep(1000);
            Reporting.EndTest(TestStatus.Passed, "Sub menu Belleza was found");
        }

        /// <summary>
        /// Step #3(Precondition): US-AT | Precon | Click into “Perfumes de Hombre” in the sub-menu.
        /// </summary>
        public static void PreCondition3()
        {
            string Case = "Step #3(Precondition): US-AT | Precon | Click into “Perfumes de Hombre” in the sub-menu";
            Reporting.LogInfo(Case);


            PCPageControls _pcPageControls = new PCPageControls();
            List<IWebElement> _iWebElements = _pcPageControls.iWebElementContainer.FindElements(By.TagName("ul")).ToList();

            bool _subCategoryPerfumesHombreFound = false;
            string _Assertion = "PERFUMES HOMBRE";

            foreach(IWebElement iWebElement in _iWebElements) 
            {
                if (iWebElement.Text.Contains(_Assertion)) 
                {
                    iWebElement.Click();
                    System.Threading.Thread.Sleep(1000);
                    _subCategoryPerfumesHombreFound = true;
                    break;
                }                
            }

            try 
            {
                Assert.IsTrue(_subCategoryPerfumesHombreFound, $"Sub Category {_Assertion} was not found");
                Reporting.EndTest(TestStatus.Passed, $"Sub Category {_Assertion} was not found");
            }
            catch(AssertionException ex) 
            {
                Reporting.EndTest(TestStatus.Failed, $"Assertion failed: {ex.Message}");
            }
        }


        /// <summary>
        /// Step #4(Test Case): US-AT | TS3 | TC1 | Validate Brand filter is displayed
        /// </summary>
        public static void TestCase1()
        {
            string Case = "Step #4(Test Case): US-AT | TS3 | TC1 | Validate Brand filter is displayed";
            Reporting.LogInfo(Case);

            PLPageControls _plPageControls = new PLPageControls();

            List<IWebElement> _btnFilterCollection = _plPageControls.btnFilterCollection.FindElements(By.TagName("button")).ToList();
            List<string> _btnFilterTextCollection = new List<string>();

            List<string> Assertions = new List<string>();
            Assertions.Add("MARCAS");

            foreach (IWebElement _btnFilter in _btnFilterCollection) _btnFilterTextCollection.Add(_btnFilter.Text.ToUpper());

            try 
            {
                Assert.IsTrue(_btnFilterTextCollection.Contains(Assertions[0]), "The collection does not contain expected filter: " + Assertions[0]);
                Console.WriteLine("The collection contains expected filter: " + Assertions[0]);
                Reporting.EndTest(TestStatus.Passed, "The collection contains expected filter: " + Assertions[0]);
            }
            catch(AssertionException ex) 
            {
                Reporting.EndTest(TestStatus.Failed, $"Assertion failed: {ex.Message}");
            }
        }


        /// <summary>
        /// Step #5(Precondition): US-AT | Precon | Apply brand filter by “Dior”
        /// </summary>
        public static void PreCondition4()
        {
            string Case = "Step #5(Precondition): US-AT | Precon | Apply brand filter by “Dior”";
            Reporting.LogInfo(Case);


            PLPageControls _plPageControls = new PLPageControls();
            _plPageControls.ViewMoreBrands.Click();
            System.Threading.Thread.Sleep(1000);

            _plPageControls.chBoxBrandDior.Click();
            System.Threading.Thread.Sleep(1000);

            try 
            {
                Assert.IsTrue(_plPageControls.chBoxBrandDior.Selected);
                Reporting.EndTest(TestStatus.Passed, "Filter by Barnd 'Dior' was selected");
            }
            catch(AssertionException ex) 
            {
                Reporting.EndTest(TestStatus.Failed, $"Assertion failed: {ex.Message}");
            } 
        }


 
        /// <summary>
        /// Step #6(Test Case): US-AT | TS3 | TC2 | Validate Dior filter was applied
        /// </summary>
        public static void TestCase2()
        {
            string Case = "Step #6(Test Case): US-AT | TS3 | TC2 | Validate Dior filter was applied";
            Reporting.LogInfo(Case);

            PLPageControls _plPageControls = new PLPageControls();

            List<IWebElement> _iWebElementFilterCollection = _plPageControls.filterAppliedByCategories.FindElements(By.ClassName("mdc-chip__text")).ToList();
            List<string> _FilterTextCollection = new List<string>();
            List<string> _Assertions = new List<string>();
            _Assertions.Add("DIOR");

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
                    Reporting.EndTest(TestStatus.Failed, $"Assertion failed: {ex.Message}");
                    goto SkipTest;
                }

   
            }

            Reporting.EndTest(TestStatus.Passed, "The filter for was applied");

        SkipTest: { }

        }


        /// <summary>
        /// Step #7(Test Case): US-AT | TS3 | TC3 | Validate the results count
        /// </summary>
        public static void TestCase3()
        {
            string Case = "Step #7(Test Case): US-AT | TS3 | TC2 | Validate the results count";
            Reporting.LogInfo(Case);

            PLPageControls _plPageControls = new PLPageControls();

            List<CardDetail> _CardDetailCollection = _plPageControls.CardsDetailCollection();
            Console.WriteLine($"Result items found: {_CardDetailCollection.Count.ToString()}");
                        
            Reporting.EndTest(TestStatus.Passed, $"Result items found: {_CardDetailCollection.Count.ToString()}");
        }
    }
}
