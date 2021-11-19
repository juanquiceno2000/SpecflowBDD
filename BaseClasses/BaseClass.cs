using System;
using AutomationFramework.Configuration;
using AutomationFramework.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SeleniumWebdriver.ComponentHelper;

namespace AutomationFramework.BaseClasses
{
    [TestClass]

    public class BaseClass
    {
        private static FirefoxOptions GetFirefoxptions()
        {
            FirefoxOptions options = new FirefoxOptions();
            FirefoxProfileManager manager = new FirefoxProfileManager();
            return options;
        }

        private static FirefoxOptions GetOptions()
        {
            FirefoxProfileManager manager = new FirefoxProfileManager();

            FirefoxOptions options = new FirefoxOptions()
            {
                Profile = manager.GetProfile("default"),
                AcceptInsecureCertificates = true,
            };
            return options;
        }

        [Obsolete]
        private static ChromeOptions GetChromeOptions()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddAdditionalCapability("useAutomationExtension", false);
            option.AddArgument("start-maximized");
            //option.AddArgument("--headless");
            return option;
        }


        private static FirefoxDriver GetFirefoxDriver()
        {
            FirefoxOptions options = new FirefoxOptions();
            FirefoxDriver driver = new FirefoxDriver(GetFirefoxptions());
            return driver;
        }

        [Obsolete]
        private static ChromeDriver GetChromeDriver()
        {
            ChromeDriver driver = new ChromeDriver(GetChromeOptions());
            return driver;
        }

        [Obsolete]
        public void StartNavigation()
        {
            switch (ConfigClass.browser)
            {
                case "Firefox":
                    ObjectRepository.Driver = GetFirefoxDriver();

                    break;

                case "Chrome":
                    ObjectRepository.Driver = GetChromeDriver();
                    break;

                default:
                    throw new NotFoundException("The webdriver is not available");
            }

            //Se define el tiempo de espera maximo para la carga de la pagina
            ObjectRepository.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(ConfigClass.PageLoadTimeout);
            //Se define el tiempo de espera maximo para la carga de algun control
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ConfigClass.PageLoadTimeout);
            //Navigate to the page
            NavigationHelper.NavigateToUrl(ConfigClass.website);
            BrowserHelper.Maximize();
        }

        public void CleanUp()
        {
            if (ObjectRepository.Driver != null)
            {
                //closing windows and driver service
                ObjectRepository.Driver.Close();
                ObjectRepository.Driver.Quit();
            }
        }
    }
}
