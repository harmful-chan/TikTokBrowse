using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TikTokBrowse.Hubstudio.TikTokActuator;

namespace TikTokBrowse.Hubstudio.Extensions
{
    public static class ByExtension
    {
        public static IWebElement Try(this By by, ChromeDriver driver)
        {

            return Try(by, driver);
        }
        public static IWebElement Try(this By by, IWebElement webElement)
        {
            try
            {
                return webElement.FindElement(by);
            }
            catch (NoSuchElementException ex)
            {

            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public static IWebElement Until(this By by, ChromeDriver driver)
        {
            return Until(by, driver);
        }

        public static IWebElement Until(this By by, IWebElement webElement)
        {
            for (int i = 0; i < 10; i++)
            {
                IWebElement web = Try(by, webElement);
                if (web != null)
                {
                    return web;
                }
            }
            return null;
        }
    }
}
