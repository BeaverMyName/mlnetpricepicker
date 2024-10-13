using System.Text;
using MLAPP.DTOs.Requests;
using MLAPP.Services.Interfaces;
using MLAPP.Utils.Consts;
using MLAPP.Utils.Extensions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using PuppeteerSharp;

namespace MLAPP.Services
{
    public class BrowserService : IBrowserService
    {
        public IEnumerable<string> SearchRequestAndGetUrlList(FormRequestRequestDto dto)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
            var button =
                driver.FindElement(By.XPath(BrowserConsts.AcceptCookiesButtonXPath));
            button.Click();
            var input = driver.FindElement(By.XPath(BrowserConsts.ChromeSearchInputXPath));
            input.SendKeys(FormChromeRequest(dto));
            input.SendKeys(Keys.Enter);
            var linkElements = driver.FindElements(By.XPath(BrowserConsts.ChromeTopLinksXPath)).ToList();
            linkElements.AddRange(driver.FindElements(By.XPath(BrowserConsts.ChromeBottomLinksXPath)));
            var urls = linkElements.Select(l => l.GetAttribute("href"));

            return urls;
        }

        public async Task MadeAndSaveScreenshotAsync(string url, string path, IPage page)
        {
            // await new BrowserFetcher().DownloadAsync();
            try
            {
                await page.GoToAsync(url);
                await page.SetViewportAsync(new ViewPortOptions
                {
                    Width = 1920,
                    Height = 1080
                });

                await page.ScreenshotAsync(path);

                Console.WriteLine("Screenshot saved!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private string FormChromeRequest(FormRequestRequestDto dto)
        {
            var request = new StringBuilder($"allintext:{dto.ProductName}")
                .ValidateAndAppendRequest(dto.Size)
                .ValidateAndAppendRequest(dto.Currency)
                .ValidateAndAppendRequest($"site:{dto.Site}");

            return request.ToString();
        }
    }
}
