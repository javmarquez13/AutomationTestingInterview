using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationTestingInterview.POM;
using AutomationTestingInterview.TestSuite;

//Automation libs
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



namespace AutomationTestingInterview
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }


        /// <summary>
        /// Setup Enviroment: VS-C# ChromeDriver Selenium Framework
        /// Javier Marquez
        /// QA - Test Automation Exercise Apex
        /// </summary>
        [SetUp]
        public static void Setup() 
        {                    
            ChromeOptions _options = new ChromeOptions();
            //string _WindowsState = "start-maximized";
            //_options.AddArguments(_WindowsState);

            string _WindowsPosition = "--window-position=2000,0";    
            _options.AddArguments(_WindowsPosition);

            IWebDriver _driver = new ChromeDriver(_options);

            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            Globals.WEB_DRIVER = _driver;
        }


        /// <summary>
        /// Scenario 1: Search for a “playstation” using the search bar, verify that the results displayed includes games for playstation 5 and playstation consoles. 
        /// Then select a playstation 5 in the results listed and validate the title and price of the item in the page displayed.
        /// 
        /// Folder 1 (Test Suite 1): US-AT | TS1 | Serach for a PlayStation, Verify results, select PlayStation 5 result and validate details.
        /// Step #1(Precondition): US-AT | Precon | Open the website and navigate to the search bar, enter “playstation” into searchbar and submit the search
        /// Step #2(Test Case): US-AT | TS1 | TC1 | Validate results displayed includes games for playstation 5 and playstation consoles.
        /// Step #3(Precondition): US-AT | Precon | Select the playstation 5 in the results listed.
        /// Step #4(Test Case): US-AT | TS1 | TC2 | Validate the title and price of the item in the page displayed.
        /// </summary>
        [Test]       
        public static void Scenario1() 
        {
            Reporting.CreateTest(TestContext.CurrentContext.Test.MethodName);
            TestSuite_1.PreCondition1();
            TestSuite_1.TestCase1();
            TestSuite_1.PreCondition2();
            TestSuite_1.TestCase2();
        }


        /// <summary>
        /// Scenario 2: Search for “smart tv” and navigate to the page. Validate that the Size and Price filters are displayed. 
        /// Filter the results by size: 55 inches, price: > 10,000, brand: sony. Validate the results count.
        /// 
        /// Folder 2 (Test Suite 2): US-AT | TS2 | Search for Smart TV apply, validate filters displayed, and apply filters
        /// Step #1(Precondition): US-AT | Precon | Open the website and navigate to the search bar, enter “smart tv” into searchbar and submit the search
        /// Step #2(Test Case): US-AT | TS2 | TC1 | Validate that the size and price filter are displayed.
        /// Step #3(Precondition): US-AT | Precon | Apply size filter to “55 inches”.
        /// Step #4(Precondition): US-AT | Precon | Apply price filter to “Item” > “$10,000”.
        /// Step #5(Precondition): US-AT | Precon | Apply brand filter to “Sony”.
        /// Step #6(Test Case): US-AT | TS2 |TC2 | Validate all filter were applied correctly
        /// Step #7(Test Case): US-AT | TS2 | TC2 | Validate the results count.
        /// </summary>
        [Test]
        public static void Scenario2()
        {
            Reporting.CreateTest(TestContext.CurrentContext.Test.MethodName);
            TestSuite_2.PreCondition1();
            TestSuite_2.TestCase1();
            TestSuite_2.PreCondition2();
            TestSuite_2.PreCondition3();
            TestSuite_2.PreCondition4();
            TestSuite_2.TestCase2();
            TestSuite_2.TestCase3();
        }


        /// <summary>
        /// Scenario 3: Expand the “Categorias” menu, place the cursor over the “Belleza” option, select the “Perfumes de Hombre” 
        /// option in the menu displayed and filter the results displayed by “Dior” brand.
        /// 
        /// Folder 3 (Test Suite 3): US-AT | TS3 | Expand Category menu, select a category, select into sub-menu, and apply filters
        /// Step #1(Precondition): US-AT | Precon | Open the website and navigate to home and locate Categorias menu
        /// Step #2(Precondition): US-AT | Precon | Navigate hover over “Belleza” Category
        /// Step #3(Precondition): US-AT | Precon | Click into “Perfumes de Hombre” in the sub-menu.
        /// Step #4(Test Case): US-AT | TS3 | TC1 | Validate Brand filter is displayed.
        /// Step #5(Precondition): US-AT | Precon | Apply brand filter by “Dior”.
        /// Step #6(Test Case): US-AT | TS3 | TC2 | Validate Dior filter was applied
        /// Step #7(Test Case): US-AT | TS3 | TC3 | Validate the results count.
        /// </summary>
        [Test]
        public static void Scenario3()
        {
            Reporting.CreateTest(TestContext.CurrentContext.Test.MethodName);
            TestSuite_3.PreCondition1();
            TestSuite_3.PreCondition2();
            TestSuite_3.PreCondition3();
            TestSuite_3.TestCase1();
            TestSuite_3.PreCondition4();
            TestSuite_3.TestCase2(); 
            TestSuite_3.TestCase3();
        }


        [TearDown]
        public static void CleanUp() 
        {
            Globals.WEB_DRIVER.Quit();
            Reporting.EndReporting();
        }



  

    }
}
