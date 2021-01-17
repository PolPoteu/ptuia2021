using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace PTUIA
{
    [TestFixture]
    public class UnitTest1
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheAddYoungTest()
        {
            driver.Navigate().GoToUrl("https://lamp.ii.us.edu.pl/~mtdyd/zawody/");
            driver.FindElement(By.Id("inputEmail3")).Click();
            driver.FindElement(By.Id("inputPassword3")).Click();
            driver.FindElement(By.Id("dataU")).Click();
            driver.FindElement(By.Id("dataU")).Clear();
            driver.FindElement(By.Id("dataU")).SendKeys("12-12-2008");
            driver.FindElement(By.Id("rodzice")).Click();
            driver.FindElement(By.XPath("//form[@id='formma']/div[5]/div/div/label")).Click();
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
            Assert.AreEqual("Roznica: 402437459905 data 315569260000lata 12.752745939354169", CloseAlertAndGetItsText());
            Assert.AreEqual("Mlodzik", CloseAlertAndGetItsText());
        }
        [Test]
        public void TheAddJuniorTest()
        {
            driver.Navigate().GoToUrl("https://lamp.ii.us.edu.pl/~mtdyd/zawody/");
            driver.FindElement(By.Id("inputEmail3")).Click();
            driver.FindElement(By.Id("inputPassword3")).Click();
            driver.FindElement(By.Id("dataU")).Click();
            driver.FindElement(By.Id("dataU")).Clear();
            driver.FindElement(By.Id("dataU")).SendKeys("12-07-2003");
            driver.FindElement(By.XPath("//form[@id='formma']/div[4]/div")).Click();
            driver.FindElement(By.Id("rodzice")).Click();
            driver.FindElement(By.XPath("//form[@id='formma']/div[5]/div/div")).Click();
            driver.FindElement(By.XPath("//form[@id='formma']/div[5]/div/div/label")).Click();
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
            Assert.AreEqual("Roznica: 560290223953 data 315569260000lata 17.754905023163538", CloseAlertAndGetItsText());
            Assert.AreEqual("Junior", CloseAlertAndGetItsText());
        }
        [Test]
        public void TheAddAdultTest()
        {
            driver.Navigate().GoToUrl("https://lamp.ii.us.edu.pl/~mtdyd/zawody/");
            driver.FindElement(By.Id("inputEmail3")).Click();
            driver.FindElement(By.Id("inputPassword3")).Click();
            driver.FindElement(By.Id("dataU")).Click();
            driver.FindElement(By.Id("dataU")).Clear();
            driver.FindElement(By.Id("dataU")).SendKeys("12-07-1956");
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
            Assert.AreEqual("Roznica: 2043432581676 data 315569260000lata 64.75385408819604", CloseAlertAndGetItsText());
            Assert.AreEqual("Dorosly", CloseAlertAndGetItsText());
        }
        [Test]
        public void TheAddSeniorTest()
        {
            driver.Navigate().GoToUrl("https://lamp.ii.us.edu.pl/~mtdyd/zawody/");
            driver.FindElement(By.Id("inputEmail3")).Click();
            driver.FindElement(By.Id("inputPassword3")).Click();
            driver.FindElement(By.Id("dataU")).Click();
            driver.FindElement(By.Id("lekarz")).Click();
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
            Assert.AreEqual("Roznica: 2106590917341 data 315569260000lata 66.75526372058546", CloseAlertAndGetItsText());
            Assert.AreEqual("Senior", CloseAlertAndGetItsText());
        }
        [Test]
        public void TheTimeNotPassTest()
        {
            driver.Navigate().GoToUrl("https://lamp.ii.us.edu.pl/~mtdyd/zawody/");
            driver.FindElement(By.XPath("//html")).Click();
            driver.FindElement(By.Id("inputPassword3")).Click();
            driver.FindElement(By.Id("dataU")).Click();
            driver.FindElement(By.Id("dataU")).Clear();
            driver.FindElement(By.Id("dataU")).SendKeys("03-02-2030");
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
            Assert.AreEqual("Roznica: -291958700768 data 315569260000lata -9.251810546058891", CloseAlertAndGetItsText());
            Assert.AreEqual("Brak kwalifikacji", CloseAlertAndGetItsText());
        }
        [Test]
        public void TheEmptyITest()
        {
            driver.Navigate().GoToUrl("https://lamp.ii.us.edu.pl/~mtdyd/zawody/");
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
            Assert.AreEqual("First name must be filled out", CloseAlertAndGetItsText());
            driver.FindElement(By.Id("inputEmail3")).Click();
            driver.FindElement(By.Id("inputEmail3")).Clear();
            driver.FindElement(By.Id("inputEmail3")).SendKeys("imie");
            driver.FindElement(By.Id("inputPassword3")).Clear();
            driver.FindElement(By.Id("inputPassword3")).SendKeys("nazwisko");
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
            Assert.AreEqual("Data urodzenia nie moze byc pusta", CloseAlertAndGetItsText());
            driver.FindElement(By.XPath("//div[@id='nazwisko']/div[2]")).Click();
            driver.FindElement(By.Id("inputPassword3")).Clear();
            driver.FindElement(By.Id("inputPassword3")).SendKeys("");
            driver.FindElement(By.Id("dataU")).Click();
            driver.FindElement(By.Id("dataU")).Clear();
            driver.FindElement(By.Id("dataU")).SendKeys("01.20.2000");
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
            Assert.AreEqual("Nazwisko musi byc wypelnione", CloseAlertAndGetItsText());
            driver.FindElement(By.Id("inputEmail3")).Click();
            driver.FindElement(By.Id("inputEmail3")).Clear();
            driver.FindElement(By.Id("inputEmail3")).SendKeys("");
            driver.FindElement(By.Id("inputPassword3")).Click();
            driver.FindElement(By.Id("inputPassword3")).Clear();
            driver.FindElement(By.Id("inputPassword3")).SendKeys("nazwisko");
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
            Assert.AreEqual("First name must be filled out", CloseAlertAndGetItsText());
        }
        [Test]
        public void TheTooManyCharTest()
        {
            driver.Navigate().GoToUrl("https://lamp.ii.us.edu.pl/~mtdyd/zawody/");
            driver.FindElement(By.Id("inputEmail3")).Click();
            driver.FindElement(By.Id("inputEmail3")).Clear();
            driver.FindElement(By.Id("inputEmail3")).SendKeys("asdfsasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss");
            driver.FindElement(By.XPath("//div[@id='nazwisko']/div")).Click();
            driver.FindElement(By.Id("inputPassword3")).Click();
            driver.FindElement(By.Id("inputPassword3")).Clear();
            driver.FindElement(By.Id("inputPassword3")).SendKeys("nazwisko");
            driver.FindElement(By.Id("dataU")).Click();
            driver.FindElement(By.Id("dataU")).Clear();
            driver.FindElement(By.Id("dataU")).SendKeys("23-01-1920");
            driver.FindElement(By.XPath("//form[@id='formma']/div[5]/div/div/label")).Click();
            driver.FindElement(By.Id("lekarz")).Click();
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
            Assert.AreEqual("Roznica: 3180114818136 data 315569260000lata 100.77390992189797", CloseAlertAndGetItsText());
            Assert.AreEqual("Senior", CloseAlertAndGetItsText());
            driver.FindElement(By.XPath("//html")).Click();
            driver.FindElement(By.Id("inputEmail3")).Clear();
            driver.FindElement(By.Id("inputEmail3")).SendKeys("imies");
            driver.FindElement(By.Id("inputPassword3")).Click();
            driver.FindElement(By.Id("inputPassword3")).Clear();
            driver.FindElement(By.Id("inputPassword3")).SendKeys("safdgsasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss");
            driver.FindElement(By.Id("dataU")).Click();
            driver.FindElement(By.XPath("//form[@id='formma']/div[5]/div/div/label")).Click();
            driver.FindElement(By.XPath("//form[@id='formma']/div[5]/div/div/label")).Click();
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
            Assert.AreEqual("Roznica: 3180114841408 data 315569260000lata 100.7739106593589", CloseAlertAndGetItsText());
            Assert.AreEqual("Senior", CloseAlertAndGetItsText());
            driver.FindElement(By.Id("inputPassword3")).Click();
            driver.FindElement(By.Id("inputPassword3")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | id=inputPassword3 | ]]
            driver.FindElement(By.Id("inputPassword3")).Click();
            driver.FindElement(By.Id("inputPassword3")).Clear();
            driver.FindElement(By.Id("inputPassword3")).SendKeys("nazwisko");
            driver.FindElement(By.Id("dataU")).Click();
            driver.FindElement(By.Id("dataU")).Clear();
            driver.FindElement(By.Id("dataU")).SendKeys("12322222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222");
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
            Assert.AreEqual("Roznica: 3180114851894 data 315569260000lata 100.77391099164728", CloseAlertAndGetItsText());
            Assert.AreEqual("Senior", CloseAlertAndGetItsText());
        }
        [Test]
        public void TheTimePassTest()
        {
            driver.Navigate().GoToUrl("https://lamp.ii.us.edu.pl/~mtdyd/zawody/");
            driver.FindElement(By.Id("inputEmail3")).Click();
            driver.FindElement(By.Id("inputEmail3")).Clear();
            driver.FindElement(By.Id("inputEmail3")).SendKeys("imie");
            driver.FindElement(By.Id("inputPassword3")).Click();
            driver.FindElement(By.Id("inputPassword3")).Clear();
            driver.FindElement(By.Id("inputPassword3")).SendKeys("nazwisko");
            driver.FindElement(By.Id("dataU")).Click();
            driver.FindElement(By.Id("dataU")).Clear();
            driver.FindElement(By.Id("dataU")).SendKeys("12-12-1200");
            driver.FindElement(By.Id("lekarz")).Click();
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
            Assert.AreEqual("Roznica: 6966679370208 data 315569260000lata 220.76546271357356", CloseAlertAndGetItsText());
            Assert.AreEqual("Senior", CloseAlertAndGetItsText());
        }
        [Test]
        public void TheOtherDateFormatTest()
        {
            driver.Navigate().GoToUrl("https://lamp.ii.us.edu.pl/~mtdyd/zawody/");
            driver.FindElement(By.Id("inputEmail3")).Click();
            driver.FindElement(By.Id("inputPassword3")).Click();
            driver.FindElement(By.Id("dataU")).Click();
            driver.FindElement(By.Id("dataU")).Clear();
            driver.FindElement(By.Id("dataU")).SendKeys("12.1.2001");
            driver.FindElement(By.Id("rodzice")).Click();
            driver.FindElement(By.Id("lekarz")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | id=lekarz | ]]
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
            Assert.AreEqual("Roznica: 3810487466378 data 315569260000lata 120.74964039203311", CloseAlertAndGetItsText());
            Assert.AreEqual("Senior", CloseAlertAndGetItsText());
            driver.FindElement(By.Id("dataU")).Click();
            driver.FindElement(By.Id("dataU")).Clear();
            driver.FindElement(By.Id("dataU")).SendKeys("12.02.2000");
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
            Assert.AreEqual("Roznica: 654726037801 data 315569260000lata 20.74745929945775", CloseAlertAndGetItsText());
            Assert.AreEqual("Dorosly", CloseAlertAndGetItsText());
            driver.FindElement(By.Id("dataU")).Click();
            driver.FindElement(By.Id("dataU")).Clear();
            driver.FindElement(By.Id("dataU")).SendKeys("12.12.2000");
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
            Assert.AreEqual("Roznica: 3810487497371 data 315569260000lata 120.74964137416299", CloseAlertAndGetItsText());
            Assert.AreEqual("Senior", CloseAlertAndGetItsText());
        }
        [Test]
        public void TheLettersInDateTest()
        {
            driver.Navigate().GoToUrl("https://lamp.ii.us.edu.pl/~mtdyd/zawody/");
            driver.FindElement(By.Id("inputEmail3")).Click();
            driver.FindElement(By.Id("inputEmail3")).Clear();
            driver.FindElement(By.Id("inputEmail3")).SendKeys("imie");
            driver.FindElement(By.Id("inputPassword3")).Click();
            driver.FindElement(By.Id("inputPassword3")).Clear();
            driver.FindElement(By.Id("inputPassword3")).SendKeys("nazwisko");
            driver.FindElement(By.Id("dataU")).Click();
            driver.FindElement(By.Id("dataU")).Clear();
            driver.FindElement(By.Id("dataU")).SendKeys("dwajedentrzyuee");
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
            Assert.AreEqual("Roznica: NaN data 315569260000lata NaN", CloseAlertAndGetItsText());
            Assert.AreEqual("Blad danych", CloseAlertAndGetItsText());
        }
        [Test]
        public void TheAddUnableTest()
        {
            driver.Navigate().GoToUrl("https://lamp.ii.us.edu.pl/~mtdyd/zawody/");
            driver.FindElement(By.Id("inputEmail3")).Click();
            driver.FindElement(By.Id("inputPassword3")).Click();
            driver.FindElement(By.Id("dataU")).Click();
            driver.FindElement(By.Id("dataU")).Click();
            driver.FindElement(By.Id("dataU")).Clear();
            driver.FindElement(By.Id("dataU")).SendKeys("12-02-2011");
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
            Assert.AreEqual("Roznica: 307829496080 data 315569260000lata 9.754736442960255", CloseAlertAndGetItsText());
            Assert.AreEqual("Brak kwalifikacji", CloseAlertAndGetItsText());
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
