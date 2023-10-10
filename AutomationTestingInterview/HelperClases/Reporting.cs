using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTestingInterview
{
    class Reporting
    {
        private static ExtentReports extentReports;
        private static ExtentTest extentTest;

      
        private static ExtentReports StartReporting() 
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"..\..\..\ReportsResults\";

            if(extentReports == null) 
            {
                Directory.CreateDirectory(path);

                extentReports = new ExtentReports();
                var htomReporter = new ExtentHtmlReporter(path);

                extentReports.AttachReporter(htomReporter);
            }


            return extentReports;
        }

        public static void CreateTest(string TestName) 
        {
            extentTest = StartReporting().CreateTest(TestName);
        }

        public static void EndReporting() 
        {
            StartReporting().Flush();
        }

        public static void LogInfo(string Detail) 
        {
            extentTest.Info(Detail);
            Console.WriteLine($"Case:  {Detail}");
        }

        public static void LogPass(string Detail) 
        {
            extentTest.Pass(Detail);
            Console.WriteLine($"Pass:  {Detail}");
        }

        public static void LogFail(string Detail)
        {
            extentTest.Fail(Detail);
            Console.WriteLine($"Fail:  {Detail}");
        }


        public static void LogScreenShot(string Detail) 
        {
            var _file = ((ITakesScreenshot)Globals.WEB_DRIVER).GetScreenshot();
            string _image = _file.AsBase64EncodedString;

            extentTest.Info(Detail, MediaEntityBuilder.CreateScreenCaptureFromBase64String(_image).Build());
        }


        public static void EndTest(TestStatus _testStatus, string _Detail)
        {
         
            switch (_testStatus)
            {
                case TestStatus.Failed:
                    Reporting.LogFail($"Test has failed {_Detail}");
                    break;

                case TestStatus.Passed:
                    Reporting.LogPass($"Test has passed {_Detail}");
                    break;

                default:
                    break;
            }

            Reporting.LogScreenShot("Ending Test");
        }











        //public static void EndTest()
        //{
        //    TestStatus _testStatus = TestContext.CurrentContext.Result.Outcome.Status;
        //    var _message = TestContext.CurrentContext.Result.Message;

        //    switch (_testStatus)
        //    {
        //        case TestStatus.Failed:
        //            Reporting.LogFail($"Test has failed {_message}");
        //            break;

        //        case TestStatus.Passed:
        //            Reporting.LogPass($"Test has passed {_message}");
        //            break;

        //        default:
        //            break;
        //    }

        //    Reporting.LogScreenShot("Ending Test");
        //}

    }
}
