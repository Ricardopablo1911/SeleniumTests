using Exemplo_2.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V110;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;



namespace Exemplo_2.Fixtures
{
    public class TestFixture : IDisposable
    {


    

        public IWebDriver Driver { get; private set; }

        //Setup
        public TestFixture()
        {
            //ChromeOptions options = new ChromeOptions();
            //options.AddArguments("--start-maximized");
            //Driver = new ChromeDriver(options);
            Driver = new ChromeDriver(TestHelpers.PastaDoExecutavel);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--start-maximized");
            Driver = new ChromeDriver(chromeOptions);




            //ScreenshotImageFormat

            //Screenshot ss = ((ITakesScreenshot)Driver).GetScreenshot();
            //ss.SaveAsFile(@"F:\Imagens.jpg");

            //var file = ((ITakesScreenshot)Driver).GetScreenshot();
            //file.SaveAsFile("C:\\Users\\pablo\\OneDrive\\Pictures\\Selenium\\001.png");
            // String screenshotBase64 = ((TakesScreenshot)driver).getScreenshotAs(OutputType.BASE64);




        }
        public void IrPaginaInicial()
        {
            Driver.Navigate().GoToUrl("https://sistema.clinicorp.com/login/");

        }

        //TearDown
        public void Dispose()
        {
            
        }
    }
}
