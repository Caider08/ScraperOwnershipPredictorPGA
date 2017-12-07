using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScraperOwnershipPredictorPGA
{
    public partial class Form1 : Form
    {
        string Test = "";
        string Table = "";
        List<string> Rows = new List<string>();
        List<string> Names = new List<string>();

        PredictionContext _context;

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _context = new PredictionContext();

        }

        private void FanShareScrape_Click(object sender, EventArgs e)
        {
           

            using (var driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://www.fansharesports.com/shared/signIn?redirectUrl=%2Fgolf%2Ftrends");

                var userName = driver.FindElementById("email");
                var passWord = driver.FindElementById("password");
                var logIn = driver.FindElementById("submit");

                userName.SendKeys("caiderwaider@hotmail.com");
                passWord.SendKeys("DKscrape");
                logIn.Click();

                System.Threading.Thread.Sleep(25);

                //var contentWrap = driver.FindElementById("content-wrap");

                driver.Navigate().GoToUrl("https://www.fansharesports.com/golf/analytics/tags");

                //var main = driver.FindElementById("main");
                // Test = main.Text;

                var select100 = driver.FindElementByXPath("//*[@id='DataTables_Table_0_length']/label/select/option[4]");
                //*[@id="DataTables_Table_0_next"]
                select100.Click();

                System.Threading.Thread.Sleep(50);

                var tableGrab = driver.FindElementByXPath("//*[@id='DataTables_Table_0']/tbody");

                Table = tableGrab.TagName;

                System.Threading.Thread.Sleep(15);



                var tableRows = tableGrab.FindElements(By.TagName("tr"));

                foreach (IWebElement row in tableRows)
                {
                    //List<string> names = new List<string>();
                    List<IWebElement> tds = new List<IWebElement>();
                    tds = row.FindElements(By.TagName("td")).ToList();
                    Names.Add(tds[1].Text);

                }
                //*[@id="DataTables_Table_0_length"]/label/select/option[4]

                //*[@id="DataTables_Table_0"]/tbody/tr[1]
                //*[@id="DataTables_Table_0"]/tbody/tr[1]
                //*[@id="DataTables_Table_0"]/tbody/tr[2]

                //*[@id="DataTables_Table_0"]/tbody/tr[1]/td[2]





                System.Threading.Thread.Sleep(15);

            }

            MessageBox.Show("We Grabbed the " + $"{Table}");
            foreach (string name in Names)
            {
                MessageBox.Show(name);
            }

            

        }
    }
}
